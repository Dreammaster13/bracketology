using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOTBALL
{
	public class TeamSimulationOutcome : Matchup
	{
        public TeamSimulationDetails SimDetails;

        public TeamSimulationOutcome(TeamSimulationDetails sim)
        {
            SimDetails = sim;
            SimDetails.Outcomes.Add(this);
            foreach(BasketballPlayer p in SimDetails.Players)
            {
                BasketballPerformance perf = new BasketballPerformance() { Player = p };
                this.Performances.Add(perf);
            }
        }

	}
}
