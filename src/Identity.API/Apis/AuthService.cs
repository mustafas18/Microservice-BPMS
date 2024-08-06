using System.Net.Http;

namespace Identity.API.Apis
{
    public class AuthService(SignInManager<ApplicationUser>  signInManager,
            UserManager<ApplicationUser> userManager,
            IIdentityServerInteractionService interaction,
            IConfiguration configuration,
            IEventService events,
        IHttpClientFactory httpClientFactory
        )
    {
        public SignInManager<ApplicationUser> SignInManager { get; } = signInManager;
        public UserManager<ApplicationUser> UserManager { get; } = userManager;
        public IIdentityServerInteractionService Interaction { get; } = interaction;
        public IConfiguration Configuration { get; } = configuration;
        public IEventService Events { get; } = events;
        public IHttpClientFactory HttpClientFactory { get; } = httpClientFactory;
    }
}
