using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOTBALL
{
	public class PlayerList : List<Player>
	{
		public PlayerList()
		{

		}

        public new void Add(Player p)
        {
            if (p != null)
                base.Add(p);
        }

		//public Player this[string name]
		//{
		//	get
		//	{
		//		foreach (Player p in this)
		//		{
		//			if (p.Name == name)
		//				return p;
		//		}
		//		return null;
		//	}
		//}

	}

    public class BasketballPlayerList : List<BasketballPlayer> //PlayerList
    {
        public BasketballPlayerList()
        {

        }

        public new void Add(BasketballPlayer p)
        {
            if (p != null)
                base.Add(p);
        }

        public BasketballPlayer this[string name]
        {
            get
            {
                foreach (BasketballPlayer p in this)
                {
                    if (p.Name == name)
                        return p;
                }
                return null;
            }
        }
    }
}
