using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDictionaryLib
{
    public class DataBaseRepository : IPhoneDictionary
    {
        private AppContext db;
        public DataBaseRepository(AppContext db)
        {
            this.db = db;
        }

        public async Task<PhoneEntry> Add(PhoneEntry entry)
        {

            entry = db.phones.Add(entry);
            await db.SaveChangesAsync();
            return entry;
        }

        public async  Task<PhoneEntry> Delete(int id)
        {
            PhoneEntry phone = await db.phones.FindAsync(id);
            db.Entry(phone).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return phone;
        }

        public async Task<PhoneEntry> Get(int id)
        {
            return await db.phones.FindAsync(id);
        }

        public async Task<IEnumerable<PhoneEntry>> GetAll()
        {
            return db.phones.AsEnumerable<PhoneEntry>();
        }

        public async Task Save()
        {
            await db.SaveChangesAsync();
        }

        public async  Task<PhoneEntry> Update(PhoneEntry entry)
        {
            PhoneEntry original = db.phones.Find(entry.Id);
            if (original != null)
            {
                original.Name = entry.Name;
                original.Phone = entry.Phone;
            }
            //db.phones(entry);
            //db.Entry(entry).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return entry;
        }
    }
}
