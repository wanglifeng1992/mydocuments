using System;
using System.Collections.Generic;
using System.Text;

namespace Solution
{
    public class SearchResult
    {
        public string url;
        public string title;
        public string content;
        public FindingEngine engine;
        public enum FindingEngine { google, bing, google_and_bing };
        public SearchResult(string url, string title, string content, FindingEngine engine)
        {
            this.url = url;
            this.title = title;
            this.content = content;
            this.engine = engine;
        }
/*
        public static List<SearchResult> GoogleSearch(string search_expression, 
      Dictionary<string, object> stats_dict)
    {
      var url_template = @"http://ajax.googleapis.com/ajax/services/search/web?v=1.0&rsz=large \ 
        &safe=active&q={0}&start={1}";
      Uri search_url;
      var results_list = new List<SearchResult>();
      int[] offsets = { 0, 8, 16, 24, 32, 40, 48 };
      foreach (var offset in offsets)
      {
        search_url = new Uri(string.Format(url_template, search_expression, offset));
 
        var page = new WebClient().DownloadString(search_url);
 
        JObject o = (JObject)JsonConvert.DeserializeObject(page);
 
        var results_query =
          from result in o["responseData"]["results"].Children()
          select new SearchResult(
              url: result.Value<string>("url").ToString(),
              title: result.Value<string>("title").ToString(),
              content: result.Value<string>("content").ToString(),
              engine: SearchResult.FindingEngine.google
              );
 
        foreach (var result in results_query)
          results_list.Add(result);
      }
 
      return results_list;
    }


public static List<SearchResult> BingSearch(string search_expression, Dictionary<string, object> stats_dict)
    {
      var url_template = @"http://api.search.live.net/json.aspx?AppId=8F9B...1CF6&Market=en-US& \
        Sources=Web&Adult=Strict&Query={0}&Web.Count=50";
      var offset_template = "&Web.Offset={1}";
      var results_list = new List<SearchResult>();
      Uri search_url;
      int[] offsets = { 0, 50, 100, 150 };
      foreach (var offset in offsets)
      {
        if (offset == 0)
          search_url = new Uri(string.Format(url_template, search_expression));
        else
          search_url = new Uri(string.Format(url_template + offset_template, search_expression, offset));
 
        var page = new WebClient().DownloadString(search_url);
 
        JObject o = (JObject)JsonConvert.DeserializeObject(page);
 
        var results_query =
          from result in o["SearchResponse"]["Web"]["Results"].Children()
          select new SearchResult
              (
              url: result.Value<string>("Url").ToString(),
              title: result.Value<string>("Title").ToString(),
              content: result.Value<string>("Description").ToString(),
              engine: SearchResult.FindingEngine.bing
              );
 
        foreach (var result in results_query)
          results_list.Add(result);
      }
 
      return results_list;
    }
        */
    }
 
}
