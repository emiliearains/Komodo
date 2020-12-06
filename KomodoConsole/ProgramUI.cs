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
            DevTeams = new DevTeamRepo();
            SeedData();
            MainMenu();

        }
        public void SeedData()
        {
            Developers.AddDeveloperToList(new Developer("Dolly Parton", 1, new DateTime(2022, 12, 22)));
            Developers.AddDeveloperToList(new Developer("Willie Nelson", 2, new DateTime(2021, 7, 1)));
            Developers.AddDeveloperToList(new Developer("Johnny Cash", 3, new DateTime(2022, 8, 6)));
            Developers.AddDeveloperToList(new Developer("Loretta Lynn", 4, new DateTime(2022, 1, 2)));
            Developers.AddDeveloperToList(new Developer("George Jones", 5, new DateTime(2020, 10, 17)));
            Developers.AddDeveloperToList(new Developer("Tammy Wynette", 6, new DateTime(2020, 12, 25)));
            Developers.AddDeveloperToList(new Developer("Hank Williams", 7, new DateTime(2020, 12, 27)));
            Developers.AddDeveloperToList(new Developer("Conway Twitty", 8, new DateTime(2020, 5, 5)));
            Developers.AddDeveloperToList(new Developer("Glen Campbell", 9, new DateTime(2020, 7, 12)));
            Developers.AddDeveloperToList(new Developer("Patsy Cline", 10, new DateTime(2020, 10, 12)));

            DevTeams.CreateTeam(new DevTeam("Ryman", 100, new List<int>() { 1, 2, 3, 4, 5}));
            DevTeams.CreateTeam(new DevTeam("Bluebird", 200, new List<int>() { 1, 4, 5}));
            DevTeams.CreateTeam(new DevTeam("Grand Ole Opry", 300, new List<int>() { 1, 6, 7}));
            DevTeams.CreateTeam(new DevTeam("Gulch", 400, new List<int>() { 1, 7, 9, 8, 2, 3 }));
            DevTeams.CreateTeam(new DevTeam("Station Inn", 500, new List<int>() { 10, 8, 4, 9, 2, 3 }));
            DevTeams.CreateTeam(new DevTeam("Robert's Western World", 600, new List<int>() { 1, 2, 3 }));
            DevTeams.CreateTeam(new DevTeam("Nashville", 700, new List<int>() { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }));
            DevTeams.CreateTeam(new DevTeam("Tennessee", 800, new List<int>() { 2, 7, 9 }));
            DevTeams.CreateTeam(new DevTeam("Tootsie", 900, new List<int>() { 1, 3, 5, 7, 9 }));
            DevTeams.CreateTeam(new DevTeam("Music City", 101, new List<int>() { 1, 2, 3 }));


        }

        public void MainMenu()
        {

            bool isAcceptingInput = true;
            while (isAcceptingInput == true)
            {
                // Display options to the user
                Console.Clear();
                Console.WriteLine("What would you like to manage?");
                Console.WriteLine("1. Developers");
                Console.WriteLine("2. Development Teams");
                Console.WriteLine("3. Exit");


                // Get user input
                string input = Console.ReadLine();

                //Evaluate user input and act accordingly
                switch (input)
                {
                    case "1":
                        DeveloperMenu();
                        break;
                    case "2":
                        DevTeamMenu();
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
                Console.WriteLine("6. Return to previous menu.");


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
                        ViewPluralsightNeed();
                        break;
                    case "6":
                        isAcceptingInput = false;
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

            foreach (Developer developer in developerDirectory)
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
            Console.Clear();
            List<Developer> developerDirectory = Developers.GetDeveloperList();

            foreach (Developer developer in developerDirectory)
            {
                if (developer.PluralsightExpiration < DateTime.Now)
                {
                    Console.WriteLine($"ID: {developer.ID}");
                    Console.WriteLine($"Developer Name: {developer.Name}");
                    Console.WriteLine($"Pluralsight expiration: {developer.PluralsightExpiration}");
                    Console.WriteLine("");
                }
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }

        // BEGIN DEV TEAM MENU
        public void DevTeamMenu()
        {
            bool isAcceptingInput = true;
            while (isAcceptingInput == true)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Create a Team");
                Console.WriteLine("2. Update a Team");
                Console.WriteLine("3. Delete a Team");
                Console.WriteLine("4. View Team Directory");
                Console.WriteLine("5. View Specific Team Roster");
                Console.WriteLine("6. Return to Main Menu.");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateTeam();
                        break;
                    case "2":
                        UpdateTeam();
                        break;
                    case "3":
                        DeleteTeam();
                        break;
                    case "4":
                        ViewTeamDirectory();
                        break;
                    case "5":
                        ViewTeamRoster();
                        break;
                    case "6":
                        isAcceptingInput = false;
                        break;
                    default:
                        Console.WriteLine("That is not an accepted input.");
                        break;
                }
            }
        }
        public void CreateTeam()
        {
            Console.Clear();
            DevTeam newDevTeam = new DevTeam();
            // Name
            Console.WriteLine("Enter development team name:");
            newDevTeam.TeamName = Console.ReadLine();

            // ID
            Console.WriteLine("Enter development team ID:");
            newDevTeam.TeamID = Int32.Parse(Console.ReadLine());
            DevTeams.CreateTeam(newDevTeam);
            // FIX -- If user input is NOT an int....THROWS ERROR 
            Console.WriteLine($"New team has been created. Team ID:{newDevTeam.TeamID}. Team name:{newDevTeam.TeamName}");
            Console.WriteLine("Press any key to continue.");
            Console.Read();
        }
        public void UpdateTeam()
        {
            Console.Clear();
            Console.WriteLine("Enter the team ID you would like to update:");
            int teamId = Int32.Parse(Console.ReadLine());
            DevTeam updatedDevTeam = DevTeams.GetDevTeamById(teamId);

            bool isAcceptingInput = true;
            while (isAcceptingInput == true)
            {
                Console.Clear();
                Console.WriteLine($"Updating {updatedDevTeam.TeamName}...");
                Console.WriteLine("1. Update Team Name");
                Console.WriteLine("2. Add Developer to Team");
                Console.WriteLine("3. Remove Developer from Team");
                Console.WriteLine("4. Exit");

                string input = Console.ReadLine();

                //Evaluate user input and act accordingly
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Enter the updated team name:");
                        string oldName = updatedDevTeam.TeamName;
                        updatedDevTeam.TeamName = Console.ReadLine();
                        DevTeams.UpdateDevTeamName(teamId, updatedDevTeam);
                        Console.WriteLine($"{oldName} is changed to {updatedDevTeam.TeamName}.  Press any key to continue.");
                        Console.Read();
                        break;
                    case "2":
                        Console.WriteLine("Choose a developer to add to the team.");
                        foreach (Developer currentDeveloper in Developers.GetDeveloperList())
                        {
                            Console.WriteLine($"{currentDeveloper.Name} ({currentDeveloper.ID})");
                        }
                        int selectedDeveloperIDToAdd = Int32.Parse(Console.ReadLine());
                        updatedDevTeam.AddDeveloperToTeam(selectedDeveloperIDToAdd);
                        Developer addedDeveloper = Developers.GetDeveloperById(selectedDeveloperIDToAdd);
                        Console.WriteLine($"{addedDeveloper.Name} has been added to the team {updatedDevTeam.TeamName}.  Press any key to continue.");
                        Console.Read();
                        break;
                    case "3":
                        Console.WriteLine("Choose a developer to remove from the team.");
                        foreach (int id in updatedDevTeam.DeveloperIDs)
                        {
                            Developer currentDeveloper = Developers.GetDeveloperById(id);
                            Console.WriteLine($"{currentDeveloper.Name} ({id})");
                        }
                        int selectedDeveloperIDToDelete = Int32.Parse(Console.ReadLine());
                        updatedDevTeam.RemoveDeveloperFromTeam(selectedDeveloperIDToDelete);
                        Developer removedDeveloper = Developers.GetDeveloperById(selectedDeveloperIDToDelete);
                        Console.WriteLine($"{removedDeveloper.Name} has been removed from the team {updatedDevTeam.TeamName}.  Press any key to continue.");
                        Console.Read();
                        break;
                    case "4":
                        isAcceptingInput = false;
                        break;
                }
            }
        }

        private void DeleteTeam()
        {
            Console.Clear();
            Console.WriteLine("Enter the team ID that you want to delete:");
            int teamId = Int32.Parse(Console.ReadLine());
            DevTeam selectedDevTeam = DevTeams.GetDevTeamById(teamId);
            Console.WriteLine($"Are you sure you want to delete {teamId} (Team {selectedDevTeam.TeamName})? Y or N:");
            string deleteTeam = Console.ReadLine();
            if (deleteTeam == "Y")
            {
                DevTeams.DeleteDevTeam(selectedDevTeam);
                Console.WriteLine("Team has been deleted.");
                Console.Read();
            }
            else
            {
                DeleteTeam();
            }
            Console.WriteLine("");
        }
        // View a List of all Teams
        public void ViewTeamDirectory()
        {
            Console.Clear();
            List<DevTeam> teamDirectory = DevTeams.GetDevTeams();

            foreach (DevTeam devTeam in teamDirectory)
            {
                Console.WriteLine($"Team ID: {devTeam.TeamID}");
                Console.WriteLine($"Team Name: {devTeam.TeamName}");
                Console.WriteLine("");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }
        // View a Specific Team Roster
        public void ViewTeamRoster()
        {
            Console.Clear();
            Console.WriteLine("To view team roster, enter team ID:");
            int teamId = Int32.Parse(Console.ReadLine());
            DevTeam selectedDevTeam = DevTeams.GetDevTeamById(teamId);
            Console.WriteLine($"Team {selectedDevTeam.TeamName}");
            Console.WriteLine("Current Developers (ID)");
            Console.WriteLine("---------------------------");
            foreach (int id in selectedDevTeam.DeveloperIDs)
            {
                Developer currentDeveloper = Developers.GetDeveloperById(id);
                Console.WriteLine($"{currentDeveloper.Name} ({id})");
            }
            Console.Read();
        }
    }
        
   
    // Return to previous menu

}
