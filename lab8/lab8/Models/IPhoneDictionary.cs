namespace lab8.Models
{
    public interface IPhoneDictionary
    {
        void Save();
        PhoneEntry Add(PhoneEntry entry);
        PhoneEntry Get(int id);
        IEnumerable<PhoneEntry> GetAll();
        PhoneEntry Delete(int id);
        PhoneEntry Update(PhoneEntry entry);
    }

}
