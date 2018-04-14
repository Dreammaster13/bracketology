using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOTBALL
{
    public class DeferredInt<T>
    {
        private Func<T, int> m_Func;

        private int? m_Value = null;

        public int Value(T t)
        {
            if (m_Value == null)
            {
                m_Value = m_Func(t);
            }

            return (int)m_Value;
        }

        public DeferredInt(Func<T,int> f)
        {
            m_Func = f;
        }
    }

    public class DeferredDouble<T>
    {
        private Func<T,double> m_Func;

        private double? m_Value = null;

        public double Value(T t)
        {
            if (m_Value == null)
            {
                m_Value = m_Func(t);
            }

            return (double)m_Value;
        }

        public DeferredDouble(Func<T, double> f)
        {
            m_Func = f;
        }
    }

    public class Player
    {
        public Team Team;
        public string Name, Position;
        public int GP, Height, Weight, Number;
        //public List<Performance> Performances;

        public Player()
        {

        }

        public Player(string name)
        {
            Name = name;
        }

        public virtual string Serialize()
        {
            return "";
        }
    }

	public class BasketballPlayer : Player
	{
        public List<BasketballPerformance> Performances;
		public string Class, BirthDate, BirthCity, Nationality, HighSchool;

        private DeferredDouble<BasketballPlayer> m_MIN = new DeferredDouble<BasketballPlayer>(p =>
        {
            if (p.Performances.Count > 0)
                return (double)p.MIN_T / p.Performances.Count;
            else return 0.0;
        });

        public double MIN
        {
            get
            {
                return m_MIN.Value(this);
            }
        }

        private DeferredDouble<BasketballPlayer> m_PPG = new DeferredDouble<BasketballPlayer>(p =>
        {
            if (p.Performances.Count > 0)
                return (double)p.PTS / p.Performances.Count;
            else return 0.0;
        });

        public double PPG
        {
            get
            {
                return m_PPG.Value(this);
            }
        }

        private DeferredDouble<BasketballPlayer> m_RPG = new DeferredDouble<BasketballPlayer>(p =>
        {
            if (p.Performances.Count > 0)
                return (double)p.REB / p.Performances.Count;
            else return 0.0;
        });

        public double RPG
        {
            get
            {
                return m_RPG.Value(this);
            }
        }

        private DeferredDouble<BasketballPlayer> m_APG = new DeferredDouble<BasketballPlayer>(p =>
        {
            if (p.Performances.Count > 0)
                return (double)p.AST / p.Performances.Count;
            else return 0.0;
        });

        public double APG
        {
            get
            {
                return m_APG.Value(this);
            }
        }

        private DeferredDouble<BasketballPlayer> m_SPG = new DeferredDouble<BasketballPlayer>(p =>
        {
            if (p.Performances.Count > 0)
                return (double)p.STL / p.Performances.Count;
            else return 0.0;
        });

        public double SPG
        {
            get
            {
                return m_SPG.Value(this);
            }
        }

        private DeferredDouble<BasketballPlayer> m_BPG = new DeferredDouble<BasketballPlayer>(p =>
        {
            if (p.Performances.Count > 0)
                    return (double)p.BLK / p.Performances.Count;
                else return 0.0;
        });

        public double BPG
        {
            get
            {
                return m_BPG.Value(this);
            }
        }

        private DeferredDouble<BasketballPlayer> m_TPG = new DeferredDouble<BasketballPlayer>(p =>
        {
            if (p.Performances.Count > 0)
                    return (double)p.TO / p.Performances.Count;
                else return 0.0;
        });

        public double TPG
        {
            get
            {
                return m_TPG.Value(this);
            }
        }

        private DeferredDouble<BasketballPlayer> m_FGP = new DeferredDouble<BasketballPlayer>(p =>
        {
            if (p.FGA > 0)
                    return (double)p.FGM / p.FGA;
                else return 0.0;
        });

        public double FGP
        {
            get
            {
                return m_FGP.Value(this);
            }
        }

        private DeferredDouble<BasketballPlayer> m_FTP = new DeferredDouble<BasketballPlayer>(p =>
        {
            if (p.FTA > 0)
                    return (double)p.FTM / p.FTA;
                else return 0.0;
        });

        public double FTP
        {
            get
            {
                return m_FTP.Value(this);
            }
        }

        private DeferredDouble<BasketballPlayer> m_P3P = new DeferredDouble<BasketballPlayer>(p =>
        {
            if (p.A3P > 0)
                    return (double)p.M3P / p.A3P;
                else return 0.0;
        });

        public double P3P
        {
            get
            {
                return m_P3P.Value(this);
            }
        }

        private DeferredInt<BasketballPlayer> m_MIN_T = new DeferredInt<BasketballPlayer>(p =>
        {
            int total = 0;
                foreach (BasketballPerformance q in p.Performances)
                    total += (int)q.Minutes;
                return total;
        });

        public int MIN_T
        {
            get
            {
                return m_MIN_T.Value(this);
            }
        }

        private DeferredInt<BasketballPlayer> m_FGM = new DeferredInt<BasketballPlayer>(p =>
        {
            int total = 0;
                foreach (BasketballPerformance q in p.Performances)
                    total += (int)q.FieldGoalsMade;
                return total;
        });

        public int FGM
        {
            get
            {
                return m_FGM.Value(this);
            }
        }

        private DeferredInt<BasketballPlayer> m_FGA = new DeferredInt<BasketballPlayer>(p =>
        {
            int total = 0;
                foreach (BasketballPerformance q in p.Performances)
                    total += (int)q.FieldGoalsAttempted;
                return total;
        });

        public int FGA
        {
            get
            {
                return m_FGA.Value(this);
            }
        }

        private DeferredInt<BasketballPlayer> m_FTM = new DeferredInt<BasketballPlayer>(p =>
        {
            int total = 0;
                foreach (BasketballPerformance q in p.Performances)
                    total += (int)q.FreeThrowsMade;
                return total;
        });

        public int FTM
        {
            get
            {
                return m_FTM.Value(this);
            }
        }

        private DeferredInt<BasketballPlayer> m_FTA = new DeferredInt<BasketballPlayer>(p =>
        {
            int total = 0;
                foreach (BasketballPerformance q in p.Performances)
                    total += (int)q.FreeThrowsAttempted;
                return total;
        });

        public int FTA
        {
            get
            {
                return m_FTA.Value(this);
            }
        }

        private DeferredInt<BasketballPlayer> m_M3P = new DeferredInt<BasketballPlayer>(p =>
        {
            int total = 0;
                foreach (BasketballPerformance q in p.Performances)
                    total += (int)q.ThreePointersMade;
                return total;
        });

        public int M3P
        {
            get
            {
                return m_M3P.Value(this);
            }
        }

        private DeferredInt<BasketballPlayer> m_A3P = new DeferredInt<BasketballPlayer>(p =>
        {
            int total = 0;
                foreach (BasketballPerformance q in p.Performances)
                    total += (int)q.ThreePointersAttempted;
                return total;
        });

        public int A3P
        {
            get
            {
                return m_A3P.Value(this);
            }
        }

        private DeferredInt<BasketballPlayer> m_PTS = new DeferredInt<BasketballPlayer>(p =>
        {
            int total = 0;
                foreach (BasketballPerformance q in p.Performances)
                    total += (int)q.Points;
                return total;
        });

        public int PTS
        {
            get
            {
                return m_PTS.Value(this);
            }
        }

        private DeferredInt<BasketballPlayer> m_OFFR = new DeferredInt<BasketballPlayer>(p =>
        {
            int total = 0;
                foreach (BasketballPerformance q in p.Performances)
                    total += (int)q.OffensiveRebounds;
                return total;
        });

        public int OFFR
        {
            get
            {
                return m_OFFR.Value(this);
            }
        }

        private DeferredInt<BasketballPlayer> m_DEFR = new DeferredInt<BasketballPlayer>(p =>
        {
            int total = 0;
                foreach (BasketballPerformance q in p.Performances)
                    total += (int)q.DefensiveRebounds;
                return total;
        });

        public int DEFR
        {
            get
            {
                return m_DEFR.Value(this);
            }
        }

        private DeferredInt<BasketballPlayer> m_REB = new DeferredInt<BasketballPlayer>(p =>
        {
            int total = 0;
                foreach (BasketballPerformance q in p.Performances)
                    total += (int)q.Rebounds;
                return total;
        });

        public int REB
        {
            get
            {
                return m_REB.Value(this);
            }
        }

        private DeferredInt<BasketballPlayer> m_AST = new DeferredInt<BasketballPlayer>(p =>
        {
            int total = 0;
                foreach (BasketballPerformance q in p.Performances)
                    total += (int)q.Assists;
                return total;
        });

        public int AST
        {
            get
            {
                return m_AST.Value(this);
            }
        }

        private DeferredInt<BasketballPlayer> m_TO = new DeferredInt<BasketballPlayer>(p =>
        {
            int total = 0;
                foreach (BasketballPerformance q in p.Performances)
                    total += (int)q.Turnovers;
                return total;
        });

        public int TO
        {
            get
            {
                return m_TO.Value(this);
            }
        }

        private DeferredInt<BasketballPlayer> m_STL = new DeferredInt<BasketballPlayer>(p =>
        {
            int total = 0;
                foreach (BasketballPerformance q in p.Performances)
                    total += (int)q.Steals;
                return total;
        });

        public int STL
        {
            get
            {
                return m_STL.Value(this);
            }
        }

        private DeferredInt<BasketballPlayer> m_BLK = new DeferredInt<BasketballPlayer>(p =>
        {
            int total = 0;
                foreach (BasketballPerformance q in p.Performances)
                    total += (int)q.Blocks;
                return total;
        });

        public int BLK
        {
            get
            {
                return m_BLK.Value(this);
            }
        }

        private DeferredInt<BasketballPlayer> m_Starts = new DeferredInt<BasketballPlayer>(p =>
        {
            int total = 0;
                foreach (BasketballPerformance q in p.Performances)
                {
                    if(q.Status != null)
                      total += q.Status.Contains("Start") ? 1 : 0;
                }
                return total;
        });

        public int Starts
        {
            get
            {
                return m_Starts.Value(this);
            }
        }

        public BasketballPlayer(string n) : base(n)
		{
            Performances = new List<BasketballPerformance>();
		}

        public BasketballPlayer() { Performances = new List<BasketballPerformance>(); }

		public override string ToString()
		{
			return Name;
		}

        public new string Serialize()
        {
            StringBuilder sb = new StringBuilder("Player:");
            sb.Append(Name).Append(";");
            sb.Append(Class).Append(";");
            sb.Append(BirthDate).Append(";");
            sb.Append(BirthCity).Append(";");
            sb.Append(Nationality).Append(";");
            sb.Append(HighSchool).Append(";");
            sb.Append(GP).Append(";");
            sb.Append(Height).Append(";");
            sb.Append(Weight).Append(";");
            sb.Append(Number).Append(";");
            sb.Append(Position).Append(";").Append("\r\n");
            foreach (BasketballPerformance p in Performances)
                sb.Append(p.Serialize());
            return sb.ToString();
        }

        public static BasketballPlayer Deserialize(string input)
        {
            try
            {
                BasketballPlayer p = new BasketballPlayer();
                if (!input.StartsWith("Player:")) return null;
                string[] fields = input.Substring(7).Split(';');
                p.Name = fields[0];
                p.Class = fields[1];
                p.BirthDate = fields[2];
                p.BirthCity = fields[3];
                p.Nationality = fields[4];
                p.HighSchool = fields[5];
                p.GP = int.Parse(fields[6]);
                p.Height = int.Parse(fields[7]);
                p.Weight = int.Parse(fields[8]);
                p.Number = int.Parse(fields[9]);
                p.Position = fields[10];
                return p;
            }
            catch { }
            return null;
        }
    }

    public class FootballPlayer : Player
    {
        public int Age, Experience;
        public string College;

        public FootballPlayer() : base()
        {

        }

        public FootballPlayer(string name):base(name)
        {

        }
    }
}
