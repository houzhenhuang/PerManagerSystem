using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PerManagerSystem.IBLL;
using PerManagerSystem.Models;
using PerManagerSystem.IDAL;
using Unity.Attributes;
using PerManagerSystem.Common;

namespace PerManagerSystem.BLL
{
    public class SysPermissionBLL : ISysPermissionBLL, IDisposable
    {
        [Dependency]
        public ISysPermissionRepository permissionRepository { get; set; }

        /// <summary>
        /// 获取操作权限
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="controllerName">当前所在控制器</param>
        /// <returns></returns>
        public List<string> GetPermissionListByconn(int userId, string controllerName)
        {
            return permissionRepository.GetPermissionListByconn(userId,controllerName);
        }


        public void Dispose()
        {
            
        }
    }
}
