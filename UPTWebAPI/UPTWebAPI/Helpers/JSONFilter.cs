using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Mvc;

namespace UPT.Helpers
{
    public class JSONFilter : System.Web.Http.Filters.ActionFilterAttribute
    {
        public string Param { get; set; }

        public Type RootType { get; set; }

        public  void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                string json = filterContext.HttpContext.Request.Form[Param];
                string contentType = filterContext.HttpContext.Request.ContentType;

                switch (contentType)
                {
                    //Which is what you get if you use the WebClient in your code.
                    //Which is what the .NET client code is using
                    case "application/x-www-form-urlencoded":
                        if (json == "[]" || json == "\",\"" || String.IsNullOrEmpty(json))
                        {
                            filterContext.ActionParameters[Param] = null;
                        }
                        else
                        {
                            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
                            {
                                filterContext.ActionParameters[Param] =
                                    new DataContractJsonSerializer(RootType).ReadObject(ms);
                            }
                        }
                        break;
                    case "application/json":
                        //allow standard Controller/ASP MVC JSONValueProvider to do its work
                        //we can't do a better job than it, so let it deal with it
                        return;
                    default:
                        filterContext.ActionParameters[Param] = null;
                        break;
                }
            }
            catch
            {
                filterContext.ActionParameters[Param] = null;
            }
        }

    }
}