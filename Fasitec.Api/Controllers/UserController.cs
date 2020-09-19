using System.Collections.Generic;
using System.Threading.Tasks;
using Fasitec.Business.ApplicationServices;
using Fasitec.Business.Dto;
using Fasitec.Business.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase
    {  
        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<List<UserOutput>>> Get([FromServices] IUserFacade userService)
        {
            return await userService.All().ToListAsync();
        }

        [HttpGet]
        [Route("{id:int}")]        
        [Authorize(Roles="developer")]
        public ActionResult<UserOutput> Get([FromServices] IUserFacade userService, int id)
        {
            return userService.ById(id);
        }

        [HttpPost]
        [Route("")]
        public ActionResult<UserOutput>Post([FromServices] IUserFacade userService, [FromBody]UserInput userInput)
        {
            return userService.Create(userInput);
        }

        [HttpPut]
        [Route("")]
        public ActionResult<UserOutput>Put([FromServices] IUserFacade userService, [FromBody]UserInput userInput)
        {
            return userService.Modify(userInput);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult<UserOutput>Delete([FromServices] IUserFacade userService, int id)
        {       
            userService.Remove(id);
            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login([FromServices] IUserFacade userService, [FromBody] UserInput dto)
        {
            var user = userService.Signin(dto.Email, dto.Password);
            user.Token = TokenService.GenerateToken(user);            
            return Ok(user);
        }
    }
}