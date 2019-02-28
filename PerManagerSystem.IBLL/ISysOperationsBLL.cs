using PerManagerSystem.Common;
using PerManagerSystem.Models;
using PerManagerSystem.Models.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerManagerSystem.IBLL
{
    public interface ISysOperationsBLL
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pager">JQgrid分页</param>
        /// <param name="queryStr">搜索条件</param>
        /// <returns>列表</returns>
        List<SysOperationModel> GetList(ref GridPager pager, string queryStr);
        /// <summary>
        /// 根据模块Id获取操作码
        /// </summary>
        /// <param name="pager"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        List<P_Sys_GetOperationByModuleId_Result> GetOperationByModuleId(ref GridPager pager, int moduleId);
        
        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        bool Create(SysOperationModel model);
        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        bool Edit(SysOperationModel model);
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        bool Delete(int id);
        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        SysOperationModel GetEntityById(int id);
        /// <summary>
        /// 判断一个实体是否存在
        ///
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>是否存在 true or false</returns>
        bool IsExist(int id);
    }
}
