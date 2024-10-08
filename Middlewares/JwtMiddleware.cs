using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_DiegoFelipeSalamanca.Services;
using PruebaNET_DiegoFelipeSalamanca.Repositories;

namespace PruebaNET_DiegoFelipeSalamanca.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context, IAuthService authService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                await AttachUserToContext(context, authService, token);

            await _next(context);
        }

        private async Task AttachUserToContext(HttpContext context, IAuthService authService, string token)
        {
            try
            {
                var jwtToken = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
                var email = jwtToken?.Claims.First(x => x.Type == "unique_name").Value;

                if (email != null)
                {
                    var user = await authService.GetUserByEmailAsync(email);
                    context.Items["User"] = user;
                }
            }
            catch
            {
                // Si el token no es válido, simplemente no se adjunta nada al contexto
            }
        }
    }
}
