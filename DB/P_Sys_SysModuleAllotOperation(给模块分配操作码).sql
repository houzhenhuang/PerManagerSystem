use PerManagerSystemDB
go
Create PROCEDURE P_Sys_SysModuleAllotOperation
@operationId int,@moduleId int
AS
--��ģ����������
BEGIN
	insert into SysModuleOperations(ModuleId,OperationId)
			values(@moduleId,@operationId)
END
