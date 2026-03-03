using MobileShopERP.API.DTOs;
using System.Threading.Tasks;

namespace MobileShopERP.API.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
        Task<UserDto> RegisterAsync(RegisterDto registerDto);
        Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword);
    }
}