using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOTBALL
{
    public class Performance
    {
        public Player Player;
        public Matchup Matchup;
        public string Status;
        public Performance() { }
    }

    public class BasketballPerformance : Performance
    {
        public int Points, OffensiveRebounds, DefensiveRebounds, Assists, Steals, Blocks, Turnovers;
        public int FieldGoalsMade, FieldGoalsAttempted;
        public int FreeThrowsMade, FreeThrowsAttempted;
        public int ThreePointersMade, ThreePointersAttempted;
        public int PersonalFouls;
        public double Minutes, FIC; //Not sure what this is #ThanksRealgm

        public int Rebounds {  get { return OffensiveRebounds + DefensiveRebounds; } }
        public double FieldGoalPercentage {  get { if (FieldGoalsAttempted > 0) return (double)(100 * FieldGoalsMade) / (double)FieldGoalsAttempted; else return 0.0; } }
        public double FreeThrowPercentage {  get { if (FreeThrowsAttempted > 0) return (double)(100 * FreeThrowsMade) / (double)FreeThrowsAttempted; else return 0.0; } }
        public double ThreePointPercentage {  get { if (ThreePointersAttempted > 0) return (double)(100 * ThreePointersMade) / (double)ThreePointersAttempted; else return 0.0; } }


        public BasketballPerformance() : base() { }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder("Performance:");
            sb.Append(Points).Append(";");
            sb.Append(OffensiveRebounds).Append(";");
            sb.Append(DefensiveRebounds).Append(";");
            sb.Append(Assists).Append(";");
            sb.Append(Steals).Append(";");
            sb.Append(Blocks).Append(";");
            sb.Append(Turnovers).Append(";");
            sb.Append(PersonalFouls).Append(";");
            sb.Append(FieldGoalsMade).Append(";");
            sb.Append(FieldGoalsAttempted).Append(";");
            sb.Append(FreeThrowsMade).Append(";");
            sb.Append(FreeThrowsAttempted).Append(";");
            sb.Append(ThreePointersMade).Append(";");
            sb.Append(ThreePointersAttempted).Append(";");
            sb.Append(Minutes).Append(";");
            sb.Append(FIC).Append(";");
            sb.Append(Status).Append(";");
            sb.Append(Matchup.ID).Append("\r\n");
            return sb.ToString();
        }

        public static BasketballPerformance Deserialize(string input, List<Matchup> Matchups)
        {
            try
            {
                BasketballPerformance p = new BasketballPerformance();
                if (!input.StartsWith("Performance:")) return null;
                string[] fields = input.Substring(12).Split(';');
                p.Points = int.Parse(fields[0]);
                p.OffensiveRebounds = int.Parse(fields[1]);
                p.DefensiveRebounds = int.Parse(fields[2]);
                p.Assists = int.Parse(fields[3]);
                p.Steals = int.Parse(fields[4]);
                p.Blocks = int.Parse(fields[5]);
                p.Turnovers = int.Parse(fields[6]);
                p.PersonalFouls = int.Parse(fields[7]);
                p.FieldGoalsMade = int.Parse(fields[8]);
                p.FieldGoalsAttempted = int.Parse(fields[9]);
                p.FreeThrowsMade = int.Parse(fields[10]);
                p.FreeThrowsAttempted = int.Parse(fields[11]);
                p.ThreePointersMade = int.Parse(fields[12]);
                p.ThreePointersAttempted = int.Parse(fields[13]);
                p.Minutes = double.Parse(fields[14]);
                p.FIC = double.Parse(fields[15]);
                p.Status = fields[16];
                p.Matchup = Matchups.Find(m => m.ID == fields[17]);
                if (p.Matchup != null)
                    p.Matchup.Performances.Add(p);
                return p;
            }
            catch { }
            return null;
        }
    }

    public class FootballPerformance : Performance
    {
        public int PassesAttempted, PassesCompleted, PassYards, PassLongest, PassingTouchdowns, PassesIntercepted, TimesSacked;
        public double PassingPercentage, PassingYardsPerAttempt, QBRating;

        public int RushesAttempted, RushingYards, RushingLongest, Rushing20Plus, RushingTouchdowns, RushingFumbles, RushingFirstDowns;
        public double RushingYardsPerAttempt;

        public int ReceivingCompletions, ReceivingTargets, ReceivingYars, ReceivingTouchdowns, ReceivingLongest, Receiving20Plus, ReceivingFumbles, ReceivingYardsAfterContact, ReceivingFirstDowns;
        public double ReceivingYardsAverage;

        public int ScoringTwoPointConversions;

        public int KickoffReturningAttempts, KickoffReturningYards, KickoffReturningLong, KickoffReturningTouchdowns;
        public int PuntReturningAttempts, PuntReturningYards, PuntReturningLong, PuntReturningTouchdowns, PuntReturningFairCatches;

        public int FieldGoalsAttempted, FieldGoalsMade, FieldGoalsLong, ExtraPointsAttempted, ExtraPointsMade;
        public int FieldGoals1to19Attempted, FieldGoals1to19Made, FieldGoals20to29Attempted, FieldGoals20to29Made;
        public int FieldGoals30to39Attempted, FieldGoals30to39Made, FieldGoals40to49Attempted, FieldGoals40to49Made, FieldGoals50plusAttempted, FieldGoals50plusMade;

        public int PuntKickingAttempts, PuntKickingYards, PuntKickingLong, PuntKickingBlocked, PPuntKickingInside20, PuntKickingTouchbacks, PuntKickingFairCatches, PuntKickingReturns, PuntKickingReturnYards;
        public double PuntKickingYardsAverage, PuntKickingYardsNetAverage, PuntKickingReturnYardsAverage;

        public int DefenseTacklesAssisted, DefenseTacklesTotal, DefenseTacklesCombined, DefenseSacks, DefenseSackYards, DefensePassesDefended;
        public int DefenseInterceptions, DefenseInterceptionYards, DefenseInterceptionYardsLong, DefenseInterceptionTouchdowns;
        public int DefenseFumblesForced, DefenseFumblesRecovered, DefenseFumbleTouchdowns;

        public FootballPerformance() : base() { }

        public int FieldGoals0to39Made {  get { return FieldGoals1to19Made + FieldGoals20to29Made + FieldGoals30to39Made; } }

        public int FieldGoalsMissed {  get { return FieldGoalsAttempted - FieldGoalsMade; } }

        public int BlockedKicks {  get { return PuntKickingBlocked; } }

        public double FantasyPoints
        {
            get
            {
                double d = 0.0;
                d += 0.04 * PassYards + 4 * PassingTouchdowns + 2 * ScoringTwoPointConversions - 2 * PassesIntercepted;
                d += 0.1 * RushingYards + 6 * RushingTouchdowns;
                d += 0.1 * ReceivingYars + 0.5 * ReceivingCompletions + 6 * ReceivingTouchdowns;
                d += 6 * KickoffReturningTouchdowns + 6 * DefenseFumbleTouchdowns + 6 * DefenseInterceptionTouchdowns;
                d += 6 * PuntReturningTouchdowns - 2 * ReceivingFumbles - 2 * RushingFumbles + 6 * DefenseFumbleTouchdowns;
                d += ExtraPointsMade + 3 * FieldGoals0to39Made + 4 * FieldGoals40to49Made + 5 * FieldGoals50plusMade - FieldGoalsMissed;
                d += DefenseSacks + 2 * BlockedKicks + 2 * DefenseFumblesRecovered + 2 * DefenseInterceptions;

                return d;
            }
        }
    }
}
