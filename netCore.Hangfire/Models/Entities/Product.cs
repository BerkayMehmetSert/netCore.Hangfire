using netCore.Hangfire.Models.Common;

namespace netCore.Hangfire.Models.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
