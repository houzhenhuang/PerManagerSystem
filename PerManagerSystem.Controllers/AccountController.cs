using PerManagerSystem.Common;
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
    public class AccountController:BaseController
    {
        [Dependency]
        public ISysUserBLL userBLL { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Login(string UserName, string Password, string Code)
        {
            if (Session["Code"] == null)
                return Json(new { type = 0, message = "请重新刷新验证码" }, JsonRequestBehavior.AllowGet);
            if (Session["Code"].ToString().ToLower() != Code.ToLower())
                return Json(new { type = 0, message = "验证码错误" }, JsonRequestBehavior.AllowGet);
            SysUser user = userBLL.Login(UserName, Md5.MD5(Password));
            if (user == null)
            {
                return Json(new { type = 0, message = "用户名或密码错误" }, JsonRequestBehavior.AllowGet);
            }
            else if (!Convert.ToBoolean(user.State))//被禁用
            {
                return Json(new { type = 0, message = "账户被系统禁用" }, JsonRequestBehavior.AllowGet);
            }
            Session.Clear();
            AccountModel account = new AccountModel();
            account.Id = user.Id;
            account.TrueName = user.TrueName;
            Session["Account"] = account;

            return Json(new { type = 1, message = "" }, JsonRequestBehavior.AllowGet);
        }
    }
}
