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
    public class SysModuleRepository:ISysModuleRepository
    {
        public IQueryable<SysModule> GetList(DBContainer db)
        {

            return db.SysModule.AsQueryable();
         
        }
        /// <summary>
        /// 根据条件获取菜单
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="moduleId">菜单ID</param>
        /// <returns></returns>
        public IList<SysModule> GetModuleListByConn(int userId, int moduleId)
        {
            using (DBContainer db=new DBContainer ())
            {
                List<SysModule> sysModuleList = (from m in db.P_Sys_GetModuleByConn(userId, moduleId)
                                                 select new SysModule
                                                 {
                                                     Id = m.ModuleId,
                                                     ModuleName = m.ModuleName,
                                                     ParentId = m.ParentId,
                                                     Code = m.Code,
                                                     Url = m.Url,
                                                     Icon = m.Icon,
                                                     Sort = m.Sort,
                                                     Enable = m.Enable,
                                                     Description = m.Description,
                                                     IsDelete = m.IsDelete,
                                                     Created = m.Created,
                                                     Creator = m.Creator
                                                 }).ToList();
                if (sysModuleList.Count == 0 && moduleId == 0)
                {
                    IList<SysModule> menus = GetModuleListByConn(userId);
                    foreach (var menu in menus)
                    {
                        GetParentModuleByModuleId(menu.Id,ref sysModuleList);
                    }
                }
                return sysModuleList.OrderBy(p=>p.Sort).ToList();
            }
        }
        /// <summary>
        /// 根据用户ID获取菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<SysModule> GetModuleListByConn(int userId) 
        {
            using (DBContainer db = new DBContainer())
            {
                List<SysModule> modelList = (from m in db.P_Sys_GetModuleByUserId(userId)
                                             select new SysModule
                                             {
                                                 Id = m.ModuleId,
                                                 ModuleName = m.ModuleName,
                                                 ParentId = m.ParentId,
                                                 Code = m.Code,
                                                 Url = m.Url,
                                                 Icon = m.Icon,
                                                 Sort = m.Sort,
                                                 Enable = m.Enable,
                                                 Description = m.Description,
                                                 IsDelete = m.IsDelete,
                                                 Created = m.Created,
                                                 Creator = m.Creator
                                             }).ToList();
                return modelList;
            }
        }
        /// <summary>
        /// 递归找到顶级菜单
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="list"></param>
        public void GetParentModuleByModuleId(int moduleId,ref List<SysModule> list) 
        {
            SysModule model = GetEntityById(moduleId);
            if (model.ParentId==0)
            {
                if (list.Where(x=>x.Id==model.Id).ToList().Count()<=0)
                {
                    list.Add(model);
                }
            }
            else
            {
                GetParentModuleByModuleId(model.ParentId, ref list);
            }
        }
        /// <summary>
        /// 给模块分配操作码
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="operaIds"></param>
        /// <returns></returns>
        public void UpdateModuleOperationByModuleId(int moduleId, string[] operaIds)
        {
            using (DBContainer db=new DBContainer ())
            {
                db.P_Sys_DeleteModuleOperation(moduleId);
                foreach (var operaId in operaIds)
                {
                    if (!String.IsNullOrWhiteSpace(operaId))
                    {
                        db.P_Sys_SysModuleAllotOperation(Convert.ToInt32(operaId),moduleId);
                    }
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public int Create(SysModule entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Set<SysModule>().Add(entity);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public int Edit(SysModule entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Set<SysModule>().Attach(entity);
                db.Entry<SysModule>(entity).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysModule entity = db.SysModule.SingleOrDefault(x => x.Id == id);
                db.Set<SysModule>().Remove(entity);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public SysModule GetEntityById(int id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.SysModule.SingleOrDefault(model => model.Id == id);
            }
        }
        /// <summary>
        /// 判断一个实体是否存在
        ///
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>是否存在 true or false</returns>
        public bool IsExist(int id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysModule entity = db.SysModule.SingleOrDefault(model => model.Id == id);
                if (entity != null)
                    return true;
                return false;
            }
        }
    }
}
