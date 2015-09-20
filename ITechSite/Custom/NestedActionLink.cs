using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ITechSite.Custom
{
    public static partial class HtmlHelperExtensions
    {
        public static IHtmlString ActionLinkGlyphicon(this HtmlHelper htmlHelper,
                                                     string linkText,
                                                     string actionName,
                                                     string controllerName,
                                                     object routeValues,
                                                     object htmlAttributes,
                                                     string glyphicon)
        {
            var l = SpanGlyphiconString(htmlHelper, "", glyphicon);
            return ActionLinkNoEncode(htmlHelper, l + linkText, actionName, controllerName, routeValues, htmlAttributes);
        }

        public static IHtmlString ActionLinkGlyphicon(this HtmlHelper htmlHelper,
                                                    string linkText,
                                                    string actionName,
                                                    string controllerName,
                                                    object htmlAttributes,
                                                    string glyphicon)
        {
            var l = SpanGlyphiconString(htmlHelper, "", glyphicon);
            return ActionLinkNoEncode(htmlHelper, l + linkText, actionName, controllerName, htmlAttributes);
        }

        public static IHtmlString ActionLinkGlyphicon(this HtmlHelper htmlHelper,
                                                    string linkText,
                                                    string actionName,
                                                    object routeValues,
                                                    string glyphicon)
        {
            var l = SpanGlyphiconString(htmlHelper, "", glyphicon);
            return ActionLinkNoEncode(htmlHelper, l + linkText, actionName, routeValues,null);
        }

        public static IHtmlString ActionLinkNoEncode(this HtmlHelper htmlHelper, string linkText, string action, object htmlAttributes)
        {
            TagBuilder builder;
            UrlHelper urlHelper;
            urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            builder = new TagBuilder("a");
            builder.InnerHtml = linkText;
            builder.Attributes["href"] = urlHelper.Action(action);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return MvcHtmlString.Create(builder.ToString());
        }

        public static MvcHtmlString ActionLinkNoEncode(this HtmlHelper htmlHelper,
                                                     string linkText,
                                                     string actionName,
                                                     object routeValues,
                                                     object htmlAttributes)
        {
            TagBuilder builder;
            UrlHelper urlHelper;
            urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            builder = new TagBuilder("a");
            builder.InnerHtml = linkText;
            builder.Attributes["href"] = urlHelper.Action(actionName, routeValues);
            if (htmlAttributes != null)
            {
                builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            }
            return MvcHtmlString.Create(builder.ToString());
        }

        public static MvcHtmlString ActionLinkNoEncode(this HtmlHelper htmlHelper,
                                                     string linkText,
                                                     string actionName,
                                                     string controllerName,
                                                     object routeValues,
                                                     object htmlAttributes)
        {
            TagBuilder builder;
            UrlHelper urlHelper;
            urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            builder = new TagBuilder("a");
            builder.InnerHtml = linkText;
            builder.Attributes["href"] = urlHelper.Action(actionName, controllerName, routeValues);
            if (htmlAttributes != null)
            {
                builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            }
            return MvcHtmlString.Create(builder.ToString());
        }




        public static string SpanGlyphiconString(this HtmlHelper htmlHelper, string Text, string glyphicon)
        {
            return SpanGlyphicon(htmlHelper, Text, glyphicon).ToString();
        }
        public static IHtmlString SpanGlyphicon(this HtmlHelper htmlHelper, string Text, string glyphicon)
        {
            //string span = "<span class='glyphicon glyphicon-name'></span>";
            TagBuilder builder;
            UrlHelper urlHelper;
            urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            builder = new TagBuilder("span");
            builder.InnerHtml = Text;
            builder.AddCssClass("glyphicon");
            builder.AddCssClass(glyphicon);

            return MvcHtmlString.Create(builder.ToString());
        }
    }
}