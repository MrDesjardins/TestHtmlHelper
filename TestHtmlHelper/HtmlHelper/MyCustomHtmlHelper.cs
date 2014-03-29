using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace TestHtmlHelper.HtmlHelper
{
    public static class MyCustomHtmlHelper
    {
        public static MvcHtmlString MyFirstHelper(this System.Web.Mvc.HtmlHelper htmlHelper)
        {
            return new MvcHtmlString("<p>Test</p>");
        }

        public static MvcHtmlString YourGenericHelperFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var propertyName = metadata.PropertyName;
            var value = metadata.Model;
            return new MvcHtmlString(string.Format("<h1>{0}</h1><p>{1}</p>", propertyName, value));
        }

        public static MvcHtmlString YourGenericHelperPropertyConstructedFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            //Get values
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var propertyName = metadata.PropertyName;
            var value = metadata.Model;
            //Html Construction
            var header = new TagBuilder("h1") {InnerHtml = propertyName};
            var paragraph = new TagBuilder("p") {InnerHtml = value.ToString()};
            return new MvcHtmlString(header.ToString() + paragraph);
        }

        public static HtmlHelper<object> GetPageHelper(this System.Web.WebPages.Html.HtmlHelper html)
        {
            return ((System.Web.Mvc.WebViewPage)WebPageContext.Current.Page).Html;
        }
    }
}