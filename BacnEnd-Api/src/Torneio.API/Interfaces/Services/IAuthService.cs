using System.Threading.Tasks;
using Torneio.API.Models.Dtos;

namespace Torneio.API.Interfaces.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}
