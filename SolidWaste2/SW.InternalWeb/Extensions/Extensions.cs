﻿using Microsoft.AspNetCore.Html;
using PE.DM;
using System.Text;

namespace SW.InternalWeb.Extensions;

public static class Extensions
{

    public static string FormatAddress(this Address a)
    {
        if (a == null)
            return "";

        var sb = new StringBuilder();
        if (a.StreetName == "PO BOX" && a.Number.HasValue)
        {
            sb.Append("PO BOX ").Append(a.Number.Value);
        }
        else
        {
            if (a.Number.HasValue && a.Number.Value > 0)
                sb.Append(a.Number.Value);
            if (!string.IsNullOrWhiteSpace(a.Direction))
                sb.Append(" ").Append(a.Direction);
            if (!string.IsNullOrWhiteSpace(a.StreetName))
                sb.Append(" ").Append(a.StreetName);
            if (!string.IsNullOrWhiteSpace(a.Suffix))
                sb.Append(" ").Append(a.Suffix);
            if (!string.IsNullOrWhiteSpace(a.Apt))
                sb.Append(" ").Append(a.Apt);
        }
        return sb.ToString().Trim();
    }

    public static HtmlString FormatMultiLine(this string str)
    {
        var sb = new StringBuilder();
        if (!string.IsNullOrWhiteSpace(str))
        {
            var stream = new System.IO.StringReader(str);
            string temp;
            bool first = true;
            while ((temp = stream.ReadLine()) != null)
            {
                if (first)
                    first = false;
                else
                    sb.Append("<br />");
                sb.Append(System.Net.WebUtility.HtmlEncode(temp));
            }
        }
        return new HtmlString(sb.ToString());
    }

    public static string Ellipsis(this string self, int length)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < length && i < self.Length; i++)
            sb.Append(self[i]);

        if (sb.Length >= length)
            sb.Append("...");

        return sb.ToString();
    }

    public static bool IsAjaxRequest(this HttpRequest request)
    {
        if (request == null)
        {
            throw new ArgumentNullException("request");
        }

        //return (request["X-Requested-With"] == "XMLHttpRequest") || ((request.Headers != null) && (request.Headers["X-Requested-With"] == "XMLHttpRequest"))
        return request.Headers["X-Requested-With"] == "XMLHttpRequest";
    }

    public static void AddXAlertMessage(this HttpResponse response, string message)
    {
        if (response == null)
            return;

        response.Headers.TryAdd("X-Alert-Message", message);
    }
}
