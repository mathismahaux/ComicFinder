using Api.Dtos;
using BdApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UserController : ControllerBase
{
    private TokenService _service;
    private IConfiguration _configuration;

    public UserController(TokenService service, IConfiguration configuration)
    {
        _service = service;
        _configuration = configuration;
    }

    [AllowAnonymous]
    [HttpPost]
    public ActionResult<DtoOutputConnectedUser> Auth(DtoInputUser dto)
    {
        var token = _service.BuildToken(
            _configuration["Jwt:Key"],
            _configuration["Jwt:Issuer"],
            dto);
        Response.Cookies.Append("cookie", token, new CookieOptions
        {
            Secure = true,
            HttpOnly = true
        });
        return new DtoOutputConnectedUser
        {
            Token = token
        };
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public ActionResult TestConnection()
    {
        var identityName = User.Identity.Name;
        Console.Write(identityName);
        return Ok(new
        {
            text = "Ok"
        });
    }
    
    [HttpGet]
    [Authorize]
    [Route("IsConnected")]
    public ActionResult IsConnected()
    {
        return Ok();
    }
}