using DataAccess.AccessModel;
using DataAccess.ViewModel;
using ECommerceComMgt.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceComMgt.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddBrand()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBrand(FormCollection formCollection)
        {
            AppDbContext dbContext = new AppDbContext();

            if (ModelState.IsValid)
            {
                string Brand = formCollection["Brand"];
                string Details = formCollection["BrandDetails"];
                ProductBrand brand = new ProductBrand();
                brand.Brand = Brand;
                brand.BrandDetails = Details + " / Brand Created on " + DateTime.Now + " by " + User.Identity.Name;



                dbContext.AddBrand(brand);
                return RedirectToAction("AddProduct");
            }

            return View();
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(FormCollection formCollection)
        {
            AppDbContext dbContext = new AppDbContext();

            if (ModelState.IsValid)
            {
                string Category = formCollection["Category"];
                string Details = formCollection["CategoryDetails"];
                ProductCategory category = new ProductCategory();
                category.Category = Category;
                category.CategoryDetails = Details + " / Category Created on " + DateTime.Now + " by " + User.Identity.Name;



                dbContext.AddCategory(category);
                return RedirectToAction("AddProduct");
            }

            return View();
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            AppDbContext dbContext = new AppDbContext();
            
            List<ProductBrand> brands = dbContext.getBrands.ToList();
            List<ProductCategory> categories = dbContext.getCategories.ToList();

            Product product = new Product();

            product.Brands = brands;
            product.Categories = categories;

            return View(product);
        }

        [HttpPost]
        public ActionResult AddProduct(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppDbContext dbContext = new AppDbContext();

                CreateProductViewModel product = new CreateProductViewModel
                {
                    Name = model.Name,
                    Details = model.Details,
                    CreatedBy = User.Identity.Name,
                    CreatedDate = DateTime.Now,
                    BrandId = model.BrandId,
                    CategoryId = model.CategoryId
                };

                dbContext.AddProduct(product);

                return RedirectToAction("Products");

            }
            return View(model);
        }
        public ActionResult Products()
        {
            AppDbContext dbContext = new AppDbContext();
            IEnumerable<ListProductsViewModel> products = dbContext.GetProducts;
            return View(products);
        }
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            AppDbContext dbContext = new AppDbContext();
            ListProductsViewModel productDetail = dbContext.GetProducts.SingleOrDefault(p => p.Id == id);

            AddProductDetailsViewModel product = new AddProductDetailsViewModel
            {
                ProductId = productDetail.Id,
            };

            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(HttpPostedFileBase PhotoPath, AddProductDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppDbContext dbContext = new AppDbContext();
                ListProductsViewModel productDetail = dbContext.GetProducts.SingleOrDefault(p => p.Id == model.ProductId);
                var fileName = Path.GetFileName(PhotoPath.FileName);
                var path = "~/App_Data/" + productDetail.Name;
                var photoUrl = Server.MapPath(path);
                var photoTitle = Path.GetFileNameWithoutExtension(PhotoPath.FileName);
                var uniqName = Guid.NewGuid().ToString() + "_" + fileName;

                if (!Directory.Exists(photoUrl))
                {
                    Directory.CreateDirectory(photoUrl);
                }

                var photoPath = Path.Combine(photoUrl, uniqName);

                PhotoPath.SaveAs(photoPath);

                AddProductDetailsViewModel product = new AddProductDetailsViewModel
                {
                    Price = model.Price,
                    Color = model.Color,
                    Storage = model.Storage,
                    Processor = model.Processor,
                    Memory = model.Memory,
                    Display = model.Display,
                    CreatedBy = User.Identity.Name,
                    CreatedDate = DateTime.Now,
                    PhotoPath = photoPath,
                    PhotoTitle = photoTitle.ToString(),
                    PhotoSrc = photoUrl,
                    ProductId = model.ProductId
                };

                dbContext.AddProductDetails(product);
                return RedirectToAction("Products");
            }
            return View();
        }

        public ActionResult ProductDetails(int id)
        {
            AppDbContext dbContext = new AppDbContext();
            List<ProductDetailsViewModel> productDetails = dbContext.GetProductDetails(id).ToList();
            ViewBag.Id = id;
            return View(productDetails);
        }
    }
}