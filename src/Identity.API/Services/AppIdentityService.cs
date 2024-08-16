using Grpc.Core;
using Identity.Api.Proto;

namespace Identity.Api.Services
{
    public class AppIdentityService : IdentityGrpc.IdentityGrpcBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public AppIdentityService(UserManager<ApplicationUser> userManager,
            IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }
        [AllowAnonymous]
        public async Task<UserResponse> CurrentUserId(UserIdRequest request, ServerCallContext context)
        {
            var userId = _contextAccessor.HttpContext.User.Identity.GetSubjectId();
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException();
            }
            var user = await _userManager.FindByIdAsync(userId);
            return new UserResponse { UserId = user.Id, UserName = user.UserName, Name = user.Name, TenantId = user.TenantId };
        }
        [AllowAnonymous]
        public async Task<UserResponse> GetUserById(AppUserRequest request, ServerCallContext context)
        {
            var result = await _userManager.FindByIdAsync(request.UserId);
            return new UserResponse { UserId = result.Id, UserName = result.UserName, Name = result.Name,TenantId=result.TenantId };
        }

    }

}

