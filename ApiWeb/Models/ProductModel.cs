
using ApiWeb.DTOs.Products;

namespace ApiWeb.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int QuantityStock { get; set; }

        public string BarCode { get; set; } = string.Empty;

        public string Mark { get; set; } = string.Empty;
    }
}
