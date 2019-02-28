using PerManagerSystem.BLL;
using PerManagerSystem.DAL;
using PerManagerSystem.IBLL;
using PerManagerSystem.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace PerManagerSystem.Core
{
    public class DependencyRegisterType
    {
        //系统注入
        public static void Container_Sys(ref UnityContainer container)
        {
            container.RegisterType<ISysSampleBLL, SysSampleBLL>();//样例
            container.RegisterType<ISysSampleRepository, SysSampleRepository>();

            container.RegisterType<ISysModuleBLL, SysModuleBLL>();//模块（菜单）
            container.RegisterType<ISysModuleRepository, SysModuleRepository>();

            container.RegisterType<ISysPermissionBLL, SysPermissionBLL>();//权限
            container.RegisterType<ISysPermissionRepository, SysPermissionRepository>();

            container.RegisterType<ISysUserBLL, SysUserBLL>();//用户
            container.RegisterType<ISysUserRepository, SysUserRepository>();

            container.RegisterType<ISysOperationsBLL, SysOperationsBLL>();//操作管理
            container.RegisterType<ISysOperationsRepository, SysOperationsRepository>();

            container.RegisterType<ISysRoleBLL, SysRoleBLL>();//操作管理
            container.RegisterType<ISysRoleRepository, SysRoleRepository>();

            container.RegisterType<ISysRoleModuleOperationsBLL, SysRoleModuleOperationsBLL>();//角色授权管理
            container.RegisterType<ISysRoleModuleOperationsRepository, SysRoleModuleOperationsRepository>();

            container.RegisterType<IIconBLL, IconBLL>();//图标
            container.RegisterType<IIconRepository, IconRepository>();
        }
    }
}
