using System.Web;
using System.Web.Mvc;

namespace ExamplesApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            // we added AuthorizeAttribute to use for all Controller's actions
            filters.Add(new AuthorizeAttribute());

            // this attribute is for external login (facebook, google, twitter...)
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
