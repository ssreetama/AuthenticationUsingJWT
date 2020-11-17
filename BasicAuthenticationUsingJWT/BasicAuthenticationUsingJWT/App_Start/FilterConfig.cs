using BasicAuthenticationUsingJWT.Filters;
using System.Web;
using System.Web.Mvc;

namespace BasicAuthenticationUsingJWT
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new BasicAuth());
        }
    }
}
