using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PerManagerSystem.Models;
using PerManagerSystem.IBLL;
using PerManagerSystem.IDAL;
using Unity.Attributes;
using PerManagerSystem.Models.Sys;
using PerManagerSystem.Common;

namespace PerManagerSystem.BLL
{
    public class SysRoleModuleOperationsBLL:ISysRoleModuleOperationsBLL
    {
        [Dependency]
        public ISysRoleModuleOperationsRepository roleModuleOperationsRepository { get; set; }
        /// <summary>
        /// 根据角色和模块获取操作码
        /// </summary>
        /// <param name="pager"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<P_Sys_GetPermByRoleAndModule_Result> GetOperaByRoleAndModule(int roleId, int moduleId)
        {
            return roleModuleOperationsRepository.GetOperaByRoleAndModule(roleId, moduleId);
        }
        /// <summary>
        /// 角色授权
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="moduleId"></param>
        /// <param name="operaIds"></param>
        public bool RolePermission(int roleId, int moduleId, string[] operaIds)
        {
            try
            {
                roleModuleOperationsRepository.RolePermission(roleId,moduleId,operaIds);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
