using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PerManagerSystem.Admin.Core
{
    public static class ExtendMvcHtml
    {
        public static MvcHtmlString ToolButton(this HtmlHelper helper, string id, string icon, string text, bool hr) 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<a href=\"javascript:void(0);\" style=\"float:left\" class=\"l-btn l-btn-small l-btn-plain\" id=\"{0}\" >", id);
            sb.AppendFormat("<span class=\"l-btn-left l-btn-icon-left\">");
            sb.AppendFormat(" <span class=\"l-btn-text\">");
            sb.AppendFormat("{0}", text);
            sb.AppendFormat("</span>");
            sb.AppendFormat(" <span class=\"l-btn-icon {0}\">&nbsp;</span>", icon);
            sb.AppendFormat("</span>");
            sb.AppendFormat(" </a>");
            sb.AppendFormat("<div class=\"datagrid-btn-separator\"></div>");
            return new MvcHtmlString(sb.ToString());
        }
        public static MvcHtmlString ToolButton(this HtmlHelper helper, string id, string icon, string text,List<string> permList,string keyCode,bool hr)
        {
            if (permList.Where(x => x.ToLower() == keyCode.ToLower()).Count() > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("<a href=\"javascript:void(0);\" style=\"float:left\" class=\"l-btn l-btn-small l-btn-plain\" id=\"{0}\" >", id);
                sb.AppendFormat("<span class=\"l-btn-left l-btn-icon-left\">");
                sb.AppendFormat(" <span class=\"l-btn-text\">");
                sb.AppendFormat("{0}", text);
                sb.AppendFormat("</span>");
                sb.AppendFormat(" <span class=\"l-btn-icon {0}\">&nbsp;</span>", icon);
                sb.AppendFormat("</span>");
                sb.AppendFormat(" </a>");
                if (hr)
                {
                    sb.AppendFormat("<div class=\"datagrid-btn-separator\"></div>");
                }               
                return new MvcHtmlString(sb.ToString());
            }
            else
            {
                return new MvcHtmlString(""); 
            }
            
        }
    }
}