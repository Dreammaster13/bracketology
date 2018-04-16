using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOTBALL
{
    public class Lazy<S,T>
    {
        private Func<S,T> m_Func;

	private T m_Value;

	private bool m_Initialized;

	public T Value(S s)
	{
            if(!m_Initialized)
	    {
                m_Value = m_Func(s);
		m_Initialized = true;
	    }

	    return m_Value;
	}

	public Lazy(Func<S,T> f)
	{
	    m_Initialized = false;
            m_Func = f;
	}
    }

    public class Lazy<T> : Lazy<None, T>
    {
        public Lazy<T>(Func<T> f)
	{
	    base(() => f());
	}
    }
}
