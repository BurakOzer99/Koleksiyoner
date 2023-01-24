using MertKoleksiyoner.Models;
using MertKoleksiyoner.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MertKoleksiyoner.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View(db.Role.Where(x => x.IsDelete == false).ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(Role role)
        {
            Role newRole = db.Role.FirstOrDefault(x => x.roleName == role.roleName && x.IsDelete == false);
            if (newRole != null)
            {
                ViewBag.mesaj = "aynı isimde role tanımlayamazsınız";
                return Redirect(Request.UrlReferrer.ToString());
            }
            newRole = new Role();
            newRole.roleName = role.roleName;
            newRole.IsActive = role.IsActive;
            db.Role.Add(newRole);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            if (Id == 1 || Id == 2)
            {
                return RedirectToAction("Index");
            }
            Role editRole = db.Role.FirstOrDefault(x => x.Id == Id && x.IsDelete == false);
            if (editRole == null)
            {
                return RedirectToAction("Index");

            }
            return View(editRole);

        }
        [HttpPost]
        public ActionResult Edit(int Id, string Name, bool? IsActive)
        {

            Role editRole = db.Role.FirstOrDefault(x => x.Id == Id && x.IsDelete == false);
            if (editRole == null)
            {
                return RedirectToAction("Index");

            }
            Role roleControl = db.Role.FirstOrDefault(x => x.roleName == Name && x.Id != Id && x.IsDelete == false);
            if (roleControl != null)
            {
                ViewBag.Mesaj = "aynı isimde role tanımlayamazsınız";
                return View(editRole);//sayfayı yeniler
            }

            editRole.roleName = Name;
            if (IsActive == null)
            {
                editRole.IsActive = false;
            }
            else
            {
                editRole.IsActive = true;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            if (Id == 1 || Id == 2)
            {
                return RedirectToAction("Index");
            }
            Role delRole = db.Role.FirstOrDefault(x => x.Id == Id);
            if (delRole == null)
            {
                return RedirectToAction("Index");
            }
            delRole.IsDelete = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}