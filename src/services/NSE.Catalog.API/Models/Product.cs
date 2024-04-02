using NSE.Core.DomainObjects;

namespace NSE.Catalog.API.Models
{
    public class Product : Entity, IAggregateRoot
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Active { get; set; }
        public decimal Value { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Image { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
    }
}