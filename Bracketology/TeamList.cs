using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOTBALL
{
	public class TeamList : List<BasketballTeam>
	{
		public TeamList()
		{

		}

		public BasketballTeam this[string name]
		{
			get
			{
				foreach (BasketballTeam t in this)
				{
                    if (t.teamURL == name || t.teamName == name || (Team.GetTeamNumber(name) == t.TeamNumber))
						return t;
				}
				return null;
			}
		}

        public static void Serialize(TeamList teams, string path)
        {
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(path))
                {
                    foreach(BasketballTeam t in teams)
                    {
                        writer.Write(t.Serialize());
                    }
                }
            }
            catch { }
        }
        
        public static TeamList Deserialize(string path)
        {
            try
            {
                TeamList teams = new TeamList();
                using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
                {
                    string[] lines = reader.ReadToEnd().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    BasketballTeam t = new BasketballTeam();
                    Matchup m = new Matchup();
                    BasketballPlayer p = new BasketballPlayer();
                    BasketballPerformance perf = new BasketballPerformance();
                    foreach(string line in lines)
                    {
                        int index = line.IndexOf(':');
                        if (index > 0)
                        {
                            switch (line.Substring(0, index))
                            {
                                case "Team":
                                    t = BasketballTeam.Deserialize(line);
                                    teams.Add(t);
                                    break;
                                case "Matchup":
                                    m = Matchup.Deserialize(line);
                                    t.Matchups.Add(m);
                                    break;
                                case "Player":
                                    p = BasketballPlayer.Deserialize(line);
                                    t.Players.Add(p);
                                    break;
                                case "Performance":
                                    perf = BasketballPerformance.Deserialize(line, t.Matchups);
                                    perf.Player = p;
                                    p.Performances.Add(perf);
                                    break;
                            }
                        }
                    }
                }
                foreach (BasketballTeam t in teams)
                    t.Teams = teams;
                return teams;
            }
            catch { }
            return null;
        }
	}
}
