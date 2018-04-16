using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOTBALL
{
    public delegate int IntStatAccumulator(Performance p);
    public delegate double DoubleStatAccumulator(Performance p);
    public static class OffensiveStatistics
    {
        public static int StatSum(this IEnumerable<Performance> list, IntStatAccumulator isa)
        {
            return list.FieldFoldLeft<Performance, int>(0, (i, p) => { return i + isa(p); });
        }

        public static double StatSum(this IEnumerable<Performance> list, DoubleStatAccumulator dsa)
        {
            return list.FieldFoldLeft<Performance, double>(0, (i, p) => { return i + dsa(p); });
        }

        public static double[] WinsByGame(this BasketballTeam t)
        {
	    return t.Matchups.Map(m => m.TeamScore - m.OppScore > 0 ? 1 : 0);
        }

        public static double[] HomeGames(this BasketballTeam t)
        {
	    return t.Matchups.Map(m => m.Home ? 1 : 0);
        }

        public static double[] AwayGames(this BasketballTeam t)
        {
	    return t.Matchups.Map(m => m.Home ? 0 : 1);
        }

        public static double[] FieldGoalsTakenByGame(this BasketballTeam t)
        {
            double[] to = new double[t.Matchups.Count];
            for (int i = 0; i < to.Length; i++)
            {
                double topg = 0;
                foreach (BasketballPerformance p in t.Matchups[i].Performances)
                    topg += p.FieldGoalsAttempted;
                to[i] = topg;
            }

            return to;
        }

        public static double[] FieldGoalsMadeByGame(this BasketballTeam t)
        {
            double[] to = new double[t.Matchups.Count];
            for (int i = 0; i < to.Length; i++)
            {
                double topg = 0;
                foreach (BasketballPerformance p in t.Matchups[i].Performances)
                    topg += p.FieldGoalsMade;
                to[i] = topg;
            }

            return to;
        }

        public static double[] FreeThrowsTakenByGame(this BasketballTeam t)
        {
            double[] to = new double[t.Matchups.Count];
            for (int i = 0; i < to.Length; i++)
            {
                double topg = 0;
                foreach (BasketballPerformance p in t.Matchups[i].Performances)
                    topg += p.FreeThrowsAttempted;
                to[i] = topg;
            }

            return to;
        }

        public static double[] FreeThrowsMadeByGame(this BasketballTeam t)
        {
            double[] to = new double[t.Matchups.Count];
            for (int i = 0; i < to.Length; i++)
            {
                double topg = 0;
                foreach (BasketballPerformance p in t.Matchups[i].Performances)
                    topg += p.FreeThrowsMade;
                to[i] = topg;
            }

            return to;
        }

        public static double[] ThreePointersTakenByGame(this BasketballTeam t)
        {
            double[] to = new double[t.Matchups.Count];
            for (int i = 0; i < to.Length; i++)
            {
                double topg = 0;
                foreach (BasketballPerformance p in t.Matchups[i].Performances)
                    topg += p.ThreePointersAttempted;
                to[i] = topg;
            }

            return to;
        }

        public static double[] ThreePointersMadeByGame(this BasketballTeam t)
        {
            double[] to = new double[t.Matchups.Count];
            for (int i = 0; i < to.Length; i++)
            {
                double topg = 0;
                foreach (BasketballPerformance p in t.Matchups[i].Performances)
                    topg += p.ThreePointersMade;
                to[i] = topg;
            }

            return to;
        }

        public static double[] AssistsByGame(this BasketballTeam t)
        {
            double[] to = new double[t.Matchups.Count];
            for (int i = 0; i < to.Length; i++)
            {
                double topg = 0;
                foreach (BasketballPerformance p in t.Matchups[i].Performances)
                    topg += p.Assists;
                to[i] = topg;
            }

            return to;
        }

        public static double[] StealsByGame(this BasketballTeam t)
        {
            double[] to = new double[t.Matchups.Count];
            for (int i = 0; i < to.Length; i++)
            {
                double topg = 0;
                foreach (BasketballPerformance p in t.Matchups[i].Performances)
                    topg += p.Steals;
                to[i] = topg;
            }

            return to;
        }

        public static double[] BlocksByGame(this BasketballTeam t)
        {
            double[] to = new double[t.Matchups.Count];
            for (int i = 0; i < to.Length; i++)
            {
                double topg = 0;
                foreach (BasketballPerformance p in t.Matchups[i].Performances)
                    topg += p.Blocks;
                to[i] = topg;
            }

            return to;
        }

        public static double[] OffensiveReboundsByGame(this BasketballTeam t)
        {
            double[] to = new double[t.Matchups.Count];
            for (int i = 0; i < to.Length; i++)
            {
                double topg = 0;
                foreach (BasketballPerformance p in t.Matchups[i].Performances)
                    topg += p.OffensiveRebounds;
                to[i] = topg;
            }

            return to;

        }

        public static double[] DefensiveReboundsByGame(this BasketballTeam t)
        {
            double[] to = new double[t.Matchups.Count];
            for (int i = 0; i < to.Length; i++)
            {
                double topg = 0;
                foreach (BasketballPerformance p in t.Matchups[i].Performances)
                    topg += p.DefensiveRebounds;
                to[i] = topg;
            }

            return to;

        }

        public static double[] ThreePointTakenPercentageByGame(this BasketballTeam t)
        {
            return t.ThreePointersTakenByGame().Divide(t.FieldGoalsTakenByGame());
        }

        public static double[] BlockPercentageByGame(this BasketballTeam t)
        {
            return t.BlocksByGame().Divide(t.FieldGoalsTakenByGame());
        }

        public static double[] OffensiveReboundPercentageByGame(this BasketballTeam t)
        {
            double[] d = t.OffensiveReboundsByGame();
            return d.Divide(d.Add(t.OpponentDefensiveReboundsByGame()));
        }

        public static double[] DefensiveReboundPercentageByGame(this BasketballTeam t)
        {
            double[] d = t.DefensiveReboundsByGame();
            return d.Divide(d.Add(t.OpponentOffensiveReboundsByGame()));
        }

        public static double PointsPerGame(this BasketballTeam t) { return t.PointsPerGameByGame().Average(); }

        public static double[] PointsPerGameByGame(this BasketballTeam t)
        {
            double[] pts = new double[t.Matchups.Count];
            for (int i = 0; i < t.Matchups.Count; i++)
                pts[i] = t.Matchups[i].TeamScore;

            return pts;
        }

        public static double[] FieldGoalPercentageByGame(this BasketballTeam t)
        {
            double[] pts = new double[t.Matchups.Count];
            for (int i = 0; i < t.Matchups.Count; i++)
            {
                double fga = 0;
                foreach (BasketballPerformance p in t.Matchups[i].Performances)
                {
                    pts[i] += p.FieldGoalsMade;
                    fga += p.FieldGoalsAttempted;
                }
                if (fga > 0)
                    pts[i] /= fga;
                else pts[i] = 0;
            }
            return pts;
        }

        public static double[] FreeThrowPercentageByGame(this BasketballTeam t)
        {
            double[] pts = new double[t.Matchups.Count];
            for (int i = 0; i < t.Matchups.Count; i++)
            {
                double fga = 0;
                foreach (BasketballPerformance p in t.Matchups[i].Performances)
                {
                    pts[i] += p.FreeThrowsMade;
                    fga += p.FreeThrowsAttempted;
                }
                if (fga > 0)
                    pts[i] /= fga;
                else pts[i] = 0;
            }
            return pts;
        }

        public static double[] ThreePointPercentageByGame(this BasketballTeam t)
        {
            double[] pts = new double[t.Matchups.Count];
            for (int i = 0; i < t.Matchups.Count; i++)
            {
                double fga = 0;
                foreach (BasketballPerformance p in t.Matchups[i].Performances)
                {
                    pts[i] += p.ThreePointersMade;
                    fga += p.ThreePointersAttempted;
                }
                if (fga > 0)
                    pts[i] /= fga;
                else pts[i] = 0;
            }
            return pts;
        }

        public static double[] FoulsByGame(this BasketballTeam t)
        {
            double[] pts = new double[t.Matchups.Count];
            for (int i = 0; i < t.Matchups.Count; i++)
            {
                foreach (BasketballPerformance p in t.Matchups[i].Performances)
                {
                    pts[i] = p.PersonalFouls;
                }
            }
            return pts;
        }

        public static double FieldGoalPercentageAgainstOpponent(this BasketballTeam t, Matchup m)
        {
            double fgm = 0.0, fga = 0.0;
            foreach (BasketballPerformance p in m.Performances)
            {
                        fgm += p.FieldGoalsMade;
                        fga += p.FieldGoalsAttempted;
            }
            if (fgm == 0 || fga == 0) return 0;
            return fgm / fga;
        }

        public static double FreeThrowPercentageAgainstOpponent(this BasketballTeam t, Matchup m)
        {
            double fgm = 0.0, fga = 0.0;
            foreach (BasketballPerformance p in m.Performances)
            {
                fgm += p.FreeThrowsMade;
                fga += p.FreeThrowsAttempted;
            }
            if (fgm == 0 || fga == 0) return 0;
            return fgm / fga;
        }

        public static double ThreePointPercentageAgainstOpponent(this BasketballTeam t, Matchup m)
        {
            double fgm = m.Performances.FieldFoldLeft<Performance, int>(0, (i, p) => { return i + ((BasketballPerformance)p).ThreePointersMade; });
            double fga = m.Performances.FieldFoldLeft<Performance, int>(0, (i, p) => { return i + ((BasketballPerformance)p).ThreePointersAttempted; });
            if (fgm == 0 || fga == 0) return 0;
            return fgm / fga;
        }

        public static double OffensiveReboundsAgainstOpponent(this BasketballTeam t, Matchup m)
        {
            return m.Performances.StatSum(p => { return ((BasketballPerformance)p).OffensiveRebounds; });
        }

        public static double DefensiveReboundsAgainstOpponent(this BasketballTeam t, Matchup m)
        {
            return m.Performances.StatSum(p => { return ((BasketballPerformance)p).DefensiveRebounds; });
        }

        public static double ReboundsAgainstOpponent(this BasketballTeam t, Matchup m)
        {
            return m.Performances.StatSum(p => { return ((BasketballPerformance)p).Rebounds; });
        }

        public static double AssistsAgainstOpponent(this BasketballTeam t, Matchup m)
        {
            return m.Performances.StatSum(p => { return ((BasketballPerformance)p).Assists; });
        }

        public static double StealsAgainstOpponent(this BasketballTeam t, Matchup m)
        {
            return m.Performances.StatSum(p => { return ((BasketballPerformance)p).Steals; });
        }

        public static double BlocksAgainstOpponent(this BasketballTeam t, Matchup m)
        {
            return m.Performances.StatSum(p => { return ((BasketballPerformance)p).Blocks; });
        }

        public static double StarterPointsAgainstOpponent(this BasketballTeam t, Matchup m)
        {
            return m.Performances.StatSum(p => { if (p.Status == "Starter") return ((BasketballPerformance)p).OffensiveRebounds; else return 0; });
        }

        public static double BenchPointsAgainstOpponent(this BasketballTeam t, Matchup m)
        {
            return m.Performances.StatSum(p => { if (p.Status == "Bench") return ((BasketballPerformance)p).OffensiveRebounds; else return 0; });
        }

        public static double FieldGoalPercentage(this BasketballTeam t)
        {
                double fgm = 0.0, fga = 0.0;
                foreach (BasketballPlayer p in t.Players)
                {
                    fgm += p.FGM;
                    fga += p.FGA;
                }
                if (fgm == 0 || fga == 0) return 0;
                return fgm / fga;
        }

        public static double FreeThrowPercentage(this BasketballTeam t)
        {
            double fgm = 0.0, fga = 0.0;
            foreach (BasketballPlayer p in t.Players)
            {
                fgm += p.FTM;
                fga += p.FTA;
            }
            if (fgm == 0 || fga == 0) return 0;
            return fgm / fga;
        }

        public static double ThreePointPercentage(this BasketballTeam t)
        {
            double fgm = 0.0, fga = 0.0;
            foreach (BasketballPlayer p in t.Players)
            {
                fgm += p.M3P;
                fga += p.A3P;
            }
            if (fgm == 0 || fga == 0) return 0;
            return fgm / fga;
        }

        public static double OffensivePpgRatioAverage(this BasketballTeam t) { return t.OffensivePpgRatio().Average(); }
        public static double[] OffensivePpgRatio(this BasketballTeam t)
        {
            double[] d = t.PointsPerGameByGame();
            double ppg = t.PointsPerGame();
            for(int k=0;k<t.Matchups.Count;k++)
            {
                BasketballTeam opp = t.Teams[t.Matchups[k].Opponent];
                if (opp != null)
                    d[k] /= (opp.DefensivePpgRatioAverage()*ppg);
            }
            return d;
        }

        public static double OffensiveFgRatioAverage(this BasketballTeam t) { return t.OffensiveFgRatio().Average(); }
        public static double[] OffensiveFgRatio(this BasketballTeam t)
        {
            return t.FieldGoalPercentageByGame().Divide(t.OpponentFieldGoalPercentageByGame());
        }

        public static double Offensive3pRatioAverage(this BasketballTeam t) { return t.Offensive3pRatio().Average(); }
        public static double[] Offensive3pRatio(this BasketballTeam t)
        {
            return t.ThreePointPercentageByGame().Divide(t.OpponentThreePointPercentageByGame());
        }

        public static double HomeAdvantage(this BasketballTeam team, double[] stat)
        {
            double den = stat.Given(team.AwayGames(), x => x >= 0.5).AverageNonZero();
            if (den != 0)
                return stat.Given(team.HomeGames(), x => x >= 0.5).AverageNonZero() / den;
            else return double.MaxValue;
        }

        public static double[] RemoveHomeAdvantage(this BasketballTeam team, double[] stat)
        {
            return stat.Multiply(team.HomeGames().Divide(team.HomeAdvantage(stat)).Add(team.AwayGames()));
        }
    }
}
