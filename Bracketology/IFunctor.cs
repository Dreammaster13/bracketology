using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Bracketology
{
    public interface IFunc<T, U>
    {
        U Evaluate(T input);
    }

    public class Function<T, U> : IFunc<T, U>
    {
        private Func<T, U> eval;

        public Function(Func<T, U> func) { eval = func; }

        public U Evaluate(T input) { return eval(input); }

        U IFunc<T, U>.Evaluate(T input) { return Evaluate(input); }
    }

    public interface IFunctor<T>
    {
        // fmap :: Functor f => (T -> U) -> f T -> f U
        IFunc<IFunctor<T>, IFunctor<U>> FMap<U>(IFunc<T, U> func);
    }

    public interface IApplicative<T> : IFunctor<T>
    {
        IApplicative<T> Pure(T val);
        IFunc<IApplicative<T>, IApplicative<U>> Lift<U>(IApplicative<IFunc<T, U>> func);
    }

    public interface IMonad<T> : IApplicative<T>
    {
        IMonad<T> Return(T val);
        IFunc<IFunc<T, IMonad<U>>, IMonad<U>> Bind<U>(IMonad<T> val);
        //IFunc<IMonad<U>, IMonad<U>> Forward<U>(IMonad<T> val);
    }

    public class MyEnumerable<T> : IEnumerable<T>, IMonad<T>
    {
        private readonly IEnumerable<T> _collection;

        public MyEnumerable(IEnumerable<T> collection)
        {
            _collection = collection;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public MyEnumerable<T> Return(T val)
        {
            return Pure(val);
        }

        IMonad<T> IMonad<T>.Return(T val) { return Return(val); }

        public IFunc<IFunc<T, MyEnumerable<U>>, MyEnumerable<U>> Bind<U>(MyEnumerable<T> val)
        {
            return new Function<IFunc<T, MyEnumerable<U>>, MyEnumerable<U>>(_f =>
            {
                List<U> list = new List<U>();
                foreach(T t in val)
                {
                    MyEnumerable<U> _u = _f.Evaluate(t);
                    foreach(U u in _u)
                    {
                        list.Add(u);
                    }
                }

                return new MyEnumerable<U>(list);
            });
        }

        IFunc<IFunc<T, IMonad<U>>, IMonad<U>> IMonad<T>.Bind<U>(IMonad<T> val)
        {
            return (IFunc<IFunc<T, IMonad<U>>, IMonad<U>>)Bind<U>((MyEnumerable<T>)val);
        }

        public IFunc<MyEnumerable<T>, MyEnumerable<U>> FMap<U>(IFunc<T, U> func)
        {
            return new Function<MyEnumerable<T>, MyEnumerable<U>>(_t =>
            {
                List<U> u = new List<U>();

                foreach (T t in _t)
                    u.Add(func.Evaluate(t));

                return new MyEnumerable<U>(u);
            });
        }

        IFunc<IFunctor<T>, IFunctor<U>> IFunctor<T>.FMap<U>(IFunc<T, U> func)
        {
            return (IFunc < IFunctor<T>, IFunctor < U >> )FMap(func);
        }

        public MyEnumerable<T> Pure(T val)
        {
            return new MyEnumerable<T>(new T[] { val });
        }

        IApplicative<T> IApplicative<T>.Pure(T val) { return Pure(val); }

        IFunc<MyEnumerable<T>, MyEnumerable<U>> Lift<U>(MyEnumerable<IFunc<T, U>> func)
        {
            return new Function<MyEnumerable<T>, MyEnumerable<U>>(_t =>
            {
                U[] list = new U[func.Count() * _t.Count()];
                int index = 0;
                foreach(IFunc<T, U> f in func)
                {
                    foreach(T t in _t)
                    {
                        list[index++] = f.Evaluate(t);
                    }
                }

                return new MyEnumerable<U>(list);
            });
        }

        IFunc<IApplicative<T>, IApplicative<U>> IApplicative<T>.Lift<U>(IApplicative<IFunc<T, U>> func)
        {
            return (IFunc<IApplicative<T>, IApplicative<U>>)Lift<U>((MyEnumerable<IFunc<T, U>>)func);
        }
    }

    public class MyNullable<T> : IFunctor<T>
    {
        private readonly bool m_HasValue;
        private readonly T m_Value;

        public MyNullable() { }

        public MyNullable(T value)
        {
            m_Value = value;
            m_HasValue = true;
        }

        public bool HasValue { get { return m_HasValue; } }

        public T Value { get { if (m_HasValue) return m_Value; else throw new InvalidOperationException(); } }

        public IFunc<MyNullable<T>, MyNullable<U>> FMap<U>(IFunc<T, U> func)
        {
            return new Function<MyNullable<T>, MyNullable<U>>(t =>
            {
                if (t.HasValue)
                    return new MyNullable<U>(func.Evaluate(t.Value));
                else return new MyNullable<U>();
            });
        }

        IFunc<IFunctor<T>, IFunctor<U>> IFunctor<T>.FMap<U>(IFunc<T, U> func)
        {
            return (IFunc < IFunctor<T>, IFunctor < U >> )FMap((Function<T, U>)func);
        }
    }
}
