using Lab6.Models;
using System;
using System.Data.Entity;
using System.Web.Mvc;


namespace Lab6.Controllers
{
    public class EquipmentsController : Controller
    {
        ClinicModel db = new ClinicModel();
        public ActionResult Index()
        {

            return View(db.Equipments);
        }

        [HttpGet]
        public ActionResult CreateEquip()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DeleteEquip(int id)
        {
            Equipments b = db.Equipments.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost]
        public ActionResult CreateEquip(Equipments equipments)
        {
            bool Status = false;
            string message = "";
            if (!ModelState.IsValid)
            {
                message = "Невірний запит";
            }
            ViewBag.Message = message;
            ViewBag.Status = Status;
            db.Entry(equipments).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditEquip(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Equipments equipments = db.Equipments.Find(id);
            if (equipments != null)
            {
                return View(equipments);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditEquip(Equipments equipments)
        {
            string message = "";
            if (!ModelState.IsValid)
            {
                message = "Невірний запит";
            }
            db.Entry(equipments).State = EntityState.Modified;

            var OriginalValue = db.Entry(equipments).Property(m => m.nameEquipment).OriginalValue;
            var CurrentValue = db.Entry(equipments).Property(m => m.nameEquipment).CurrentValue;
            var DatabaseValues = db.Entry(equipments).GetDatabaseValues().GetValue<string>("nameEquipment");

            ModelState.AddModelError("", "(Аудит поля \"nameEquipment\") Оригінальне значення:" + Convert.ToString(OriginalValue) + ", Поточне значення: " + Convert.ToString(CurrentValue) + ", Значення в БД: " + Convert.ToString(DatabaseValues));

            db.SaveChanges();
            return View(equipments);
        }

        [HttpPost, ActionName("DeleteEquip")]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipments equipments = db.Equipments.Find(id);
            if (equipments == null)
            {
                return HttpNotFound();
            }
            db.Equipments.Remove(equipments);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}