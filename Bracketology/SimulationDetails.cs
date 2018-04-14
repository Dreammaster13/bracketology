using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOTBALL
{

    public class TeamSimulationDetails
    {
        public BasketballTeam Team;
        public BasketballPlayerList Players;
        public List<TeamSimulationOutcome> Outcomes;
        public double FieldGoalPercentage, FieldGoalsTaken;
        public double FreeThrowPercentage, FreeThrowsTaken;
        public double ThreePointPercentage, ThreePointsTakenPercentage;
        public double OffensiveReboundPercentage;
        public double DefensiveReboundPercentage;
        public double OffensiveTurnoverPercentage, DefensiveTurnoverPercentage;
        public double StealPercentage, StolenPercentage;
        public double BlockPercentage, BlockedPercentage;
        public double FoulPercentage, FouledPercentage;
        public double[] PlayerFreeThrowProbabilities, PlayerFreeThrowPercentages;
        public double[] PlayerFieldGoalProbabilities, PlayerThreePointProbabilities;
        public double[] PlayerFieldGoalPercentages, PlayerAssistPercentages;
        public double[] PlayerThreePointPercentages, PlayerOnCourtProbabilities;
        public double[] PlayerStartProbabilities;

        public double[] PlayersOnCourt;

        private Random m_Rand = new Random();

        public TeamSimulationDetails(BasketballTeam t)
        {
            Team = t;
            Players = new BasketballPlayerList();
            Outcomes = new List<TeamSimulationOutcome>();
            double[] oppfg = t.OpponentFieldGoalsTakenByGame();
            double[] fg = t.FieldGoalsTakenByGame();
            FieldGoalPercentage = t.RemoveHomeAdvantage(t.FieldGoalPercentageByGame()).Average();
            FieldGoalsTaken = t.RemoveHomeAdvantage(fg).Average();
            FreeThrowPercentage = t.RemoveHomeAdvantage(t.FreeThrowPercentageByGame()).Average();
            ThreePointPercentage = t.RemoveHomeAdvantage(t.ThreePointPercentageByGame()).Average();
            ThreePointsTakenPercentage = t.RemoveHomeAdvantage(t.ThreePointersTakenByGame().Divide(fg)).Average();
            OffensiveReboundPercentage = t.RemoveHomeAdvantage(t.OffensiveReboundPercentageByGame()).Average();
            DefensiveReboundPercentage = t.RemoveHomeAdvantage(t.DefensiveReboundPercentageByGame()).Average();
            OffensiveTurnoverPercentage = t.RemoveHomeAdvantage(t.TurnoversByGame().Divide(fg)).Average();
            double[] b = t.StealsByGame();
            StealPercentage = t.RemoveHomeAdvantage(b.Divide(b.Add(oppfg))).Average();
            b = t.BlocksByGame();
            BlockPercentage = t.RemoveHomeAdvantage(b.Divide(b.Add(oppfg))).Average();
            BlockedPercentage = t.RemoveHomeAdvantage(t.OpponentBlocksByGame().Divide(fg)).Average();
            FoulPercentage = t.RemoveHomeAdvantage(t.FoulsByGame().Divide(oppfg)).Average();
            FouledPercentage = t.RemoveHomeAdvantage(t.OpponentFoulsByGame().Divide(fg)).Average();
            PlayerFreeThrowProbabilities = new double[t.Players.Count];
            PlayerFreeThrowPercentages = new double[t.Players.Count];
            PlayerFieldGoalProbabilities = new double[t.Players.Count];
            PlayerFieldGoalPercentages = new double[t.Players.Count];
            PlayerThreePointProbabilities = new double[t.Players.Count];
            PlayerThreePointPercentages = new double[t.Players.Count];
            PlayerAssistPercentages = new double[t.Players.Count];
            PlayerOnCourtProbabilities = new double[t.Players.Count];
            PlayerStartProbabilities = new double[t.Players.Count];
            PlayersOnCourt = new double[t.Players.Count];
            double ft = t.FreeThrowsTakenByGame().Sum();
            double fgs = fg.Sum();
            double ap = t.AssistsByGame().Sum();
            for (int p = 0; p < t.Players.Count; p++)
            {
                Players.Add(t.Players[p]);
                PlayerFreeThrowProbabilities[p] = t.Players[p].FTA / ft;
                PlayerFreeThrowPercentages[p] = t.Players[p].FTP;
                PlayerFieldGoalProbabilities[p] = t.Players[p].FTA / fgs;
                PlayerFieldGoalPercentages[p] = t.Players[p].FGP;
                if(t.Players[p].FGA > 0)
                    PlayerThreePointProbabilities[p] = t.Players[p].A3P / t.Players[p].FGA;
                else
                    PlayerThreePointProbabilities[p] = 0;
                PlayerThreePointPercentages[p] = t.Players[p].P3P;
                PlayerAssistPercentages[p] = t.Players[p].AST / (double)(t.Players[p].AST + t.Players[p].FGA);
                PlayerOnCourtProbabilities[p] = t.Players[p].MIN_T * t.Matchups.Count / 48.0;
                PlayerStartProbabilities[p] = t.Players[p].Starts / (double)t.Matchups.Count;
            }
        }

        public int PlayerWithBall = 0;

        public void SetStarters()
        {
            double[] sp_sorted = new double[5];
            int[] sp_sorted_indices = new int[5];
            for(int k=0;k<Players.Count;k++)
            {
                if(PlayerStartProbabilities[k] > sp_sorted[0])
                {
                    sp_sorted[4] = sp_sorted[3];
                    sp_sorted_indices[4] = sp_sorted_indices[3];
                    sp_sorted[3] = sp_sorted[2];
                    sp_sorted_indices[3] = sp_sorted_indices[2];
                    sp_sorted[2] = sp_sorted[1];
                    sp_sorted_indices[2] = sp_sorted_indices[1];
                    sp_sorted[1] = sp_sorted[0];
                    sp_sorted_indices[1] = sp_sorted_indices[0];
                    sp_sorted[0] = PlayerStartProbabilities[k];
                    sp_sorted_indices[0] = k;
                }
                else if (PlayerStartProbabilities[k] > sp_sorted[1])
                {
                    sp_sorted[4] = sp_sorted[3];
                    sp_sorted_indices[4] = sp_sorted_indices[3];
                    sp_sorted[3] = sp_sorted[2];
                    sp_sorted_indices[3] = sp_sorted_indices[2];
                    sp_sorted[2] = sp_sorted[1];
                    sp_sorted_indices[2] = sp_sorted_indices[1];
                    sp_sorted[1] = PlayerStartProbabilities[k];
                    sp_sorted_indices[1] = k;
                }
                else if (PlayerStartProbabilities[k] > sp_sorted[2])
                {
                    sp_sorted[4] = sp_sorted[3];
                    sp_sorted_indices[4] = sp_sorted_indices[3];
                    sp_sorted[3] = sp_sorted[2];
                    sp_sorted_indices[3] = sp_sorted_indices[2];
                    sp_sorted[2] = PlayerStartProbabilities[k];
                    sp_sorted_indices[2] = k;
                }
                else if (PlayerStartProbabilities[k] > sp_sorted[3])
                {
                    sp_sorted[4] = sp_sorted[3];
                    sp_sorted_indices[4] = sp_sorted_indices[3];
                    sp_sorted[3] = PlayerStartProbabilities[k];
                    sp_sorted_indices[3] = k;
                }
                else if (PlayerStartProbabilities[k] > sp_sorted[4])
                {
                    sp_sorted[4] = PlayerStartProbabilities[k];
                    sp_sorted_indices[4] = k;
                }
            }

            PlayersOnCourt.Flatten(x => x > 2);
            for(int j=0;j<5;j++)
            {
                PlayersOnCourt[sp_sorted_indices[j]] = 1;
            }
        }

        public void SetPlayersOnCourt()
        {
            double[] sp_sorted = new double[5];
            int[] sp_sorted_indices = new int[5];
            for (int k = 0; k < Players.Count; k++)
            {
                if (PlayerStartProbabilities[k] > sp_sorted[0])
                {
                    sp_sorted[4] = sp_sorted[3];
                    sp_sorted_indices[4] = sp_sorted_indices[3];
                    sp_sorted[3] = sp_sorted[2];
                    sp_sorted_indices[3] = sp_sorted_indices[2];
                    sp_sorted[2] = sp_sorted[1];
                    sp_sorted_indices[2] = sp_sorted_indices[1];
                    sp_sorted[1] = sp_sorted[0];
                    sp_sorted_indices[1] = sp_sorted_indices[0];
                    sp_sorted[0] = PlayerStartProbabilities[k];
                    sp_sorted_indices[0] = k;
                }
                else if (PlayerStartProbabilities[k] > sp_sorted[1])
                {
                    sp_sorted[4] = sp_sorted[3];
                    sp_sorted_indices[4] = sp_sorted_indices[3];
                    sp_sorted[3] = sp_sorted[2];
                    sp_sorted_indices[3] = sp_sorted_indices[2];
                    sp_sorted[2] = sp_sorted[1];
                    sp_sorted_indices[2] = sp_sorted_indices[1];
                    sp_sorted[1] = PlayerStartProbabilities[k];
                    sp_sorted_indices[1] = k;
                }
                else if (PlayerStartProbabilities[k] > sp_sorted[2])
                {
                    sp_sorted[4] = sp_sorted[3];
                    sp_sorted_indices[4] = sp_sorted_indices[3];
                    sp_sorted[3] = sp_sorted[2];
                    sp_sorted_indices[3] = sp_sorted_indices[2];
                    sp_sorted[2] = PlayerStartProbabilities[k];
                    sp_sorted_indices[2] = k;
                }
                else if (PlayerStartProbabilities[k] > sp_sorted[3])
                {
                    sp_sorted[4] = sp_sorted[3];
                    sp_sorted_indices[4] = sp_sorted_indices[3];
                    sp_sorted[3] = PlayerStartProbabilities[k];
                    sp_sorted_indices[3] = k;
                }
                else if (PlayerStartProbabilities[k] > sp_sorted[4])
                {
                    sp_sorted[4] = PlayerStartProbabilities[k];
                    sp_sorted_indices[4] = k;
                }
            }

            PlayersOnCourt.Flatten(x => x > 2);
            for (int j = 0; j < 5; j++)
            {
                PlayersOnCourt[sp_sorted_indices[j]] = 1;
            }
        }

        public void SelectPlayerWithBall()
        {
            double[] player_probs = PlayerFieldGoalProbabilities.Given(PlayersOnCourt, x => x >= 0.5);
            PlayerWithBall = player_probs.GetCdfBin(m_Rand.NextDouble());
        }

        public BasketballPlayer GetPlayerWithBall()
        {
            return Team.Players[PlayerWithBall];
        }

        public bool IsTwoPointShotMade(BasketballTeam t)
        {
            return m_Rand.NextDouble() < PlayerFieldGoalPercentages[PlayerWithBall] * Team.OffensiveFgRatioAverage() * Team.Score;
        }

        public bool IsThreePointShotMade(BasketballTeam t)
        {
            return m_Rand.NextDouble() < PlayerThreePointPercentages[PlayerWithBall] * Team.Offensive3pRatioAverage() * Team.Score;
        }

        public bool IsFreeThrowMade()
        {
            return m_Rand.NextDouble() < PlayerFreeThrowPercentages[PlayerWithBall] * Team.Score;
        }

        public bool IsShootingThree()
        {
            return m_Rand.NextDouble() < PlayerThreePointProbabilities[PlayerWithBall];
        }

        public bool IsPass()
        {
            return m_Rand.NextDouble() < PlayerAssistPercentages[PlayerWithBall];
        }
        
        public bool IsTurnover()
        {
            return m_Rand.NextDouble() * Team.Score < OffensiveTurnoverPercentage;
        }

        public bool IsBlock()
        {
            return m_Rand.NextDouble() < BlockPercentage * Team.Score;
        }

        public bool IsFoul()
        {
            return m_Rand.NextDouble() * Team.Score < FoulPercentage * Team.Score;
        }
    }
}
