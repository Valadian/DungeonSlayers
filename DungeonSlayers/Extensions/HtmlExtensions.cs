using DungeonSlayers.Models;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace DungeonSlayers.Extensions
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString AddOnEditorFor<TModel, TValue>(this HtmlHelper<TModel> Html, Expression<Func<TModel, TValue>> expr,
            string comptype = "editor", object choices = null, string label = null, int width = 80, string abbr = null, bool editable = true, bool multiple = false, int numShown = 3)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expr, Html.ViewData);
            string name = ExpressionHelper.GetExpressionText(expr);
            string id = HtmlHelper.GenerateIdFromName(name) ?? metaData.PropertyName;
            var body = new StringBuilder();
            var div = new TagBuilder("div");
            div.AddCssClass("input-group-addon");
            div.Attributes.Add("style", "min-width:" + width + "px;");
            label = label ?? Html.NameFor(expr).ToString();
            label += ":";
            if (abbr != null)
            {
                var abbrtag = new TagBuilder("abbr");
                abbrtag.Attributes.Add("title", abbr);
                abbrtag.InnerHtml = label;
                div.InnerHtml = abbrtag.ToString();
            }
            else
            {
                div.InnerHtml = label;
            }
            body.Append(div.ToString());
            switch (comptype.ToLower())
            {
                case "editor":
                    body.Append(Html.EditorFor(expr, new { htmlAttributes = new { @class = "form-control", @data_bind="value: "+name } }));
                    break;
                case "dropdown":
                    choices = choices ?? GetChoices(Html, Html.NameFor(expr).ToString());
                    body.Append(Html.DropDownListFor(expr, (IEnumerable<SelectListItem>)choices, new { @class = "form-control", @data_bind = "value: " + name }));
                    break;
                case "editabledropdown":
                    choices = choices ?? GetChoices(Html, Html.NameFor(expr).ToString());
                    body.Append(Html.EditorFor(expr, "EditableDropDown", new { SelectList = choices, editable = editable, multiple = multiple, numShown = numShown, exprText = name }));
                    break;
                case "koeditabledropdown":
                    body.Append(Html.EditorFor(expr, "KoEditableDropDown", new { editable = editable, multiple = multiple, numShown = numShown, exprText = name }));
                    break;
                default:
                    body.Append("comptype: '" + comptype + "' Invalid ");
                    break;
            }
            body.Append(Html.ValidationMessageFor(expr, "", new { @class = "text-danger" }));
            return new MvcHtmlString(body.ToString());
        }
        private static IEnumerable<SelectListItem> GetChoices(HtmlHelper Html, String propName)
        {
            //var propertyInfo = Html.ViewBag.GetType().GetProperty(propName+"Choices");
            //return (IEnumerable<SelectListItem>) propertyInfo.GetValue(Html.ViewBag, null);
            return GetDynamicMember(Html.ViewBag, propName + "Choices") as IEnumerable<SelectListItem>;
        }
        private static object GetDynamicMember(object obj, string memberName)
        {
            var binder = Binder.GetMember(CSharpBinderFlags.None, memberName, obj.GetType(),
                new[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) });
            var callsite = CallSite<Func<CallSite, object, object>>.Create(binder);
            return callsite.Target(callsite, obj);
        }
        public static MvcHtmlString AttributeEditorFor(this HtmlHelper<Character> Html, Expression<Func<Character, int>> expr,
            string labelText = null, bool attribute = false)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expr, Html.ViewData);
            var name = ExpressionHelper.GetExpressionText(expr);
            labelText = labelText ?? name;
            string id = HtmlHelper.GenerateIdFromName(name) ?? metaData.PropertyName;
            var body = new StringBuilder();

            var row = new TagBuilder("div");
            row.AddCssClass("row");
            if (attribute)
            {
                row.AddCssClass("attribute");
            }
            else
            {
                row.AddCssClass("trait");
            }
            var label = new TagBuilder("div");
            label.AddCssClass("col-xs-8");
            label.InnerHtml = labelText.ToUpper();

            var input = new TagBuilder("div");
            input.AddCssClass("col-xs-2");
            input.InnerHtml = Html.EditorFor(expr, new { htmlAttributes = new { @class = "form-control", data_bind = "value: base_"+name } }).ToString();

            var modifier = new TagBuilder("div");
            modifier.AddCssClass("col-xs-2");
            modifier.InnerHtml = "<span data-bind=\"visible: SumModifiersOfName('" + name + "')!=0,text: '+' + SumModifiersOfName('" + name+"')\"></span>";

            row.InnerHtml = label.ToString() + input.ToString() + modifier.ToString();



            body.Append(row);

            return new MvcHtmlString(body.ToString());
        }

        public static MvcHtmlString EditorForMany<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, IEnumerable<TValue>>> expression, string htmlFieldName = null) where TModel : class
        {
            var items = expression.Compile()(html.ViewData.Model);
            var sb = new StringBuilder();

            if (String.IsNullOrEmpty(htmlFieldName))
            {
                var prefix = html.ViewContext.ViewData.TemplateInfo.HtmlFieldPrefix;

                htmlFieldName = (prefix.Length > 0 ? (prefix + ".") : String.Empty) + ExpressionHelper.GetExpressionText(expression);
            }

            foreach (var item in items)
            {
                var dummy = new { Item = item };
                var guid = Guid.NewGuid().ToString();

                var memberExp = Expression.MakeMemberAccess(Expression.Constant(dummy), dummy.GetType().GetProperty("Item"));
                var singleItemExp = Expression.Lambda<Func<TModel, TValue>>(memberExp, expression.Parameters);

                sb.Append("<tr>");
                sb.Append(String.Format(@"<input type=""hidden"" name=""{0}.Index"" value=""{1}"" />", htmlFieldName, guid));
                sb.Append(html.EditorFor(singleItemExp, null, String.Format("{0}[{1}]", htmlFieldName, guid)));
                sb.Append("</tr>");
            }

            return new MvcHtmlString(sb.ToString());
        }
    }
}