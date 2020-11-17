using BasicAuthenticationUsingJWT.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace BasicAuthenticationUsingJWT.Controllers
{
    public class AccountController : ApiController
    {
        // GET: Account
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Account/Index")]
        [BasicAuthenticationUsingJWT.Filters.BasicAuth(Roles="Admin")]
        public HttpResponseMessage Index()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }
        [System.Web.Http.HttpGet]
        [BasicAuth(Roles="Sales")]
        [EnableCors(origins:"",headers:"*",methods:"get,post")]
        public HttpResponseMessage ValidLogin(string username, string password)
        {
            if (username == "Admin" && password == "Admin")
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Valid User");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid");
            }
        }

    }
}