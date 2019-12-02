USE `dektos`;
DROP procedure IF EXISTS `GetLiveReport`;

DELIMITER $$
USE `dektos`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetLiveReport`( _siteId long, _configid long ,
_paramid long ,
_Fromdate Datetime,
_Todate DateTime,
_time int,
_isExport bit,
_Limit int,
_offset int )
BEGIN
Declare paramname varchar(100)  default '' ;
if(_paramid > 0)
then
set paramname=(select distinct param_name from dl_param where param_id=_paramid);
else
set paramname='';
End IF;


SET @sql = NULL;
SELECT
  GROUP_CONCAT(DISTINCT
    CONCAT(
      'MAX(IF(r.param_name = ''',
      dt,
      ''', ROUND(r.param_value,2), null)) AS `',
      dt,'`'
    )
  ) INTO @sql
from
(
    select distinct (COALESCE(d.param_name,'')) as dt
  from dl_data_live d
 join dl_confg c on c.confg_id = d.confg_id

  where (c.site_id = _siteId or c.site_id= 0) and  (d.confg_id = _configid or  _configid=0)
 and (d.param_name=paramname or _paramid=0)
  order by d.creat_ts desc
) r;
if @sql is null or @sql =''
then
select 'No Records Found' as Message;
else

SET @row_number = 0;

SET @sql =    CONCAT('select * from ( SELECT  DATE_FORMAT(r.creat_ts, ''%Y-%m-%d %h:%m:%s'') as `CreatedDate`, ', @sql, '
            from
            (select data_id,d.confg_id,param_name,param_value,d.creat_ts  from `dl_data` d
            join dl_confg c on c.confg_id = d.confg_id  and c.site_id = _siteId or c.site_id= 0
where  (d.confg_id = _configid or  _configid=0)
 and (d.param_name=''paramname''  or _paramid=0) and  cast(d.creat_ts as Date) between cast(''_Fromdate'' as date) and cast(''_Todate'' as date)
 union all
 select data_id,d.confg_id,param_name,param_value,d.creat_ts  from `dl_data_historicaldata` d
 join dl_confg c on c.confg_id = d.confg_id  and c.site_id = _siteId or c.site_id= 0
where  (d.confg_id = _configid or  _configid=0)
 and (d.param_name=''paramname'' or _paramid=0) and  cast(d.creat_ts as Date) between cast(''_Fromdate'' as date) and cast(''_Todate'' as date))r
            group by DATE_FORMAT(r.creat_ts, ''%Y-%m-%d %h:%m:%s''))A
            order by `CreatedDate` asc;');

set @sql =replace(@sql,'paramname',(paramname));
set @sql =replace(@sql,'_paramid',_paramid);
set @sql =replace(@sql,'_configid',_configid);
set @sql =replace(@sql,'_Fromdate',_Fromdate);
set @sql =replace(@sql,'_Todate',_Todate);
set @sql =replace(@sql,'_siteId',_siteId);

PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;
end if;

 END$$

DELIMITER ;

