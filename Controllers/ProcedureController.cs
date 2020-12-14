using Lab6.Models;
using System;
using System.Data.Entity;
using System.Web.Mvc;


namespace Lab6.Controllers
{
    public class ProcedureController : Controller
    {
        ClinicModel db = new ClinicModel();
        public ActionResult Index()
        {

            return View(db.Procedure);
        }

        [HttpGet]
        public ActionResult CreateProcedure()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DeleteProcedure(int id)
        {
            Procedure b = db.Procedure.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost]
        public ActionResult CreateProcedure(Procedure procedure)
        {
            bool Status = false;
            string message = "";
            if (!ModelState.IsValid)
            {
                message = "Невірний запит";
            }
            ViewBag.Message = message;
            ViewBag.Status = Status;
            db.Entry(procedure).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditProcedure(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Procedure procedure = db.Procedure.Find(id);
            if (procedure != null)
            {
                return View(procedure);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditProcedure(Procedure procedure)
        {
            string message = "";
            if (!ModelState.IsValid)
            {
                message = "Невірний запит";
            }
            db.Entry(procedure).State = EntityState.Modified;

            var OriginalValue = db.Entry(procedure).Property(m => m.Name).OriginalValue;
            var CurrentValue = db.Entry(procedure).Property(m => m.Name).CurrentValue;
            var DatabaseValues = db.Entry(procedure).GetDatabaseValues().GetValue<string>("Name");

            ModelState.AddModelError("", "(Аудит поля \"Name\") Оригінальне значення:" + Convert.ToString(OriginalValue) + ", Поточне значення: " + Convert.ToString(CurrentValue) + ", Значення в БД: " + Convert.ToString(DatabaseValues));

            db.SaveChanges();
            return View(procedure);
        }

        [HttpPost, ActionName("DeleteProcedure")]
        public ActionResult DeleteConfirmed(int id)
        {
            Procedure procedure = db.Procedure.Find(id);
            if (procedure == null)
            {
                return HttpNotFound();
            }
            db.Procedure.Remove(procedure);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}