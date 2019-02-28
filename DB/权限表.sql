if exists (select * from sysobjects where name = 'SysUser')
drop table SysUser
go
--1�����û���
create table SysUser
(
   Id int identity(1,1) primary key,
   UserName nvarchar(200) not null,
   [Password]  nvarchar(50) not null,
   TrueName nvarchar(200) null,
   Sex varchar(10) null,  
   Phone varchar(50) null,
   Telephone varchar(50) null,
   EmailAddress varchar(200) null,   
   QQ varchar(50) null,
   OtherContact varchar(200) null,--������ϵ��ʽ
   Province varchar(200) null,--����ʡ��
   City varchar(200) null,--���ڳ���
   Street varchar(200) null,--���ڽֵ�
   [Address] varchar(200) null,
   [State] bit null,
   Birthday datetime null,
   Marital varchar(10) null,--����״��
   Political varchar(50) null,--������ò
   Nationality varchar(20) null,--����
   School varchar(50) null,--��ҵѧУ
   Professional varchar(100) null,--רҵ
   Degree varchar(20) null,--�����ȼ�
   DepartmentId int not null,
   PostId int not null,--��λ(ְλ)���
   JobState varchar(20) null,--��ְ״̬
   Photo varchar(200) null,--��Ƭ
   [Attach] varchar(200) null,--����
   [Description] nvarchar(4000),
   IsDelete bit null,
   Created datetime default(getdate()),
   Creator int null
)
if exists (select * from sysobjects where name = 'SysRole')
drop table SysRole
go
--2������ɫ��
create table SysRole
(
   Id int identity(1,1) primary key,
   RoleName nvarchar(50) not null,
   [Description] nvarchar(4000),
   IsDelete bit null,
   Created datetime default(getdate()),
   Creator int null
)

if exists (select * from sysobjects where name = 'SysUserRole')
drop table SysUserRole
go
--3�����û���ɫ��
create table SysUserRole
(
   Id int identity(1,1) primary key,
   UserId int not null foreign key references [SysUser]([Id]),
   RoleId int not null foreign key references [SysRole]([Id])
)

if exists (select * from sysobjects where name = 'SysModule')
drop table SysModule
go
--4����ģ���
create table SysModule
(
   Id int identity(1,1) primary key,
   ModuleName nvarchar(50) not null,
   ParentId int not null,
   Code  varchar(50) null,
   Url varchar(100) null,
   Icon varchar(50) null,
   Sort int null,
   [Enable]  bit not null,--�Ƿ�����
   [Description] nvarchar(4000),
   IsDelete bit null,
   Created datetime default(getdate()),
   Creator int null
)

if exists (select * from sysobjects where name = 'SysOperations')
drop table SysOperations
go
--5��������(��ť)��
create table SysOperations
(
   Id int identity(1,1) primary key,
   OperationName nvarchar(50) not null,
   Code  varchar(50),
   Icon  varchar(50),
   Sort int null,
   [Description] varchar(3000),
   IsDelete bit null,
   Created datetime default(getdate()),
   Creator int null
)
if exists (select * from sysobjects where name = 'SysModuleOperations')
drop table SysModuleOperations
go
--6����ģ�����ť��
create table SysModuleOperations
(
   Id int identity(1,1) primary key,
   ModuleId int not null foreign key references SysModule(Id),
   OperationId int not null foreign key references SysOperations(Id)
)
if exists (select * from sysobjects where name = 'SysRoleModuleOperations')
drop table SysRoleModuleOperations
go
--7������ɫģ�������
create table SysRoleModuleOperations
(
   Id int identity(1,1) primary key,
   RoleId int not null foreign key references SysRole(Id),
   ModuleId int not null foreign key references SysModule(Id),
   OperationId int not null foreign key references SysOperations(Id),
)

--8�������ű�
if exists (select * from sysobjects where name = 'Department')
drop table Department
go
create table Department
(
   Id int identity(1,1) primary key,
   ParentId int not null,
   DepartmentName nvarchar(50) not null,
   Principal int,--���Ÿ�����
   Sort int not null,
   IsDelete bit null,
   Created datetime default(getdate()),
   Creator int null
)


--9�����û���¼��־��
if exists (select * from sysobjects where name = 'SysLoginLog')
drop table SysLoginLog
go
create table SysLoginLog
(
   Id int identity(1,1) primary key,
   UserId int foreign key references [SysUser](Id),--���(�û���)
   UserIp  varchar(50),
   City varchar(50),
   IfSuccess bit not null,
   LoginDate datetime default(getdate())
)

