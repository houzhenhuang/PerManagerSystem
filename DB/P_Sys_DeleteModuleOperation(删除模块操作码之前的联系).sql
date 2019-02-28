use PerManagerSystemDB
go
Create PROCEDURE P_Sys_DeleteModuleOperation
@moduleId int
AS
--给模块分配操作码前，删除它们之前的关系
BEGIN
	delete from SysModuleOperations where ModuleId=@moduleId;
END

