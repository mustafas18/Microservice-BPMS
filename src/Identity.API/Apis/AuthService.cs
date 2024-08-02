namespace Identity.API.Apis
{
    public class AuthService(SignInManager<ApplicationUser>  signInManager,
            UserManager<ApplicationUser> userManager,
            IEventService events
        )
    {
        public SignInManager<ApplicationUser> SignInManager { get; } = signInManager;
        public UserManager<ApplicationUser> UserManager { get; } = userManager;
        public IEventService Events { get; } = events;
    }
}
