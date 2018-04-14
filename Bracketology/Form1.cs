using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using AnimatedControls;

namespace FOOTBALL
{
	public partial class Form1 : Form
	{
        
		private TeamList teamURLs;
		public Form1()
		{
			InitializeComponent();
            lineGraphMinutes.Maximum = 48;
            lineGraphFieldGoal.Maximum = 100;
            lineGraphFreeThrow.Maximum = 100;
            lineGraphThreePoint.Maximum = 100;
            System.Threading.Thread _t = new System.Threading.Thread(get_data);
            _t.Start();
		}

		private delegate void Updater(string s);
		private void StatusUpdate(string s)
		{
			if(InvokeRequired)
			{
				this.Invoke(new Updater(StatusUpdate), s);
			}
			else
			{
				label3.Text = s;
			}
		}

		private void EnableControls()
		{
			if (InvokeRequired)
				this.Invoke(new MethodInvoker(EnableControls));
			else
			{
				foreach(Team te in teamURLs)
				{
					comboBox1.Items.Add(te.teamName);
                    comboBox2.Items.Add(te.teamName);
                    comboBox3.Items.Add(te.teamName);
                    comboBox4.Items.Add(te.teamName);
                    comboBox5.Items.Add(te.teamName);
				}
				comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                comboBox5.Enabled = true;
                listBox1.Enabled = true;
                listBox2.Enabled = true;
                listBox3.Enabled = true;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//Simulation sim = new Simulation(teamURLs[(string)comboBox1.SelectedItem], teamURLs[(string)comboBox2.SelectedItem]);
			//sim.SimulationCompleted += sim_SimulationCompleted;
			//sim.StartSimulation(1);
		}

		private delegate void SimComplete(object s, SimulationCompletedEventArgs e);

		void sim_SimulationCompleted(object sender, SimulationCompletedEventArgs e)
		{
			if(this.InvokeRequired)
			{
				this.Invoke(new SimComplete(sim_SimulationCompleted), sender, e);
			}
			else
			{
				TeamSimulationOutcome so = e.Team1Outcome.SimDetails.Outcomes[0];
			}
		}

		private void get_data()
        {
            bool downloadLatestData = true;

            StatusUpdate("Retrieving teams...");

            if (downloadLatestData)
            {
                teamURLs = new TeamList();
                Teams.GetNcaabTeams(teamURLs);
                StatusUpdate("Getting team schedules...");
                Schedule.GetTeamSchedule(teamURLs);
                StatusUpdate("Accessing player statistics...");
                Statistics.GetTeamStatistics(teamURLs);
            }
            else
            {
                teamURLs = TeamList.Deserialize("C:\\Users\\Dustin\\Desktop\\Teams.txt");
            }
            StatusUpdate("Determining team power rankings...");
            TeamRankings.GetTeamRawScores(teamURLs, 2.0, 2.0, 0.0);
            while (!TeamRankings.SortTeams(teamURLs))
            {
                TeamRankings.AdjustTeamScores(teamURLs);
            }

            double maxScore = teamURLs[0].Score;
            double minScore = teamURLs[teamURLs.Count - 1].Score;

            for (int k = 0; k < teamURLs.Count; k++)
            {
                teamURLs[k].Score -= minScore;
                teamURLs[k].Score /= (maxScore - minScore);
                teamURLs[k].Score++;
                teamURLs[k].Score /= 2;
                teamURLs[k].Score *= teamURLs[k].Score;
                //teamURLs[k].Score = Math.Log(teamURLs[k].Score, 2);
            }

            string[] ind = new string[] { "Virginia", "UMBC", "Creighton", "Kansas State", "Kentucky", "Davidson", "Arizona", "Buffalo",
                                    "Miami (FL)", "Loyola (IL)", "Tennessee", "Wright State", "Nevada", "Texas", "Cincinnati", "Georgia State",
                                    "Xavier", "Texas Southern", "Missouri", "Florida State", "Ohio State", "South Dakota State", "Gonzaga", "UNC Greensboro",
                                    "Houston", "San Diego State", "Michigan", "Montana", "Texas A&M", "Providence", "North Carolina", "Lipscomb",
                                    "Villanova", "Radford", "Virginia Tech", "Alabama", "West Virginia", "Murray State", "Wichita State", "Marshall",
                                    "Florida", "St. Bonaventure", "Texas Tech", "Stephen F. Austin", "Arkansas", "Butler", "Purdue", "Cal State Fullerton",
                                    "Kansas", "Pennsylvania", "Seton Hall", "NC State", "Clemson", "New Mexico State", "Auburn", "Charleston",
                                    "Texas Christian", "Syracuse", "Michigan State", "Bucknell", "Rhode Island", "Oklahoma", "Duke", "Iona" };
            for (int i = 0; i < 64; i++)
            {
                BasketballTeam t = teamURLs[ind[i]];
                bracketGraph1.Add(t);
            }

            bracketGraph1.Bracket.RunBracketMatchup();

            if (downloadLatestData)
            {
                TeamRankings.SortTeamsAve(teamURLs);
                StatusUpdate("");
                TeamList.Serialize(teamURLs, "C:\\Users\\Dustin\\Desktop\\Teams.txt");
            }
            else StatusUpdate("");

            EnableControls();
		}
    

		private void StatusLabel_Load(object sender, EventArgs e)
		{

		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			listBoxTeams.Items.Clear();
			BasketballTeam te = teamURLs[(string)comboBox1.SelectedItem];
			foreach (BasketballPlayer p in te.Players)
                if(p != null)
				    listBoxTeams.Items.Add(p.Name);
		}

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BasketballTeam te = teamURLs[(string)comboBox1.SelectedItem];
            BasketballPlayer p = te.Players[listBoxTeams.SelectedIndex];
            if(p != null && p.Performances.Count > 0)
            {
                double[] minutes = new double[p.Performances.Count];
                double[] points = new double[p.Performances.Count];
                double[] fgp = new double[p.Performances.Count];
                double[] ftp = new double[p.Performances.Count];
                double[] p3p = new double[p.Performances.Count];
                double[] reb = new double[p.Performances.Count];
                double[] offreb = new double[p.Performances.Count];
                double[] defreb = new double[p.Performances.Count];
                double[] ast = new double[p.Performances.Count];
                double[] stl = new double[p.Performances.Count];
                double[] blk = new double[p.Performances.Count];
                double[] to = new double[p.Performances.Count];
                for(int k=0;k<p.Performances.Count;k++)
                {
                    minutes[k] = p.Performances[k].Minutes;
                    points[k] = p.Performances[k].Points;
                    fgp[k] = p.Performances[k].FieldGoalPercentage;
                    ftp[k] = p.Performances[k].FreeThrowPercentage;
                    p3p[k] = p.Performances[k].ThreePointPercentage;
                    reb[k] = p.Performances[k].Rebounds;
                    offreb[k] = p.Performances[k].OffensiveRebounds;
                    defreb[k] = p.Performances[k].DefensiveRebounds;
                    ast[k] = p.Performances[k].Assists;
                    stl[k] = p.Performances[k].Steals;
                    blk[k] = p.Performances[k].Blocks;
                    to[k] = p.Performances[k].Turnovers;
                }

                lineGraphMinutes.FeedData(minutes);
                lineGraphPoint.FeedData(points);
                lineGraphFieldGoal.FeedData(fgp);
                lineGraphFreeThrow.FeedData(ftp);
                lineGraphThreePoint.FeedData(p3p);
                lineGraphRebound.FeedData(reb);
                lineGraphOffensiveRebound.FeedData(offreb);
                lineGraphDefensiveRebound.FeedData(defreb);
                lineGraphAssist.FeedData(ast);
                lineGraphSteal.FeedData(stl);
                lineGraphBlock.FeedData(blk);
                lineGraphTurnover.FeedData(to);
            }
        }

