using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Shared.Features.Jwt
{
    public class JwtAuthResult
    {
        public string AccessToken { get; set; }

        public RefreshToken RefreshToken { get; set; }
    }
}
