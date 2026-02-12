using System.Runtime.CompilerServices;
using ApiWeb.DTOs.Products;
using ApiWeb.Models;

namespace ApiWeb.Mappings
{
    public static class ProductMappingExtensions
    {

        public static ProductModel ToEntity(this CreateProductRequest request)
        {
            return new ProductModel
            {
                Name = request.Name,
                Description = request.Description,
                QuantityStock = request.QuantityStock,
                BarCode = request.BarCode,
                Mark = request.Mark
            };
        }

        public static ProductResponse ToResponse(this ProductModel entity)
        {
            return new ProductResponse(
                entity.Id,
                entity.Name,
                entity.Description,
                entity.QuantityStock,
                entity.BarCode,
                entity.Mark
                );
        }

        public static void ApplyUpdate(this ProductModel entity, UpdateProductRequest request)
        {
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.QuantityStock = request.QuantityStock;
            entity.Mark = request.Mark;
        }
    }
}
