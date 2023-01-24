using MertKoleksiyoner.Models;
using MertKoleksiyoner.Models.Entity;
using MertKoleksiyoner.Models.MultiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MertKoleksiyoner.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        DataContext db = new DataContext();

        public ActionResult Index()
        {
            MultiModel userModel = new MultiModel
            {
                Users = db.User.Where(x => x.IsDelete == false).ToList(),
                Roles = db.Role.Where(x => x.IsDelete == false && x.IsActive == true).ToList()
            };

            //  userModel.Users=db.User.Where(x=> x.IsDelete==false).ToList();
            //userModel.Roles=db.Role.Where(x=> x.IsDelete== false && x.IsActive==true).ToList();
            return View(userModel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            List<Role> roleList = new List<Role>();
            roleList = db.Role.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            return View(roleList);
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            User userControl = db.User.FirstOrDefault(x => x.UserName == user.UserName || x.Email == user.Email);
            if (userControl != null)
            {
                return RedirectToAction("index");
            }
            User newUSer = new User();
            newUSer.UserName = user.UserName;
            newUSer.Email = user.Email;
            newUSer.Name = user.Name;
            newUSer.Surname = user.Surname;
            newUSer.Password = user.Password;
            newUSer.RoleId = user.RoleId;
            newUSer.IsActive = user.IsActive;
            db.User.Add(newUSer);
            db.SaveChanges();


            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            MultiModel userModel = new MultiModel();
            userModel.Roles = db.Role.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            userModel.User = db.User.FirstOrDefault(x => x.Id == Id && x.IsDelete == false);
            if (userModel.User == null)
            {
                return RedirectToAction("index");
            }
            return View(userModel);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            User EditUser = new User();
            EditUser = db.User.Find(user.Id);
            User userControl = new User();

            if (EditUser == null)
            {
                return RedirectToAction("index");
            }
            userControl = db.User.FirstOrDefault(x => x.UserName == user.UserName ||
            x.Email == user.Email && x.IsDelete == false && x.Id != user.Id);
            if (userControl != null)
            {
                MultiModel userModel = new MultiModel()
                {
                    Roles = db.Role.Where(x => x.IsDelete == false && x.IsActive == true).ToList(),
                    User = EditUser
                };

                ViewBag.mesaj = "aynı kullanıcı adı yada mail kullanılamaz";
                return View(userModel);
            }
            EditUser.UserName = user.UserName;
            EditUser.Email = user.Email;
            EditUser.Name = user.Name;
            EditUser.Surname = user.Surname;
            EditUser.RoleId = user.RoleId;
            EditUser.Password = user.Password;
            EditUser.IsActive = user.IsActive;
            db.SaveChanges();


            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {


            MultiModel userModel = new MultiModel();
            userModel.Roles = db.Role.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            userModel.User = db.User.FirstOrDefault(x => x.Id == id && x.IsDelete == false);
            if (userModel.User == null)
            {
                return RedirectToAction("index");
            }
            return View(userModel);
        }

        [HttpPost]
        public ActionResult Delete(User user)
        {

            User delUser = new User();
            delUser = db.User.Find(user.Id);
            delUser.IsDelete = true;
            db.SaveChanges();
            return RedirectToAction("Index");


        }


    }
}