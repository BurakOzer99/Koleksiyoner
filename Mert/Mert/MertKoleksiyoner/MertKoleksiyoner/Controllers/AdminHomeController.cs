using MertKoleksiyoner.Models;
using MertKoleksiyoner.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MertKoleksiyoner.Controllers
{
    public class AdminHomeController : Controller
    {

            DataContext db = new DataContext();
            // GET: AdminHome
            [Authorize]
            public ActionResult Index()
            {
                return View();
            }
            [Authorize]
            public ActionResult Logout()
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Login");
            }
            [HttpGet]
            public ActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Login(User user)
            {
                User userControl = new User();
                userControl = db.User.FirstOrDefault(x => x.UserName == user.UserName
                && x.Password == user.Password && x.IsDelete == false);
                if (userControl != null)
                {
                    if (userControl.IsActive == false)
                    {
                        ViewBag.Mesaj = "Bu kullanıcı aktif değildir.";

                    }

                    else
                    {
                        FormsAuthentication.SetAuthCookie(userControl.UserName, true);

                        if (userControl.RoleId == 1)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            return Redirect("~/UserHome/Index");
                        }
                    }
                }
                else
                {
                    ViewBag.Mesaj = "Kullanıcı adı ve şifre hatalı tekrar deneyiniz.";
                }
                return View();
            }
        }
}