Create Procedure P_Sys_DeleteUserRole
@userId int
as
--�����ɫǰɾ��֮�����ϵ
begin
	delete from SysUserRole where UserId=@userId
end

go

Create Procedure P_Sys_UserAllotRole
@userId int,@roleId int
as
--�û������ɫ
begin
 insert into SysUserRole(UserId,RoleId)
 values(@userId,@roleId)
end