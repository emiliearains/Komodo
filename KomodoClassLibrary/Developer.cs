using System;

namespace KomodoClassLibrary
{
    public class Developer
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public DateTime PluralsightExpiration { get; set; }
        public Developer()
        {
        }
        public Developer(string name, int id, DateTime pluralsightExpiration)
        {
            Name = name;
            ID = id;
            PluralsightExpiration = pluralsightExpiration;
        }
        public bool HasPluralsightAccess()
        {
            if (DateTime.Now > PluralsightExpiration)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
