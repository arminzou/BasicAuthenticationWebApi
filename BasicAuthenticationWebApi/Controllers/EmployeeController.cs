﻿using BasicAuthenticationWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BasicAuthenticationWebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        [BasicAuthentication]
        [EnableCorsAttribute("*", "*", "*")]
        [MyAuthorize(Roles = "Manager,Admin")]
        [Route("api/Employees")]
        public HttpResponseMessage GetEmployees()
        {
            //var identity = (ClaimsIdentity)User.Identity;
            //var username = identity.Name;
            //OR you can use the below code to get the login username
            string username = Thread.CurrentPrincipal.Identity.Name;
            var EmpList = new EmployeeList().GetEmployees();
            switch (username.ToLower())
            {
                case "adminuser":
                    return Request.CreateResponse(HttpStatusCode.OK,
                        EmpList.Where(e => e.Gender.ToLower() == "male").ToList());
                case "superadminuser":
                    return Request.CreateResponse(HttpStatusCode.OK,
                        EmpList.Where(e => e.Gender.ToLower() == "female").ToList());
                case "bothuser":
                    return Request.CreateResponse(HttpStatusCode.OK, EmpList);
                default:
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [BasicAuthentication]
        [MyAuthorize(Roles = "Manager")]
        [Route("api/AllMaleEmployees")]
        public HttpResponseMessage GetAllMaleEmployees()
        {
            var identity = (ClaimsIdentity)User.Identity;
            //Getting the ID value
            var ID = identity.Claims
                       .FirstOrDefault(c => c.Type == "ID").Value;
            //Getting the Email value
            var Email = identity.Claims
                      .FirstOrDefault(c => c.Type == "Email").Value;
            //Getting the Username value
            var username = identity.Name;
            //Getting the Roles only if you set the roles in the claims
            //var Roles = identity.Claims
            //            .Where(c => c.Type == ClaimTypes.Role)
            //            .Select(c => c.Value).ToArray();
            var EmpList = new EmployeeList().GetEmployees().Where(e => e.Gender.ToLower() == "male").ToList();
            return Request.CreateResponse(HttpStatusCode.OK, EmpList);
        }
        [BasicAuthentication]
        [MyAuthorize(Roles = "Admin")]
        [Route("api/AllFemaleEmployees")]
        public HttpResponseMessage GetAllFemaleEmployees()
        {
            var EmpList = new EmployeeList().GetEmployees().Where(e => e.Gender.ToLower() == "female").ToList();
            return Request.CreateResponse(HttpStatusCode.OK, EmpList);
        }
        [BasicAuthentication]
        [MyAuthorize(Roles = "Manager,Admin")]
        [Route("api/AllEmployees")]
        public HttpResponseMessage GetAllEmployees()
        {
            var EmpList = new EmployeeList().GetEmployees();
            return Request.CreateResponse(HttpStatusCode.OK, EmpList);
        }
    }
}
