using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

public class AuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement)
    {
        if (context.User.IsInRole("Admin"))
        {
            context.Succeed(requirement);
        }
        else if (requirement.Name == Operations.Edit.Name && context.User.IsInRole("Editor"))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}

public static class Operations
{
    public static OperationAuthorizationRequirement Edit = new OperationAuthorizationRequirement { Name = nameof(Edit) };
    public static OperationAuthorizationRequirement Delete = new OperationAuthorizationRequirement { Name = nameof(Delete) };
}
