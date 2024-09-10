using AuthService_JWT.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace AuthService_JWT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<AuthController> _logger;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public AuthController(ILogger<AuthController> logger, ITokenService tokenService, IConfiguration configuration)
        {
            _logger = logger;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        [HttpGet(Name = "data")]
        public string Get()
        {
            return "No Token!!!";
        }

        [HttpPost(Name = "data")]
        public object Post(string userName, string password)
        {
           if(userName == "charlie" && password == "1234") 
            {
                var token = _tokenService.BuildToken(_configuration.GetValue<string>("Jwt:Key"),
                                            _configuration.GetValue<string>("Jwt:Issuer"),
                                            new[]
                                            {
                                                        _configuration.GetValue<string>("Jwt:Aud1"),
                                                        _configuration.GetValue<string>("Jwt:Aud2"),
                                                        _configuration.GetValue<string>("Jwt:Aud3")
                                                    },
                                            userName);
                return new
                {
                    Token = token,
                    IsAuthenticated = true,
                };
           }

            return new
            {
                Token = string.Empty,
                IsAuthenticated = false
            };
        }
    }
}
