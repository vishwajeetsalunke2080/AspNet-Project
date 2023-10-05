using EF_first_approach_demo.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace EF_first_approach_demo.Filters
{
    public class CustomerAuthFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if(filterContext.HttpContext.User.IsInRole("Customer") == false)
            {
                filterContext.Result = new HttpUnauthorizedResult();                                    
            }
        }
    }
}