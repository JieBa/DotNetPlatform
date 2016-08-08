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
    public class CityListInfo
    {
        public string Timestamp { get; set; }
        public string Html { get; set; }
    }
    public partial class CitiesControl : System.Web.UI.UserControl
    {
        private static readonly string _fileName = "/CitiesList.html";
        private static readonly string _cache_key = "cities_html";
        private CityListInfo cityInfo;
        private bool cached = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            cityInfo=Cache[_cache_key] as CityListInfo;
            if (cityInfo == null)
            {
                cityInfo=new CityListInfo() {Timestamp = DateTime.Now.ToLongTimeString(),Html = File.ReadAllText(MapPath(_fileName))};
                Cache.Insert(_cache_key,cityInfo,new CacheDependency(MapPath(_fileName)));
            }
            else
            {
                cached = true;
            }
        }

        public string GetCities()
        {
            //return File.ReadAllText(MapPath(_fileName));
            return cityInfo.Html;
        }

        protected string GetTimeStamp()
        {
            //return DateTime.Now.ToLongTimeString();
            return cityInfo.Timestamp + (cached ? "<b>Cached</b>" : "");
        }
    }
}