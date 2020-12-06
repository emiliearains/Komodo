using System;
using System.Collections.Generic;
using System.Text;

namespace KomodoClassLibrary
{
    public class DevTeamRepo
    {
            private List<DevTeam> Teams = new List<DevTeam>();

            // Create
            public void CreateTeam(DevTeam devTeam)
            {
                Teams.Add(devTeam);
            }
            
            public void SeedTeam()
            {
            Teams.Add(new DevTeam("Ryman", 100));
            Teams.Add(new DevTeam("Bluebird", 200));
            Teams.Add(new DevTeam("Grand Ole Opry", 300));
            Teams.Add(new DevTeam("Gulch", 400));
            Teams.Add(new DevTeam("Station Inn", 500)); 
            Teams.Add(new DevTeam("Robert's Western World", 600));
            Teams.Add(new DevTeam("Nashville", 700));
            Teams.Add(new DevTeam("Tennessee", 800));
            Teams.Add(new DevTeam("Tootsie", 900));
            Teams.Add(new DevTeam("Music City", 101));
        }

        // Read
        public List<DevTeam> GetDevTeams()
            {
                return Teams;
            }
        public DevTeam GetDevTeamById(int id)
            {
                foreach (DevTeam devTeam in Teams)
                {
                    if (devTeam.TeamID == id)
                    {
                        return devTeam;
                    }
                }
                return null;
            }

            // Update
            public bool UpdateDevTeamName(int id, DevTeam updatedDevTeamName)
            {
            return true;
            }

            

        // Delete
        public void DeleteDevTeam(DevTeam devTeam)
            {
                Teams.Remove(devTeam);
                    
            }
        }
    }
