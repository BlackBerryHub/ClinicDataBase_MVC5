using Lab6.Models;
using System;
using System.Data.Entity;
using System.Web.Mvc;


namespace Lab6.Controllers
{
    public class PacientsController : Controller
    {
        ClinicModel db = new ClinicModel();
        public ActionResult Index()
        {

            return View(db.Pacients);
        }

        [HttpGet]
        public ActionResult CreatePacients()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DeletePacients(int id)
        {
            Pacients b = db.Pacients.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost]
        public ActionResult CreatePacients(Pacients pacients)
        {
            bool Status = false;
            string message = "";
            if (!ModelState.IsValid)
            {
                message = "Невірний запит";
            }
            ViewBag.Message = message;
            ViewBag.Status = Status;
            db.Entry(pacients).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditPacients(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Pacients pacients = db.Pacients.Find(id);
            if (pacients != null)
            {
                return View(pacients);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditPacients(Pacients pacients)
        {
            string message = "";
            if (!ModelState.IsValid)
            {
                message = "Невірний запит";
            }
            db.Entry(pacients).State = EntityState.Modified;

            var OriginalValue = db.Entry(pacients).Property(m => m.Name).OriginalValue;
            var CurrentValue = db.Entry(pacients).Property(m => m.Name).CurrentValue;
            var DatabaseValues = db.Entry(pacients).GetDatabaseValues().GetValue<string>("Name");

            ModelState.AddModelError("", "(Аудит поля \"Name\") Оригінальне значення:" + Convert.ToString(OriginalValue) + ", Поточне значення: " + Convert.ToString(CurrentValue) + ", Значення в БД: " + Convert.ToString(DatabaseValues));

            db.SaveChanges();
            return View(pacients);
        }

        [HttpPost, ActionName("DeletePacients")]
        public ActionResult DeleteConfirmed(int id)
        {
            Pacients pacients = db.Pacients.Find(id);
            if (pacients == null)
            {
                return HttpNotFound();
            }
            db.Pacients.Remove(pacients);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}