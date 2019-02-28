using PerManagerSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerManagerSystem.IBLL
{
    public interface ISysRoleModuleOperationsBLL
    {
        /// <summary>
        /// 根据角色和模块获取操作码
        /// </summary>
        /// <param name="pager"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        List<P_Sys_GetPermByRoleAndModule_Result> GetOperaByRoleAndModule(int roleId, int moduleId);

        /// <summary>
        /// 角色授权
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="moduleId"></param>
        /// <param name="operaIds"></param>
        bool RolePermission(int roleId, int moduleId, string[] operaIds);
    }
}
