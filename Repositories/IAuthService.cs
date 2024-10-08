using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_DiegoFelipeSalamanca.DTOs;
using PruebaNET_DiegoFelipeSalamanca.Models;

namespace PruebaNET_DiegoFelipeSalamanca.Repositories
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDto loginDto);
    }
}