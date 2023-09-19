using PhoneDictionaryLib;
using System.Threading.Tasks;
using System.Web.Mvc;
using PhoneEntry = PhoneDictionaryLib.PhoneEntry;

namespace lab3.Controllers
{
    public class DictController : Controller
    {
        IPhoneDictionary phoneDictionary;

        public DictController(IPhoneDictionary phoneDictionary)
        {
            this.phoneDictionary = phoneDictionary;
        }


        public async  Task<ActionResult> Index()
        {
            ViewBag.Phones = await phoneDictionary.GetAll();
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddSave(PhoneEntry phoneEntry)
        {
            if (ModelState.IsValid)
            {
                await phoneDictionary.Add(phoneEntry);
                await phoneDictionary.Save();
                return RedirectToActionPermanent("Index");
            }
            return View("Add", phoneEntry);
        }

        public async Task<ActionResult> Update(int id)
        {
            ViewBag.Phone = await phoneDictionary.Get(id);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UpdateSave(PhoneEntry phoneEntry)
        {
            if (ModelState.IsValid)
            {
                await phoneDictionary.Update(phoneEntry);
                await phoneDictionary.Save();
                return RedirectToActionPermanent("Index");
            }
            ViewBag.Phone = phoneEntry;
            return View("Update");
        }

        public async Task<ActionResult> Delete(int id)
        {
            ViewBag.Phone = await phoneDictionary.Get(id);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> DeleteSave(int Id)
        {
            await phoneDictionary.Delete(Id);
            await phoneDictionary.Save();
            return RedirectToActionPermanent("Index");
        }
    }
}