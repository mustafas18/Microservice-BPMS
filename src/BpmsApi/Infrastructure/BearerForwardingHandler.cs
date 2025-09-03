public class BearerForwardingHandler : DelegatingHandler
{
    private readonly IHttpContextAccessor _ctx;

    public BearerForwardingHandler(IHttpContextAccessor ctx) => _ctx = ctx;

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        var token = _ctx.HttpContext?.Request.Headers["Authorization"].ToString();
        if (!string.IsNullOrEmpty(token))
            request.Headers.Add("Authorization", token);

        return base.SendAsync(request, ct);
    }
}
