using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace PhoneDictionaryLib
{
    public class FileRepository : IPhoneDictionary
    {
        private string path = "D:/data.json";
        private List<PhoneEntry> storage = new List<PhoneEntry>();

        private async Task readEntriesFromFile()
        {
            if (!File.Exists(path))
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
            entry.Id = storage.Count!=0?storage.Max(ent=>ent.Id)+1:1;
            storage.Add(entry);
            await this.Save();
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
            if (storage.Remove(entry))
            {
                await this.Save();
                return entry;
            }
            return null;
        }

        public async Task<PhoneEntry> Update(PhoneEntry entry)
        {
            await this.readEntriesFromFile();
            if (storage.Remove(storage.Find(ent => ent.Id == entry.Id)))
            {
                storage.Add(entry);
                await this.Save();
                return entry;
            }
            return null;
        }

        public FileRepository(string path)
        {
            this.path = path;
        }

        public FileRepository()
        {

        }
    }
}
