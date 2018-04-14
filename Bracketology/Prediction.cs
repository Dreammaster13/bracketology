using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOTBALL
{
    public static class Prediction
    {
        public static double[] CorrelateByElement(IEnumerable<double[]> statistics, IEnumerable<double[]> comparators)
        {
            int i = 0;
            double[] list = new double[statistics.Count()];
            IEnumerator<double[]> s = statistics.GetEnumerator();
            IEnumerator<double[]> c = comparators.GetEnumerator();
            while(s.MoveNext() && c.MoveNext())
            {
                list[i++] = (s.Current.Correlation(c.Current));
            }

            return list;
        }

        public static double CorrelateOverSet(IEnumerable<double[]> statistics, IEnumerable<double[]> comparators)
        {
            return Probability.E(CorrelateByElement(statistics, comparators));
        }

    }
}
