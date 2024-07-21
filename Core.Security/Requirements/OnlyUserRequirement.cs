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
                context.Fail(context.FailureReasons.First());

            if (context.User.ClaimRoles().Any(c => c == USER))
                context.Succeed(requirement);
            else
                context.Fail(context.FailureReasons.First());

            return Task.CompletedTask;
        }
    }
}

