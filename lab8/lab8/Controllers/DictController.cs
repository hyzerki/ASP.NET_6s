using lab8.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab8.Controllers
{
    public class DictController : Controller
    {
        IPhoneDictionary phoneDictionary;

        public DictController(IPhoneDictionary phoneDictionary)
        {
            this.phoneDictionary = phoneDictionary;
        }


        public  ActionResult Index()
        {
            ViewBag.Phones =  phoneDictionary.GetAll();
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public  ActionResult  AddSave(PhoneEntry phoneEntry)
        {
            if (ModelState.IsValid)
            {
                phoneDictionary.Add(phoneEntry);
                phoneDictionary.Save();
                return RedirectToActionPermanent("Index");
            }
            return View("Add", phoneEntry);
        }

        public  ActionResult Update(int id)
        {
            ViewBag.Phone =  phoneDictionary.Get(id);
            return View();
        }

        [HttpPost]
        public ActionResult UpdateSave(PhoneEntry phoneEntry)
        {
            if (ModelState.IsValid)
            {
                phoneDictionary.Update(phoneEntry);
                phoneDictionary.Save();
                return RedirectToActionPermanent("Index");
            }
            ViewBag.Phone = phoneEntry;
            return View("Update");
        }

        public  ActionResult Delete(int id)
        {
            ViewBag.Phone =  phoneDictionary.Get(id);
            return View();
        }

        [HttpPost]
        public ActionResult DeleteSave(int Id)
        {
            phoneDictionary.Delete(Id);
            phoneDictionary.Save();
            return RedirectToActionPermanent("Index");
        }
    }
}
