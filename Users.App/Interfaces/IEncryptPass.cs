using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.App.Interfaces
{
    public interface IEncryptPass
    {
        string HashPass(string password);
        bool ComparePass(string passHashed, string pass);
    }
}
