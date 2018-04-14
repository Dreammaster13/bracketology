using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOTBALL
{
    public class BracketMatchup
    {
        public BasketballTeam Team1, Team2, Winner, Loser;
        public BracketMatchup PrevRound1, PrevRound2, NextRound;

        public Simulation Simulation;

        public int Team1Wins, Team2Wins;

        public int X = 0, Y = 0;

        public BracketMatchup()
        {

        }

        public BracketMatchup(BasketballTeam t1, BasketballTeam t2) {
            Team1 = t1;
            Team2 = t2;
        }

        public BracketMatchup(BasketballTeam t1, BasketballTeam t2, BracketMatchup p1, BracketMatchup p2) {
            Team1 = t1;
            Team2 = t2;
            PrevRound1 = p1;
            PrevRound2 = p2;
            if (PrevRound1 != null)
                PrevRound1.NextRound = this;
            if (PrevRound2 != null)
                PrevRound2.NextRound = this;
        }

        public void RunMatchup()
        {
            if(PrevRound1 != null)
            {
                PrevRound1.RunMatchup();
                Team1 = PrevRound1.Winner;
            }

            if (PrevRound2 != null)
            {
                PrevRound2.RunMatchup();
                Team2 = PrevRound2.Winner;
            }

            int numSims = 21;
            Simulation = new Simulation(this.Team1, this.Team2);
            Simulation.SimulationCompleted += Simulation_SimulationCompleted;
            Simulation.StartSimulation(numSims);
            int numWins = 0;
            for(int k=0;k<numSims;k++)
            {
                if (Simulation.team1.Outcomes[k].Win)
                    numWins++;
            }

            Team1Wins = numWins;
            Team2Wins = numSims - numWins;

            if(numWins > 0 && numSims / numWins < 2)
            {
                this.Winner = Team1;
                this.Loser = Team2;
            }
            else
            {
                this.Winner = Team2;
                this.Loser = Team1;
            }

        }

        private void Simulation_SimulationCompleted(object sender, SimulationCompletedEventArgs e)
        {
        }
    }

    public class Bracket
    {
        public List<BracketMatchup> Matchups;
        public Bracket()
        {
            Matchups = new List<BracketMatchup>();
        }

        public BracketMatchup this[int index] { get { return Matchups[index]; } }

        public void Add(BracketMatchup b) { Matchups.Add(b); }
    }

    public class NcaaBracket : Bracket
    {
        public int Padding = 6;
        public System.Drawing.Size RectangleSize = new System.Drawing.Size(125,40);

        public NcaaBracket()
        {
            Initialize();
        }

        public void RunBracketMatchup()
        {
           Matchups[62].RunMatchup();
        }

        public void Initialize()
        {
            int i;
            int x = Padding, y = Padding;
            for (i = 0; i < 32; i++)
            {
                BracketMatchup bm = new BracketMatchup();
                bm.X = x; bm.Y = y;
                Matchups.Add(bm);
                y += RectangleSize.Height + Padding;
                if(i == 15)
                {
                    x += 8 * (Padding + RectangleSize.Width);
                    y = Padding;
                }
            }
            x = Padding + Padding + RectangleSize.Width;
            y = Padding + (Padding+ RectangleSize.Height) / 2;
            for(i=0;i<16;i++)
            {
                BracketMatchup bm = new BracketMatchup();
                bm.X = x; bm.Y = y;
                Matchups.Add(bm);
                Matchups[2 * i].NextRound = bm;
                Matchups[2 * i + 1].NextRound = bm;
                bm.PrevRound1 = Matchups[2 * i];
                bm.PrevRound2 = Matchups[2 * i + 1];
                y += 2 * (RectangleSize.Height + Padding);
                if(i==7)
                {
                    x += 6 * (Padding + RectangleSize.Width);
                    y = Padding + (Padding + RectangleSize.Height) / 2;
                }
            }
            x = Padding + 2 * (Padding + RectangleSize.Width);
            y = Padding + 3* (Padding + RectangleSize.Height) / 2;
            for (i = 0; i < 8; i++)
            {
                BracketMatchup bm = new BracketMatchup();
                bm.X = x; bm.Y = y;
                Matchups.Add(bm);
                Matchups[2 * i + 32].NextRound = bm;
                Matchups[2 * i + 33].NextRound = bm;
                bm.PrevRound1 = Matchups[2 * i + 32];
                bm.PrevRound2 = Matchups[2 * i + 33];
                y += 4 * (RectangleSize.Height + Padding);
                if (i == 3)
                {
                    x += 4 * (Padding + RectangleSize.Width);
                    y = Padding + 3*(Padding + RectangleSize.Height) / 2;
                }
            }

            x = Padding + 3 * (Padding + RectangleSize.Width);
            y = Padding + 7 * (Padding + RectangleSize.Height) / 2;
            for (i = 0; i < 4; i++)
            {
                BracketMatchup bm = new BracketMatchup();
                bm.X = x; bm.Y = y;
                Matchups.Add(bm);
                Matchups[2 * i + 48].NextRound = bm;
                Matchups[2 * i + 49].NextRound = bm;
                bm.PrevRound1 = Matchups[2 * i + 48];
                bm.PrevRound2 = Matchups[2 * i + 49];

                y += 8 * (RectangleSize.Height + Padding);
                if (i == 1)
                {
                    x += 2 * (Padding + RectangleSize.Width);
                    y = Padding + 7 * (Padding + RectangleSize.Height) / 2;
                }
            }
            x = Padding + 4 * (Padding + RectangleSize.Width);
            y = Padding + 7 * (Padding + RectangleSize.Height) / 2;
            for (i = 0; i < 2; i++)
            {
                BracketMatchup bm = new BracketMatchup();
                bm.X = x; bm.Y = y;
                Matchups.Add(bm);
                Matchups[2 * i + 56].NextRound = bm;
                Matchups[2 * i + 57].NextRound = bm;
                bm.PrevRound1 = Matchups[2 * i + 56];
                bm.PrevRound2 = Matchups[2 * i + 57];
                y += 8 * (Padding + RectangleSize.Height);
            }
            y = 15 * (Padding + RectangleSize.Height)/2;
            {
                BracketMatchup bm = new BracketMatchup();
                bm.X = x; bm.Y = y;
                Matchups.Add(bm);
                Matchups[60].NextRound = bm;
                Matchups[61].NextRound = bm;
                bm.PrevRound1 = Matchups[60];
                bm.PrevRound2 = Matchups[61];
            }
        }
    }
}
