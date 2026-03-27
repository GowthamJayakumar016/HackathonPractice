using System.Threading.Tasks;
using NangaNaluPeru.DTOs;

namespace NangaNaluPeru.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterDto dto);
        Task<LoginResponseDto> LoginAsync(LoginDto dto);
    }
}