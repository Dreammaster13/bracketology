using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOTBALL
{
	public static class Teams
	{
        //public static void GetNflTeams(TeamList teams)
        //{

        //    HtmlIterator teamPage = new HtmlIterator(WebUtility.GetNflURL().ToString());
        //    while (teamPage.GetNext("<h5 ><a href=\"http://www.espn.com/nfl/team/_/name/"))
        //    {
        //        Team te = new Team();
        //        te.teamName = teamPage.GetNextTagText("a");
        //        teamPage.GetNext("<h5 ><a href=\"/nfl/team/roster/_/name/");
        //        te.teamURL = "http://www.espn.com" + teamPage.GetNextAttributeValue("href");
        //        teams.Add(te);
        //        PlayerList playerList = new PlayerList();
        //        HtmlIterator t = new HtmlIterator(te.teamURL);
        //        if (!t.GetNext("COLLEGE")) continue;
        //        int endOfTable = t.HTML.IndexOf("</table>", t.StartIndex);
        //        while (t.StartIndex < endOfTable && t.StartIndex >= 0)
        //        {
        //            FootballPlayer player = new FootballPlayer();
        //            int dummy;
        //            if (int.TryParse(t.GetNextTagText("td"), out dummy))
        //                player.Number = dummy;
        //            player.Name = t.GetNextTagText("a");
        //            player.Position = t.GetNextTagText("td");
        //            if (int.TryParse(t.GetNextTagText("td"), out dummy))
        //                player.Age = dummy;
        //            player.Height = 0;
        //            string[] height = t.GetNextTagText("td").Split('-');
        //            for (int i = 0; i < height.Length; i++)
        //            {
        //                if (int.TryParse(height[i], out dummy))
        //                    player.Height += (12 * dummy) / (11 * i + 1);
        //            }
        //            if (int.TryParse(t.GetNextTagText("td"), out dummy))
        //                player.Weight = dummy;
        //            if (int.TryParse(t.GetNextTagText("td"), out dummy))
        //                player.Experience = dummy;
        //            else player.Experience = 0; // Rookie
        //            player.College = t.GetNextTagText("td");
        //            te.Players.Add(player);
        //        }
        //    }
        //}

		public static void GetNcaabTeams(TeamList teams)
		{
            HtmlIterator teamPage = new HtmlIterator(WebUtility.GetURL().ToString());
            while(teamPage.GetNext("<tr><td class='nowrap'"))
            {
                BasketballTeam te = new BasketballTeam();
                te.teamName = teamPage.GetNextAttributeValue("rel");
                te.teamURL = "http://basketball.realgm.com" + teamPage.GetNextAttributeValue("href");
                teams.Add(te);
                BasketballPlayerList playerList = new BasketballPlayerList();
                HtmlIterator t = new HtmlIterator(te.teamURL + "rosters/");
                if (!t.GetNext("High School/Prep School")) continue;
                int endOfTable = t.HTML.IndexOf("</tbody>", t.StartIndex);
                while (t.StartIndex < endOfTable && t.StartIndex >= 0)
                {
                    BasketballPlayer player = new BasketballPlayer();
                    int dummy;
                    if (int.TryParse(t.GetNextTagText("td"), out dummy))
                        player.Number = dummy;
                    else continue;
                    player.Name = t.GetNextTagText("a");
                    player.Class = t.GetNextTagText("td");
                    player.Position = t.GetNextTagText("td");
                    player.Height = 0;
                    string[] height = t.GetNextTagText("td").Split('-');
                    for (int i = 0; i < height.Length; i++)
                    {
                        if(int.TryParse(height[i], out dummy))
                        player.Height += (12 * dummy) / (11 * i + 1);
                    }
                    if (int.TryParse(t.GetNextTagText("td"), out dummy))
                        player.Weight = dummy;
                    player.BirthDate = t.GetNextTagText("td");
                    player.BirthCity = t.GetNextTagText("td");
                    player.Nationality = t.GetNextTagText("td");
                    player.HighSchool = t.GetNextTagText("td");
                    te.Players.Add(player);
                }
            }
		}
	}
}
