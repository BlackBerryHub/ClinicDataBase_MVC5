using Lab6.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace Lab6.Controllers
{
    public class DocumentsController : Controller
    {
        ClinicModel db = new ClinicModel();
        public ActionResult Index()
        {

            return View(db.Documents);
        }

        [HttpGet]
        public ActionResult CreateDoc()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DeleteDoc(int id)
        {
            Documents b = db.Documents.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost]
        public ActionResult CreateDoc(Documents documents)
        {
            bool Status = false;
            string message = "";
            if (ModelState.IsValid)
            {
                using (ClinicModel dc = new ClinicModel())
                {
                    var e = dc.Equipments.Where(a => a.ID_Equipment == documents.ID_Equipment).FirstOrDefault();
                    var p = dc.Procedure.Where(a => a.ID_Procedure == documents.ID_Procedure).FirstOrDefault();
                    if (e == null)
                    {
                        ModelState.AddModelError("doeqExist", "Введені не існуючі дані");
                        return View(documents);
                    }
                    else if (p == null)
                    {
                        ModelState.AddModelError("doprExist", "Введені не існуючі дані");
                        return View(documents);
                    }
                }
            }
            else
            {
                message = "Невірний запит";
            }
            ViewBag.Message = message;
            ViewBag.Status = Status;
            db.Entry(documents).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditDoc(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Documents documents = db.Documents.Find(id);
            if (documents != null)
            {
                return View(documents);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditDoc(Documents documents)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                using (ClinicModel dc = new ClinicModel())
                {
                    var e = dc.Equipments.Where(a => a.ID_Equipment == documents.ID_Equipment).FirstOrDefault();
                    var p = dc.Procedure.Where(a => a.ID_Procedure == documents.ID_Procedure).FirstOrDefault();
                    if (e == null)
                    {
                        ModelState.AddModelError("doeqExist", "Введені не існуючі дані");
                        return View(documents);
                    }
                    else if (p == null)
                    {
                        ModelState.AddModelError("doprExist", "Введені не існуючі дані");
                        return View(documents);
                    }

                }
            }
            else
            {
                message = "Невірний запит";
            }
            db.Entry(documents).State = EntityState.Modified;

            var OriginalValue = db.Entry(documents).Property(m => m.ID_Equipment).OriginalValue;
            var CurrentValue = db.Entry(documents).Property(m => m.ID_Equipment).CurrentValue;
            var DatabaseValues = db.Entry(documents).GetDatabaseValues().GetValue<int>("ID_Equipment");
            ModelState.AddModelError("", "(Аудит) Оригінальне значення:" + Convert.ToString(OriginalValue) + ", Поточне значення: " + Convert.ToString(CurrentValue) + ", Значення в БД: " + Convert.ToString(DatabaseValues));
            db.SaveChanges();
            return View(documents);
        }

        [HttpPost, ActionName("DeleteDoc")]
        public ActionResult DeleteConfirmed(int id)
        {
            Documents documents = db.Documents.Find(id);
            if (documents == null)
            {
                return HttpNotFound();
            }
            db.Documents.Remove(documents);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}