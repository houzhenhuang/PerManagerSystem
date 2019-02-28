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
    public class SysSampleBLL:ISysSampleBLL
    {
        [Dependency]
        public ISysSampleRepository sampleRepository { get; set; }

        DBContainer db = new DBContainer();
        public List<SysSampleModel> GetList(ref GridPager pager, string queryStr)
        {
            IQueryable<SysSample> queryData = null;
            queryData = sampleRepository.GetList(db);
            if (!String.IsNullOrWhiteSpace(queryStr))
            {
                queryData = queryData.Where(x => x.Name.Contains(queryStr));
            }
            pager.TotalRows = queryData.Count();
            queryData = LinqHelper.DataSorting(queryData, pager.Sort, pager.Order);
            queryData = LinqHelper.DataPaging(queryData, pager.Page, pager.Rows);
            List<SysSampleModel> modelList = (from r in queryData
                                              select new SysSampleModel
                                              {
                                                  Id = r.Id,
                                                  Name = r.Name,
                                                  Age = r.Age,
                                                  Bir = r.Bir,
                                                  Photo = r.Photo,
                                                  Note = r.Note,
                                                  CreateTime = r.CreateTime,
                                              }).ToList();
            return modelList;
        }

        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public bool Create(SysSampleModel model)
        {
            try
            {
                SysSample entity = sampleRepository.GetEntityById(model.Id);
                if (entity != null)
                {
                    return false;
                }
                entity = new SysSample();
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Age = model.Age;
                entity.Bir = model.Bir;
                entity.Photo = model.Photo;
                entity.Note = model.Note;
                entity.CreateTime = model.CreateTime;
                if (sampleRepository.Create(entity) == 1)//成功
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
        public bool Edit(SysSampleModel model)
        {
            try
            {
                SysSample entity = sampleRepository.GetEntityById(model.Id);
                if (entity == null)
                {
                    return false;
                }
                entity.Name = model.Name;
                entity.Age = model.Age;
                entity.Bir = model.Bir;
                entity.Photo = model.Photo;
                entity.Note = model.Note;
                entity.CreateTime = model.CreateTime;
                if (sampleRepository.Edit(entity) == 1)//成功
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
                if (sampleRepository.Delete(id)==1)
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
        public SysSampleModel GetEntityById(int id)
        {
            SysSample entity = sampleRepository.GetEntityById(id);
            SysSampleModel model = new SysSampleModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Age = entity.Age;
            model.Bir = entity.Bir;
            model.Photo = entity.Photo;
            model.Note = entity.Note;
            model.CreateTime = entity.CreateTime;
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
            return sampleRepository.IsExist(id);
        }

    }
}
