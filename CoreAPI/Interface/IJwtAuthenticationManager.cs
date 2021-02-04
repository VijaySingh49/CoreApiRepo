using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Interface
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string userName, string Password);
    }
}
