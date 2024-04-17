using Microsoft.AspNetCore.Authorization;

namespace Cloud_Based_Inventory_Management_System.Helpers
{
    public class JwtAudienceHandler : AuthorizationHandler<JwtAudienceRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, JwtAudienceRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == "aud" && c.Value == requirement.Audience))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
