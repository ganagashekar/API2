USE `dektos`;
DROP procedure IF EXISTS `GetAverageTimeReport`;

DELIMITER $$
USE `dektos`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAverageTimeReport`(_siteId long, _configid long ,_paramid long ,_Fromdate Datetime,
_Todate DateTime,
_time int,
_isExport bit,
_Limit int,
_offset int
 )
BEGIN
Declare paramname varchar(100)  default '' ;
 set @timerange= (select cast(r.value as UNSIGNED) from referencerecords r where r.ReferenceRecordTyepId=17 and ( r.id=_time or _time = 0 ) limit 1);
if(_paramid > 0)
then
set paramname=(select distinct param_name from dl_param where param_id=_paramid);
End IF;
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
    select (COALESCE(d.param_name,'')) as dt
  from dl_data_live d
   join dl_confg c on c.confg_id = d.confg_id
  where c.site_id = _siteId or c.site_id= 0
  order by d.creat_ts desc
) r;
if @sql is null or @sql =''
then
select 'No Records Found' as Message;
else
SET @row_number = 0;


 SET @row_number = 0;
SET @sql =    CONCAT('select * from ( SELECT  DATE_FORMAT(r.ts, ''%Y-%m-%d %T'') as `CreatedDate`, ', @sql, '
            from  (
        select  d.data_id,
   d.confg_id,
   d.param_name,
    from_unixtime(unix_timestamp(d.creat_ts) - unix_timestamp(d.creat_ts) mod _avgtime) as ts,

    Round(avg(d.param_value),2) as param_value

      from   (select data_id,d.confg_id,param_name,param_value,d.creat_ts  from `dl_data` d
       join dl_confg c on c.confg_id = d.confg_id


where (c.site_id = _siteId or c.site_id= 0 ) and  (d.confg_id = _configid or  _configid=0)
 and (d.param_name=''paramname''  or _paramid=0) and  cast(d.creat_ts as Date) between cast(''_Fromdate'' as date) and cast(''_Todate'' as date)
 union all
 select data_id,d.confg_id,param_name,param_value,d.creat_ts  from `dl_data_historicaldata` d
   join dl_confg c on c.confg_id = d.confg_id
where (c.site_id = _siteId or c.site_id= 0 )  and  (d.confg_id = _configid or  _configid=0)
 and (d.param_name=''paramname'' or _paramid=0) and  cast(d.creat_ts as Date) between cast(''_Fromdate'' as date) and cast(''_Todate'' as date))d
 group by  ts ,d.param_name,d.confg_id
 )r
            group by DATE_FORMAT(r.ts, ''%Y-%m-%d %T''))A
            order by `CreatedDate` asc;');


set @sql =replace(@sql,'paramname',(paramname));
set @sql =replace(@sql,'_paramid',_paramid);
set @sql =replace(@sql,'_configid',_configid);
set @sql =replace(@sql,'_Fromdate',_Fromdate);
set @sql =replace(@sql,'_Todate',_Todate);
set @sql =replace(@sql,'_avgtime',@timerange);
set @sql =replace(@sql,'_siteId',_siteId);

PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;
End IF;
 END$$

DELIMITER ;

