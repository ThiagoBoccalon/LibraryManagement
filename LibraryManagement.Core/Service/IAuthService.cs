using LibraryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Service
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, RoleEnum role);
        string ComputeSha256Hash(string password);
    }
}
