Create Procedure P_Sys_DeleteRoleModuleOpera
@roleId int,@moduleId int
as
--����ɫ��Ȩ֮ǰ��ɾ����ɫģ�����֮ǰ����ϵ
begin
	delete from SysRoleModuleOperations where RoleId=@roleId and ModuleId=@moduleId
end

go

Create Procedure P_Sys_RolePermSet
@roleId int,@moduleId int,@operatId int
as
--����ɫ��Ȩ
begin
	insert into SysRoleModuleOperations(RoleId,ModuleId,OperationId)
	values (@roleId,@moduleId,@operatId)
end