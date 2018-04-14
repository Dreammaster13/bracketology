using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOTBALL
{
	public class Team
	{
        public TeamList Teams;
		public string teamURL;
		public string teamName;
		public List<Matchup> Matchups;
		//public PlayerList Players;
		public int Wins
		{
			get
			{
				int w = 0;
				foreach (Matchup m in Matchups)
				{
					if (m.Win)
						w++;
				}
				return w;
			}

		}
		public int Losses
		{
			get
			{
				int w = 0;
				foreach (Matchup m in Matchups)
				{
					if (!m.Win)
						w++;
				}
				return w;
			}

		}
		public int GamesPlayed { get { return Wins + Losses; } }
		public double WinPercentage { get { return (Wins + 1) / (double)(GamesPlayed+2); } }

		public Team()
		{
			Matchups = new List<Matchup>();
			//Players = new PlayerList();
		}

		public double Score;
		public double OldScore;
		public double weight;
        public int flag;
        public double aveScore = 0.0;
        public int numEntries = 0;

        public Matchup GetOpposingMatchup(int i, out BasketballTeam opponent)
        {
            return GetOpposingMatchup(Matchups[i], out opponent);
        }

        public Matchup GetOpposingMatchup(Matchup m, out BasketballTeam opponent)
        {
            opponent = Teams[m.Opponent];
            if (opponent != null)
            {
                Matchup oppMatch = opponent.Matchups.Find(z => z.ID == teamName+m.OppScore.ToString()+m.TeamScore.ToString());
                if (oppMatch != null)
                    return oppMatch;
            }
            return null;
        }

        public static int GetTeamNumber(string url)
        {
            bool useForwardSlash = false;
            int c = url.LastIndexOf('/');
            int teamNum;
            if (c == -1)
            {
                c = url.LastIndexOf('\\');
                useForwardSlash = true;
            }
            if (c == -1) return -1;

            do
            {
                if (int.TryParse(url.Substring(c + 1), out teamNum))
                    return teamNum;
                url = url.Substring(0, c);
                c = url.LastIndexOf(useForwardSlash ? '\\' : '/');
            } while (c != -1);

            return -1;

        }

        public int TeamNumber
        {
            get
            {
                int num = GetTeamNumber(this.teamURL);
                if (num == -1) return 0;
                else return num;
            }
        }

		public override string ToString()
		{
			return this.teamName + " " + this.Score.ToString();
		}

        //public string Serialize()
        //{
        //    StringBuilder sb = new StringBuilder("Team:");
        //    sb.Append(teamName).Append(";");
        //    sb.Append(teamURL).Append("\r\n");
        //    foreach (Matchup m in Matchups)
        //        sb.Append(m.Serialize());
        //    foreach (Player pl in Players)
        //        sb.Append(pl.Serialize());
        //    return sb.ToString();
        //}

        //public static Team Deserialize(string input)
        //{
        //    try
        //    {
        //        Team p = new Team();
        //        if (!input.StartsWith("Team:")) return null;
        //        string[] fields = input.Substring(5).Split(';');
        //        p.teamName = fields[0];
        //        p.teamURL = fields[1];
        //        return p;
        //    }
        //    catch { }
        //    return null;
        //}
    }

    public class BasketballTeam : Team
    {
        public BasketballPlayerList Players;
        public BasketballTeam():base()
        {
            Players = new BasketballPlayerList();
        }

        public Player[] GetStarters()
        {
            Player[] starters = new Player[5];
            SortPlayersByMinutes();
            for (int i = 0; i < 5; i++)
            {
                starters[i] = this.Players[i];
            }

            return starters;
        }

        private void SortPlayersByMinutes()
        {
            for (int i = 0; i < this.Players.Count - 1; i++)
            {
                for (int j = i + 1; j < this.Players.Count; j++)
                {
                    if (((BasketballPlayer)this.Players[j]).MIN > ((BasketballPlayer)this.Players[j]).MIN)
                    {
                        BasketballPlayer temp = this.Players[i];
                        this.Players[i] = this.Players[j];
                        this.Players[j] = temp;
                    }
                }
            }
        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder("Team:");
            sb.Append(teamName).Append(";");
            sb.Append(teamURL).Append("\r\n");
            foreach (Matchup m in Matchups)
                sb.Append(m.Serialize());
            foreach (BasketballPlayer pl in Players)
                sb.Append(pl.Serialize());
            return sb.ToString();
        }

        public static BasketballTeam Deserialize(string input)
        {
            try
            {
                BasketballTeam p = new BasketballTeam();
                if (!input.StartsWith("Team:")) return null;
                string[] fields = input.Substring(5).Split(';');
                p.teamName = fields[0];
                p.teamURL = fields[1];
                return p;
            }
            catch { }
            return null;
        }
    }

    public class FootballTeam : Team
    {
        public FootballTeam():base()
        {

        }

        private string m_ScheduleURL;

        public string ScheduleUrl
        {
            get
            {
                if (string.IsNullOrEmpty(m_ScheduleURL))
                {
                    string s = teamURL.Substring(teamURL.Substring(0, teamURL.LastIndexOf('/')).LastIndexOf('/'), 3);
                    m_ScheduleURL = "http://www.espn.com/nfl/team/schedule/_/name/###/year/2015".Replace("###", s);
                }
                return m_ScheduleURL;
            }
        }
    }
}
