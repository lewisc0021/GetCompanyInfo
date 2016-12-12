using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GetGraphTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string Symbol = Console.ReadLine();
            WebRequest request = WebRequest.Create("https://query2.finance.yahoo.com/v10/finance/quoteSummary/"+Symbol+"?modules=assetProfile");
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            string html = String.Empty;
            using (StreamReader sr = new StreamReader(data))
            {
                html = sr.ReadToEnd();
            }
            //Console.WriteLine(html);
            string start = "longBusinessSummary";
            string end = "fullTimeEmployees";
            string paragraph = getBetween(html, start, end);
            string paragraphTrimmed = paragraph.Substring(2,paragraph.Length-4);
            Console.WriteLine(paragraphTrimmed);

        }//MAIN
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "Description Not Found";
            }
        
    }
  
    }//PROGAM
    }//N.S.

