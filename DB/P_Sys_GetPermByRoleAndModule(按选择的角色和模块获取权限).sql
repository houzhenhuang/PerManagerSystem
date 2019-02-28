Create procedure P_Sys_GetPermByRoleAndModule
@roleId int,@moduleId int
as
--按选择的角色及模块加载模块的权限项
begin
	select opera.*,ISNULL(per.OperationId,0) IsAuthor from 
	(select mo.ModuleId,mo.OperationId,m.ModuleName,op.OperationName,op.Code from SysModuleOperations mo
	inner join SysModule m on m.Id=mo.ModuleId
	inner join SysOperations op on op.Id=mo.OperationId
	where m.Id=@moduleId) opera left join 
	(select rmo.OperationId from SysRoleModuleOperations rmo
	inner join SysRole r on r.Id=rmo.RoleId
	inner join SysModule m on m.Id=rmo.ModuleId
	where rmo.ModuleId=@moduleId and rmo.RoleId=@roleId) per on per.OperationId=opera.OperationId
end

exec P_Sys_GetPermByRoleAndModule 2,12