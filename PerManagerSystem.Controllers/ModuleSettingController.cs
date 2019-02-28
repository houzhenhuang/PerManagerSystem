using PerManagerSystem.Common;
using PerManagerSystem.Core;
using PerManagerSystem.IBLL;
using PerManagerSystem.Models;
using PerManagerSystem.Models.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Unity.Attributes;

namespace PerManagerSystem.Controllers
{
    public class ModuleSettingController:BaseController
    {
        [Dependency]
        public ISysModuleBLL moduleBLL { get; set; }
        [Dependency]
        public ISysOperationsBLL operationsBLL { get; set; }
        [Dependency]
        public ISysUserBLL userBLL { get; set; }

        [SupportFilter(ActionName = "Browser")]
        public ActionResult Index()
        {
            ViewBag.Perm = GetPermission();
            return View();
        }
        #region 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pager">分页</param>
        /// <param name="queryStr">查询条件</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetList(int? id)
        {
            List<SysModuleModel> list = moduleBLL.GetList(id ?? 0);
            var json = from m in list
                       select new SysModuleModel()
                       {
                           Id = m.Id,
                           ModuleName = m.ModuleName,
                           ParentId = m.ParentId,
                           Code = m.Code,
                           Url = m.Url,
                           Icon = m.Icon,
                           Sort = m.Sort,
                           Description = m.Description,
                           Enable = m.Enable,
                           IsDelete = m.IsDelete,
                           Created = m.Created,
                           CreatePerson = userBLL.GetEntityById(m.Creator ?? 0).UserName,
                           Creator = m.Creator,
                           state = (moduleBLL.GetList(m.Id).Count > 0) ? "closed" : "open",
                           iconCls = m.Icon
                       };
            return Json(json, JsonRequestBehavior.AllowGet);
        } 
        #endregion
        #region 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pager">分页</param>
        /// <param name="queryStr">查询条件</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetComboTreeList(int? id)
        {
            List<SysModuleModel> list = moduleBLL.GetList(id ?? 0);
            var json = from m in list
                       select new
                       {
                           id = m.Id,
                           text = m.ModuleName,
                           pId = m.ParentId,
                           state = (moduleBLL.GetList(m.Id).Count > 0) ? "closed" : "open",
                           iconCls = m.Icon
                       };
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region 分配操作码
        [SupportFilter(ActionName = "AllotOperation")]
        public ActionResult AllotOpt(int? id)
        {
            ViewBag.Perm = GetPermission();
            ViewBag.ModuleId = id;
            return View();
        }
        [HttpPost]
        public JsonResult GetOperationByModuleId(GridPager pager, int moduleId)
        {
            var list = operationsBLL.GetOperationByModuleId(ref pager, moduleId);
            var json = new
            {
                total = pager.TotalRows,
                rows = (from o in list
                        select new
                        {
                            Id = o.Id,
                            OperationName = o.OperationName,
                            Code = o.Code,
                            Icon = o.Icon,
                            Sort = o.Sort,
                            Description = o.Description,
                            IsDelete = o.IsDelete,
                            Created = o.Created,
                            Creator = o.Creator,
                            Flag = o.Flag
                        }).ToArray()
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateModuleOperationByModuleId(int moduleId,string operatId) 
        {
            string[] operatIds=operatId.TrimEnd().Split(',');
            bool flag = moduleBLL.UpdateModuleOperationByModuleId(moduleId, operatIds);
            if (flag)
            {
                return Json(new { type = 1, message = "设置成功" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { type = 0, message = "设置失败" }, JsonRequestBehavior.AllowGet);
            }
           
        }
        #endregion
        #region 创建
        [SupportFilter(ActionName = "Create")]
        public ActionResult Create()
        {
            ViewBag.Perm = GetPermission();
            SysModuleModel model = new SysModuleModel();
            return View(model);
        }
        [HttpPost]
        [SupportFilter(ActionName = "Save")]
        public JsonResult Create(SysModuleModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                model.Created = DateTime.Now;
                model.IsDelete = false;
                model.Creator = ((AccountModel)Session["Account"]).Id;
                if (moduleBLL.Create(model))
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
            SysModuleModel model = moduleBLL.GetEntityById(id ?? 0);
            return View("Edit", model);
        }
        [HttpPost]
        [SupportFilter(ActionName = "Save")]
        public JsonResult Edit(SysModuleModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                if (moduleBLL.Edit(model))
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
            SysModuleModel model = moduleBLL.GetEntityById(id);
            return View("Details", model);
        }
        #endregion
        #region 删除
        [SupportFilter(ActionName = "Delete")]
        public JsonResult Delete(int? id)
        {
            if (!String.IsNullOrWhiteSpace(id.ToString()))
            {
                if (moduleBLL.Delete(id ?? 0))
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
