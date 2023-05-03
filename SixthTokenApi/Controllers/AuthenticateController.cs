using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SixthTokenApi.Models;
using SixthTokenApi.Repository;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SixthTokenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : BaseController
    { 
  
        private readonly IEmployee interface1;
       public AuthenticateController( IEmployee obj)
        {          
            interface1 = obj;
        }
   
        
        [AllowAnonymous]
        [HttpPost(nameof(Post))]
        public IActionResult Post(LoginModel model)
        {
            var data = interface1.Login(model);
            return Ok(data);
        }



        [HttpGet(nameof(GetAllRecord))]
        [Authorize(Roles ="admin")]
        public IActionResult GetAllRecord()
        {
            var data=interface1.GetRecord();
            return Ok(data);    
        }

    }

  
}
