using ApiWeb.Data;
using ApiWeb.DTOs.Products;
using ApiWeb.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Services.Products;

public sealed class ProductService : IProductService
{
    private readonly AppDbContent _context;

    public ProductService(AppDbContent context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<ProductResponse>> GetAllAsync(CancellationToken ct)
    {
        var products = await _context.Products
            .AsNoTracking()
            .ToListAsync(ct);

        return products.Select(p => p.ToResponse()).ToList();
    }

    public async Task<ProductResponse?> GetByIdAsync(int id, CancellationToken ct)
    {
        var product = await _context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, ct);

        return product?.ToResponse();
    }

    public async Task<ProductResponse> CreateAsync(CreateProductRequest request, CancellationToken ct)
    {
        var entity = request.ToEntity();

        await _context.Products.AddAsync(entity, ct);
        await _context.SaveChangesAsync(ct);

        return entity.ToResponse();
    }

    public async Task<ProductResponse?> UpdateAsync(int id, UpdateProductRequest request, CancellationToken ct)
    {
        var entity = await _context.Products.FirstOrDefaultAsync(p => p.Id == id, ct);

        if (entity is null)
            return null;

        entity.ApplyUpdate(request);
        await _context.SaveChangesAsync(ct);
        return entity.ToResponse();
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct)
    {
        var entity = await _context.Products.FirstOrDefaultAsync(p => p.Id == id, ct);

        if (entity is null)
            return false;

        _context.Products.Remove(entity);
        await _context.SaveChangesAsync(ct);

        return true;
    }
}