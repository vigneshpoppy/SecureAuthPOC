using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecureAuthPOC.Helper;
using SecureAuthPOC.Models;
using System.IdentityModel.Tokens.Jwt;

namespace SecureAuthPOC.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
   
    public class User : ControllerBase
    {
        [HttpGet]
        public Users get()
        {
          var token=  HttpContext.GetTokenAsync("access_token");
            var handler = new JwtSecurityTokenHandler();
            var decodedValue = handler.ReadJwtToken(token.Result);
            var email = decodedValue.Payload["email"];
            email.ToString().Upper();
            UserData userData = new UserData();
          var data=  userData.GetData();
           var filteredData= data.FirstOrDefault(x => x.email == email.ToString());
                if (filteredData != null)
                return filteredData;
            return new Users();
        }
    }
}
