using System;
using System.Collections.Generic;
using System.Text;

namespace KomodoClassLibrary
{
    public class DeveloperRepo
    {
        private List<Developer> Developers = new List<Developer>();

        // Create
        public void AddDeveloperToList(Developer developer)
        {
            Developers.Add(developer);
        }
        public void SeedDevelopers()
        {
            Developers.Add(new Developer("Dolly Parton", 1, new DateTime(2022, 12, 22)));
            Developers.Add(new Developer("Willie Nelson", 2, new DateTime(2021, 7, 1)));
            Developers.Add(new Developer("Johnny Cash", 3, new DateTime(2022, 8, 6)));
            Developers.Add(new Developer("Loretta Lynn", 4, new DateTime(2022, 1, 2)));
            Developers.Add(new Developer("George Jones", 5, new DateTime(2020, 10, 17)));
            Developers.Add(new Developer("Tammy Wynette", 6, new DateTime(2020, 12, 25)));
            Developers.Add(new Developer("Hank Williams", 7, new DateTime(2020, 12, 27)));
            Developers.Add(new Developer("Conway Twitty", 8, new DateTime(2020, 5, 5)));
            Developers.Add(new Developer("Glen Campbell", 9, new DateTime(2020, 7, 12)));
            Developers.Add(new Developer("Patsy Cline", 10, new DateTime(2020, 10, 12)));

        }

        // Read
        public List<Developer> GetDeveloperList()
        {
            return Developers;
        }
        public Developer GetDeveloperById(int id)
        {

            foreach (Developer developer in Developers)
            {
                if (developer.ID == id)
                {
                    return developer;
                }
            }
            return null;
        }
        // Update
        public bool UpdateExistingDeveloper(int id, Developer newDeveloper)
        {
            Developer existingDeveloper = GetDeveloperById(id);
            if (existingDeveloper != null)
            {
                existingDeveloper.Name = newDeveloper.Name;
                existingDeveloper.ID = newDeveloper.ID;
                existingDeveloper.PluralsightExpiration = newDeveloper.PluralsightExpiration;

                return true;
            }
            else
            {
                return false;
            }
        }
        // Delete
        public void DeleteDeveloper(int id)
        {
            foreach (Developer developer in Developers)
            {
                if (developer.ID == id)
                {
                    Developers.Remove(developer);
                }
            }
        }
    }
}
