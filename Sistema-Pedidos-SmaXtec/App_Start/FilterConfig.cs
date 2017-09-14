using System.Web;
using System.Web.Mvc;

namespace Sistema_Pedidos_SmaXtec
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