        private double[] GetTeamStatByGame(BasketballTeam t, string stat)
        {
            switch (stat)
            {
                case "Points Per Game":
                    return t.PointsPerGameByGame();
                case "Field Goal Percentage":
                    return t.FieldGoalPercentageByGame();
                case "Free Throw Percentage":
                    return t.FreeThrowPercentageByGame();
                case "Three Point Percentage":
                    return t.ThreePointPercentageByGame();
                case "Average Offensive PPG Ratio":
                    return t.PointsPerGameByGame();
                case "Points Allowed Per Game":
                    return t.PointsAllowedByGame();
                case "Opponent Field Goal Percentage":
                    return t.OpponentFieldGoalPercentageByGame();
                case "Opponent Free Throw Percentage":
                    return t.OpponentFreeThrowPercentageByGame();
                case "Opponent Three Point Percentage":
                    return t.OpponentThreePointPercentageByGame();
                case "Opponent Field Goal Percentage Ratio":
                    return t.OpponentFieldGoalPercentageRatioByGame();
                case "Opponent Free Throw Percentage Ratio":
                    return t.OpponentFreeThrowPercentageRatioByGame();
                case "Opponent Three Point Percentage Ratio":
                    return t.OpponentThreePointPercentageRatioByGame();
            }

            return new double[] { 0 };
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            barGraph1.Clear();
            foreach (BasketballTeam t in teamURLs)
            {
                if (t != null)
                {
                    double d = GetTeamStatByGame(t, (string)listBox1.SelectedItem).Average();
                    barGraph1.Add(t.teamName + ": " + d.ToString(), d);
                    barGraph1.Ascending = false;
                }
            }
            barGraph1.Feed();
            comboBox2_SelectedIndexChanged(sender, e);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex >= 0)
            {
                lineGraphTeamStats.Text = (string)(listBox1.SelectedItem);
                BasketballTeam t = teamURLs[comboBox2.SelectedIndex];
                if (t != null)
                {
                    lineGraphTeamStats.FeedData(GetTeamStatByGame(t, (string)listBox1.SelectedItem));
                }
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.tabControl1.Size = new Size(this.ClientSize.Width - 24, this.ClientSize.Height - 12);
            this.bracketGraph1.Size = new Size(this.ClientSize.Width - 44, this.ClientSize.Height - 50);

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox3.SelectedItem != null)
            {
                scatterPlot1.SelectedIndex = comboBox3.SelectedIndex;
                scatterPlot1.Invalidate();
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2_SelectedIndexChanged(sender, e);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null && listBox3.SelectedItem != null)
            {
                scatterPlot1.Clear();
                foreach (BasketballTeam t in teamURLs)
                {
                    scatterPlot1.Add(t.teamName, GetTeamStatByGame(t, (string)listBox2.SelectedItem).Average(), GetTeamStatByGame(t, (string)listBox3.SelectedItem).Average());
                }
                scatterPlot1.Text = (string)listBox2.SelectedItem + " vs. " + (string)listBox3.SelectedItem;
                scatterPlot1.Feed();
            }
        }

        private void lineGraphTeamStats_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem != null)
            {
                scatterPlot1.SelectedIndex2 = comboBox4.SelectedIndex;
                scatterPlot1.Invalidate();
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedItem != null)
            {
                scatterPlot2.Clear();
                BasketballTeam t = teamURLs[comboBox5.SelectedIndex];
                scatterPlot2.Add(t.teamName, 0, 0);
                foreach (Matchup m in t.Matchups)
                {
                    BasketballTeam opp = t.Teams[m.Opponent];
                    if (opp != null)
                        scatterPlot2.Add(t.teamName, m.TeamScore, opp.OpponentPointsPerGame());
                }
                scatterPlot2.Text = "Points vs. Points Allowed Per Game";
                scatterPlot2.Feed();
            }
        }
    }
}
