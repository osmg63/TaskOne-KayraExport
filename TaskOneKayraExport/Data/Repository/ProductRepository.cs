using System.Linq.Expressions;
using System.Runtime;
using Microsoft.EntityFrameworkCore;
using TaskOneKayraExport.Data.Context;
using TaskOneKayraExport.Entity;

namespace TaskOneKayraExport.Data.Repository
{
    public class ProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }


        public async Task<Product> Add(Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<Product> Get(Expression<Func<Product, bool>> filter = null)
        {
            return await _context.Set<Product>().SingleOrDefaultAsync(filter);
        }
        public async Task<List<Product>> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return filter == null ? await _context.Set<Product>().ToListAsync() :
             await _context.Set<Product>().Where(filter).ToListAsync();
        }


        public async Task<Boolean> Delete(Product entity)
        {
            _context.Set<Product>().Remove(entity);
            int result=await _context.SaveChangesAsync();
            return result > 0;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }







    }
}
