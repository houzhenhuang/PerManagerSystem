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
    public class SysOperationsRepository:ISysOperationsRepository
    {
        /// <summary>
        /// 获取列表
        ///</summary>
        /// <param name="db">数据库上下文</param>
        /// <returns>数据列表</returns>
        public IQueryable<SysOperations> GetList(DBContainer db)
        {
            IQueryable<SysOperations>
                list = db.SysOperations.AsQueryable();
            return list;
        }
        /// <summary>
        /// 根据模块Id获取操作码
        /// </summary>
        /// <param name="pager"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<P_Sys_GetOperationByModuleId_Result> GetOperationByModuleId(int moduleId)
        {
            using (DBContainer db=new DBContainer ())
            {
                return db.P_Sys_GetOperationByModuleId(moduleId).ToList();
            }
        }
        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public int Create(SysOperations entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Set<SysOperations>().Add(entity);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public int Edit(SysOperations entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Set<SysOperations>().Attach(entity);
                db.Entry<SysOperations>(entity).State = EntityState.Modified;
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
                SysOperations entity = db.SysOperations.SingleOrDefault(x => x.Id == id);
                db.Set<SysOperations>().Remove(entity);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public SysOperations GetEntityById(int id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.SysOperations.SingleOrDefault(model => model.Id == id);
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
                SysOperations entity = db.SysOperations.SingleOrDefault(model => model.Id == id);
                if (entity != null)
                    return true;
                return false;
            }
        }
    }
}