--10�����û�������־��
if exists (select * from sysobjects where name = 'SysUserOperateLog')
drop table SysUserOperateLog
go
create table SysUserOperateLog
(
   Id int identity(1,1) primary key,
   UserId int foreign key references [SysUser](Id),--���(�û���)
   UserIp  varchar(50),
   OperateInfo  varchar(100),
   [Description] varchar(max),
   IfSuccess bit not null,
   OperateDate datetime default(getdate())
)


--11�����û������쳣��
if exists (select * from sysobjects where name = 'SysException')
drop table SysException
go
create table SysException
(
   Id int identity(1,1) primary key,
   UserId int foreign key references [SysUser](Id),--���(�û���)
   HelpLink varchar(500) null,
   [Message] varchar(500) null,
   [Source] varchar(500) null,
   StackTrace text null,
   TargetSite varchar(500) null,
   Data varchar(500) null,
   OperateTime datetime default(getdate())
)
select * from SysModule

INSERT INTO [SysModule]([ModuleName],[ParentId],[Code],[Url],[Icon],[Sort],[Enable],[Description],[IsDelete],[Created],[Creator])
VALUES('����ָ������',0,'SampleFile','','',1,1,'',0,GETDATE(),0);
INSERT INTO [SysModule]([ModuleName],[ParentId],[Code],[Url],[Icon],[Sort],[Enable],[Description],[IsDelete],[Created],[Creator])
VALUES('ģ������',1,'BaseSample','BaseSample','',1,1,'',0,GETDATE(),0);

INSERT INTO [SysModule]([ModuleName],[ParentId],[Code],[Url],[Icon],[Sort],[Enable],[Description],[IsDelete],[Created],[Creator])
VALUES('��������',0,'PersonDocument','','',1,1,'',0,GETDATE(),0);

INSERT INTO [SysModule]([ModuleName],[ParentId],[Code],[Url],[Icon],[Sort],[Enable],[Description],[IsDelete],[Created],[Creator])
VALUES('ϵͳ����',0,'SystemManage','','',1,1,'',0,GETDATE(),0);
INSERT INTO [SysModule]([ModuleName],[ParentId],[Code],[Url],[Icon],[Sort],[Enable],[Description],[IsDelete],[Created],[Creator])
VALUES('ϵͳ����',4,'SystemConfig','SystemConfig','',1,1,'',0,GETDATE(),0);
INSERT INTO [SysModule]([ModuleName],[ParentId],[Code],[Url],[Icon],[Sort],[Enable],[Description],[IsDelete],[Created],[Creator])
VALUES('ϵͳ��־',4,'SystemLog','SystemLog','',2,1,'',0,GETDATE(),0);
INSERT INTO [SysModule]([ModuleName],[ParentId],[Code],[Url],[Icon],[Sort],[Enable],[Description],[IsDelete],[Created],[Creator])
VALUES('ϵͳ�쳣',4,'SystemExcepiton','SystemExcepiton','',3,1,'',0,GETDATE(),0);

INSERT INTO [SysModule]([ModuleName],[ParentId],[Code],[Url],[Icon],[Sort],[Enable],[Description],[IsDelete],[Created],[Creator])
VALUES('Ȩ�޹���',0,'PerManage','','',4,1,'',0,GETDATE(),0);
INSERT INTO [SysModule]([ModuleName],[ParentId],[Code],[Url],[Icon],[Sort],[Enable],[Description],[IsDelete],[Created],[Creator])
VALUES('�û�����',8,'UserManage','UserManage','',1,1,'',0,GETDATE(),0);
INSERT INTO [SysModule]([ModuleName],[ParentId],[Code],[Url],[Icon],[Sort],[Enable],[Description],[IsDelete],[Created],[Creator])
VALUES('��ɫ����',8,'RoleManage','RoleManage','',2,1,'',0,GETDATE(),0);
INSERT INTO [SysModule]([ModuleName],[ParentId],[Code],[Url],[Icon],[Sort],[Enable],[Description],[IsDelete],[Created],[Creator])
VALUES('��ɫȨ������',8,'RolePerSetting','RolePerSetting','',3,1,'',0,GETDATE(),0);
INSERT INTO [SysModule]([ModuleName],[ParentId],[Code],[Url],[Icon],[Sort],[Enable],[Description],[IsDelete],[Created],[Creator])
VALUES('ģ��ά��',8,'ModuleSetting','ModuleSetting','',4,1,'',0,GETDATE(),0);




