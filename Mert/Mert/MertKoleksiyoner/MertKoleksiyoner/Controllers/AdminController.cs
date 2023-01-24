using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MertKoleksiyoner.Models;
using MertKoleksiyoner.Models.Entity;
/**************************************  ARAÇ EKLEME EKRANI  ********************************************/
namespace MertKoleksiyoner.Controllers
{
    public class AdminController : Controller
    {
        DataContext db = new DataContext();

        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Araba.Where(x => x.IsDelete == false).ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Araba araba, HttpPostedFileBase Image)
        {

            Araba newAraba = new Araba();

            if (Image != null && Image.ContentLength > 0)
            {
                string ImagePath = "", ImageName = "";
                ImageName = Guid.NewGuid().ToString().Substring(0, 8) + "-" + Path.GetFileName(Image.FileName);
                ImagePath = Path.Combine(Server.MapPath("~/Content/assets/images/Araba"), ImageName);
                Image.SaveAs(ImagePath);
                newAraba.Image = ImageName;


            }
            newAraba.carName = araba.carName;
            newAraba.carModel = araba.carModel;
            newAraba.carColor = araba.carColor;
            newAraba.carYear = araba.carYear;
            newAraba.carCompany = araba.carCompany;
            newAraba.IsActive = araba.IsActive;
            db.Araba.Add(newAraba);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult Edit(int id)
        {
            Araba araba = db.Araba.FirstOrDefault(x => x.Id == id && x.IsDelete == false);
            if (araba == null)
            {
                return RedirectToAction("Index");

            }

            return View(araba);
        }

        [HttpPost]
        public ActionResult Edit(Araba araba, HttpPostedFileBase Image)
        {
            Araba EditAraba = db.Araba.FirstOrDefault(x =>
            x.Id == araba.Id && x.IsDelete == false);
            if (EditAraba == null)
            {
                return RedirectToAction("Index");
            }
            if (Image != null && Image.ContentLength > 0)
            {
                string imageName = "", imagePath = "";
                imageName = Guid.NewGuid().ToString().Substring(0, 8) + "-" + Path.GetFileName(Image.FileName);
                imagePath = Path.Combine(Server.MapPath("~/Content/assets/images/Slider"), imageName);
                Image.SaveAs(imagePath);
                EditAraba.Image = imageName;

            }
            EditAraba.carName = araba.carName;
            EditAraba.carModel = araba.carModel;
            EditAraba.carColor = araba.carColor;
            EditAraba.carYear = araba.carYear;
            EditAraba.carCompany = araba.carCompany;
            EditAraba.IsActive = araba.IsActive;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Araba delAraba = db.Araba.Find(id);
            if (delAraba == null)
            {
                return RedirectToAction("Index");
            }
            delAraba.IsDelete = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}