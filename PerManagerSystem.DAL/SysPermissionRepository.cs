using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PerManagerSystem.IDAL;
using PerManagerSystem.Models;

namespace PerManagerSystem.DAL
{
    public class SysPermissionRepository:ISysPermissionRepository
    {
        /// <summary>
        /// 获取操作权限
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="controllerName">当前所在控制器</param>
        /// <returns></returns>
        public List<string> GetPermissionListByconn(int userId, string controllerName)
        {
            using (DBContainer db=new DBContainer ())
            {
                List<string> codeList = (from c in db.P_SyS_GetPermission(userId, controllerName) select c).ToList();
                return codeList;
            }
          
        }
    }
}
