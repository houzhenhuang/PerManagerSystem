using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Unity.Attributes;
using PerManagerSystem.IBLL;
using PerManagerSystem.Models.Sys;
using PerManagerSystem.Common;
using PerManagerSystem.Core;

namespace PerManagerSystem.Controllers
{
    public class SysSampleController : BaseController
    {
        [Dependency]
        public ISysSampleBLL sampleBLL { get; set; }
        //
        // GET: /SysSample/
        [SupportFilter(ActionName="Browser")]
        public ActionResult Index()
        {
            ViewBag.Perm = GetPermission();
            return View();
        }
        [HttpPost]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<SysSampleModel> list = sampleBLL.GetList(ref pager,queryStr);
            var json = new 
            {
                total=pager.TotalRows,
                rows=(from r in list
                          select new SysSampleModel()
                          {
                            Id = r.Id,
                            Name = r.Name,
                            Age = r.Age,
                            Bir = r.Bir,
                            Photo = r.Photo,
                            Note = r.Note,
                            CreateTime = r.CreateTime
                          }).ToArray()
            };
            return Json(json,JsonRequestBehavior.AllowGet);
        }
        #region 创建
        [SupportFilter(ActionName = "Create")]
        public ActionResult Create()
        {
            ViewBag.Perm = GetPermission();
            return View("Create");
        }
        [HttpPost]
        [SupportFilter(ActionName = "Save")]
        public JsonResult Create(SysSampleModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                model.CreateTime = DateTime.Now;
                if (sampleBLL.Create(model))
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
            SysSampleModel model = sampleBLL.GetEntityById(id ?? 0);
            return View("Edit", model);
        }
        [HttpPost]
        [SupportFilter(ActionName = "Save")]
        public JsonResult Edit(SysSampleModel model)
        {
            if (sampleBLL.Edit(model))
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
            SysSampleModel model = sampleBLL.GetEntityById(id);
            return View("Details", model);
        }       
        #endregion
        #region 删除
        [SupportFilter(ActionName = "Delete")]
        public JsonResult Delete(int? id)
        {
            if (!String.IsNullOrWhiteSpace(id.ToString()))
            {
                if (sampleBLL.Delete(id ?? 0))
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