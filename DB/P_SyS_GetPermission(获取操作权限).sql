Create PROCEDURE P_SyS_GetPermission
@userId int,@controller varchar(200)
as
begin
	select distinct(o.Code) from SysOperations o inner join SysRoleModuleOperations rmo on o.Id=rmo.OperationId
	inner join SysModule m on m.Id=rmo.ModuleId
	inner join SysRole r on r.Id=rmo.RoleId
	inner join SysUserRole ur on ur.RoleId=r.Id
	inner join SysUser u on u.Id=ur.UserId
	where u.Id=@userId and m.Code=@controller
end

exec P_SyS_GetPermission 1,'syssample'