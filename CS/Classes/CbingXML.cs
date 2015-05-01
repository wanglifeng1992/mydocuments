using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Xml;
using System.Windows.Forms ;

namespace Solution
{
    public class CbingXML
    {
        // Replace the following string with the AppId you received from the
        // Bing Developer Center.
        const string AppId = "32D4F01F4D94D7098D1529E13F87553B30DBE8FB";
        public static HttpWebResponse xml_result;

        public  void bingSearchXML(string sKey)
        {
            HttpWebRequest request = BuildRequest(sKey);

            try
            {
                // Send the request; display the response.
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                xml_result = response ;

                //DisplayResponse(response);
            }
            catch (WebException ex)
            {
                // An exception occurred while accessing the network.
             MessageBox .Show  (ex.Message);
            }

        }

        static HttpWebRequest BuildRequest(string sKey)
        {
            string requestString = "http://api.bing.net/xml.aspx?"

                // Common request fields (required)
                + "AppId=" + AppId
                + "&Query=" + sKey 
                + "&Sources=Web"

                // Common request fields (optional)
                + "&Version=2.0"
                + "&Market=zh-CN"
                + "&Adult=Moderate"
                + "&Options=EnableHighlighting"

                // Web-specific request fields (optional)
                + "&Web.Count=10"
                + "&Web.Offset=0"
                + "&Web.Options=DisableHostCollapsing+DisableQueryAlterations";

            // Create and initialize the request.
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(
                requestString);

            return request;
        }

        static void DisplayResponse(HttpWebResponse response)
        {
            // Load the response into an XmlDocument.
            XmlDocument document = new XmlDocument();
            document.Load(response.GetResponseStream());

            // Add the default namespace to the namespace manager.
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(
                document.NameTable);
            nsmgr.AddNamespace(
                "api",
                "http://schemas.microsoft.com/LiveSearch/2008/04/XML/element");

            XmlNodeList errors = document.DocumentElement.SelectNodes(
                "./api:Errors/api:Error",
                nsmgr);

            if (errors.Count > 0)
            {
                // There are errors in the response. Display error details.
                DisplayErrors(errors);
            }
            else
            {
                // There were no errors in the response. Display the
                // Web results.
                DisplayResults(document.DocumentElement, nsmgr);
            }
        }

        static void DisplayResults(XmlNode root, XmlNamespaceManager nsmgr)
        {
            // Add the Web SourceType namespace to the namespace manager.
            nsmgr.AddNamespace(
                "web",
                "http://schemas.microsoft.com/LiveSearch/2008/04/XML/web");

            XmlNode web = root.SelectSingleNode("./web:Web", nsmgr);
            XmlNodeList results = web.SelectNodes(
                "./web:Results/web:WebResult",
                nsmgr);

            string version = root.SelectSingleNode("./@Version", nsmgr).InnerText;
            string searchTerms = root.SelectSingleNode(
                "./api:Query/api:SearchTerms",
                nsmgr).InnerText;
            int offset;
            int.TryParse(
                web.SelectSingleNode("./web:Offset", nsmgr).InnerText,
                out offset);
            int total;
            int.TryParse(
                web.SelectSingleNode("./web:Total", nsmgr).InnerText,
                out total);

            // Display the results header.
            Console.WriteLine("Bing API Version " + version);
            Console.WriteLine("Web results for " + searchTerms);
            Console.WriteLine(
                "Displaying {0} to {1} of {2} results",
                offset + 1,
                offset + results.Count,
                total);
            Console.WriteLine();

            // Display the Web results.
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            foreach (XmlNode result in results)
            {
                builder.Length = 0;
                builder.AppendLine(
                    result.SelectSingleNode("./web:Title", nsmgr).InnerText);
                builder.AppendLine(
                    result.SelectSingleNode("./web:Url", nsmgr).InnerText);
                builder.AppendLine(
                    result.SelectSingleNode("./web:Description", nsmgr).InnerText);
                builder.Append("Last Crawled: ");
                builder.AppendLine(
                    result.SelectSingleNode("./web:DateTime", nsmgr).InnerText);

                DisplayTextWithHighlighting(builder.ToString());
                Console.WriteLine();
            }
        }

        static void DisplayTextWithHighlighting(string text)
        {
            // Write text to the standard output stream, changing the console
            // foreground color as highlighting characters are encountered.
            foreach (char c in text.ToCharArray())
            {
                if (c == '\uE000')
                {
                    // If the current character is the begin highlighting
                    // character (U+E000), change the console foreground color
                    // to green.
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (c == '\uE001')
                {
                    // If the current character is the end highlighting
                    // character (U+E001), revert the console foreground color
                    // to gray.
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.Write(c);
                }
            }
        }

        static void DisplayErrors(XmlNodeList errors)
        {
            // Iterate over the list of errors and display error details.
            Console.WriteLine("Errors:");
            Console.WriteLine();
            foreach (XmlNode error in errors)
            {
                foreach (XmlNode detail in error.ChildNodes)
                {
                    Console.WriteLine(detail.Name + ": " + detail.InnerText);
                }

                Console.WriteLine();
            }
        }

    }
}
