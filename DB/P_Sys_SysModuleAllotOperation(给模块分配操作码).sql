use PerManagerSystemDB
go
Create PROCEDURE P_Sys_SysModuleAllotOperation
@operationId int,@moduleId int
AS
--给模块分配操作码
BEGIN
	insert into SysModuleOperations(ModuleId,OperationId)
			values(@moduleId,@operationId)
END
