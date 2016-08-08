using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Caching
{
    public partial class Default : System.Web.UI.Page
    {
        private static readonly string _cache_key = "code_behind_ts";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetTime()
        {
            string ts = (string) Cache[_cache_key];
            if (ts == null)
            {
                Cache[_cache_key] = ts = DateTime.Now.ToLongTimeString();
            }
            else
            {
                ts += "<b>(Cached)</b>";
            }
            return ts;
        }
    }
}