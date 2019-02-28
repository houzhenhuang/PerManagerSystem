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
using System.Web;

namespace PerManagerSystem.Controllers
{
    public class RolePerSettingController:BaseController
    {
        [Dependency]
        public ISysRoleBLL roleBLL { get; set; }
        [Dependency]
        public ISysModuleBLL moduleBLL { get; set; }
        [Dependency]
        public ISysRoleModuleOperationsBLL roleModuleOperationsBLL { get; set; }
        [SupportFilter(ActionName = "Browser")]
        public ActionResult Index()
        {
            ViewBag.Perm = GetPermission();
            return View();
        }
        #region 获取角色列表
        [HttpPost]
        public JsonResult GetRoleList(GridPager pager, string queryStr)
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
                        }).ToArray()
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        } 
        #endregion
        #region 获取模块列表
        /// <summary>
        /// 获取模块列表
        /// </summary>
        /// <param name="pager">分页</param>
        /// <param name="queryStr">查询条件</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetModuleList(int? id)
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
                           Creator = m.Creator,
                           state = (moduleBLL.GetList(m.Id).Count > 0) ? "closed" : "open",
                           iconCls = m.Icon
                       };
            return Json(json, JsonRequestBehavior.AllowGet);
        } 
        #endregion
        #region 根据角色和模块获取授权
        [HttpPost]
        public JsonResult GetOperationByRoleAndModule(GridPager pager, int? roleId, int? moduleId)
        {
            pager.TotalRows = 10000;
            var list = roleModuleOperationsBLL.GetOperaByRoleAndModule(roleId ?? 0, moduleId ?? 0);
            var json = new
            {
                total = pager.TotalRows,
                rows = (from o in list
                        select new
                        {
                            OperationId = o.OperationId,
                            OperationName = o.OperationName,
                            Code = o.Code,
                            ModuleId = o.ModuleId,
                            ModuleName = o.ModuleName,
                            IsAuthor = o.IsAuthor,
                        }).ToArray()
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        } 
        #endregion
        #region 保存授权设置
        [SupportFilter(ActionName = "Save")]
        public JsonResult RolePermissionSet(int? roleId, int? moduleId, string operatId)
        {
            string[] operatIds = operatId.TrimEnd().Split(',');
            if (roleModuleOperationsBLL.RolePermission(roleId ?? 0, moduleId ?? 0, operatIds))
            {
                SysModuleModel model = moduleBLL.GetEntityById(moduleId ?? 0);
                if (model!=null)
                {
                    string path = "/" + model.Code + "/" + "Index";
                    HttpContext.Session[path] = null;
                }

                return Json(new { type = 1, message = "保存成功" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { type = 0, message = "保存失败" }, JsonRequestBehavior.AllowGet);
            }
        } 
        #endregion
    }
}
