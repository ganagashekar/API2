USE `dektos`;
DROP procedure IF EXISTS `GetExcedenceReport`;

DELIMITER $$
USE `dektos`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetExcedenceReport`( _siteId long,_configid long ,
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
End IF;

select A.stack_name as `StackName` ,
A.param_id as param_id,
A.confg_id as confg_id,
A.param_name as `ParamName`,
A.param_unit as `ParamUnits`,
A.param_value as `ParamValue`,
'Exceeded Threshold Value' as `Description`,
A.creat_ts as `RecordedDate` from

(select  p.param_id,a.confg_id,a.param_name,a.param_value,a.creat_ts,p.param_unit,c.stack_name  from dl_data  a
inner join dl_param p on   a.param_value> p.threshhold_val and  p.param_name =a.param_name and a.confg_id =p.confg_id

 join dl_confg c on c.confg_id = a.confg_id  and c.site_id = _siteId or c.site_id= 0
where cast(a.creat_ts  as Date) BETWEEN cast(_Fromdate as Date) AND cast(_Todate as Date)
and (a.confg_id = _configid or  _configid=0)
 and (a.param_name=paramname or _paramid=0)
 union all
select  p.param_id,a.confg_id,a.param_name,a.param_value,a.creat_ts,p.param_unit,c.stack_name  from dl_data_historicaldata  a
inner join dl_param p on   a.param_value> p.threshhold_val and  p.param_name =a.param_name and a.confg_id =p.confg_id
join dl_confg c on c.confg_id = a.confg_id  and c.site_id = _siteId or c.site_id= 0
where cast(a.creat_ts  as Date) BETWEEN cast(_Fromdate as Date) AND cast(_Todate as Date)
and (a.confg_id = _configid or  _configid=0)
 and (a.param_name=paramname or _paramid=0))A




 END$$

DELIMITER ;

