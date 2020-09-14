using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginAPI.Interfaces;
using LoginAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginAPI.Controllers
{
    [Route("api/usr/[controller]/[action]")]
    [ApiController]
    public class UsrController : ControllerBase
    {
        private readonly IUsrManager _usrs;
        public UsrController(IUsrManager usrs)
        {
            _usrs = usrs;
        }

        [HttpPost]
        public ActionResult<bool> NewUser([FromBody]User user)
        {
            return _usrs.NewUsr(user) ? Ok() : (ActionResult)BadRequest();
        }

        [HttpPut]
        public ActionResult<bool> CheckLogin([FromBody]User user)
        {
            return Ok(_usrs.CheckLogin(user));
        }
    }
}
