using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOTBALL
{
    class HtmlIterator
    {
        private int m_Start, m_End;

        public int StartIndex { get { return m_Start; } set { m_Start = value; if (m_Start > m_End) m_End = m_Start; } }
        public int EndIndex { get { return m_End; } set { m_End = value; if (m_Start > m_End) m_Start = m_End; } }

        private string m_Html;

        public string HTML { get { return m_Html; } }

        public string Selection {  get { if (m_Html != null) { if (m_Start >= m_End) return ""; return m_Html.Substring(m_Start, m_End - m_Start); } else return ""; } }

        public string Substring {  get { return m_Html.Substring(m_Start); } }
        public HtmlIterator(string Url)
        {
            //    m_Start = 0; m_End = 0;
            //    string fileUrl = Url.Replace('.', '-').Replace('/', '-').Replace(':','-');
            //   if (!System.IO.File.Exists(@"C:\Users\Dustin\FOOTBALL\" + fileUrl + ".football"))
            //   {
            m_Html = WebUtility.GetWebpage(Url); //.Replace('\"', '\'');
          //      using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"C:\Users\Dustin\FOOTBALL\" + fileUrl + ".football"))
         //           sw.Write(m_Html);
            //}
            //else
            //{
            //    using (System.IO.StreamReader sr = new System.IO.StreamReader(@"C:\Users\Dustin\FOOTBALL\" + fileUrl + ".football"))
            //        m_Html = sr.ReadToEnd();
            //}
        }

        public bool SetStart(int index)
        {
            if (m_Html == null) return false;
            if (index >= m_Html.Length) return false;

            m_Start = index;

            if (m_Start > m_End) m_End = m_Start;

            return true;
        }

        public bool SetEnd(int index)
        {
            if (m_Html == null) return false;
            if (index >= m_Html.Length) return false;

            m_End = index;

            if (m_Start > m_End) m_Start = m_End;

            return true;
        }

        public bool GetNext(string pattern)
        {
            int index = 0;

            if (m_Html == null) return false;

            index = m_Html.IndexOf(pattern, m_End);

            if (index == -1) return false;

            m_Start = index;

            m_End = index + pattern.Length;

            return true;
        }

        public bool GetPrevious(string pattern)
        {
            int index = 0;

            if (m_Html == null) return false;

            index = m_Html.LastIndexOf(pattern, m_Start);

            if (index == -1) return false;

            m_Start = index;

            m_End = index + pattern.Length;

            return true;
        }

        public bool ExtendToBeginningOfNext(string pattern)
        {
            int index = 0;

            if (m_Html == null) return false;

            index = m_Html.IndexOf(pattern, m_End);

            if (index == -1) return false;

            m_End = index;

            return true;
        }

        public bool ExtendToBeginningOfPrevious(string pattern)
        {
            int index = 0;

            if (m_Html == null) return false;

            index = m_Html.LastIndexOf(pattern, m_Start);

            if (index == -1) return false;

            m_Start = index;

            return true;
        }

        public bool ExtendToEndOfNext(string pattern)
        {
            int index = 0;

            if (m_Html == null) return false;

            index = m_Html.IndexOf(pattern, m_End);

            if (index == -1) return false;

            m_End = index + pattern.Length;

            return true;
        }

        public bool ExtendToEndOfPrevious(string pattern)
        {
            int index = 0;

            if (m_Html == null) return false;

            index = m_Html.LastIndexOf(pattern, m_Start);

            if (index == -1) return false;

            m_Start = index + pattern.Length;

            return true;
        }

        public string GetNextValue()
        {
            if (!GetNext(">")) return null;
            m_Start = m_End;
            string delimiter = GetNextDelimiter();
            if (!ExtendToBeginningOfNext(delimiter)) return null;

            if (m_End <= m_Start)
            {
                m_End = m_Start;
                return "";
            }

            return this.Selection;
        }

        public string GetNextAttributeValue(string attribute)
        {
            string delimiter = GetNextDelimiter();
            if (!GetNext(attribute + "=" + delimiter)) return null;
            m_Start = m_End;
            if (!ExtendToBeginningOfNext(delimiter)) return null;

            if (m_End <= m_Start)
            {
                m_End = m_Start;
                return "";
            }

            return this.Selection;
        }

        public string GetNextTagText(string tag)
        {
            if (!GetNext("<" + tag)) return null;
            if (!GetNext(">")) return null;
            m_Start = m_End;
            if (!ExtendToBeginningOfNext("</" + tag)) return null;

            if (m_End <= m_Start)
            {
                m_End = m_Start;
                return "";
            }

            return this.Selection;
        }

        private string GetNextDelimiter()
        {
            int index = (int)Math.Min((uint)m_Html.IndexOf("\'", m_End), (uint)m_Html.IndexOf("\"", m_End));
            if (index >= 0 && index < m_Html.Length)
                return m_Html[index].ToString();
            else return "\'";
        }
    }
}
