using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using R54_M9_Class_05_Work_01.Models;
using R54_M9_Class_05_Work_01.ViewModels.Input;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace R54_M9_Class_05_Work_01.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductDbContext db;
        private readonly IWebHostEnvironment env;
        public ProductsController(ProductDbContext db, IWebHostEnvironment env)
        {
              this.db = db;
            this.env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductList(int pg = 1)
        {
            Thread.Sleep(1000);
            return ViewComponent("ProductListVC", new { pg = pg });
        }
        public IActionResult Create()
        {
            var data = new ProductInputModel { UnitPrice=null};
            data.ProductInventories.Add(new ProductInventory { Date=null, Quantity=null});
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductInputModel model, string act="")
        {
            if(act== "add")
            {
                model.ProductInventories.Add(new ProductInventory { Date = null, Quantity = null });
                foreach (var v in ModelState.Values)
                {
                    v.Errors.Clear();
                }
               
            }
            if(act.StartsWith("remove"))
            {
                int index = int.Parse(act.Substring(act.IndexOf("_") + 1));
                model.ProductInventories.RemoveAt(index);
               
                foreach (var v in ModelState.Values)
                {
                    
                    v.RawValue = null;
                    v.Errors.Clear();
                }
                
            }
            if(act == "insert")
            {
                if(ModelState.IsValid)
                {
                    var data = new Product 
                    { 
                        Name = model.Name,
                        UnitPrice = model.UnitPrice ?? 0,
                        SellUnit = model.SellUnit
                        
                    };
                    //
                    string ext = Path.GetExtension(model.Picture.FileName);
                    string fileName = $"{Path.GetFileNameWithoutExtension(Path.GetRandomFileName())}{ext}";
                    string savePath = Path.Combine(this.env.WebRootPath, "Images", fileName);
                    FileStream fs = new FileStream(savePath, FileMode.Create);
                    await model.Picture.CopyToAsync(fs);
                    fs.Close();
                    //
                    data.Picture = fileName;
                    foreach(var pi in model.ProductInventories)
                    {
                        data.ProductInventories.Add(pi);
                    }
                    await db.Products.AddAsync(data);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var data = await db.Products
                .Include(x => x.ProductInventories)
                .FirstOrDefaultAsync(x=> x.ProductId == id);
            if (data == null) return NotFound();
            return View(data);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DoDelete(int id)
        {
            var data = await db.Products.FirstOrDefaultAsync(x=> x.ProductId == id);
            if(data == null) return NotFound();
            db.Products.Remove(data);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var data = await db.Products.Include(x => x.ProductInventories).FirstOrDefaultAsync(x => x.ProductId == id);
            if (data == null) return NotFound();
            var modelData = new ProductEditModel {
                ProductId = id,
                Name = data.Name,
                UnitPrice = data.UnitPrice,
                SellUnit = data.SellUnit
            };
            foreach (var pi in data.ProductInventories)
            {
                modelData.ProductInventories.Add(pi);
            }
            ViewBag.CurrentPic = data.Picture;
            return View(modelData);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditModel model, string act="")
        {
            var data = await db.Products.Include(x => x.ProductInventories).FirstOrDefaultAsync(x => x.ProductId == model.ProductId);
            if (data == null) return NotFound();
            if (act == "add")
            {
                model.ProductInventories.Add(new ProductInventory { Date = null, Quantity = null });
                foreach (var v in ModelState.Values)
                {
                    v.Errors.Clear();
                }
            }
            if (act.StartsWith("remove"))
            {
                int index = int.Parse(act.Substring(act.IndexOf("_") + 1));
                model.ProductInventories.RemoveAt(index);

                foreach (var v in ModelState.Values)
                {

                    v.RawValue = null;
                    v.Errors.Clear();
                }

            }
            if(act== "update")
            {
                if (ModelState.IsValid)
                {
                    data.Name = model.Name;
                    data.UnitPrice = model.UnitPrice;
                    data.SellUnit = model.SellUnit;

                };
                if(model.Picture != null)
                {
                    string ext = Path.GetExtension(model.Picture.FileName);
                    string fileName = $"{Path.GetFileNameWithoutExtension(Path.GetRandomFileName())}{ext}";
                    string savePath = Path.Combine(this.env.WebRootPath, "Images", fileName);
                    FileStream fs = new FileStream(savePath, FileMode.Create);
                    model.Picture?.CopyTo(fs);
                    fs.Close();
                    //
                    data.Picture = fileName;
                }
                else
                {
                    //nothing
                   
                }
                db.ProductInventories.RemoveRange(db.ProductInventories.Where(x=> x.ProductId == model.ProductId).ToList());
                foreach (var pi in model.ProductInventories)
                {
                    if (pi.ProductInventoryId != 0)
                    {
                        data.ProductInventories.Add(pi);
                    }                        
                    else
                    {
                        pi.ProductId = model.ProductId;
                        await db.ProductInventories.AddAsync(pi);
                    }
                        
                }
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            ViewBag.CurrentPic = data.Picture;
            return View(model);
        }


    }
    

}
