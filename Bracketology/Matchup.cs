using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOTBALL
{
	public class Matchup
	{
		public string Opponent;
		public bool Win, Home;
		public int TeamScore = 0;
		public int OppScore = 0;
        public string MatchupURL;
        public List<Performance> Performances;

        public string ID;

		public Matchup()
		{
            Performances = new List<Performance>();
		}

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder("Matchup:");
            sb.Append(Opponent).Append(";");
            sb.Append(Win.ToString()).Append(";");
            sb.Append(Home.ToString()).Append(";");
            sb.Append(TeamScore.ToString()).Append(";");
            sb.Append(OppScore.ToString()).Append(";");
            sb.Append(ID).Append("\r\n");
            return sb.ToString();
        }

        public static Matchup Deserialize(string input)
        {
            try
            {
                Matchup p = new Matchup();
                if (!input.StartsWith("Matchup:")) return null;
                string[] fields = input.Substring(8).Split(';');
                p.Opponent = fields[0];
                p.Win = bool.Parse(fields[1]);
                p.Home = bool.Parse(fields[2]);
                p.TeamScore = int.Parse(fields[3]);
                p.OppScore = int.Parse(fields[4]);
                p.ID = fields[5];
                return p;
            }
            catch { }
            return null;
        }
    }
}
