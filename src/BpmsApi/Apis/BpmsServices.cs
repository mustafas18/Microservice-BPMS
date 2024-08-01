using Bpms.API.Infrastructure.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BpmsApi.Apis
{
    public class BpmsServices(
    IIdentityService identityService)
{
 
        public IIdentityService IdentityService { get; } = identityService;
    }
}
