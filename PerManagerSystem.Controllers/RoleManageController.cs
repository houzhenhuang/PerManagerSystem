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
    public class RoleManageController : BaseController
    {
        [Dependency]
        public ISysRoleBLL roleBLL { get; set; }
        [Dependency]
        public ISysUserBLL userBLL { get; set; }
        //
        // GET: /SysSample/
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
            List<SysRoleModel> list = roleBLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.TotalRows,
                rows = (from rm in list
                        select new SysRoleModel()
                        {
                            Id = rm.Id,
                            RoleName = rm.RoleName,
                            Description = rm.Description,
                            IsDelete = rm.IsDelete,
                            Created = rm.Created,
                            Creator = rm.Creator,
                            CreatePerson = userBLL.GetEntityById(rm.Creator ?? 0).UserName,
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
        public JsonResult Create(SysRoleModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                model.Created = DateTime.Now;
                model.Creator = ((AccountModel)Session["Account"]).Id; ;
                model.IsDelete = false;
                if (roleBLL.Create(model))
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
            SysRoleModel model = roleBLL.GetEntityById(id ?? 0);
            return View("Edit", model);
        }
        [HttpPost]
        [SupportFilter(ActionName = "Save")]
        public JsonResult Edit(SysRoleModel model)
        {
            if (roleBLL.Edit(model))
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
            SysRoleModel model = roleBLL.GetEntityById(id);
            return View("Details", model);
        }
        #endregion
        #region 删除
        [SupportFilter(ActionName = "Delete")]
        public JsonResult Delete(int? id)
        {
            if (!String.IsNullOrWhiteSpace(id.ToString()))
            {
                if (roleBLL.Delete(id ?? 0))
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
    }
}
