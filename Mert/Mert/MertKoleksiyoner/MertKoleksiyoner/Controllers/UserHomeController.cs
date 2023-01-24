using MertKoleksiyoner.Models.Entity;
using MertKoleksiyoner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MertKoleksiyoner.Controllers
{
    public class UserHomeController : Controller
    {
        DataContext db = new DataContext();
        // GET: UserHome
        public ActionResult Index()
        {
            List<Araba> arabas = new List<Araba>();
            arabas = db.Araba.Where(x => x.IsDelete == false).ToList();
            return View(arabas);
        }


    }
}