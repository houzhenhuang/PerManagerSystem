create PROCEDURE P_Sys_GetModuleByConn
@userId int,@moduleId int
as
begin
	select Distinct(m.ModuleName),m.Id as ModuleId,m.ParentId,m.Code,m.Url,m.Icon,m.Sort,m.Enable,m.Description,m.IsDelete,m.Created,m.Creator
	from SysModule m inner join SysRoleModuleOperations rmo on m.Id=rmo.ModuleId
	inner join SysRole role on role.Id=rmo.RoleId
	inner join SysUserRole ur on ur.RoleId=role.Id
	inner join SysUser u on u.Id=ur.UserId
	where m.ParentId=@moduleId and u.Id=@userId
end

exec  P_Sys_GetModuleByConn 1,8