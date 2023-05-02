namespace netCore.Hangfire.Application.Requests
{
    public sealed record CreateProductRequest(string Name, string Description, double Price);
}
