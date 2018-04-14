using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOTBALL
{
	public static class TeamRankings
	{
		private static int count;
		private static double tolerance = 1.0;
		public static void GetTeamRawScores(TeamList teams, double p5, double g5, double fcs)
		{
			foreach (Team team in teams)
			{
                team.weight = (team.flag == 2 ? p5 : team.flag == 1 ? g5 : fcs);
                double s = 0.0;
				double fade = 1.0;
				double factor = 1.0;
				//foreach (Matchup m in team.Matchups)
				for (int m = team.Matchups.Count - 1; m >= 0; m--)
				{
					Team t = teams[team.Matchups[m].Opponent];
					if (t != null)
					{
						s += fade * (t.WinPercentage + (double)(team.Matchups[m].TeamScore - team.Matchups[m].OppScore) / 35 + (team.Matchups[m].Win ? 0 : -tolerance));
					}

					fade *= factor;
				}
				team.Score = s + team.weight;
			}
		}

		public static void AdjustTeamScores(TeamList teams)
		{
			double maxScore = teams[0].Score;
			double minScore = teams[teams.Count - 1].Score;
            double rangeScore = maxScore - minScore;
			foreach (Team t in teams) t.OldScore = t.Score;
			foreach (Team team in teams)
			{
				double s = 0.0;
				double fade = 1.0;
				double factor = 0.95;
				//foreach (Matchup m in team.Matchups)
				for (int m = team.Matchups.Count - 1; m >= 0; m--)
				{
					Team t = teams[team.Matchups[m].Opponent];
					if (t != null)
					{
						s += fade * ((t.OldScore - minScore) / rangeScore + (team.Matchups[m].Win ? 0 : -tolerance));
					}
					fade *= factor;
				}
				team.Score = s + team.weight;
			}
		}

		public static bool SortTeams(TeamList teams)
		{
			count = 0;
			List<string> ranks = new List<string>();
			for (int i = 0; i < teams.Count; i++)
			{
				for (int j = i + 1; j < teams.Count; j++)
				{
					if (teams[i].Score < teams[j].Score)
					{
						count++;
						BasketballTeam t = teams[i];
						teams[i] = teams[j];
						teams[j] = t;
					}
				}
			}

			return count < 5;
		}

        public static void SortTeamsAve(TeamList teams)
        {
            List<string> ranks = new List<string>();
            for (int i = 0; i < teams.Count; i++)
            {
                for (int j = i + 1; j < teams.Count; j++)
                {
                    if (teams[i].aveScore < teams[j].aveScore)
                    {
                        BasketballTeam t = teams[i];
                        teams[i] = teams[j];
                        teams[j] = t;
                    }
                }
            }
        }
    }
}
