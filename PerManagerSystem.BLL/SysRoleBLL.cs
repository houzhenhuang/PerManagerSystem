using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PerManagerSystem.Models;
using PerManagerSystem.IBLL;
using PerManagerSystem.IDAL;
using Unity.Attributes;
using PerManagerSystem.Models.Sys;
using PerManagerSystem.Common;


namespace PerManagerSystem.BLL
{
    public class SysRoleBLL:ISysRoleBLL
    {
        [Dependency]
        public ISysRoleRepository roleRepository { get; set; }

        DBContainer db = new DBContainer();
        public List<SysRoleModel> GetList(ref GridPager pager, string queryStr)
        {
            IQueryable<SysRole> queryData = null;
            queryData = roleRepository.GetList(db);
            if (!String.IsNullOrWhiteSpace(queryStr))
            {
                queryData = queryData.Where(x => x.RoleName.Contains(queryStr));
            }
            pager.TotalRows = queryData.Count();
            queryData = LinqHelper.DataSorting(queryData, pager.Sort, pager.Order);
            queryData = LinqHelper.DataPaging(queryData, pager.Page, pager.Rows);
            List<SysRoleModel> modelList = (from rm in queryData
                                            select new SysRoleModel
                                            {
                                                Id = rm.Id,
                                                RoleName = rm.RoleName,
                                                Description = rm.Description,
                                                IsDelete = rm.IsDelete,
                                                Created = rm.Created,
                                                Creator = rm.Creator,
                                            }).ToList();
            return modelList;
        }

        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public bool Create(SysRoleModel model)
        {
            try
            {
                SysRole entity = roleRepository.GetEntityById(model.Id);
                if (entity != null)
                {
                    return false;
                }
                entity = new SysRole();
                entity.Id = model.Id;
                entity.RoleName = model.RoleName;
                entity.Description = model.Description;
                entity.IsDelete = model.IsDelete;
                entity.Created = model.Created;
                entity.Creator = model.Creator;
                if (roleRepository.Create(entity) == 1)//成功
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public bool Edit(SysRoleModel model)
        {
            try
            {
                SysRole entity = roleRepository.GetEntityById(model.Id);
                if (entity == null)
                {
                    return false;
                }
                entity.RoleName = model.RoleName;
                entity.Description = model.Description;
                entity.IsDelete = model.IsDelete;
                entity.Created = model.Created;
                entity.Creator = model.Creator;
                if (roleRepository.Edit(entity) == 1)//成功
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            try
            {
                if (roleRepository.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public SysRoleModel GetEntityById(int id)
        {
            SysRole entity = roleRepository.GetEntityById(id);
            SysRoleModel model = new SysRoleModel();
            model.Id = entity.Id;
            model.RoleName = entity.RoleName;
            model.Description = entity.Description;
            model.IsDelete = entity.IsDelete;
            model.Created = entity.Created;
            model.Creator = entity.Creator;
            return model;
        }
        /// <summary>
        /// 判断一个实体是否存在
        ///
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>是否存在 true or false</returns>
        public bool IsExist(int id)
        {
            return roleRepository.IsExist(id);
        }
        /// <summary>
        /// 根据用户Id获取角色
        /// </summary>
        /// <param name="pager"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<P_Sys_GetRoleListByUserId_Result> GetRoleListByUserId(ref GridPager pager, int userId) 
        {
            List<P_Sys_GetRoleListByUserId_Result> queryData = null;
            queryData = roleRepository.GetRoleListByUserId(userId);
            pager.TotalRows = queryData.Count();
            return queryData.Skip((pager.Page - 1) * pager.Rows).Take(pager.Rows).ToList();
        }
    }
}
