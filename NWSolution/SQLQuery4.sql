use NWSolution;
select *  from [dbo].[users];
select * from [dbo].[user_shortinfo]
select * from [dbo].[user_detailinfo];

select users.user_id,users.device_type, short.devicetype, 
detail.user_deviceversion, detail.user_deviceversion, 
detail.user_email, detail.user_email from [dbo].[users]
AS users inner join [dbo].[user_shortinfo] AS short  
on users.id = short.id inner join [dbo].[user_detailinfo] AS detail on 
users.id = detail.us_id;