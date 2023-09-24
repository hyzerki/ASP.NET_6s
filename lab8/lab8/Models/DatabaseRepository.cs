namespace lab8.Models
{
    public class DatabaseRepository:IPhoneDictionary
    {
        private AppContext db;
        public DatabaseRepository(AppContext db)
        {
            this.db = db;
        }

        public PhoneEntry Add(PhoneEntry entry)
        {
            db.phones.Add(entry);
            db.SaveChanges();
            return entry;
        }

        public PhoneEntry Delete(int id)
        {
            PhoneEntry phone = db.phones.Find(id)!;
            db.phones.Remove(phone!);
            db.SaveChanges();
            return phone;
        }

        public PhoneEntry Get(int id)
        {
            return db.phones.Find(id)!;
        }

        public IEnumerable<PhoneEntry> GetAll()
        {
            return db.phones.AsEnumerable<PhoneEntry>();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public PhoneEntry Update(PhoneEntry entry)
        {
            db.phones.Update(entry);
            db.SaveChanges();
            return entry;
        }
    }
}
