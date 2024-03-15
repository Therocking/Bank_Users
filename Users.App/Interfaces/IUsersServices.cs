using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.App.Dtos;

namespace Users.App.Interfaces
{
    public interface IUserServices
    {
        Task<DataResponseDto> Login(LoginUserDto loginDto);
        Task<DataResponseDto> Register(RegisterUserDto registerDto);
    }
}
