using Lab6.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace Lab6.Controllers
{
    public class NapravController : Controller
    {
        ClinicModel db = new ClinicModel();
        public ActionResult Index()
        {

            return View(db.Naprav);
        }

        [HttpGet]
        public ActionResult CreateNaprav()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DeleteNaprav(int id)
        {
            Naprav b = db.Naprav.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
       [HttpPost]
        public ActionResult CreateNaprav(Naprav naprav)
        {
            bool Status = false;
            string message = "";
            if (ModelState.IsValid)
            {
                using (ClinicModel dc = new ClinicModel())
                {
                    var e = dc.Pacients.Where(a => a.ID_Pacinents == naprav.ID_Pacients).FirstOrDefault();
                    var p = dc.Procedure.Where(a => a.ID_Procedure == naprav.ID_Procedure).FirstOrDefault();
                    if (e == null)
                    {
                        ModelState.AddModelError("donapExist", "Введені не існуючі дані");
                        return View(naprav);
                    }
                    else if (p == null)
                    {
                        ModelState.AddModelError("donappExist", "Введені не існуючі дані");
                        return View(naprav);
                    }
                }
            }
            else
            {
                message = "Невірний запит";
            }
            ViewBag.Message = message;
            ViewBag.Status = Status;
            db.Entry(naprav).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditNaprav(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Naprav naprav = db.Naprav.Find(id);
            if (naprav != null)
            {
                return View(naprav);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditNaprav(Naprav naprav)
        {
            string message = "";
            if (!ModelState.IsValid)
            {
                message = "Невірний запит";
            }
            db.Entry(naprav).State = EntityState.Modified;

            var OriginalValue = db.Entry(naprav).Property(m => m.ID_Pacients).OriginalValue;
            var CurrentValue = db.Entry(naprav).Property(m => m.ID_Pacients).CurrentValue;
            var DatabaseValues = db.Entry(naprav).GetDatabaseValues().GetValue<string>("ID_Pacients");

            ModelState.AddModelError("", "(Аудит поля \"ID_Pacients\") Оригінальне значення:" + Convert.ToString(OriginalValue) + ", Поточне значення: " + Convert.ToString(CurrentValue) + ", Значення в БД: " + Convert.ToString(DatabaseValues));

            db.SaveChanges();
            return View(naprav);
        }

        [HttpPost, ActionName("DeleteNaprav")]
        public ActionResult DeleteConfirmed(int id)
        {
            Naprav naprav = db.Naprav.Find(id);
            if (naprav == null)
            {
                return HttpNotFound();
            }
            db.Naprav.Remove(naprav);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}