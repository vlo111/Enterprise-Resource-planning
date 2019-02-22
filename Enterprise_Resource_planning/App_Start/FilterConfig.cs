using System.Web;
using System.Web.Mvc;

namespace Enterprise_Resource_planning
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
