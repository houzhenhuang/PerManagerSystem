Create Procedure P_Sys_DeleteUserRole
@userId int
as
--分配角色前删除之间的联系
begin
	delete from SysUserRole where UserId=@userId
end

go

Create Procedure P_Sys_UserAllotRole
@userId int,@roleId int
as
--用户分配角色
begin
 insert into SysUserRole(UserId,RoleId)
 values(@userId,@roleId)
end