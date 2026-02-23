using System.ComponentModel.DataAnnotations;

namespace ApiWeb.DTOs.Products;

public sealed record UpdateProductRequest(
[param: Required(ErrorMessage = "Name is required.")]
    [param: StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
    string Name,

[param: Required(ErrorMessage = "Description is required.")]
    [param: StringLength(300, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 300 characters.")]
    string Description,

[param: Range(0, int.MaxValue, ErrorMessage = "QuantityStock must be 0 or greater.")]
    int QuantityStock,

[param: Required(ErrorMessage = "Mark is required.")]
    [param: StringLength(80, MinimumLength = 2, ErrorMessage = "Mark must be between 2 and 80 characters.")]
    string Mark
);



