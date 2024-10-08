using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaNET_DiegoFelipeSalamanca.Data;
using PruebaNET_DiegoFelipeSalamanca.DTOs;
using PruebaNET_DiegoFelipeSalamanca.Models;
using PruebaNET_DiegoFelipeSalamanca.Repositories;

namespace PruebaNET_DiegoFelipeSalamanca.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _tokenService;

        public AuthService(ApplicationDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Email == loginDto.Email && e.Password == loginDto.Password);

            if (employee == null) return null;

            // Usar el TokenService para generar el token
            return _tokenService.GenerateToken(employee);
        }

        public async Task<Employee> GetUserByEmailAsync(string email)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Email == email);
        }
    }
}
