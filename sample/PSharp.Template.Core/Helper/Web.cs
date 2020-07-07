using System;
using System.Collections.Generic;
using System.Text;

namespace PSharp.Template.Core.Helper
{
    public static class Web
    {
        public static string GetHttpAndHost()
        {
            return Util.Helpers.Web.Request.IsHttps ? "https://" : "http://" + Util.Helpers.Web.Request.Host.Value + "/";
        }

        public static string GetAbsoluteUri()
        {
            var request = Util.Helpers.Web.Request;

            return new StringBuilder()
                .Append(request.Scheme)
                .Append("://")
                .Append(request.Host)
                .Append(request.PathBase)
                .Append(request.Path)
                .Append(request.QueryString)
                .ToString();
        }
    }
}
