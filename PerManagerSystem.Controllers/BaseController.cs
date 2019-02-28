using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PerManagerSystem.Controllers
{
    public class BaseController : Controller
    {
        //protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        //{
        //    return new JsonResult
        //    {
        //        Data = data,
        //        ContentEncoding = contentEncoding,
        //        ContentType = contentType,
        //        JsonRequestBehavior = behavior,
        //        FormateStr = "yyyy-MM-dd HH:mm:ss"
        //    };
        //}
        /// <summary>
        /// 获取当前页或操作访问权限
        /// </summary>
        /// <returns>权限列表</returns>
        public List<string> GetPermission()
        {
            string filePath = HttpContext.Request.FilePath;

            List<string> perm = (List<string>)Session[filePath];
            return perm;
        }

    }
}
