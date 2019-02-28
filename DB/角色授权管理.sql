Create Procedure P_Sys_DeleteRoleModuleOpera
@roleId int,@moduleId int
as
--给角色授权之前，删除角色模块操作之前的联系
begin
	delete from SysRoleModuleOperations where RoleId=@roleId and ModuleId=@moduleId
end

go

Create Procedure P_Sys_RolePermSet
@roleId int,@moduleId int,@operatId int
as
--给角色授权
begin
	insert into SysRoleModuleOperations(RoleId,ModuleId,OperationId)
	values (@roleId,@moduleId,@operatId)
end