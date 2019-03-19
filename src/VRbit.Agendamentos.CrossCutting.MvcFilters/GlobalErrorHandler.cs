using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace VRbit.Agendamentos.CrossCutting.MvcFilters
{
    public class GlobalErrorHandler : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //LOG Auditoria
            //Usuario X gravou Y informação na model Z

            if(filterContext.Exception != null)
            {
                //Manipular exception
                //Injetar Lib de tratamento de erro
                //Gravar erro no banco
                //Enviar email do erro
                //Retornar codigo do erro amigavel
                //Realizar tudo de forma async

            }

            base.OnActionExecuted(filterContext);
        }
    }
}
