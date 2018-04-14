using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOTBALL
{
	public delegate void SimulationCompletedEvent(object sender, SimulationCompletedEventArgs e);

	public class SimulationCompletedEventArgs : EventArgs
	{
        public TeamSimulationOutcome Team1Outcome, Team2Outcome;

		public SimulationCompletedEventArgs(TeamSimulationOutcome o1, TeamSimulationOutcome o2)
		{
            Team1Outcome = o1;
            Team2Outcome = o2;
		}
	}

	public class Simulation
	{
        public TeamSimulationDetails team1, team2;
		public event SimulationCompletedEvent SimulationCompleted;
        private Random m_Rand = new Random();
        private TeamSimulationOutcome outcome1, outcome2;
        private int FreeThrows = 0;

		public Simulation(BasketballTeam t1, BasketballTeam t2)
		{
            team1 = new TeamSimulationDetails(t1);
            team2 = new TeamSimulationDetails(t2);
		}

		public void StartSimulation(int numSims)
		{
			for(int i = 0; i < numSims; i++)
			{
                _sim();
			}

            if (this.SimulationCompleted != null)
            {
                SimulationCompletedEventArgs e = new SimulationCompletedEventArgs(outcome1, outcome2);
                this.SimulationCompleted(this, e);
            }
        }

        private void _sim()
        {
            outcome1 = new TeamSimulationOutcome(team1);
            outcome2 = new TeamSimulationOutcome(team2);

            int ot = 0;
            team1.SetStarters();
            team2.SetStarters();

            PlayPeriod(1);
            PlayPeriod(2);

            while (outcome1.TeamScore == outcome2.TeamScore)
            {
                ot++;
                PlayPeriod(2 + ot);
            }

            var mu_o1 = team1.Team.PointsPerGame();
            var var_o1 = Math.Pow(team1.Team.PointsPerGameByGame().StandardDeviation(), 2);

            var mu_o2 = team2.Team.PointsPerGame();
            var var_o2 = Math.Pow(team2.Team.PointsPerGameByGame().StandardDeviation(), 2);

            var mu_d1 = team1.Team.PointsAllowedPerGame();
            var var_d1 = Math.Pow(team1.Team.PointsAllowedByGame().StandardDeviation(), 2);

            var mu_d2 = team2.Team.PointsAllowedPerGame();
            var var_d2 = Math.Pow(team2.Team.PointsAllowedByGame().StandardDeviation(), 2);

            outcome1.Win = outcome1.TeamScore > outcome2.TeamScore;
            outcome2.Win = outcome1.TeamScore < outcome2.TeamScore;
        }

        private void PlayPeriod(int number)
        {
            bool Possession = m_Rand.NextDouble() > 0.5 ? false : true;
            double Seconds = number < 3 ? 60.0 * 20.0 : 60.0 * 5.0;

            while (Seconds > 0)
            {
                TeamSimulationOutcome teamWithBall = (Possession ? outcome1 : outcome2);
                TeamSimulationOutcome teamWithoutBall = (Possession ? outcome2 : outcome1);
                double shotClock = 35.0;
                PointsFromPossession(teamWithBall, teamWithoutBall, number, ref shotClock, ref Seconds);

                Possession = !Possession;
            }
        }

        private void PointsFromPossession(TeamSimulationOutcome teamWithBall, TeamSimulationOutcome teamWithoutBall, int period, ref double shotClock, ref double seconds)
        {
            teamWithBall.SimDetails.SelectPlayerWithBall();
            if (teamWithBall.SimDetails.IsTurnover())
            {
                RemoveSeconds(ref shotClock, ref seconds);
            }
            else if(FoulRoutine(teamWithBall, teamWithoutBall, period, ref shotClock, ref seconds, false)) // Not shooting foul
            {
                RemoveSeconds(ref shotClock, ref seconds);
                while(FreeThrows-- > 0)
                    FreeThrowRoutine(teamWithBall, teamWithoutBall, period, ref shotClock, ref seconds);
            }
            else if(teamWithBall.SimDetails.IsPass())
            {
                if (RemoveSeconds(ref shotClock, ref seconds))
                {
                    PointsFromPossession(teamWithBall, teamWithoutBall, period, ref shotClock, ref seconds);
                }
            }
            else
            {
                if (RemoveSeconds(ref shotClock, ref seconds))
                {
                    if (!ShootBall(teamWithBall, teamWithoutBall, period, ref shotClock, ref seconds))
                    {
                        if (ReboundRoutine(teamWithBall, teamWithoutBall, period, ref shotClock, ref seconds))
                        {
                            shotClock = 35.0;
                            PointsFromPossession(teamWithBall, teamWithoutBall, period, ref shotClock, ref seconds);
                        }
                    }
                }
            }
        }

        private void FreeThrowRoutine(TeamSimulationOutcome teamWithBall, TeamSimulationOutcome teamWithoutBall, int period, ref double shotClock, ref double seconds)
        {
            if (teamWithBall.SimDetails.IsFreeThrowMade())
                teamWithBall.TeamScore += 1;
        }

        private bool ShootBall(TeamSimulationOutcome teamWithBall, TeamSimulationOutcome teamWithoutBall, int period, ref double shotClock, ref double seconds)
        {
            if (FoulRoutine(teamWithBall, teamWithoutBall, period, ref shotClock, ref seconds, true)) // Shooting foul
            {
                return ShootWithFoul(teamWithBall, teamWithoutBall, period, ref shotClock, ref seconds);
            }
            else if (teamWithoutBall.SimDetails.IsBlock())
            {

            }
            else
            {
                if (ShootWithoutFoul(teamWithBall, teamWithoutBall, period, ref shotClock, ref seconds))
                    return true;
            }

            return false;
        }

        private bool ShootWithFoul(TeamSimulationOutcome teamWithBall, TeamSimulationOutcome teamWithoutBall, int period, ref double shotClock, ref double seconds)
        {
            if (teamWithBall.SimDetails.IsShootingThree())
            {
                if (PointsForShot(teamWithBall, teamWithoutBall, period, ref shotClock, ref seconds, true, true))
                {
                    while (FreeThrows-- > 0)
                        FreeThrowRoutine(teamWithBall, teamWithoutBall, period, ref shotClock, ref seconds);

                    return true;
                }

            }
            else
            {
                if (PointsForShot(teamWithBall, teamWithoutBall, period, ref shotClock, ref seconds, false, true))
                {
                    while (FreeThrows-- > 0)
                        FreeThrowRoutine(teamWithBall, teamWithoutBall, period, ref shotClock, ref seconds);

                    return true;
                }
            }

            return false;
        }

        private bool ShootWithoutFoul(TeamSimulationOutcome teamWithBall, TeamSimulationOutcome teamWithoutBall, int period, ref double shotClock, ref double seconds)
        {
            if (teamWithBall.SimDetails.IsShootingThree())
            {
                if (PointsForShot(teamWithBall, teamWithoutBall, period, ref shotClock, ref seconds, true, false))
                {
                    teamWithBall.TeamScore += 3;
                    return true;
                }

            }
            else
            {
                if (PointsForShot(teamWithBall, teamWithoutBall, period, ref shotClock, ref seconds, false, false))
                {
                    teamWithBall.TeamScore += 2;
                    return true;
                }
            }

            return false;
        }

        private bool PointsForShot(TeamSimulationOutcome teamWithBall, TeamSimulationOutcome teamWithoutBall, int period, ref double shotClock, ref double seconds, bool IsThree, bool IsFoul)
        {
            if(IsThree)
            {
                if (PointsForThreePointShot(teamWithBall, teamWithoutBall, period, ref shotClock, ref seconds))
                {
                    if (IsFoul && m_Rand.NextDouble() < 0.5)
                        FreeThrows = 1;
                    else if (IsFoul)
                        FreeThrows = 3;
                    else FreeThrows = 0;
                    teamWithBall.TeamScore += 3;
                    return true;
                }
                else FreeThrows = 0;
            }
            else
            {
                if (PointsForTwoPointShot(teamWithBall, teamWithoutBall, period, ref shotClock, ref seconds))
                {
                    if (IsFoul && m_Rand.NextDouble() < 0.5)
                        FreeThrows = 1;
                    else if (IsFoul)
                        FreeThrows = 2;
                    else FreeThrows = 0;

                    teamWithBall.TeamScore += 2;
                    return true;
                }
                else FreeThrows = 0;
            }

            return false;
        }

        private bool PointsForThreePointShot(TeamSimulationOutcome teamWithBall, TeamSimulationOutcome teamWithoutBall, int period, ref double shotClock, ref double seconds)
        {
            return teamWithBall.SimDetails.IsThreePointShotMade(teamWithoutBall.SimDetails.Team);
        }

        private bool PointsForTwoPointShot(TeamSimulationOutcome teamWithBall, TeamSimulationOutcome teamWithoutBall, int period, ref double shotClock, ref double seconds)
        {
            return teamWithBall.SimDetails.IsTwoPointShotMade(teamWithoutBall.SimDetails.Team);
        }

        private bool FoulRoutine(TeamSimulationOutcome teamWithBall, TeamSimulationOutcome teamWithoutBall, int period, ref double shotClock, ref double seconds, bool isShootingFoul)
        {
            if (!isShootingFoul)
            {
                double foulUrgency;
                if (teamWithBall.TeamScore >= teamWithoutBall.TeamScore)
                {
                    foulUrgency = 1;
                }
                else
                {
                    foulUrgency = ((period >= 2) && (teamWithBall.TeamScore < teamWithoutBall.TeamScore) && (seconds < 120)) ? (teamWithoutBall.TeamScore-teamWithBall.TeamScore)*(150 - seconds)/(30 * 4): 1;
                }
            if (m_Rand.NextDouble() / foulUrgency < teamWithoutBall.SimDetails.FoulPercentage * teamWithoutBall.SimDetails.Team.Score)
                return true;
            }
            else
            {
                if (m_Rand.NextDouble() < teamWithoutBall.SimDetails.FoulPercentage * teamWithoutBall.SimDetails.Team.Score)
                    return true;
            }

            return false;
        }

        private bool ReboundRoutine(TeamSimulationOutcome teamWithBall, TeamSimulationOutcome teamWithoutBall, int period, ref double shotClock, ref double seconds)
        {
            return (new double[] { teamWithBall.SimDetails.OffensiveReboundPercentage * teamWithBall.SimDetails.Team.Score, teamWithoutBall.SimDetails.DefensiveReboundPercentage * teamWithoutBall.SimDetails.Team.Score }).GetCdfBin(m_Rand.NextDouble()) == 0;
        }

        bool RemoveSeconds(ref double shotClock, ref double seconds)
        {
           return RemoveSeconds(ref shotClock, ref seconds, m_Rand.NextDouble() * (shotClock + 1));
        }

        bool RemoveSeconds(ref double shotClock, ref double seconds, double remove)
        {
            shotClock -= remove;
            seconds -= remove;

            return shotClock > 0 && seconds > 0;
        }
    }
}
