namespace WarehouseMgmtApp.Client.Services.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public int Stock { get; set; }

        public int categoryId { get; set; }

        public string Category {  get; set; }

        public int productTypeId { get; set; }

        public string productTye { get; set; }

        public int metricUnitId { get; set; }

        public string metricUnit { get; set; }
    }
}
