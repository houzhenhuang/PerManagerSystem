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
    public class SysUserBLL:ISysUserBLL
    {
        [Dependency]
        public ISysUserRepository userRepository { get; set; }
        DBContainer db = new DBContainer();
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public SysUser Login(string userName, string pwd)
        {
            return userRepository.Login(userName,pwd);
        }
        public List<SysUserModel> GetList(ref GridPager pager, string queryStr)
        {
            IQueryable<SysUser> queryData = null;
            queryData = userRepository.GetList(db);
            if (!String.IsNullOrWhiteSpace(queryStr))
            {
                queryData = queryData.Where(x => x.UserName.Contains(queryStr));
            }
            pager.TotalRows = queryData.Count();
            queryData = LinqHelper.DataSorting(queryData, pager.Sort, pager.Order);
            queryData = LinqHelper.DataPaging(queryData, pager.Page, pager.Rows);
            List<SysUserModel> modelList = (from u in queryData
                                            select new SysUserModel
                                              {
                                                  Id = u.Id,
                                                  UserName = u.UserName,
                                                  Password = u.Password,
                                                  TrueName = u.TrueName,
                                                  Photo = u.Photo,
                                                  Phone = u.Phone,
                                                  Telephone = u.Telephone,
                                                  EmailAddress = u.EmailAddress,
                                                  QQ = u.QQ,
                                                  OtherContact = u.OtherContact,
                                                  Province = u.Province,
                                                  City = u.City,
                                                  Street = u.Street,
                                                  Address = u.Address,
                                                  State = u.State,
                                                  Birthday = u.Birthday,
                                                  Marital = u.Marital,
                                                  Political = u.Political,
                                                  Nationality = u.Nationality,
                                                  School = u.School,
                                                  Professional = u.Professional,
                                                  Degree = u.Degree,
                                                  DepartmentId = u.DepartmentId,
                                                  PostId = u.PostId,
                                                  JobState = u.JobState,
                                                  Attach = u.Attach,
                                                  Description = u.Description,
                                                  IsDelete = u.IsDelete,
                                                  Created = u.Created,
                                                  Creator = u.Creator
                                              }).ToList();
            return modelList;
        }
        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public bool Create(SysUserModel model)
        {
            try
            {
                SysUser entity = userRepository.GetEntityById(model.Id);
                if (entity != null)
                {
                    return false;
                }
                entity = new SysUser();
                entity.Id = model.Id;
                entity.UserName = model.UserName;
                entity.Password = model.Password;
                entity.TrueName = model.TrueName;
                entity.Photo = model.Photo;
                entity.Phone = model.Phone;
                entity.Telephone = model.Telephone;
                entity.EmailAddress = model.EmailAddress;
                entity.QQ = model.QQ;
                entity.OtherContact = model.OtherContact;
                entity.Province = model.Province;
                entity.City = model.City;
                entity.Street = model.Street;
                entity.Address = model.Address;
                entity.State = model.State;
                entity.Birthday = model.Birthday;
                entity.Marital = model.Marital;
                entity.Political = model.Political;
                entity.Nationality = model.Nationality;
                entity.School = model.School;
                entity.Professional = model.Professional;
                entity.Degree = model.Degree;
                entity.DepartmentId = model.DepartmentId;
                entity.PostId = model.PostId;
                entity.JobState = model.JobState;
                entity.Attach = model.Attach;
                entity.Description = model.Description;
                entity.IsDelete = model.IsDelete;
                entity.Created = model.Created;
                entity.Creator = model.Creator;
                if (userRepository.Create(entity) == 1)//成功
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
        public bool Edit(SysUserModel model)
        {
            try
            {
                SysUser entity = userRepository.GetEntityById(model.Id);
                if (entity == null)
                {
                    return false;
                }
                entity.UserName = model.UserName;
                entity.Password = model.Password;
                entity.TrueName = model.TrueName;
                entity.Phone = model.Phone;
                entity.Telephone = model.Telephone;
                entity.EmailAddress = model.EmailAddress;
                entity.QQ = model.QQ;
                entity.OtherContact = model.OtherContact;
                entity.Province = model.Province;
                entity.City = model.City;
                entity.Street = model.Street;
                entity.Address = model.Address;
                entity.State = model.State;
                entity.Birthday = model.Birthday;
                entity.Marital = model.Marital;
                entity.Political = model.Political;
                entity.Nationality = model.Nationality;
                entity.School = model.School;
                entity.Professional = model.Professional;
                entity.Degree = model.Degree;
                entity.DepartmentId = model.DepartmentId;
                entity.PostId = model.PostId;
                entity.JobState = model.JobState;
                entity.Photo = model.Photo;
                entity.Attach = model.Attach;
                entity.Description = model.Description;
                entity.IsDelete = model.IsDelete;
                entity.Created = model.Created;
                entity.Creator = model.Creator;
                if (userRepository.Edit(entity) == 1)//成功
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
                if (userRepository.Delete(id) == 1)
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
        public SysUserModel GetEntityById(int id)
        {
            SysUser entity = userRepository.GetEntityById(id);
            SysUserModel model = new SysUserModel();
            if (model != null)
            {
                model.Id = entity.Id;
                model.UserName = entity.UserName;
                model.Password = entity.Password;
                model.TrueName = entity.TrueName;
                model.Phone = entity.Phone;
                model.Telephone = entity.Telephone;
                model.EmailAddress = entity.EmailAddress;
                model.QQ = entity.QQ;
                model.OtherContact = entity.OtherContact;
                model.Province = entity.Province;
                model.City = entity.City;
                model.Street = entity.Street;
                model.Address = entity.Address;
                model.State = entity.State;
                model.Birthday = entity.Birthday;
                model.Marital = entity.Marital;
                model.Political = entity.Political;
                model.Nationality = entity.Nationality;
                model.School = entity.School;
                model.Professional = entity.Professional;
                model.Degree = entity.Degree;
                model.DepartmentId = entity.DepartmentId;
                model.PostId = entity.PostId;
                model.JobState = entity.JobState;
                model.Photo = entity.Photo;
                model.Attach = entity.Attach;
                model.Description = entity.Description;
                model.IsDelete = entity.IsDelete;
                model.Created = entity.Created;
                model.Creator = entity.Creator;
            }
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
            return userRepository.IsExist(id);
        }
        /// <summary>
        /// 用户分配角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        public bool UserAllotRoleByUserId(int userId, string[] roleIds) 
        {
            try
            {
                userRepository.UserAllotRoleByUserId(userId,roleIds);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
