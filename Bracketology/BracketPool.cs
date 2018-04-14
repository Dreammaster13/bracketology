using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOTBALL
{
    class BracketPool
    {
        public const int NUMBRACKETS = 1000000;
        public UInt64[] Matrix;
        private int fetch;
        private System.Threading.Semaphore m_Sem;

        public BracketPool()
        {
            fetch = 0;
            Matrix = new UInt64[NUMBRACKETS];
            m_Sem = new System.Threading.Semaphore(100, 100);
        }

        public UInt64[] GetBrackets()
        {
            for(int k=0;k<NUMBRACKETS;k++)
            {
                m_Sem.WaitOne(System.Threading.Timeout.Infinite);
                System.Threading.Thread thr = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(_getsched));
                thr.Start(k);
                // _getsched((object)k);
            }

            while (fetch < NUMBRACKETS) ;

            return this.Matrix;
        }

        private void _getsched(object o)
        {
            int index = (int)o;
            // HtmlIterator h_team = new HtmlIterator(((Team)o).teamURL), h;
            //  HtmlIterator h = new HtmlIterator("http://espn.go.com/college-football/team/schedule/"+((Team)o).teamURL.Substring(((Team)o).teamURL.IndexOf('_')));
            HtmlIterator h = new HtmlIterator("http://games.espn.go.com/tournament-challenge-bracket/2016/en/entry?entryID="+(index+1).ToString());
            Matrix[index] = 0;
            UInt64 mask = 0x4000000000000000;
            while (h.GetNext("class=\"slots\""))
            {
                h.GetNext("<div");
                if (h.GetNextAttributeValue("class").Contains("userPickable"))
                {
                    //Hasn't happened yet
                    h.GetNext("<span class=\"picked");
                    h.EndIndex = h.StartIndex;
                    if (h.GetNextAttributeValue("class").Contains("selectedToAdvance"))
                    {
                        Matrix[index] |= mask;
                    }
                }
                else
                {
                    //Already happened
                    h.GetNext("<span");
                    if (h.GetNextAttributeValue("class").Contains("selectedToAdvance"))
                    {
                        Matrix[index] |= mask;
                    }
                }
                mask >>= 1;
            }
            if (mask != 0)
                Matrix[index] |= 0x8000000000000000;
            System.Threading.Interlocked.Increment(ref fetch);
            m_Sem.Release();
        }

        public void Serialize(string path)
        {
            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create);
            using (System.IO.BinaryWriter sw = new System.IO.BinaryWriter(fs))
            {
                foreach (UInt64 u in this.Matrix)
                {
                    sw.Write(u);
                }
            }

        }

        public void Deserialize(string path)
        {
            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open);
            using (System.IO.BinaryReader sw = new System.IO.BinaryReader(fs))
            {
                int count = 0;
                while (count < NUMBRACKETS && sw.BaseStream.Position < sw.BaseStream.Length)
                    Matrix[count++] = sw.ReadUInt64();
            }
        }

    }
}
