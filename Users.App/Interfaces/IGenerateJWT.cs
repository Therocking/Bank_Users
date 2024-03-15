using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.App.Interfaces
{
    public interface IGenerateJWT
    {
        string GenerateToken(string email);
    }
}
