using ApiWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Data
{
    public class AppDbContent : DbContext
    {

        public AppDbContent(DbContextOptions<AppDbContent> options) : base(options)
        {
        }

        public DbSet<ProductModel> Products { get; set; }


    }
}
