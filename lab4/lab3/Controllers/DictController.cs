using lab3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace lab3.Controllers
{
    public class DictController:Controller 
    {
        Models.AppContext db = new Models.AppContext();


        public ActionResult Index()
        {
            ViewBag.Phones = db.phones.ToList();
            return View();
        }

        public ActionResult Add() {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddSave(PhoneEntry phoneEntry)
        {
            if (ModelState.IsValid)
            {
                db.phones.Add(phoneEntry);
                await db.SaveChangesAsync();
                return RedirectToActionPermanent("Index");
            }
            return View("Add",phoneEntry);
        }

        public async Task<ActionResult> Update(int id)
        {
            ViewBag.Phone = await db.phones.FindAsync(id);
            return View();
        }
            
        [HttpPost]
        public async Task<ActionResult> UpdateSave(PhoneEntry phoneEntry)
        {
            if(ModelState.IsValid)
            {
                db.Entry(phoneEntry).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToActionPermanent("Index");
            }
            ViewBag.Phone = phoneEntry;
            return View("Update", phoneEntry);
        }

        public async Task<ActionResult> Delete(int id)
        {
            ViewBag.Phone = await db.phones.FindAsync(id);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> DeleteSave(int Id)
        {
            PhoneEntry p = new PhoneEntry() { Id = Id };
            db.Entry(p).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return RedirectToActionPermanent("Index");
        }
    }
}