using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.App.Services.Helpers
{
    public class HandleErrors : Exception
    {
        public readonly string Msg;
        public readonly int StatusCode;
        private HandleErrors(string error, int statusCode) : base(error)
        {
            StatusCode = statusCode;
            Msg = error;
        }

        public static HandleErrors NotFound()
        {
            return new HandleErrors("User not found", 404);
        }

        public static HandleErrors InternalError()
        {
            return new HandleErrors("Internal error. Try later.", 500);
        }
    }
}
