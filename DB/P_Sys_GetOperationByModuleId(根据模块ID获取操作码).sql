Create procedure P_Sys_GetOperationByModuleId
@moduleId int
as
begin
	select o.*,ISNULL(mp.ModuleId,0) as Flag from SysOperations o left join
    SysModuleOperations mp 
    on o.Id = mp.OperationId
    and mp.ModuleId = @moduleId
    order by o.Id desc
end

exec P_Sys_GetOperationByModuleId 5