using lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace lab3.Controllers
{
    public class DictController:Controller 
    {
        IFlatFileDB<PhoneEntry> fileDB;
        public DictController() {
            fileDB = new PhoneBook();
        }

        public async Task<ActionResult> Index()
        {
            ViewBag.Phones = await fileDB.GetAll();
            return View();
        }

        public ActionResult Add() {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddSave(PhoneEntry phoneEntry)
        {
            await fileDB.Add(phoneEntry);
            await fileDB.Save();
            return RedirectToActionPermanent("Index");
        }

        public async Task<ActionResult> Update(int id)
        {
            ViewBag.Phone = await fileDB.Get(id);
            return View();
        }
        [HttpPost]
        public async Task< ActionResult> UpdateSave(PhoneEntry phoneEntry)
        {
            await fileDB.Update(phoneEntry);
            await fileDB.Save();
            return RedirectToActionPermanent("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            ViewBag.Phone = await fileDB.Get(id);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> DeleteSave(int Id)
        {
            await fileDB.Delete(Id);
            await fileDB.Save();
            return RedirectToActionPermanent("Index");
        }
    }
}