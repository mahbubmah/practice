using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace TulaTreeMvc.CustomClass
{
    public class MvcExtentions
    {
    }
}

namespace System.Web.Mvc.Html
{
    //class for chk requitred field and add * afert it
    public static class ChqHtmlHelperExtensions
    {
        public static MvcHtmlString ChqLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string resolvedLabelText = metadata.DisplayName ?? metadata.PropertyName;
            if (metadata.IsRequired)
            {
                resolvedLabelText += "*";
            }
            return LabelExtensions.LabelFor<TModel, TValue>(html, expression, resolvedLabelText, htmlAttributes);
        }
    }
}