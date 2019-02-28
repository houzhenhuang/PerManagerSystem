CREATE procedure [dbo].[P_Sys_GetRoleListByUserId]
@userId int
as
begin
	select r.*,ISNULL(ur.UserId,0) as Flag from SysRole r left join
    SysUserRole ur 
    on r.Id = ur.RoleId
    and ur.UserId = @userId
    order by r.Id desc
end

exec [P_Sys_GetRoleListByUserId] 1