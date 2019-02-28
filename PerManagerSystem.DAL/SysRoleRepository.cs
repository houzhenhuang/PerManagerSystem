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
    public class SysRoleRepository:ISysRoleRepository
    {
        /// <summary>
        /// 获取列表
        ///</summary>
        /// <param name="db">数据库上下文</param>
        /// <returns>数据列表</returns>
        public IQueryable<SysRole> GetList(DBContainer db)
        {
            IQueryable<SysRole>
                list = db.SysRole.AsQueryable();
            return list;
        }
        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public int Create(SysRole entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Set<SysRole>().Add(entity);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public int Edit(SysRole entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Set<SysRole>().Attach(entity);
                db.Entry<SysRole>(entity).State = EntityState.Modified;
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
                SysRole entity = db.SysRole.SingleOrDefault(x => x.Id == id);
                db.Set<SysRole>().Remove(entity);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public SysRole GetEntityById(int id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.SysRole.SingleOrDefault(model => model.Id == id);
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
                SysRole entity = db.SysRole.SingleOrDefault(model => model.Id == id);
                if (entity != null)
                    return true;
                return false;
            }
        }
        /// <summary>
        /// 根据用户Id获取角色
        /// </summary>
        /// <param name="pager"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<P_Sys_GetRoleListByUserId_Result> GetRoleListByUserId(int userId) 
        {
            using (DBContainer db=new DBContainer ())
            {
                return db.P_Sys_GetRoleListByUserId(userId).ToList();
            }
        }
    }
}
