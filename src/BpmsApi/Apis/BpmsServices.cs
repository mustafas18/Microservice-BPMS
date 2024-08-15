using Bpms.API.Infrastructure.Services;
using Microsoft.Extensions.Logging;

namespace BpmsApi.Apis
{
    public class BpmsServices(
    IIdentityService identityService)
{
 
        public IIdentityService IdentityService { get; } = identityService;
    }
}
