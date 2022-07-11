using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tohou_Project.Extensions
{
    public static class ImgHelper
    {
        public static HtmlString CreateImage(this IHtmlHelper html, string str,int width,int height)
        {
            char symbol = '"';
            string result = $"<img src={symbol}{str}{symbol} width={symbol}{width}{symbol} height={symbol}{height}{symbol} style={symbol}float: left{symbol}; alt={symbol}Image not found{symbol} />";
            return new HtmlString(result);
        }
    }
}
