using System;
using System.Xml;
//using Solution.net.bing.api;
using System.Windows.Forms;

namespace Solution
{
    public class CbingSOAP
    {
        // Replace the following string with the AppId you received from the
        // Bing Developer Center.
        const string AppId = "32D4F01F4D94D7098D1529E13F87553B30DBE8FB";
        public  SearchResponse    soap_result;

        public void bingSearchSOAP(string sKey)
        {
            // BingService implements IDisposable.
            using (BingService service = new BingService())
            {
                try
                {
                    SearchRequest request = BuildRequest(sKey);

                    // Send the request; display the response.
                    SearchResponse response = service.Search(request);
                    soap_result = response;

                    //DisplayResponse(response);
                }
                catch (System.Web.Services.Protocols.SoapException ex)
                {
                    // A SOAP Exception was thrown. Display error details.
                    //DisplayErrors(ex.Detail);
                    MessageBox.Show(ex.Message);
                }
                catch (System.Net.WebException ex)
                {
                    // An exception occurred while accessing the network.
                    MessageBox .Show (ex.Message);
                }
            }

        }

        static SearchRequest BuildRequest(string sKey)
        {
            SearchRequest request = new SearchRequest();

            // Common request fields (required)
            request.AppId = AppId;
            request.Query = sKey ;
            request.Sources = new SourceType[] { SourceType.Web };

            // Common request fields (optional)
            request.Version = "2.0";
            request.Market = "zh-CN";
            request.Adult = AdultOption.Moderate;
            request.AdultSpecified = true;
            request.Options = new SearchOption[]
        {
            SearchOption.EnableHighlighting
        };

            // Web-specific request fields (optional)
            request.Web = new WebRequest();
            request.Web.Count = 10;
            request.Web.CountSpecified = true;
            request.Web.Offset = 0;
            request.Web.OffsetSpecified = true;
            request.Web.Options = new WebSearchOption[]
        {
            WebSearchOption.DisableHostCollapsing,
            WebSearchOption.DisableQueryAlterations
        };

            return request;
        }

        static void DisplayResponse(SearchResponse response)
        {
            // Display the results header.
            Console.WriteLine("Bing API Version " + response.Version);
            Console.WriteLine("Web results for " + response.Query.SearchTerms);
            Console.WriteLine(
                "Displaying {0} to {1} of {2} results",
                response.Web.Offset + 1,
                response.Web.Offset + response.Web.Results.Length,
                response.Web.Total);

            // Display the Web results.
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            foreach (WebResult result in response.Web.Results)
            {
                builder.Length = 0;
                builder.AppendLine(result.Title);
                builder.AppendLine(result.Description);
                builder.AppendLine(result.Url);
                builder.Append("Last Crawled: ");
                builder.AppendLine(result.DateTime);

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

        static void DisplayErrors(XmlNode errorDetails)
        {
            // Add the default namespace to the namespace manager.
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(
                errorDetails.OwnerDocument.NameTable);
            nsmgr.AddNamespace(
                "api",
                "http://schemas.microsoft.com/LiveSearch/2008/03/Search");

            XmlNodeList errors = errorDetails.SelectNodes(
                "./api:Errors/api:Error",
                nsmgr);

            if (errors != null)
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
}
