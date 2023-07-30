using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Services.ColorService.Contract;

namespace Shop.Services.ColorService
{
    public class ColorService : IColorService
    {
        private readonly ShopDbContext dbContext;
        public ColorService(ShopDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<IEnumerable<string>> GetColors()
        {
            IEnumerable<string> colors = dbContext.Colors.AsNoTracking().Select(x => x.Name).ToListAsync();
        }
    }
}
