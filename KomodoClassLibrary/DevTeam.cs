using System;
using System.Collections.Generic;
using System.Text;

namespace KomodoClassLibrary
{
    public class DevTeam
    {
        public List<int> DeveloperIDs { get; set; }
        public string TeamName { get; set; }
        public int TeamID { get; set; }

        public DevTeam()
        {
            DeveloperIDs = new List<int>();
        }
        public DevTeam(string teamName, int teamId)
        {
            DeveloperIDs = new List<int>();
            TeamName = teamName;
            TeamID = teamId;
        }
        public void AddDeveloperToTeam(int developerID)
        {
            DeveloperIDs.Add(developerID);
        }

        public void RemoveDeveloperFromTeam(int developerID)
        {
            DeveloperIDs.Remove(developerID);
        }
    }
}
