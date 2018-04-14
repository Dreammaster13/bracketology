using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOTBALL
{
    public delegate double FitnessEvaluator(double[] parameters);

    public class GeneticAlgorithm
    {
        public FitnessEvaluator Evaluate;

        public event EventHandler GenerationCompleted;

        private List<double[]> m_Chromosomes;

        private Random m_Rand;
        
        public int NumRuns { get; set; }
        public int NumOffspring { get; set; }
        public double AdvancementPercentage { get { return 1 / (double)NumOffspring; } }

        private double randRange;

        public Tuple<double[], double> BestChromosome;

        public GeneticAlgorithm()
        {
            m_Chromosomes = new List<double[]>();
            m_Rand = new Random();
            NumRuns = 100;
            NumOffspring = 10;
            randRange = 1;
        }

        public void Run(int number, double rand_radius)
        {
            double[] ancestor = new double[number];
            for (int z = 0; z < ancestor.Length; z++)
                ancestor[z] = 0.5;
            m_Chromosomes.Add(ancestor);
            GenerateOffspring();
            randRange = rand_radius;
            for (int k=0;k<NumRuns;k++)
            {
                GenerateOffspring();
                KillTheWeak();
                if (GenerationCompleted != null)
                    GenerationCompleted(this, EventArgs.Empty);
            }
        }

        private void GenerateOffspring()
        {
            List<double[]> new_list = new List<double[]>();
            foreach(double[] list in m_Chromosomes)
            {
                for (int i = 0; i < NumOffspring; i++)
                {
                    double[] d = new double[list.Length];
                    for (int j = 0; j < list.Length; j++)
                    {
                        d[j] = list[j] + (2*m_Rand.NextDouble() - 1) * randRange;
                       // if (d[j] < -1) d[j] = 0;
                       // else if (d[j] > 1) d[j] = 1;
                    }
                    new_list.Add(d);
                }
            }
            m_Chromosomes = new_list;
        }

        private List<Tuple<double[], double>> fitList = new List<Tuple<double[], double>>();
        private object lockobj = new object();

        private void KillTheWeak()
        {
            if (Evaluate != null)
            {
                fitList.Clear();
                foreach (double[] d in m_Chromosomes)
                {
                    System.Threading.Thread nThread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(run_nthread));
                    nThread.Start(d);
                }

                while (fitList.Count < this.m_Chromosomes.Count) ;
                fitList.Sort((pairA, pairB) => pairA.Item2.CompareTo(pairB.Item2));
                m_Chromosomes.Clear();
                for (int k = (int)((1 - AdvancementPercentage) * fitList.Count); k < fitList.Count; k++)
                    m_Chromosomes.Add(fitList[k].Item1);

                if (BestChromosome != null && BestChromosome.Item2 < fitList[fitList.Count - 1].Item2)
                    BestChromosome = fitList[fitList.Count - 1];
                else if (BestChromosome == null)
                    BestChromosome = fitList[fitList.Count - 1];
            }
        }

        private void run_nthread(object o)
        {
            double d = Evaluate((double[])o);
            lock(lockobj)
            {
                fitList.Add(new Tuple<double[], double>((double[])o, d));
            }
        }

    }
}
