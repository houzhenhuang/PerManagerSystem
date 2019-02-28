Create PROCEDURE [dbo].[P_Sys_GetModuleByUserId]
@userId int
as
--根据用户ID获取菜单列表
begin
	select Distinct(m.ModuleName),m.Id as ModuleId,m.ParentId,m.Code,m.Url,m.Icon,m.Sort,m.Enable,m.Description,m.IsDelete,m.Created,m.Creator
	from SysModule m inner join SysRoleModuleOperations rmo on m.Id=rmo.ModuleId
	inner join SysRole role on role.Id=rmo.RoleId
	inner join SysUserRole ur on ur.RoleId=role.Id
	inner join SysUser u on u.Id=ur.UserId
	where u.Id=@userId
end

exec [P_Sys_GetModuleByUserId] 2