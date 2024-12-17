using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entites;

namespace BusinessLogic.authorization
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User account);
        public int? ValidateJwtToken(string token);
        public Task<RefreshToken> GenerateRefreshToken(string ipAddress);
    }
}
