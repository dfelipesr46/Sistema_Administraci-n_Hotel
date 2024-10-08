using Microsoft.AspNetCore.Mvc;
using PruebaNET_DiegoFelipeSalamanca.Services;
using PruebaNET_DiegoFelipeSalamanca.DTOs;
using PruebaNET_DiegoFelipeSalamanca.Repositories;
using PruebaNET_DiegoFelipeSalamanca.Models;

namespace PruebaNET_DiegoFelipeSalamanca.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }



        /// <summary>
        /// Authenticate an employee and get a JWT token.
        /// </summary>
        // <param name="loginDto">Login credentials.</param>
        /// <returns>JWT token if successful.</returns>
        /// <response code="200">Returns the JWT token.</response>
        /// <response code="401">If the login credentials are invalid.</response>
        

        [HttpPost("login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> Login([FromBody] LoginDto loginRequest)
        {
            var token = await _authService.LoginAsync(loginRequest);

            if (token == null)
            {
                return Unauthorized("Invalid email or password");
            }

            return Ok(new { Message = "Login successful", Token = token }); 
        }


    }
}
