using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Shared.Identity.Account
{
    public class LoginModel
    {
        [Required]
        public string EmailOrName { get; set; }

        [Required]
        public string Password { get; set; }

        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public bool RememberMe { get; set; }
    }
}
