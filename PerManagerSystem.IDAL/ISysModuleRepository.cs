using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PerManagerSystem.Models;

namespace PerManagerSystem.IDAL
{
    public interface ISysModuleRepository
    {
        IQueryable<SysModule> GetList(DBContainer db);
        /// <summary>
        /// 根据条件获取菜单
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="moduleId">菜单ID</param>
        /// <returns></returns>
        IList<SysModule> GetModuleListByConn(int userId, int moduleId);
        /// <summary>
        /// 给模块分配操作码
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="operaIds"></param>
        /// <returns></returns>
        void UpdateModuleOperationByModuleId(int moduleId, string[] operaIds);

        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        int Create(SysModule entity);
        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        int Edit(SysModule entity);
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
        SysModule GetEntityById(int id);
        /// <summary>
        /// 判断一个实体是否存在
        ///
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>是否存在 true or false</returns>
        bool IsExist(int id);
    }
}
