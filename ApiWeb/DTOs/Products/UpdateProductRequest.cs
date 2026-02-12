namespace ApiWeb.DTOs.Products;

    public sealed record UpdateProductRequest(
        string Name,
        string Description,
        int QuantityStock,
        string BarCode,
        string Mark
    );

        

