using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOTBALL
{
	static class Schedule
	{
		private static int fetch = 0;
		private static TeamList teams;
		public static void GetTeamSchedule(TeamList tl)
		{
			fetch = 0;
			teams = tl;
			foreach (Team t in teams)
			{
               // System.Threading.Thread thr = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(_getncaabsched));
               // thr.Start(t);
               _getncaabsched((object)t);
			}

			while (fetch < teams.Count) ;
		}

        //private static void _getnflsched(object o)
        //{
        //    Team team = (Team)o;
        //    // HtmlIterator h_team = new HtmlIterator(((Team)o).teamURL), h;
        //    //  HtmlIterator h = new HtmlIterator("http://espn.go.com/college-football/team/schedule/"+((Team)o).teamURL.Substring(((Team)o).teamURL.IndexOf('_')));
        //    HtmlIterator h = new HtmlIterator(((FootballTeam)o).ScheduleUrl);
        //    while (h.GetNext("<li class=\"game-status\">"))
        //    {
        //        Matchup m = new Matchup();
        //        m.Home = !h.GetNextTagText("li").Contains("@");
        //        h.GetNext("<li class=\"team - name\"><a href=\"");
        //        m.Opponent = h.GetNextAttributeValue("href");
        //        h.GetNext("<li class=\"score\"><a href=\"");
        //        m.MatchupURL = "http:" + h.GetNextAttributeValue("href");
        //        HtmlIterator g = new HtmlIterator(m.MatchupURL);

        //        if (!g.GetNext("<h2>" + team.teamName)) continue;
        //        g.GetNext("<tbody");

        //        int endOfTable = g.HTML.IndexOf("/tbody", g.StartIndex);
        //        while (g.StartIndex < endOfTable)
        //        {
        //            string name = g.GetNextTagText("a");
        //            FootballPlayer p;
        //            if ((p = (FootballPlayer)team.Players[name]) != null)
        //            {
        //                int dummy;
        //                double doubleDummy;
        //                FootballPerformance perf = new FootballPerformance();
        //                perf.Status = g.GetNextTagText("td");
        //                g.GetNextTagText("td");
        //                if (double.TryParse(g.GetNextAttributeValue("rel"), out doubleDummy))
        //                    perf.Minutes = doubleDummy;
        //                string[] fg = g.GetNextTagText("td").Split('-');
        //                if (fg != null && fg.Length > 0)
        //                {
        //                    if (int.TryParse(fg[0], out dummy))
        //                        perf.FieldGoalsMade = dummy;
        //                    if (fg.Length > 1 && int.TryParse(fg[1], out dummy))
        //                        perf.FieldGoalsAttempted = dummy;
        //                }
        //                fg = g.GetNextTagText("td").Split('-');
        //                if (fg != null && fg.Length > 0)
        //                {
        //                    if (int.TryParse(fg[0], out dummy))
        //                        perf.ThreePointersMade = dummy;
        //                    if (fg.Length > 1 && int.TryParse(fg[1], out dummy))
        //                        perf.ThreePointersAttempted = dummy;
        //                }
        //                fg = g.GetNextTagText("td").Split('-');
        //                if (fg != null && fg.Length > 0)
        //                {
        //                    if (int.TryParse(fg[0], out dummy))
        //                        perf.FreeThrowsMade = dummy;
        //                    if (fg.Length > 1 && int.TryParse(fg[1], out dummy))
        //                        perf.FreeThrowsAttempted = dummy;
        //                }
        //                if (double.TryParse(g.GetNextAttributeValue("rel"), out doubleDummy))
        //                    perf.FIC = doubleDummy;
        //                if (double.TryParse(g.GetNextAttributeValue("rel"), out doubleDummy))
        //                    perf.OffensiveRebounds = (int)doubleDummy;
        //                if (int.TryParse(g.GetNextAttributeValue("rel"), out dummy))
        //                    perf.DefensiveRebounds = dummy;
        //                g.GetNextAttributeValue("rel");
        //                if (int.TryParse(g.GetNextAttributeValue("rel"), out dummy))
        //                    perf.Assists = dummy;
        //                if (int.TryParse(g.GetNextAttributeValue("rel"), out dummy))
        //                    perf.PersonalFouls = dummy;
        //                if (int.TryParse(g.GetNextAttributeValue("rel"), out dummy))
        //                    perf.Steals = dummy;
        //                if (int.TryParse(g.GetNextAttributeValue("rel"), out dummy))
        //                    perf.Turnovers = dummy;
        //                if (int.TryParse(g.GetNextAttributeValue("rel"), out dummy))
        //                    perf.Blocks = dummy;
        //                if (int.TryParse(g.GetNextAttributeValue("rel"), out dummy))
        //                    perf.Points = dummy;
        //                perf.Matchup = m;
        //                perf.Player = p;
        //                p.Performances.Add(perf);
        //            }
        //        }

        //    }
        //    System.Threading.Interlocked.Increment(ref fetch);
        //}

        private static void _getncaabsched(object o)
		{
            BasketballTeam team = (BasketballTeam)o;
            // HtmlIterator h_team = new HtmlIterator(((Team)o).teamURL), h;
            //  HtmlIterator h = new HtmlIterator("http://espn.go.com/college-football/team/schedule/"+((Team)o).teamURL.Substring(((Team)o).teamURL.IndexOf('_')));
            HtmlIterator h = new HtmlIterator(((BasketballTeam)o).teamURL + "Schedule");
            while (h.GetNext("data-th=\"Opponent\""))
            {
                Matchup m = new Matchup();
                m.Home = !h.GetNextTagText("div").Contains("@");
                h.GetNext("<img");
                h.GetNext("</div>");
                h.ExtendToBeginningOfNext("</td>");
                if (h.Selection.Contains("<a href"))
                {
                    h.EndIndex = h.StartIndex;
                    m.Opponent = h.GetNextTagText("a");
                }
                else
                {
                    h.StartIndex += 6;
                    m.Opponent = h.Selection;
                }
                bool win = false;
                int awayScore = 0, homeScore = 0;
                h.GetNext("data-th=\"Result\"");
                string gameUrl = h.GetNextAttributeValue("href");
                h.GetPrevious("Result");
                string[] GameResult = h.GetNextTagText("a").RemoveWhiteSpace().Split(',','-');
                if(GameResult.Length >= 3)
                {
                    win = GameResult[0].Contains("W");
                    int.TryParse(GameResult[1], out homeScore);
                    int.TryParse(GameResult[2], out awayScore);
                    if (m.Home)
                    {
                        //m.Opponent = away_team;
                        m.Win = homeScore > awayScore;
                        m.TeamScore = homeScore;
                        m.OppScore = awayScore;
                        // m.MatchupURL = h_team.Selection;
                    }
                    else
                    {
                        //m.Opponent = home_team;
                        m.Win = homeScore < awayScore;
                        m.TeamScore = awayScore;
                        m.OppScore = homeScore;
                        // m.MatchupURL = h_team.Selection;
                    }
                    m.ID = m.Opponent + m.TeamScore.ToString() + m.OppScore.ToString();
                    team.Matchups.Add(m);
                }
                HtmlIterator g = new HtmlIterator("http://basketball.realgm.com" + gameUrl);

                if (!g.GetNext("<h2>" + team.teamName)) continue;
                g.GetNext("<tbody");
                
                int endOfTable = g.HTML.IndexOf("/tbody", g.StartIndex);
                while (g.StartIndex < endOfTable)
                {
                    string name = g.GetNextTagText("a");
                    BasketballPlayer p;
                    if ((p = (BasketballPlayer)team.Players[name]) != null)
                    {
                        int dummy;
                        double doubleDummy;
                        BasketballPerformance perf = new BasketballPerformance();
                        perf.Status = g.GetNextTagText("td");
                        g.GetNextTagText("td");
                        if (double.TryParse(g.GetNextAttributeValue("rel"), out doubleDummy))
                            perf.Minutes = doubleDummy;
                        string[] fg = g.GetNextTagText("td").Split('-');
                        if (fg != null && fg.Length > 0)
                        {
                            if (int.TryParse(fg[0], out dummy))
                                perf.FieldGoalsMade = dummy;
                            if (fg.Length > 1 && int.TryParse(fg[1], out dummy))
                                perf.FieldGoalsAttempted = dummy;
                        }
                        fg = g.GetNextTagText("td").Split('-');
                        if (fg != null && fg.Length > 0)
                        {
                            if (int.TryParse(fg[0], out dummy))
                                perf.ThreePointersMade = dummy;
                            if (fg.Length > 1 && int.TryParse(fg[1], out dummy))
                                perf.ThreePointersAttempted = dummy;
                        }
                        fg = g.GetNextTagText("td").Split('-');
                        if (fg != null && fg.Length > 0)
                        {
                            if (int.TryParse(fg[0], out dummy))
                                perf.FreeThrowsMade = dummy;
                            if (fg.Length > 1 && int.TryParse(fg[1], out dummy))
                                perf.FreeThrowsAttempted = dummy;
                        }
                        if (double.TryParse(g.GetNextAttributeValue("rel"), out doubleDummy))
                            perf.FIC = doubleDummy;
                        if (double.TryParse(g.GetNextAttributeValue("rel"), out doubleDummy))
                            perf.OffensiveRebounds = (int)doubleDummy;
                        if (int.TryParse(g.GetNextAttributeValue("rel"), out dummy))
                            perf.DefensiveRebounds = dummy;
                        g.GetNextAttributeValue("rel");
                        if (int.TryParse(g.GetNextAttributeValue("rel"), out dummy))
                            perf.Assists = dummy;
                        if (int.TryParse(g.GetNextAttributeValue("rel"), out dummy))
                            perf.PersonalFouls = dummy;
                        if (int.TryParse(g.GetNextAttributeValue("rel"), out dummy))
                            perf.Steals = dummy;
                        if (int.TryParse(g.GetNextAttributeValue("rel"), out dummy))
                            perf.Turnovers = dummy;
                        if (int.TryParse(g.GetNextAttributeValue("rel"), out dummy))
                            perf.Blocks = dummy;
                        if (int.TryParse(g.GetNextAttributeValue("rel"), out dummy))
                            perf.Points = dummy;
                        perf.Matchup = m;
                        perf.Player = p;
                        p.Performances.Add(perf);
                    }
                }

            }
            System.Threading.Interlocked.Increment(ref fetch);
		}
	}
}
