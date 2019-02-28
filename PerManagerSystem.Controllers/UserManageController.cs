using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unity.Attributes;
using PerManagerSystem.IBLL;
using PerManagerSystem.Models.Sys;
using PerManagerSystem.Common;
using PerManagerSystem.Core;
using System.Web.Mvc;

namespace PerManagerSystem.Controllers
{
    public class UserManageController:BaseController
    {
        [Dependency]
        public ISysUserBLL userBLL { get; set; }
        [Dependency]
        public ISysRoleBLL roleBLL { get; set; }

        [SupportFilter(ActionName = "Browser")]
        public ActionResult Index() 
        {
            ViewBag.Perm = GetPermission();
            return View();
        }
        #region 获取列表
        [HttpPost]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<SysUserModel> list = userBLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.TotalRows,
                rows = (from u in list
                        select new SysUserModel()
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
                        }).ToArray()
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region 创建
        [SupportFilter(ActionName = "Create")]
        public ActionResult Create()
        {
            ViewBag.Perm = GetPermission();
            return View("Create");
        }
        [HttpPost]
        [SupportFilter(ActionName = "Save")]
        public JsonResult Create(SysUserModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                model.Created = DateTime.Now;
                model.Creator = ((AccountModel)Session["Account"]).Id; ;
                model.IsDelete = false;
                model.Password = Md5.MD5(model.Password);
                if (userBLL.Create(model))
                {
                    return Json(new { type = 1, message = "插入成功!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { type = 0, message = "插入失败!" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { type = 0, message = "插入失败!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        #region 编辑
        [SupportFilter(ActionName = "Edit")]
        public ActionResult Edit(int? id)
        {
            ViewBag.Perm = GetPermission();
            SysUserModel model = userBLL.GetEntityById(id ?? 0);
            return View("Edit", model);
        }
        [HttpPost]
        [SupportFilter(ActionName = "Save")]
        public JsonResult Edit(SysUserModel model)
        {
            model.Password = Md5.MD5(model.Password);
            if (userBLL.Edit(model))
            {
                return Json(new { type = 1 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { type = 0 }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        #region 详细
        [SupportFilter(ActionName = "Details")]
        public ActionResult Details(int id)
        {
            ViewBag.Perm = GetPermission();
            SysUserModel model = userBLL.GetEntityById(id);
            return View("Details", model);
        }
        #endregion
        #region 删除
        [SupportFilter(ActionName = "Delete")]
        public JsonResult Delete(int? id)
        {
            if (!String.IsNullOrWhiteSpace(id.ToString()))
            {
                if (userBLL.Delete(id ?? 0))
                {
                    return Json(new { type = 1, message = "删除成功!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { type = 0, message = "删除失败!" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { type = 0, message = "删除失败!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        #region 分配角色
        [SupportFilter(ActionName = "AllotRole")]
        public ActionResult AllotRole(int? id)
        {
            ViewBag.Perm = GetPermission();
            ViewBag.UserId = id;
            return View();
        }
        [HttpPost]
        public JsonResult GetRoleListByUserId(GridPager pager, int? userId)
        {
            var list = roleBLL.GetRoleListByUserId(ref pager, userId ?? 0);
            var json = new
            {
                total = pager.TotalRows,
                rows = (from o in list
                        select new
                        {
                            Id = o.Id,
                            RoleName = o.RoleName,
                            Description = o.Description,
                            IsDelete = o.IsDelete,
                            Created = o.Created,
                            Creator = o.Creator,
                            Flag = o.Flag
                        }).ToArray()
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UserAllotRoleByUserId(int? userId,string roleId) 
        {
            string[] roleIds = roleId.TrimEnd(',').Split(',');
            if (userBLL.UserAllotRoleByUserId(userId ?? 0, roleIds))
            {
                return Json(new { type = 1, message = "设置成功" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { type = 0, message = "设置失败" }, JsonRequestBehavior.AllowGet);
            }
            
        }
        #endregion
    }
}
