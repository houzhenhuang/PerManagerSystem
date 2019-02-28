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
    public class SysUserRepository:ISysUserRepository
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public SysUser Login(string userName, string pwd)
        {
            using (DBContainer db = new DBContainer())
            {
                SysUser userModel = db.SysUser.SingleOrDefault(model => model.UserName == userName && model.Password == pwd);
                return userModel;
            }
        }
        /// <summary>
        /// 获取列表
        ///</summary>
        /// <param name="db">数据库上下文</param>
        /// <returns>数据列表</returns>
        public IQueryable<SysUser> GetList(DBContainer db)
        {
            IQueryable<SysUser>
                list = db.SysUser.AsQueryable();
            return list;
        }
        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public int Create(SysUser entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Set<SysUser>().Add(entity);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public int Edit(SysUser entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Set<SysUser>().Attach(entity);
                db.Entry<SysUser>(entity).State = EntityState.Modified;
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
                SysUser entity = db.SysUser.SingleOrDefault(x => x.Id == id);
                db.Set<SysUser>().Remove(entity);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public SysUser GetEntityById(int id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.SysUser.SingleOrDefault(model => model.Id == id);
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
                SysUser entity = db.SysUser.SingleOrDefault(model => model.Id == id);
                if (entity != null)
                    return true;
                return false;
            }
        }
        /// <summary>
        /// 用户分配角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        public void UserAllotRoleByUserId(int userId, string[] roleIds) 
        {
            using (DBContainer db=new DBContainer ())
            {
                db.P_Sys_DeleteUserRole(userId);
                foreach (var roleId in roleIds)
                {
                    if (!String.IsNullOrWhiteSpace(roleId))
                    {
                        db.P_Sys_UserAllotRole(userId, Convert.ToInt32(roleId));
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
