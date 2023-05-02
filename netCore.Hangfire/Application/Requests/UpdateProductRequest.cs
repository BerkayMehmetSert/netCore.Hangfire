namespace netCore.Hangfire.Application.Requests
{
    public sealed record UpdateProductRequest(string Name, string Description, double Price);
}
