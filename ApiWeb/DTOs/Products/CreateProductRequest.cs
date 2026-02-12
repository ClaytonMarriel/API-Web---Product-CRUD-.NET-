
namespace ApiWeb.DTOs.Products;

public sealed record CreateProductRequest(
    string Name,
    string Description,
    int QuantityStock,
    string BarCode,
    string Mark
)
{
}

        

