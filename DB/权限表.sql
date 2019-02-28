if exists (select * from sysobjects where name = 'SysUser')
drop table SysUser
go
--1创建用户表
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
   OtherContact varchar(200) null,--其它联系方式
   Province varchar(200) null,--所在省份
   City varchar(200) null,--所在城市
   Street varchar(200) null,--所在街道
   [Address] varchar(200) null,
   [State] bit null,
   Birthday datetime null,
   Marital varchar(10) null,--婚姻状况
   Political varchar(50) null,--政治面貌
   Nationality varchar(20) null,--国籍
   School varchar(50) null,--毕业学校
   Professional varchar(100) null,--专业
   Degree varchar(20) null,--教育等级
   DepartmentId int not null,
   PostId int not null,--岗位(职位)编号
   JobState varchar(20) null,--在职状态
   Photo varchar(200) null,--照片
   [Attach] varchar(200) null,--附件
   [Description] nvarchar(4000),
   IsDelete bit null,
   Created datetime default(getdate()),
   Creator int null
)
if exists (select * from sysobjects where name = 'SysRole')
drop table SysRole
go
--2创建角色表
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
--3创建用户角色表
create table SysUserRole
(
   Id int identity(1,1) primary key,
   UserId int not null foreign key references [SysUser]([Id]),
   RoleId int not null foreign key references [SysRole]([Id])
)

if exists (select * from sysobjects where name = 'SysModule')
drop table SysModule
go
--4创建模块表
create table SysModule
(
   Id int identity(1,1) primary key,
   ModuleName nvarchar(50) not null,
   ParentId int not null,
   Code  varchar(50) null,
   Url varchar(100) null,
   Icon varchar(50) null,
   Sort int null,
   [Enable]  bit not null,--是否启用
   [Description] nvarchar(4000),
   IsDelete bit null,
   Created datetime default(getdate()),
   Creator int null
)

if exists (select * from sysobjects where name = 'SysOperations')
drop table SysOperations
go
--5创建操作(按钮)表
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
--6创建模块操作钮表
create table SysModuleOperations
(
   Id int identity(1,1) primary key,
   ModuleId int not null foreign key references SysModule(Id),
   OperationId int not null foreign key references SysOperations(Id)
)
if exists (select * from sysobjects where name = 'SysRoleModuleOperations')
drop table SysRoleModuleOperations
go
--7创建角色模块操作表
create table SysRoleModuleOperations
(
   Id int identity(1,1) primary key,
   RoleId int not null foreign key references SysRole(Id),
   ModuleId int not null foreign key references SysModule(Id),
   OperationId int not null foreign key references SysOperations(Id),
)

--8创建部门表
if exists (select * from sysobjects where name = 'Department')
drop table Department
go
create table Department
(
   Id int identity(1,1) primary key,
   ParentId int not null,
   DepartmentName nvarchar(50) not null,
   Principal int,--部门负责人
   Sort int not null,
   IsDelete bit null,
   Created datetime default(getdate()),
   Creator int null
)


--9创建用户登录日志表
if exists (select * from sysobjects where name = 'SysLoginLog')
drop table SysLoginLog
go
create table SysLoginLog
(
   Id int identity(1,1) primary key,
   UserId int foreign key references [SysUser](Id),--外键(用户表)
   UserIp  varchar(50),
   City varchar(50),
   IfSuccess bit not null,
   LoginDate datetime default(getdate())
)

--10创建用户操作日志表
if exists (select * from sysobjects where name = 'SysUserOperateLog')
drop table SysUserOperateLog
go
create table SysUserOperateLog
(
   Id int identity(1,1) primary key,
   UserId int foreign key references [SysUser](Id),--外键(用户表)
   UserIp  varchar(50),
   OperateInfo  varchar(100),
   [Description] varchar(max),
   IfSuccess bit not null,
   OperateDate datetime default(getdate())
)


--11创建用户操作异常表
if exists (select * from sysobjects where name = 'SysException')
drop table SysException
go
create table SysException
(
   Id int identity(1,1) primary key,
   UserId int foreign key references [SysUser](Id),--外键(用户表)
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
VALUES('开发指南样例',0,'SampleFile','','',1,1,'',0,GETDATE(),0);
INSERT INTO [SysModule]([ModuleName],[ParentId],[Code],[Url],[Icon],[Sort],[Enable],[Description],[IsDelete],[Created],[Creator])
VALUES('模板样例',1,'BaseSample','BaseSample','',1,1,'',0,GETDATE(),0);

INSERT INTO [SysModule]([ModuleName],[ParentId],[Code],[Url],[Icon],[Sort],[Enable],[Description],[IsDelete],[Created],[Creator])
VALUES('个人中心',0,'PersonDocument','','',1,1,'',0,GETDATE(),0);

INSERT INTO [SysModule]([ModuleName],[ParentId],[Code],[Url],[Icon],[Sort],[Enable],[Description],[IsDelete],[Created],[Creator])
VALUES('系统管理',0,'SystemManage','','',1,1,'',0,GETDATE(),0);
INSERT INTO [SysModule]([ModuleName],[ParentId],[Code],[Url],[Icon],[Sort],[Enable],[Description],[IsDelete],[Created],[Creator])
VALUES('系统配置',4,'SystemConfig','SystemConfig','',1,1,'',0,GETDATE(),0);
INSERT INTO [SysModule]([ModuleName],[ParentId],[Code],[Url],[Icon],[Sort],[Enable],[Description],[IsDelete],[Created],[Creator])
VALUES('系统日志',4,'SystemLog','SystemLog','',2,1,'',0,GETDATE(),0);
INSERT INTO [SysModule]([ModuleName],[ParentId],[Code],[Url],[Icon],[Sort],[Enable],[Description],[IsDelete],[Created],[Creator])
VALUES('系统异常',4,'SystemExcepiton','SystemExcepiton','',3,1,'',0,GETDATE(),0);

INSERT INTO [SysModule]([ModuleName],[ParentId],[Code],[Url],[Icon],[Sort],[Enable],[Description],[IsDelete],[Created],[Creator])
VALUES('权限管理',0,'PerManage','','',4,1,'',0,GETDATE(),0);
INSERT INTO [SysModule]([ModuleName],[ParentId],[Code],[Url],[Icon],[Sort],[Enable],[Description],[IsDelete],[Created],[Creator])
VALUES('用户管理',8,'UserManage','UserManage','',1,1,'',0,GETDATE(),0);
INSERT INTO [SysModule]([ModuleName],[ParentId],[Code],[Url],[Icon],[Sort],[Enable],[Description],[IsDelete],[Created],[Creator])
VALUES('角色管理',8,'RoleManage','RoleManage','',2,1,'',0,GETDATE(),0);
INSERT INTO [SysModule]([ModuleName],[ParentId],[Code],[Url],[Icon],[Sort],[Enable],[Description],[IsDelete],[Created],[Creator])
VALUES('角色权限设置',8,'RolePerSetting','RolePerSetting','',3,1,'',0,GETDATE(),0);
INSERT INTO [SysModule]([ModuleName],[ParentId],[Code],[Url],[Icon],[Sort],[Enable],[Description],[IsDelete],[Created],[Creator])
VALUES('模块维护',8,'ModuleSetting','ModuleSetting','',4,1,'',0,GETDATE(),0);




