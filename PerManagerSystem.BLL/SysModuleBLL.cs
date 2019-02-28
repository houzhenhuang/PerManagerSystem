using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PerManagerSystem.IBLL;
using PerManagerSystem.Models;
using PerManagerSystem.IDAL;
using Unity.Attributes;
using PerManagerSystem.Common;
using PerManagerSystem.Models.Sys;

namespace PerManagerSystem.BLL
{
    public class SysModuleBLL:ISysModuleBLL
    {
        [Dependency]
        public ISysModuleRepository moduleRepository { get; set; }
        DBContainer db = new DBContainer();
        public List<SysModuleModel> GetList(int id)
        {
            IQueryable<SysModule> queryData = null;
            queryData = moduleRepository.GetList(db).Where(a => a.ParentId == id).OrderBy(a => a.Sort); ;
            List<SysModuleModel> modelList = (from m in queryData 
                                              select new SysModuleModel 
                                              {
                                                Id=m.Id,
                                                ModuleName=m.ModuleName,
                                                ParentId=m.ParentId,
                                                Code = m.Code,
                                                Url = m.Url,
                                                Icon = m.Icon,
                                                Sort = m.Sort,
                                                Description = m.Description,
                                                Enable = m.Enable,
                                                IsDelete = m.IsDelete,
                                                Created = m.Created,
                                                Creator = m.Creator
                                              }).ToList();

            return modelList;
        }
        /// <summary>
        /// 根据条件获取菜单
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="moduleId">菜单ID</param>
        /// <returns></returns>
        public IList<SysModule> GetModuleListByConn(int userId, int moduleId)
        {
            return moduleRepository.GetModuleListByConn(userId, moduleId);
        }
        /// <summary>
        /// 给模块分配操作码
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="operaIds"></param>
        /// <returns></returns>
        public bool UpdateModuleOperationByModuleId(int moduleId, string[] operaIds)
        {
            try
            {
                moduleRepository.UpdateModuleOperationByModuleId(moduleId,operaIds);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public bool Create(SysModuleModel model)
        {
            try
            {
                SysModule entity = moduleRepository.GetEntityById(model.Id);
                if (entity != null)
                {
                    return false;
                }
                entity = new SysModule();
                entity.Id = model.Id;
                entity.ModuleName = model.ModuleName;
                entity.ParentId = model.ParentId;
                entity.Code = model.Code;
                entity.Url = model.Url;
                entity.Icon = model.Icon;
                entity.Sort = model.Sort;
                entity.Description = model.Description;
                entity.Enable = model.Enable;
                entity.IsDelete = model.IsDelete;
                entity.Created = model.Created;
                entity.Creator = model.Creator;
                if (moduleRepository.Create(entity) == 1)//成功
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
        public bool Edit(SysModuleModel model)
        {
            try
            {
                SysModule entity = moduleRepository.GetEntityById(model.Id);
                if (entity == null)
                {
                    return false;
                }
                entity.ModuleName = model.ModuleName;
                entity.ParentId = model.ParentId;
                entity.Code = model.Code;
                entity.Url = model.Url;
                entity.Icon = model.Icon;
                entity.Sort = model.Sort;
                entity.Description = model.Description;
                entity.Enable = model.Enable;
                entity.IsDelete = model.IsDelete;
                entity.Created = model.Created;
                entity.Creator = model.Creator;
                if (moduleRepository.Edit(entity) == 1)//成功
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
                if (moduleRepository.Delete(id) == 1)
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
        public SysModuleModel GetEntityById(int id)
        {
            SysModule entity = moduleRepository.GetEntityById(id);
            SysModuleModel model = new SysModuleModel();
            model.Id = entity.Id;
            model.ModuleName = entity.ModuleName;
            model.ParentId = entity.ParentId;
            model.Code = entity.Code;
            model.Url = entity.Url;
            model.Icon = entity.Icon;
            model.Sort = entity.Sort;
            model.Description = entity.Description;
            model.Enable = entity.Enable;
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
            return moduleRepository.IsExist(id);
        }
    }
}
