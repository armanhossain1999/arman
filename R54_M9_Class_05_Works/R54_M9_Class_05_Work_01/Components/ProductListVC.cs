using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using R54_M9_Class_05_Work_01.Models;
using X.PagedList;
namespace R54_M9_Class_05_Work_01.Components
{
    
    public class ProductListVC : ViewComponent
    {
        private readonly ProductDbContext db;
        public ProductListVC(ProductDbContext db)
        {
            this.db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(int pg = 1)
        {
            var data = await db.Products
                .Include(x => x.ProductInventories)
                .OrderBy(x => x.ProductId)
                .ToPagedListAsync(pg, 5);
            return View(data);
        }
    }
}
