using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.App.Interfaces;

namespace Users.App.Services.Helpers
{
    public class CustomBcrypt : IEncryptPass
    {
        public string HashPass(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool ComparePass(string passHashed, string pass)
        {
            return BCrypt.Net.BCrypt.Verify(pass, passHashed);
        }
    }
}
