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
    public class SysOperationsBLL:ISysOperationsBLL
    {
        [Dependency]
        public ISysOperationsRepository operationsRepository { get; set; }

        DBContainer db = new DBContainer();
        public List<SysOperationModel> GetList(ref GridPager pager, string queryStr)
        {
            IQueryable<SysOperations> queryData = null;
            queryData = operationsRepository.GetList(db);
            if (!String.IsNullOrWhiteSpace(queryStr))
            {
                queryData = queryData.Where(x => x.OperationName.Contains(queryStr));
            }
            pager.TotalRows = queryData.Count();
            queryData = LinqHelper.DataSorting(queryData, pager.Sort, pager.Order);
            queryData = LinqHelper.DataPaging(queryData, pager.Page, pager.Rows);
            List<SysOperationModel> modelList = (from o in queryData
                                                 select new SysOperationModel
                                              {
                                                  Id = o.Id,
                                                  OperationName = o.OperationName,
                                                  Code = o.Code,
                                                  Icon = o.Icon,
                                                  Sort = o.Sort,
                                                  Description = o.Description,
                                                  IsDelete = o.IsDelete,
                                                  Created = o.Created,
                                                  Creator = o.Creator
                                              }).ToList();
            return modelList;
        }
        /// <summary>
        /// 根据模块Id获取操作码
        /// </summary>
        /// <param name="pager"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<P_Sys_GetOperationByModuleId_Result> GetOperationByModuleId(ref GridPager pager, int moduleId) 
        {
            List<P_Sys_GetOperationByModuleId_Result> queryData = null;
            queryData = operationsRepository.GetOperationByModuleId(moduleId);
            pager.TotalRows = queryData.Count();
            return queryData.Skip((pager.Page - 1) * pager.Rows).Take(pager.Rows).ToList();
        }
        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public bool Create(SysOperationModel model)
        {
            try
            {
                SysOperations entity = operationsRepository.GetEntityById(model.Id);
                if (entity != null)
                {
                    return false;
                }
                entity = new SysOperations();
                entity.Id = model.Id;
                entity.OperationName = model.OperationName;
                entity.Code = model.Code;
                entity.Icon = model.Icon;
                entity.Sort = model.Sort;
                entity.Description = model.Description;
                entity.IsDelete = model.IsDelete;
                entity.Created = model.Created;
                entity.Creator = model.Creator;
                if (operationsRepository.Create(entity) == 1)//成功
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
        public bool Edit(SysOperationModel model)
        {
            try
            {
                SysOperations entity = operationsRepository.GetEntityById(model.Id);
                if (entity == null)
                {
                    return false;
                }
                entity.OperationName = model.OperationName;
                entity.Code = model.Code;
                entity.Icon = model.Icon;
                entity.Sort = model.Sort;
                entity.Description = model.Description;
                entity.IsDelete = model.IsDelete;
                entity.Created = model.Created;
                entity.Creator = model.Creator;
                if (operationsRepository.Edit(entity) == 1)//成功
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
                if (operationsRepository.Delete(id) == 1)
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
        public SysOperationModel GetEntityById(int id)
        {
            SysOperations entity = operationsRepository.GetEntityById(id);
            SysOperationModel model = new SysOperationModel();
            model.Id = entity.Id;
            model.OperationName = entity.OperationName;
            model.Code = entity.Code;
            model.Icon = entity.Icon;
            model.Sort = entity.Sort;            
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
            return operationsRepository.IsExist(id);
        }

    }
}
