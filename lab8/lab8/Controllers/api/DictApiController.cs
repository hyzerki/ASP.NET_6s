using lab8.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace lab8.Controllers.api
{
    [Route("api/dict")]
    [ApiController]
    public class DictApiController : ControllerBase
    {
        IPhoneDictionary phoneDictionary;

        public DictApiController(IPhoneDictionary phoneDictionary)
        {
            this.phoneDictionary = phoneDictionary;
        }
        [HttpGet]
        public IActionResult Get() {
            IEnumerable<PhoneEntry> phones  = phoneDictionary.GetAll();
            return new JsonResult(phones);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetId([FromRoute]int id)
        {
            PhoneEntry phones = phoneDictionary.Get(id);
            return new JsonResult(phones);
        }

        [HttpPost]
        public IActionResult Post([FromBody]PhoneEntry entry)
        {
            PhoneEntry added = phoneDictionary.Add(entry);
            return new JsonResult(added);
        }

        [HttpPut]
        public IActionResult Put(PhoneEntry entry)
        {
            PhoneEntry updated = phoneDictionary.Update(entry);
            return new JsonResult(updated);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute]int id)
        {
            PhoneEntry deleted = phoneDictionary.Delete(id);
            return new JsonResult(deleted);
        }
    }
}
