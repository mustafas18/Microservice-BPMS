using Grpc.Core;
using Identity.Api.Proto;
using System.Threading.Tasks;

namespace Identity.Api.Services
{
    public interface IAppIdentityService
    {
        Task<ApplicationUser> CurrentUserId(UserIdRequest request, ServerCallContext context);
        Task<ApplicationUser> GetUserById(AppUserRequest request, ServerCallContext context);
    }
}
