using Core.Security.Extensions;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Core.Security.Requirements
{
    public class OnlyUserRequirement : AuthorizationHandler<OnlyUserRequirement>, IAuthorizationRequirement
    {
        private const string USER = "User";

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyUserRequirement requirement)
        {
            var success = context.User.HasClaim(claim => claim.Type is ClaimTypes.NameIdentifier);

            if (!success)
                throw new Exception("You are not authorized");

            if (context.User.ClaimRoles().Any(c => c == USER))
                context.Succeed(requirement);
            else
                throw new Exception("You have not permission");

            return Task.CompletedTask;
        }
    }
}

