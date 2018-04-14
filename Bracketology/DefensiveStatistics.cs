using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOTBALL
{
    public static class DefensiveStatistics
    {
        public static double PointsAllowedPerGame(this BasketballTeam t)
        {
                double papg = 0.0;
                foreach (Matchup m in t.Matchups)
                {
                    papg += m.OppScore;
                }

                return papg / t.Matchups.Count;
        }

        public static double[] PointsAllowedByGame(this BasketballTeam t)
        {
            double[] pts = new double[t.Matchups.Count];
            for (int i = 0; i < t.Matchups.Count; i++)
                pts[i] = t.Matchups[i].OppScore;

            return pts;
        }

        public static double OpponentPointsPerGame(this BasketballTeam t) { return t.OpponentPointsPerGameByGame().Average(); }
        public static double[] OpponentPointsPerGameByGame(this BasketballTeam t)
        {
            double[] ofgp = new double[t.Matchups.Count];

            for (int i = 0; i < t.Matchups.Count; i++)
            {
                BasketballTeam opp = t.Teams[t.Matchups[i].Opponent];
                if (opp != null)
                    ofgp[i] = opp.PointsPerGame();
            }

            return ofgp;
        }

        public static double OpponentFieldGoalPercentage(this BasketballTeam t) { return t.OpponentFieldGoalPercentageByGame().Average(); }
        public static double[] OpponentFieldGoalPercentageByGame(this BasketballTeam t)
        {
            double[] ofgp = new double[t.Matchups.Count];

            for(int i=0;i<t.Matchups.Count;i++)
            {
                BasketballTeam opp;
                Matchup oppMatch = t.GetOpposingMatchup(i, out opp);
                if(opp!=null && oppMatch != null)
                       ofgp[i] = opp.FieldGoalPercentageAgainstOpponent(oppMatch);
            }

            return ofgp;
        }

        public static double OpponentFreeThrowPercentage(this BasketballTeam t) { return t.OpponentFreeThrowPercentageByGame().Average(); }
        public static double[] OpponentFreeThrowPercentageByGame(this BasketballTeam t)
        {
            double[] ofgp = new double[t.Matchups.Count];

            for (int i = 0; i < t.Matchups.Count; i++)
            {
                BasketballTeam opp;
                Matchup oppMatch = t.GetOpposingMatchup(i, out opp);
                if (opp != null && oppMatch != null)
                    ofgp[i] = opp.FreeThrowPercentageAgainstOpponent(oppMatch);
            }

            return ofgp;
        }

        public static double OpponentThreePointPercentage(this BasketballTeam t) { return t.OpponentThreePointPercentageByGame().Average(); }
        public static double[] OpponentThreePointPercentageByGame(this BasketballTeam t)
        {
            double[] ofgp = new double[t.Matchups.Count];

            for (int i = 0; i < t.Matchups.Count; i++)
            {
                BasketballTeam opp;
                Matchup oppMatch = t.GetOpposingMatchup(i, out opp);
                if (opp != null && oppMatch != null)
                    ofgp[i] = opp.ThreePointPercentageAgainstOpponent(oppMatch);
            }

            return ofgp;
        }

        public static double OpponentFieldGoalPercentageRatio(this BasketballTeam t) { return t.OpponentFieldGoalPercentageRatioByGame().Average(); }
        public static double[] OpponentFieldGoalPercentageRatioByGame(this BasketballTeam t)
        {
            double[] ofgp = new double[t.Matchups.Count];

            for (int i = 0; i < t.Matchups.Count; i++)
            {
                BasketballTeam opp;
                Matchup oppMatch = t.GetOpposingMatchup(i, out opp);
                if (opp != null && oppMatch != null)
                    ofgp[i] = opp.FieldGoalPercentageAgainstOpponent(oppMatch) / opp.FieldGoalPercentage();
            }

            return ofgp;
        }

        public static double OpponentFreeThrowPercentageRatio(this BasketballTeam t) { return t.OpponentFreeThrowPercentageRatioByGame().Average(); }
        public static double[] OpponentFreeThrowPercentageRatioByGame(this BasketballTeam t)
        {
            double[] ofgp = new double[t.Matchups.Count];

            for (int i = 0; i < t.Matchups.Count; i++)
            {
                BasketballTeam opp;
                Matchup oppMatch = t.GetOpposingMatchup(i, out opp);
                if (opp != null && oppMatch != null)
                    ofgp[i] = opp.FreeThrowPercentageAgainstOpponent(oppMatch) / opp.FreeThrowPercentage();
            }

            return ofgp;
        }

        public static double OpponentThreePointPercentageRatio(this BasketballTeam t) { return t.OpponentThreePointPercentageRatioByGame().Average(); }
        public static double[] OpponentThreePointPercentageRatioByGame(this BasketballTeam t)
        {
            double[] ofgp = new double[t.Matchups.Count];

            for (int i = 0; i < t.Matchups.Count; i++)
            {
                BasketballTeam opp;
                Matchup oppMatch = t.GetOpposingMatchup(i, out opp);
                if (opp != null && oppMatch != null)
                    ofgp[i] = opp.ThreePointPercentageAgainstOpponent(oppMatch) / opp.ThreePointPercentage();
            }

            return ofgp;
        }

        public static double[] OpponentFieldGoalsTakenByGame(this BasketballTeam t)
        {
            double[] ofgp = new double[t.Matchups.Count];

            for (int i = 0; i < t.Matchups.Count; i++)
            {
                BasketballTeam opp;
                Matchup oppMatch = t.GetOpposingMatchup(i, out opp);
                if (opp != null && oppMatch != null)
                {
                    foreach (BasketballPerformance p in oppMatch.Performances)
                    {
                        ofgp[i] += p.FieldGoalsAttempted;
                    }
                }
            }

            return ofgp;
        }

        public static double[] OpponentThreePointsTakenByGame(this BasketballTeam t)
        {
            double[] ofgp = new double[t.Matchups.Count];

            for (int i = 0; i < t.Matchups.Count; i++)
            {
                BasketballTeam opp;
                Matchup oppMatch = t.GetOpposingMatchup(i, out opp);
                if (opp != null && oppMatch != null)
                {
                    foreach (BasketballPerformance p in oppMatch.Performances)
                    {
                        ofgp[i] += p.ThreePointersAttempted;
                    }
                }
            }

            return ofgp;
        }

        public static double[] OpponentAssistsByGame(this BasketballTeam t)
        {
            double[] ofgp = new double[t.Matchups.Count];

            for (int i = 0; i < t.Matchups.Count; i++)
            {
                BasketballTeam opp;
                Matchup oppMatch = t.GetOpposingMatchup(i, out opp);
                if (opp != null && oppMatch != null)
                {
                    foreach (BasketballPerformance p in oppMatch.Performances)
                    {
                        ofgp[i] += p.Assists;
                    }
                }
            }

            return ofgp;
        }

        public static double[] OpponentOffensiveReboundsByGame(this BasketballTeam t)
        {
            double[] ofgp = new double[t.Matchups.Count];

            for (int i = 0; i < t.Matchups.Count; i++)
            {
                BasketballTeam opp;
                Matchup oppMatch = t.GetOpposingMatchup(i, out opp);
                if (opp != null && oppMatch != null)
                {
                    foreach(BasketballPerformance p in oppMatch.Performances)
                    {
                        ofgp[i] += p.OffensiveRebounds;
                    }
                }
            }

            return ofgp;
        }

        public static double[] OpponentDefensiveReboundsByGame(this BasketballTeam t)
        {
            double[] ofgp = new double[t.Matchups.Count];

            for (int i = 0; i < t.Matchups.Count; i++)
            {
                BasketballTeam opp;
                Matchup oppMatch = t.GetOpposingMatchup(i, out opp);
                if (opp != null && oppMatch != null)
                {
                    foreach (BasketballPerformance p in oppMatch.Performances)
                    {
                        ofgp[i] += p.DefensiveRebounds;
                    }
                }
            }

            return ofgp;
        }

        public static double[] OpponentStealsByGame(this BasketballTeam t)
        {
            double[] ofgp = new double[t.Matchups.Count];

            for (int i = 0; i < t.Matchups.Count; i++)
            {
                BasketballTeam opp;
                Matchup oppMatch = t.GetOpposingMatchup(i, out opp);
                if (opp != null && oppMatch != null)
                {
                    foreach (BasketballPerformance p in oppMatch.Performances)
                    {
                        ofgp[i] += p.Steals;
                    }
                }
            }

            return ofgp;
        }

        public static double[] OpponentBlocksByGame(this BasketballTeam t)
        {
            double[] ofgp = new double[t.Matchups.Count];

            for (int i = 0; i < t.Matchups.Count; i++)
            {
                BasketballTeam opp;
                Matchup oppMatch = t.GetOpposingMatchup(i, out opp);
                if (opp != null && oppMatch != null)
                {
                    foreach (BasketballPerformance p in oppMatch.Performances)
                    {
                        ofgp[i] += p.DefensiveRebounds;
                    }
                }
            }

            return ofgp;
        }

        public static double[] OpponentFoulsByGame(this BasketballTeam t)
        {
            double[] ofgp = new double[t.Matchups.Count];

            for (int i = 0; i < t.Matchups.Count; i++)
            {
                BasketballTeam opp;
                Matchup oppMatch = t.GetOpposingMatchup(i, out opp);
                if (opp != null && oppMatch != null)
                {
                    foreach (BasketballPerformance p in oppMatch.Performances)
                    {
                        ofgp[i] += p.PersonalFouls;
                    }
                }
            }

            return ofgp;
        }

        public static double DefensivePpgRatioAverage(this BasketballTeam t) { return t.DefensivePpgRatio().Average(); }
        public static double[] DefensivePpgRatio(this BasketballTeam t)
        {
            double[] data = new double[t.Matchups.Count];
            for (int k = 0; k < data.Length; k++)
            {
                BasketballTeam opp = t.Teams[t.Matchups[k].Opponent];
                if (opp == null)
                    data[k] = 1.0;
                else
                    data[k] = t.Matchups[k].OppScore / opp.PointsPerGame();
            }

            return data;
        }

        public static double TurnoversPerGame(this BasketballTeam t)
        {
                double to = 0.0;
                foreach (BasketballPlayer p in t.Players)
                {
                    to += p.TO;
                }

                return to / t.Matchups.Count;
        }

        public static double[] TurnoversByGame(this BasketballTeam t)
        {
            double[] to = new double[t.Matchups.Count];
            for(int i=0;i<to.Length;i++)
            {
                double topg = 0;
                foreach (BasketballPerformance p in t.Matchups[i].Performances)
                    topg += p.Turnovers;
                to[i] = topg;
            }

            return to;
        }
    }
}
