using Microsoft.AspNetCore.Identity;

namespace Identity.API.Models
{
    public class ApplicationUserTokens : IdentityUserToken<string>
    {
        public DateTime ExpireDate { get; set; }
    }
}