using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using PerManagerSystem.IDAL;
using PerManagerSystem.Models;
using System.Data.Entity;

namespace PerManagerSystem.DAL
{
    public class SysRoleModuleOperationsRepository:ISysRoleModuleOperationsRepository
    {
        /// <summary>
        /// 根据角色和模块获取操作码
        /// </summary>
        /// <param name="pager"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<P_Sys_GetPermByRoleAndModule_Result> GetOperaByRoleAndModule(int roleId, int moduleId)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.P_Sys_GetPermByRoleAndModule(roleId, moduleId).ToList();
            }
        }
        /// <summary>
        /// 角色授权
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="moduleId"></param>
        /// <param name="operaIds"></param>
        public void RolePermission(int roleId, int moduleId, string[] operaIds) 
        {
            using (DBContainer db=new DBContainer ())
            {
                db.P_Sys_DeleteRoleModuleOpera(roleId,moduleId);
                foreach (var operaId in operaIds)
                {
                    if (!String.IsNullOrWhiteSpace(operaId))
                    {
                        //int operationId=Convert.ToInt32(operaId);
                        //SysOperations operaModel = db.SysOperations.SingleOrDefault(model => model.Id == operationId);
                        //if (operaModel.Code == "Browser")
                        //{
                        //    AddRoleModuleOpera(roleId, moduleId, Convert.ToInt32(operaId), db);
                        //}
                        //else
                        //{
                            db.P_Sys_RolePermSet(roleId, moduleId, Convert.ToInt32(operaId));  
                        //}
                       
                    }
                }
                db.SaveChanges();
            }
        }
        public void AddRoleModuleOpera(int roleId, int moduleId, int operaId, DBContainer db) 
        {
            SysModule moduleModel = db.SysModule.SingleOrDefault(x => x.Id == moduleId);
            db.P_Sys_RolePermSet(roleId, moduleId, operaId);
            if (moduleModel.ParentId != 0)
            {
                AddRoleModuleOpera(roleId, moduleModel.ParentId, operaId, db);
            }
        }
    }
}
