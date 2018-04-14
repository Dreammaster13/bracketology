using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace FOOTBALL
{
	public static class WebUtility
	{
		public static string GetWebpage(string Url, Encoding encoding)
		{
			HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Url);
			myRequest.Method = "GET";
			WebResponse myResponse;
			bool done = false;
			string result = "";
			int count = 0;
			do
			{
				try
				{
					done = false;
					myResponse = myRequest.GetResponse();
					System.IO.StreamReader sr = new System.IO.StreamReader(myResponse.GetResponseStream(), encoding);
					result = sr.ReadToEnd();
					sr.Close();
					myResponse.Close();
					done = true;
				}
				catch
				{
					count++;
				}
			} while (!done && count < 5);
			return result;
		}

        public static string GetWebpage(string Url)
        {
            return GetWebpage(Url, Encoding.UTF8);
        }

		public static Uri GetURL()
		{
            return new Uri(@"http://basketball.realgm.com/ncaa/teams");
            //return new Uri(@"http://espn.go.com/college-football/teams");
            //return new Uri(@"http://espn.go.com/mens-college-basketball/teams");
            //return new Uri(@"http://espn.go.com/nba/teams");
        }

        public static Uri GetNflURL()
        {

            return new Uri(@"http://espn.go.com/nfl/teams");
        }

		public static Uri GetBackupURL()
		{
			return GetURL();

		}

		public static string Format(string s)
		{

			if (string.IsNullOrEmpty(s)) return s;
			StringBuilder t = new StringBuilder(s.Length);
			// int last_space = 0;
			t.Append(ToUpper(s[0]));
			for (int c = 1; c < s.Length; c++)
			{
				int i = s.IndexOf(' ', c) - c;
				if ((s[c - 1] == ' ') && ((i > 3) || ((i < 0) && (c + 3 < s.Length))))
					t.Append(ToUpper(s[c]));
				else t.Append(s[c]);
			}

			return t.ToString();
		}

		public static char ToUpper(char c)
		{
			return ((c >= 'a') && (c <= 'z') ? (char)(c & 0xDF) : c);
		}
	}
}
