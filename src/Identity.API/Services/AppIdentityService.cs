
using Grpc.Core;
using Identity.Api.Proto;

namespace Identity.Api.Services
{
    public class AppIdentityService : IAppIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AppIdentityService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [AllowAnonymous]
        public async Task<ApplicationUser> GetUserById(AppUserRequest request, ServerCallContext context)
        {
            var result = await _userManager.FindByIdAsync(request);
            return result;
        }
    }
      
    }
}
