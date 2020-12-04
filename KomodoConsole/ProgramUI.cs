using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoClassLibrary;

namespace Komodo
{
    class ProgramUI
    {
        
        public DeveloperRepo Developers { get; set; }
        public DevTeamRepo DevTeams { get; set; } 
        public void Run()
        {
            Developers = new DeveloperRepo();
            Developers.SeedDevelopers();
            DevTeams = new DevTeamRepo();

            MainMenu();
        }
        public void MainMenu()
        {
            // Display options to the user
            Console.WriteLine("What would you like to manage?");
            Console.WriteLine("1. Developers");
            Console.WriteLine("2. Development Teams");
            Console.WriteLine("3. Exit");


            bool isAcceptingInput = true;
            while (isAcceptingInput == true)
            {
                // Get user input
                string input = Console.ReadLine();

                //Evaluate user input and act accordingly
                switch (input)
                {
                    case "1":
                        DeveloperMenu();
                        break;
                    case "2":
                       //DevTeamMenu();
                        break;
                    case "3":
                        isAcceptingInput = false;
                        break;
                    default:
                        Console.WriteLine("That is not an accepted input.");
                        break;
                }
            }
        }

        public void DeveloperMenu()
        {
            bool isAcceptingInput = true;
            while (isAcceptingInput == true)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Add developer");
                Console.WriteLine("2. Update developer");
                Console.WriteLine("3. Delete developer");
                Console.WriteLine("4. View Developer Directory");
                Console.WriteLine("5. View developers that need Pluralsight access");


                string input = Console.ReadLine();


                switch (input)
                {
                    case "1":
                        AddDeveloper();
                        break;
                    case "2":
                        UpdateDeveloper();
                        break;
                    case "3":
                        DeleteDeveloper();
                        break;
                    case "4":
                        
                        ViewDeveloperDirectory();
                        break;
                    case "5":
                        //    ViewPluralsightNeed();
                        break;
                    default:
                        Console.WriteLine("That is not an accepted input.");
                        break;
                }
            }
        }
        private void AddDeveloper()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();

            // Name
            Console.WriteLine("Enter developer's name:");
            newDeveloper.Name = Console.ReadLine();

            // ID
            Console.WriteLine("Enter developer's ID:");
            newDeveloper.ID = Int32.Parse(Console.ReadLine());

            // Pluralsight access
            Console.WriteLine("Does this developer currently have Pluralsight access? Y or N: ");
            string pluralsightResponse = Console.ReadLine();
            if (pluralsightResponse == "Y")
            {
                Console.WriteLine("Enter developer's Pluralsight access expiration date (MM/DD/YYYY):");
                newDeveloper.PluralsightExpiration = DateTime.Parse(Console.ReadLine());
            }
            else
            {
                newDeveloper.PluralsightExpiration = new DateTime(1900, 1, 1);
            }
            Developers.AddDeveloperToList(newDeveloper);
        }
        private void UpdateDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Enter the ID of the developer you would like to update:");
            int developerId = Int32.Parse(Console.ReadLine());
            Developer updatedDev = Developers.GetDeveloperById(developerId);
            Console.WriteLine($"Updating {updatedDev.Name}. What would you like to update?");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Pluralsight Expiration");
            Console.WriteLine("3. Exit");

            bool isAcceptingInput = true;
            while (isAcceptingInput == true)
            {

                // Get user input
                string input = Console.ReadLine();

                //Evaluate user input and act accordingly
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Enter the updated name:");
                        string oldName = updatedDev.Name;
                        updatedDev.Name = Console.ReadLine();
                        Developers.UpdateExistingDeveloper(developerId, updatedDev);
                        Console.WriteLine($"{oldName} is changed to {updatedDev.Name}.");
                        break;
                    case "2":
                        Console.WriteLine("Enter the updated Pluralsight expiration date (MM/DD/YYYY:");
                        updatedDev.PluralsightExpiration = DateTime.Parse(Console.ReadLine());
                        Developers.UpdateExistingDeveloper(developerId, updatedDev);
                        break;
                    case "3":
                        isAcceptingInput = false;
                        break;
                    default:
                        Console.WriteLine("That is not an accepted input.");
                        break;
                }
            }
        }
        private void DeleteDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Enter the ID of the developer you would like to delete:");
            int developerId = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Are you sure you want to delete this developer? Y or N:");

            string deleteResponse = Console.ReadLine();
            if (deleteResponse == "Y")
            {
                Developers.DeleteDeveloper(developerId);
            }
            else
            {
                Console.WriteLine("Enter the ID of the developer you would like to delete:");
            }
        }
        private void ViewDeveloperDirectory()
        {
            Console.Clear();
            List<Developer> developerDirectory = Developers.GetDeveloperList();

            foreach(Developer developer in developerDirectory)
            {
                Console.WriteLine($"ID: {developer.ID}"); 
                Console.WriteLine($"Developer Name: {developer.Name}");
                Console.WriteLine($"Pluralsight expiration: {developer.PluralsightExpiration}");
                Console.WriteLine("");

            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }

        private void ViewPluralsightNeed()
        {
            bool isAcceptingInput = true;
            while (isAcceptingInput == true)
            {

            }
        }

        




        public void DevTeamMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Create a Team");
            Console.WriteLine("2. Update a Team");
            Console.WriteLine("3. Delete a Team");
            Console.WriteLine("4. View Team Directory");
            Console.WriteLine("5. View Specific Team Roster");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    //CreateTeam();
                    break;
                case "2":
                    //UpdateTeam();
                    break;
                case "3":
                    //DeleteTeam();
                    break;
                case "4":
                    //ViewTeamDirectory();
                    break;
                case "5":
                    //ViewTeamRoster();
                    break;
                default:
                    Console.WriteLine("That is not an accepted input.");
                    break;
            }
        }
    }
}
