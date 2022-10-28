using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace BasicAuthenticationWebApi.Controllers
{
    public class TestController : ApiController
    {
        [Authorize(Roles = "Admin,User")]
        public HttpResponseMessage Get()
        {
            //You can implement youe own logic
            //Get the Identity Name
            string username = Thread.CurrentPrincipal.Identity.Name;

            return Request.CreateResponse(HttpStatusCode.OK, "User Name = " + username);
        }
        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Post()
        {
            string username = Thread.CurrentPrincipal.Identity.Name;
            return Request.CreateResponse(HttpStatusCode.OK, "User Name = " + username);
        }
    }
}
