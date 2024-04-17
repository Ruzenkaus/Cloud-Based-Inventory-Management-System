using Microsoft.AspNetCore.Authorization;

namespace Cloud_Based_Inventory_Management_System.Helpers
{
    public class JwtAudienceRequirement : IAuthorizationRequirement
    {
        public string Audience { get; }

        public JwtAudienceRequirement(string audience)
        {
            Audience = audience;
        }
    }
}
