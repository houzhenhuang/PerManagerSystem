use PerManagerSystemDB
go
Create PROCEDURE P_Sys_DeleteModuleOperation
@moduleId int
AS
--��ģ����������ǰ��ɾ������֮ǰ�Ĺ�ϵ
BEGIN
	delete from SysModuleOperations where ModuleId=@moduleId;
END

