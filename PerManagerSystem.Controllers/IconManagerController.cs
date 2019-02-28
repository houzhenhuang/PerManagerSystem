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
using PerManagerSystem.Models;

namespace PerManagerSystem.Controllers
{
    public class IconManagerController : BaseController
    {
        [Dependency]
        public IIconBLL iconBLL { get; set; }
        public ActionResult Index()
        {
            ViewBag.Perm = GetPermission();
            GridPager pager = new GridPager();
            pager.Rows = 470;
            pager.Page = 1;
            pager.Sort = "Id";
            pager.Order = "asc";
            List<Icon> list = iconBLL.GetList(ref pager,"");
            return View(list);
        }
        public JsonResult Create()
        {
            Icon model=new Icon ();
            for (int i = 1; i < 471; i++)
            {
                model.Code="pic_"+i;
                model.Description="";
                model.IsDelete=false;
                model.Created=DateTime.Now;
                model.Creator = ((AccountModel)Session["Account"]).Id;
                iconBLL.Create(model);
            }
            return Json(new { type = 1, message = "插入成功!" }, JsonRequestBehavior.AllowGet);
            //if (model != null && ModelState.IsValid)
            //{
            //    model.Created = DateTime.Now;
            //    model.IsDelete = false;
            //    model.Creator = ((AccountModel)Session["Account"]).Id;
            //    if (moduleBLL.Create(model))
            //    {
            //        return Json(new { type = 1, message = "插入成功!" }, JsonRequestBehavior.AllowGet);
            //    }
            //    else
            //    {
            //        return Json(new { type = 0, message = "插入失败!" }, JsonRequestBehavior.AllowGet);
            //    }
            //}
            //else
            //{
            //    return Json(new { type = 0, message = "插入失败!" }, JsonRequestBehavior.AllowGet);
            //}
        }
        public JsonResult GetIconList() 
        {
            GridPager pager = new GridPager();
            pager.Rows = 470;
            pager.Page = 1;
            pager.Sort = "Id";
            pager.Order = "asc";
            var jsonList = iconBLL.GetList(ref pager, "");
            return Json(jsonList, JsonRequestBehavior.AllowGet);
        }
    }
}
