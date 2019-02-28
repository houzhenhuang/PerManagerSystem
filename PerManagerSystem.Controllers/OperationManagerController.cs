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
    public class OperationManagerController:BaseController
    {
        [Dependency]
        public ISysOperationsBLL operationsBLL { get; set; }
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
            List<SysOperationModel> list = operationsBLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.TotalRows,
                rows = (from o in list
                        select new SysOperationModel()
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
        public JsonResult Create(SysOperationModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                model.Created = DateTime.Now;
                model.IsDelete = false;
                model.Creator = ((AccountModel)Session["Account"]).Id;
                if (operationsBLL.Create(model))
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
            SysOperationModel model = operationsBLL.GetEntityById(id ?? 0);
            return View("Edit", model);
        }
        [HttpPost]
        [SupportFilter(ActionName = "Save")]
        public JsonResult Edit(SysOperationModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                if (operationsBLL.Edit(model))
                {
                    return Json(new { type = 1 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { type = 0 }, JsonRequestBehavior.AllowGet);
                }
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
            SysOperationModel model = operationsBLL.GetEntityById(id);
            return View("Details", model);
        }
        #endregion
        #region 删除
        [SupportFilter(ActionName = "Delete")]
        public JsonResult Delete(int? id)
        {
            if (!String.IsNullOrWhiteSpace(id.ToString()))
            {
                if (operationsBLL.Delete(id ?? 0))
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
