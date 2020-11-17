using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Security.Principal;
using System.Net.Http;
using System.Web.Http;

namespace BasicAuthenticationUsingJWT.Filters
{
    public class BasicAuth : AuthorizeAttribute, IAuthorizationFilter
    {
        public override object TypeId => base.TypeId;

        public override bool AllowMultiple => base.AllowMultiple;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool IsDefaultAttribute()
        {
            return base.IsDefaultAttribute();
        }

        public override bool Match(object obj)
        {
            return base.Match(obj);
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            try
            {
                var authen = actionContext.Request.Headers.Authorization.ToString();
                if (authen != null)
                {
                    var autheticatetoken = actionContext.Request.Headers.Authorization.Parameter;
                    //var decodedtoken = Encoding.UTF8.GetString(Convert.FromBase64String(autheticatetoken));
                    var decodeToken = TokenManager.ValiadateToken(authen);
                    //var usernameArray = decodedtoken.Split(':');
                    //var username = usernameArray[0];
                    //var password = usernameArray[1];
                    //if (username == "Admin" && password == "Admin")
                    {
                        var identity = new GenericIdentity(decodeToken);
                        SetPrincipal(new GenericPrincipal(identity, null));
                        //SetPrincipal()
                    }
                    //else
                    //{
                      //  actionContext.Response=actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, "not an authenticated user");
                        //actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                        //actionContext.Response.Headers.Add("WWW-Autheticate", "BAsic Scheme='Data' location='http:''localhost:");
                    //}
                }
            }
            catch(Exception e)
            {
                actionContext.Response=actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, e.Message);
            }
           
        }
        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        //public override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        //{
        //    return base.OnAuthorizationAsync(actionContext, cancellationToken);
        //}

        public override string ToString()
        {
            return base.ToString();
        }
    }
}