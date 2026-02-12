using ApiWeb.Data;
using ApiWeb.DTOs.Products;
using ApiWeb.Mappings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContent _context;
        public ProductController(AppDbContent context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetAll(CancellationToken ct)
        {
            var products = await _context.Products
                .AsNoTracking()
                .ToListAsync(ct);

            var response = products.Select(p => p.ToResponse()).ToList();
            return Ok(response);
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<ProductResponse>> GetById([FromRoute] int id, CancellationToken ct)
        {

            var product = await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id, ct);

            if (product is null)
                return NotFound("Product not found");


            return Ok(product.ToResponse());
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponse>> Create(
        [FromBody] CreateProductRequest request,
        CancellationToken ct)
        {
            var entity = request.ToEntity();

            await _context.Products.AddAsync(entity, ct);
            await _context.SaveChangesAsync(ct);

            //var response = entity.ToResponse();
            var response = ApiWeb.Mappings.ProductMappingExtensions.ToResponse(entity);


            return CreatedAtAction(
                nameof(GetById),
                new { id = response.Id },
                response
            );
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProductResponse>> Update(
            [FromRoute] int id,
            [FromBody] UpdateProductRequest request,
            CancellationToken ct)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(p => p.Id == id, ct);

            if (entity is null)
                return NotFound();

            entity.ApplyUpdate(request);

            await _context.SaveChangesAsync(ct);

            return Ok(entity.ToResponse());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken ct)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(p => p.Id == id, ct);

            if (entity is null)
                return NotFound();

            _context.Products.Remove(entity);
            await _context.SaveChangesAsync(ct);

            return NoContent();
        }
    }
}
