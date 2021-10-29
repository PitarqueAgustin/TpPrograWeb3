using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecetasTP.Filters
{
    public class LayoutActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int role = context.HttpContext.Session.GetInt32("roleId") != null ? (int)context.HttpContext.Session.GetInt32("roleId") : 0;

            context.HttpContext.Session.SetString("layout", getValidLayout(role));
        }

        private string getValidLayout(int role)
        {

            switch (role)
            {
                case (int)Roles.Diner:
                    return "_Diner";
                case (int)Roles.Chef:
                    return "_Chef";
                case (int)Roles.Anonymous:
                    return "_Anonymous";
                default:
                    return "_Anonymous";
            }
        }
    }

    public enum Roles
    {
        Anonymous = 1,
        Chef = 2,
        Diner = 3
    }
}
