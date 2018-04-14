using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOTBALL
{
    public delegate T Evaluator<T>(T t1, T t2);
    public delegate U FieldEvaluator<T, U>(U u, T t);

    public static class IEnumerableExtension
    {
        public static T[] SubList<T>(this T[] list, int startIndex)
        {
            return SubList(list, startIndex, list.Length - startIndex);
        }

        public static T[] SubList<T>(this T[] list, int startIndex, int count)
        {
            if (startIndex < 0) startIndex = 0;
            if (startIndex + count > list.Length) count = list.Length - startIndex;

            T[] newList = new T[count];

            for (int k = 0; k < count; k++)
                newList[k] = list[startIndex + k];

            return newList;
        }

        public static T[] Intersperse<T>(this T[] list, T intersperser)
        {
            int len = list.Length - 1;
            T[] newList = new T[2 * len + 1];
            for (int k = 0; k < len; k++)
            {
                newList[2 * k] = list[k];
                newList[2 * k + 1] = intersperser;
            }
            newList[2 * len] = list[len];

            return newList;
        }

        public static T FoldLeft<T>(this IEnumerable<T> list, T accumulator, Evaluator<T> func)
        {
            return foldl(list.GetEnumerator(), accumulator, func);
        }

        private static T foldl<T>(IEnumerator<T> list, T accumulator, Evaluator<T> func)
        {
            if (list.MoveNext())
            {
                return foldl(list, func(accumulator, list.Current), func);
            }
            else
            {
                return accumulator;
            }
        }

        public static T FoldRight<T>(this IEnumerable<T> list, T accumulator, Evaluator<T> func)
        {
            return foldr(list.GetEnumerator(), accumulator, func);
        }

        private static T foldr<T>(IEnumerator<T> list, T accumulator, Evaluator<T> func)
        {
            if (list.MoveNext())
            {
                return func(list.Current, foldr(list, accumulator, func));
            }
            else
            {
                return accumulator;
            }
        }

        public static U FieldFoldLeft<T, U>(this IEnumerable<T> list, U accumulator, FieldEvaluator<T, U> func)
        {
            return ffoldl(list.GetEnumerator(), accumulator, func);
        }

        private static U ffoldl<T, U>(IEnumerator<T> list, U accumulator, FieldEvaluator<T, U> func)
        {
            if (list.MoveNext())
            {
                return ffoldl(list, func(accumulator, list.Current), func);
            }
            else
            {
                return accumulator;
            }
        }

        public static U FieldFoldRight<T, U>(this IEnumerable<T> list, U accumulator, FieldEvaluator<T, U> func)
        {
            return ffoldr(list.GetEnumerator(), accumulator, func);
        }

        private static U ffoldr<T, U>(IEnumerator<T> list, U accumulator, FieldEvaluator<T, U> func)
        {
            if (list.MoveNext())
            {
                T t = list.Current;
                return func(ffoldr(list, accumulator, func), t);
            }
            else
            {
                return accumulator;
            }
        }
    }
}
