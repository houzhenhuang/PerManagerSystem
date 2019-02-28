using PerManagerSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerManagerSystem.IDAL
{
    public interface ISysSampleRepository
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="db">数据库上下文</param>
        /// <returns>数据列表</returns>
        IQueryable<SysSample> GetList(DBContainer db);
        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        int Create(SysSample entity);
        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        int Edit(SysSample entity);
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        int Delete(int id);
        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        SysSample GetEntityById(int id);
        /// <summary>
        /// 判断一个实体是否存在
        ///
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>是否存在 true or false</returns>
        bool IsExist(int id);
    }
}
