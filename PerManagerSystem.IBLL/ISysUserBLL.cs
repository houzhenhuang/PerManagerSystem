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
    public interface ISysUserBLL
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        SysUser Login(string userName, string pwd);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pager">JQgrid分页</param>
        /// <param name="queryStr">搜索条件</param>
        /// <returns>列表</returns>
        List<SysUserModel> GetList(ref GridPager pager, string queryStr);
        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        bool Create(SysUserModel model);
        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        bool Edit(SysUserModel model);
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
        SysUserModel GetEntityById(int id);
        /// <summary>
        /// 判断一个实体是否存在
        ///
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>是否存在 true or false</returns>
        bool IsExist(int id);

        /// <summary>
        /// 用户分配角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        bool UserAllotRoleByUserId(int userId, string[] roleIds);
    }
}
