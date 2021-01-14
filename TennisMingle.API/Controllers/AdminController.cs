using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisMingle.API.Controllers
{
    public class AdminController: BaseApiController
    {

        [Authorize(Policy="RequireAdminRole")]
        [HttpGet("users-with-roles")]
        public ActionResult GetUsersWithRoles()
        {
            return Ok("Only admins can see this");
        }

        [Authorize(Policy = "RequireCoachRole")]
        [HttpGet("users-for-coach")]
        public ActionResult GetUsersForCoach()
        {
            return Ok("Only coaches can see this");
        }
    }
}
