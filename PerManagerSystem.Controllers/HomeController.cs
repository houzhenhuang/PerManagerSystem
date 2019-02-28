using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PerManagerSystem.IBLL;
using Unity.Attributes;
using PerManagerSystem.Models;
using PerManagerSystem.Models.Sys;
using System.Globalization;
using System.Threading;


namespace PerManagerSystem.Controllers
{
    public class HomeController : Controller
    {
        [Dependency]
        public ISysModuleBLL sysModuleBLL { get; set; }
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetModuleTree(int id) 
        {
            if (Session["Account"]!=null)
            {
                List<SysModule> modules = sysModuleBLL.GetModuleListByConn(((AccountModel)Session["Account"]).Id, id).ToList();
                var jsonData = (from m in modules
                                select new
                                {
                                    id = m.Id,
                                    text = m.ModuleName,
                                    value = m.Url,
                                    iconCls = m.Icon,
                                    state = (sysModuleBLL.GetModuleListByConn(1, m.Id).Count > 0) ? "closed" : "open",
                                    attributes = m.Url
                                }).ToArray();
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("0", JsonRequestBehavior.AllowGet);
            }
           
        }
	}
}