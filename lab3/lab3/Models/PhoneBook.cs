using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;

namespace lab3.Models
{
    public class PhoneBook:IFlatFileDB<PhoneEntry>
    {
        private string path = "data.json";
        private List<PhoneEntry> storage = new List<PhoneEntry>();

        private async Task readEntriesFromFile()
        {
            if(!File.Exists(path))
            {
                File.WriteAllText(path, "[]");
            }
            using (StreamReader sr = new StreamReader(path))
            {
                string json = await sr.ReadToEndAsync();
                storage = Json.Decode(json, typeof(List<PhoneEntry>));
            }
        }

        public async Task Save()
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                await sw.WriteAsync(Json.Encode(storage));
            }
        }

        public async Task<PhoneEntry> Add(PhoneEntry entry)
        {
            await this.readEntriesFromFile();
            entry.Id = storage.Count;
            storage.Add(entry);
            return entry;
        }


        

        public async Task<PhoneEntry> Get(int id)
        {
            await this.readEntriesFromFile();
            return storage.Find(entry => entry.Id == id);
        }

        public async Task<IEnumerable<PhoneEntry>> GetAll()
        {
            await this.readEntriesFromFile();
            return storage;
        }

        public async Task<PhoneEntry> Delete(int id)
        {
            await this.readEntriesFromFile();
            PhoneEntry entry = storage.Find(ent => ent.Id == id);
            if(storage.Remove(entry))
            {
                return entry;
            }
            return null;
        }

        public async Task<PhoneEntry> Update(PhoneEntry entry)
        {
            await this.readEntriesFromFile();
            if(storage.Remove(storage.Find(ent=>ent.Id == entry.Id)))
            {
                storage.Add(entry);
                return entry;
            }
            return null;
        }

        public PhoneBook(string path)
        {
            this.path = path;
        }

        public PhoneBook()
        {

        }
    }
}   