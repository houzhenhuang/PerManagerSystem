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
    public class DepartmentManagerController : BaseController
    {

        public ActionResult Index()
        {
            ViewBag.Perm = GetPermission();
            return View();
        }

    }
}
