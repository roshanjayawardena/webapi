using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extention;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Bo;
using Service.Models;
using Service.Services.Interfaces;

namespace InterviewOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;

        public SecurityController(ISecurityService securityService) {

            _securityService = securityService;
        }


        [Route("Authenticate")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginViewModel loginModel) {

            try
            {

                if (ModelState.IsValid)
                {
                    var result = await _securityService.authentication(loginModel.MapObject<LoginViewModel, LoginBo>());
                    if (result.Token != null)
                    {
                        return Created("", result);

                    } else {

                        return Unauthorized();
                    }

                } else {

                    return BadRequest();
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }










    }
}