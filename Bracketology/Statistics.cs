using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOTBALL
{
	public static class Statistics
	{
		private static int fetch = 0;
		private static TeamList teams;
		public static void GetTeamStatistics(TeamList tl)
		{
			fetch = 0;
			teams = tl;
			foreach (BasketballTeam t in teams)
			{
			//	System.Threading.Thread thr = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(_getstats));
			//	thr.Start(t);
				_getstats(t);
			}

			while (fetch < teams.Count) ;
		}

		private static void _getstats(object o)
		{
			int value = ((BasketballTeam)o).teamURL.IndexOf("_/id");
			string url = ((BasketballTeam)o).teamURL.Insert(value, "stats/");
			string s = WebUtility.GetWebpage(url);
			int count = s.IndexOf("oddrow player"), end = 0;
			int enddiv = s.IndexOf("</div>", count);
			while ((count = s.IndexOf("oddrow player", count)) < enddiv)
			{
				((BasketballTeam)o).Players.Add(GetPlayer(s, ref count, ref end));
				if ((count = s.IndexOf("evenrow player", count)) < enddiv)
					((BasketballTeam)o).Players.Add(GetPlayer(s, ref count, ref end));
			}
			count = enddiv;

			while (count >= 0 && (count = s.IndexOf("oddrow player", count)) != -1)
			{
				GetPlayerStats((BasketballTeam)o, s, ref count, ref end);
				if (count >= 0 && (count = s.IndexOf("evenrow", count)) != -1)
					GetPlayerStats((BasketballTeam)o, s, ref count, ref end);
			}

			value = ((BasketballTeam)o).teamURL.IndexOf("_/id");
			url = ((BasketballTeam)o).teamURL.Insert(value, "roster/");
			s = WebUtility.GetWebpage(url);
			count = 0;
			end = 0;
			while (count >= 0 && (count = s.IndexOf("oddrow", count)) != -1)
			{
				GetPlayerInfo((BasketballTeam)o, s, ref count, ref end);
				if (count >= 0 && (count = s.IndexOf("evenrow", count)) != -1)
					GetPlayerInfo((BasketballTeam)o, s, ref count, ref end);

			}

			System.Threading.Interlocked.Increment(ref fetch);
		}

		private static BasketballPlayer GetPlayer(string s, ref int count, ref int end)
		{
			count = s.IndexOf("a href=", count + 11) + 8;
			count = s.IndexOf("\">", count) + 2;
			end = s.IndexOf("</a>", count);
			BasketballPlayer p = new BasketballPlayer(s.Substring(count, end - count));
			//p.GP = (int)GetStatistic(s, ref count, ref end);
			//p.MIN = GetStatistic(s, ref count, ref end);
			//p.PPG = GetStatistic(s, ref count, ref end);
			//p.RPG = GetStatistic(s, ref count, ref end);
			//p.APG = GetStatistic(s, ref count, ref end);
			//p.SPG = GetStatistic(s, ref count, ref end);
			//p.BPG = GetStatistic(s, ref count, ref end);
			//p.TPG = GetStatistic(s, ref count, ref end);
			//p.FGP = GetStatistic(s, ref count, ref end);
			//p.FTP = GetStatistic(s, ref count, ref end);
			//p.P3P = GetStatistic(s, ref count, ref end);
			return p;
		}

		private static BasketballPlayer GetPlayerStats(BasketballTeam t, string s, ref int count, ref int end)
		{
			count = s.IndexOf("a href=", count + 11) + 8;
			count = s.IndexOf("\">", count) + 2;
			end = s.IndexOf("</a>", count);
			BasketballPlayer p = t.Players[s.Substring(count, end - count)];
			//p.MIN_T = (int)GetStatistic(s, ref count, ref end);
			//p.FGM = (int)GetStatistic(s, ref count, ref end);
			//p.FGA = (int)GetStatistic(s, ref count, ref end);
			//p.FTM = (int)GetStatistic(s, ref count, ref end);
			//p.FTA = (int)GetStatistic(s, ref count, ref end);
			//p.M3P = (int)GetStatistic(s, ref count, ref end);
			//p.A3P = (int)GetStatistic(s, ref count, ref end);
			//p.PTS = (int)GetStatistic(s, ref count, ref end);
			//p.OFFR = (int)GetStatistic(s, ref count, ref end);
			//p.DEFR = (int)GetStatistic(s, ref count, ref end);
			//p.REB = (int)GetStatistic(s, ref count, ref end);
			//p.AST = (int)GetStatistic(s, ref count, ref end);
			//p.TO = (int)GetStatistic(s, ref count, ref end);
			//p.STL = (int)GetStatistic(s, ref count, ref end);
			//p.BLK = (int)GetStatistic(s, ref count, ref end);
			return p;
		}

		private static double GetStatistic(string s, ref int count, ref int end)
		{
			count = s.IndexOf("<td align=\"right\"", end);
			count = s.IndexOf("\">", count) + 2;
			end = s.IndexOf("</td>", count);
			return double.Parse(s.Substring(count, end - count));
		}

		private static void GetPlayerInfo(BasketballTeam t, string s, ref int count, ref int end)
		{
			count = s.IndexOf("a href=", count + 11) + 8;
			count = s.IndexOf("\">", count) + 2;
			end = s.IndexOf("</a>", count);
			BasketballPlayer p = t.Players[s.Substring(count, end - count)];
			if (p != null)
			{
				count = s.IndexOf("<td>", end) + 4;
				end = s.IndexOf("</td>", count);
				p.Position = char.Parse(s.Substring(count, 1)).ToString();
				
				count = s.IndexOf("<td>", end) + 4;
				end = s.IndexOf("</td>", count);
				int feet = (int)(s[count] - '0');
				if (feet < 0)
					feet = 6;
				int inches = 0;
				if(!int.TryParse(s.Substring(count + 2, end - count - 2), out inches))
				{
					inches = 0;
				}
				p.Height = 12 * feet + inches;
			}
		}

	}
}
