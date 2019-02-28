using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerManagerSystem.IDAL
{
    public interface ISysPermissionRepository
    {
        /// <summary>
        /// 获取操作权限
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="controllerName">当前所在控制器</param>
        /// <returns></returns>
        List<string> GetPermissionListByconn(int userId,string controllerName);
    }
}
