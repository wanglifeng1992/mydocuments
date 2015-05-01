using System;
using System.Collections.Generic;
using System.Text;
using Google.API.Search;

namespace Solution
{
    public class CgoogleAPI
    {
        public  IList<IWebResult> list_result;

        public void googleSearchAPI(string sKey)
        {
            //bing APID: 32D4F01F4D94D7098D1529E13F87553B30DBE8FB
            // Search 32 results of keyword : "Google APIs for .NET"
            GwebSearchClient client = new GwebSearchClient("http://www.google.co.uk/");
            IList<IWebResult> results = client.Search(sKey, 10);
            list_result = results;
            /*
             foreach (IWebResult result in results)
             {
                 Console.WriteLine("[{0}]\r\n {1}\r\n => {2}", result.Title, result.Content, result.Url);
             }
             */
        }
    }
}
