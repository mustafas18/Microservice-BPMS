
public interface IVariablesClient
{
    Task<IReadOnlyList<VariableResponse>> GetByWorkflowAsync(Guid workflowId);
    Task<VariableResponse?> GetByNameAsync(Guid workflowId, string name);
    Task<VariableResponse> CreateAsync(CreateVariableRequest request);
}

public class VariablesClient : IVariablesClient
{
    private readonly HttpClient _http;

    public VariablesClient(HttpClient http) => _http = http;

    public async Task<IReadOnlyList<VariableResponse>> GetByWorkflowAsync(Guid workflowId) =>
        await _http.GetFromJsonAsync<IReadOnlyList<VariableResponse>>(
            $"/api/bpms/variables?workflowId={workflowId}") ?? [];

    public async Task<VariableResponse?> GetByNameAsync(Guid workflowId, string name) =>
        await _http.GetFromJsonAsync<VariableResponse>(
            $"/api/bpms/variables/{name}?workflowId={workflowId}");

    public async Task<VariableResponse> CreateAsync(CreateVariableRequest request)
    {
        var resp = await _http.PostAsJsonAsync("/api/bpms/variables", request);
        resp.EnsureSuccessStatusCode();
        return (await resp.Content.ReadFromJsonAsync<VariableResponse>())!;
    }
}
