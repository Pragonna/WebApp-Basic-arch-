using Core.Security.Extensions;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Core.Security.Requirements
{
    public class OnlyAdminRequirement : AuthorizationHandler<OnlyUserRequirement>, IAuthorizationRequirement
    {
        private const string ADMIN = "Admin";
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyUserRequirement requirement)
        {
            var success = context.User.HasClaim(claim => claim.Type is ClaimTypes.NameIdentifier);

            //var defaultHttpContext= (Microsoft.AspNetCore.Http.DefaultHttpContext)context.Resource;
            

            if (!success)
                context.Fail(context.FailureReasons.First());

            if (context.User.ClaimRoles().Any(c => c == ADMIN))
                context.Succeed(requirement);
            else
                context.Fail(context.FailureReasons.First());
            
            return Task.CompletedTask;

        }
    }
}
