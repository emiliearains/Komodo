﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo
{
    class DevTeamRepo
    {
        private List<DevTeam> Teams = new List<DevTeam>();
        
        // Create
        public void CreateTeam(DevTeam devTeam)
        {
            Teams.Add(devTeam);
        }

        // Read
        public List<DevTeam> GetDevTeams()
        {
            return Teams;
        }

        // Update


        // Delete
        public void DeleteDevTeam(int id) 
        {
            foreach (DevTeam devTeam in Teams)
            {
                if (devTeam.TeamID == id)
                {
                    Teams.Remove(devTeam);
                }
            }
        }
    }
}
