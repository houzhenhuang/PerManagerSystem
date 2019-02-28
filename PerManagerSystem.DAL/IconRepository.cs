using PerManagerSystem.IDAL;
using PerManagerSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerManagerSystem.DAL
{
    public class IconRepository : IIconRepository
    {
        /// <summary>
        /// 获取列表
        ///</summary>
        /// <param name="db">数据库上下文</param>
        /// <returns>数据列表</returns>
        public IQueryable<Icon> GetList(DBContainer db)
        {
            IQueryable<Icon>
                list = db.Icon.AsQueryable();
            return list;
        }
        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public int Create(Icon entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Set<Icon>().Add(entity);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public Icon GetEntityById(int id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.Icon.SingleOrDefault(model => model.Id == id);
            }
        }
    }
}
