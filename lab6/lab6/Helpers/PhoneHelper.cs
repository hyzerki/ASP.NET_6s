using Newtonsoft.Json.Linq;
using PhoneDictionaryLib;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Adapters;
using System.Xml.Linq;

namespace lab3.Helpers
{
    public static class PhoneHelper
    {
        public static MvcHtmlString AddPhone(this HtmlHelper html)
        {
            TagBuilder form = new TagBuilder("form");
            form.Attributes.Add("method", "post");
            form.Attributes.Add("action", "/Dict/AddSave");
            TagBuilder div = new TagBuilder("div");
            TagBuilder div2 = new TagBuilder("div");
            TagBuilder Input = new TagBuilder("input");
            Input.Attributes.Add("name", "Name");
            Input.Attributes.Add("type", "text");
            Input.Attributes.Add("placeholder", "Name");
            Input.AddCssClass("form-control");

            div2.InnerHtml = Input.ToString();
            div2.InnerHtml += html.ValidationMessage("Name");
            div.InnerHtml += div2.ToString();

            Input.Attributes["name"] = "Phone";
            Input.Attributes["placeholder"] = "Phone number";
            div2.InnerHtml = Input.ToString();
            div2.InnerHtml += html.ValidationMessage("Phone");
            div.InnerHtml += div2.ToString();

            Input.Attributes.Clear();
            Input.Attributes.Add("type", "submit");
            Input.Attributes.Add("value", "Добавить");
            Input.AddCssClass("btn btn-primary");
            div2.InnerHtml = Input.ToString();
            div.InnerHtml += div2.ToString();

            form.InnerHtml += div.ToString();

            return new MvcHtmlString(form.ToString());
        }

        public static MvcHtmlString UpdatePhone(this HtmlHelper html)
        {
            TagBuilder form = new TagBuilder("form");
            form.Attributes.Add("method", "post");
            form.Attributes.Add("action", "/Dict/UpdateSave");

            TagBuilder hidden = new TagBuilder("input");
            hidden.Attributes.Add("type", "hidden");
            hidden.Attributes.Add("name", "Id");
            hidden.Attributes.Add("value", html.ViewBag.Phone.Id.ToString());


            TagBuilder div = new TagBuilder("div");
            TagBuilder div2 = new TagBuilder("div");
            TagBuilder Input = new TagBuilder("input");
            Input.Attributes.Add("name", "Name");
            Input.Attributes.Add("type", "text");
            Input.Attributes.Add("placeholder", "Name");
            Input.Attributes.Add("value", html.ViewBag.Phone.Name);
            Input.AddCssClass("form-control");

            div2.InnerHtml = Input.ToString();
            div2.InnerHtml += html.ValidationMessage("Name");
            div.InnerHtml += div2.ToString();

            Input.Attributes["name"] = "Phone";
            Input.Attributes["placeholder"] = "Phone number";
            Input.Attributes["value"]= html.ViewBag.Phone.Phone;
            div2.InnerHtml = Input.ToString();
            div2.InnerHtml += html.ValidationMessage("Phone");
            div.InnerHtml += div2.ToString();

            Input.Attributes.Clear();
            Input.Attributes.Add("type", "submit");
            Input.Attributes.Add("value", "Добавить");
            Input.AddCssClass("btn btn-primary");
            div2.InnerHtml = Input.ToString();
            div.InnerHtml += div2.ToString();

            form.InnerHtml += div.ToString();

            return new MvcHtmlString(form.ToString());
        }
    }
}

//< form method = "post"  action = "/Dict/AddSave" >
//    < div >
//        < div >
//            < input name = "Name" class= "form-control" type = "text" placeholder = "Имя" />
//@Html.ValidationMessageFor(model => model.Name)
//</ div >
//        < div >
//            < input name = "Phone" class= "form-control" type = "text" placeholder = "Phone number" />
//            @Html.ValidationMessageFor(model => model.Phone)
//        </ div >
//        < div >
//            < input class= "btn btn-primary" type = "submit" value = "Добавить" />
//        </ div >
//    </ div >
//</ form >


//< form method = "post" action = "/Dict/UpdateSave" >
//    < input name = "Id" type = "hidden" value = "@ViewBag.Phone.Id" />
//    < div >
//        < div >
//            < input name = "Name" class= "form-control" type = "text" placeholder = "Name" value = "@ViewBag.Phone.Name" />
//            @Html.ValidationMessageFor(model => model.Name)
//        </ div >
//        < div >
//            < input name = "Phone" class= "form-control" type = "text" placeholder = "Phone number" value = "@ViewBag.Phone.Phone" />
//            @Html.ValidationMessageFor(model => model.Phone)
//        </ div >
//        < div >
//            < input class= "btn btn-primary" type = "submit" value = "Изменить" />
//        </ div >
//    </ div >
//</ form >