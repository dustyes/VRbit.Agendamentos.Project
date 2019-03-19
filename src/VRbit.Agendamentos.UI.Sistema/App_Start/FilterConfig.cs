using System.Web;
using System.Web.Mvc;
using VRbit.Agendamentos.CrossCutting.MvcFilters;

namespace VRbit.Agendamentos.UI.Sistema
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalErrorHandler());
        }
    }
}
