using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.App.Dtos
{
    public class DataResponseDto
    {
        public UserResponseDto User {  get; set; }
        public string Token { get; set; }
    }
}
