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
    public class IconBLL:IIconBLL
    {
        [Dependency]
        public IIconRepository iconRepository { get; set; }

        DBContainer db = new DBContainer();
        public List<Icon> GetList(ref GridPager pager, string queryStr)
        {
            IQueryable<Icon> queryData = null;
            queryData = iconRepository.GetList(db);
            if (!String.IsNullOrWhiteSpace(queryStr))
            {
                queryData = queryData.Where(x => x.Code.Contains(queryStr));
            }
            pager.TotalRows = queryData.Count();
            queryData = LinqHelper.DataSorting(queryData, pager.Sort, pager.Order);
            queryData = LinqHelper.DataPaging(queryData, pager.Page, pager.Rows);

            return queryData.ToList();
        }

        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public bool Create(Icon model)
        {
            try
            {
                Icon entity = iconRepository.GetEntityById(model.Id);
                if (entity != null)
                {
                    return false;
                }
                entity = new Icon();
                entity.Id = model.Id;
                entity.Code = model.Code;
                entity.Created = model.Created;
                entity.IsDelete = model.IsDelete;
                entity.Creator = model.Creator;
                entity.Description = model.Description;
                if (iconRepository.Create(entity) == 1)//成功
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

    }
}
