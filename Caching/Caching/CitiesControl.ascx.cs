using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Caching
{

    public partial class CitiesControl : System.Web.UI.UserControl
    {
        private static readonly string _fileName = "/CitiesList.html";
        private static readonly string _time_cache_key = "cities_time";
        private static readonly string _html_cache_key = "cities_html";
        private bool cached = false;
        
        public string GetCities()
        {
            string html = (string) Cache[_html_cache_key];
            if (html == null)
            {
                html = File.ReadAllText(MapPath(_fileName));
                Cache.Insert(_html_cache_key,html,new CacheDependency(MapPath(_fileName)));
            }
            else
            {
                cached = true;
            }
            return html;
        }

        protected string GetTimeStamp()
        {
            string timeStamp = (string) Cache[_time_cache_key];
            if (timeStamp == null)
            {
                timeStamp = DateTime.Now.ToShortTimeString();
                Cache.Insert(_time_cache_key,timeStamp,new CacheDependency(null,new[] {_html_cache_key}));
            }
            return timeStamp + (cached ? "<b>Cached</b>" : "");
        }
    }
}