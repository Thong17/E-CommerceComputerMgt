using DataAccess.ViewModel;
using ECommerceComMgt.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AccessModel
{
    public class AppDbContext
    {
        public void AddBrand(ProductBrand brand)
        {
            string cs = ConfigurationManager.ConnectionStrings["EComMgt"].ConnectionString;

            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("addBrand", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Brand";
                paramName.Value = brand.Brand;
                cmd.Parameters.Add(paramName);

                SqlParameter paramDetails = new SqlParameter();
                paramDetails.ParameterName = "@Details";
                paramDetails.Value = brand.BrandDetails;
                cmd.Parameters.Add(paramDetails);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void AddCategory(ProductCategory category)
        {
            string cs = ConfigurationManager.ConnectionStrings["EComMgt"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("addCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Category";
                paramName.Value = category.Category;
                cmd.Parameters.Add(paramName);

                SqlParameter paramDetails = new SqlParameter();
                paramDetails.ParameterName = "@Details";
                paramDetails.Value = category.CategoryDetails;
                cmd.Parameters.Add(paramDetails);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public IEnumerable<ProductBrand> getBrands
        {
            get
            {
                string cs = ConfigurationManager.ConnectionStrings["EComMgt"].ConnectionString;
                List<ProductBrand> brands = new List<ProductBrand>();

                using(SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("getBrands", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ProductBrand brand = new ProductBrand();
                        brand.BrandId = Convert.ToInt32(rdr["Id"]);
                        brand.Brand = rdr["Brand"].ToString();
                        brand.BrandDetails = rdr["Details"].ToString();

                        brands.Add(brand);
                    }
                    return brands;
                }
            }
        }
        public IEnumerable<ProductCategory> getCategories
        {
            get
            {
                string cs = ConfigurationManager.ConnectionStrings["EComMgt"].ConnectionString;
                List<ProductCategory> categories = new List<ProductCategory>();

                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("getCategories", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ProductCategory category = new ProductCategory();
                        category.CategoryId = Convert.ToInt32(rdr["Id"]);
                        category.Category = rdr["Category"].ToString();
                        category.CategoryDetails = rdr["Details"].ToString();

                        categories.Add(category);
                    }
                    return categories;
                }
            }
        }
        public void AddProduct(CreateProductViewModel product)
        {
            string cs = ConfigurationManager.ConnectionStrings["EComMgt"].ConnectionString;

            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("addProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = product.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramDetails = new SqlParameter();
                paramDetails.ParameterName = "@Details";
                paramDetails.Value = product.Details;
                cmd.Parameters.Add(paramDetails);

                SqlParameter paramCreatedBy = new SqlParameter();
                paramCreatedBy.ParameterName = "@CreatedBy";
                paramCreatedBy.Value = product.CreatedBy;
                cmd.Parameters.Add(paramCreatedBy);

                SqlParameter paramCreatedDate = new SqlParameter();
                paramCreatedDate.ParameterName = "@CreatedDate";
                paramCreatedDate.Value = product.CreatedDate;
                cmd.Parameters.Add(paramCreatedDate);

                SqlParameter paramBrandId = new SqlParameter();
                paramBrandId.ParameterName = "@BrandId";
                paramBrandId.Value = product.BrandId;
                cmd.Parameters.Add(paramBrandId);

                SqlParameter paramCategoryId = new SqlParameter();
                paramCategoryId.ParameterName = "@CategoryId";
                paramCategoryId.Value = product.CategoryId;
                cmd.Parameters.Add(paramCategoryId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public IEnumerable<ListProductsViewModel> GetProducts
        {
            get
            {
                string cs = ConfigurationManager.ConnectionStrings["EComMgt"].ConnectionString;
                List<ListProductsViewModel> products = new List<ListProductsViewModel>();

                using(SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("getProducts", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ListProductsViewModel product = new ListProductsViewModel();
                        product.Id = Convert.ToInt32(rdr["Id"]);
                        product.Name = rdr["Name"].ToString();
                        product.Details = rdr["Details"].ToString();
                        product.CreatedBy = rdr["CreatedBy"].ToString();
                        product.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]);
                        product.Brand = rdr["Brand"].ToString();
                        product.Category = rdr["Category"].ToString();

                        products.Add(product);
                    }
                }
                return products;
            }
        }
        public void AddProductDetails(AddProductDetailsViewModel productDetails)
        {
            string cs = ConfigurationManager.ConnectionStrings["EComMgt"].ConnectionString;

            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("addProductDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramPrice = new SqlParameter();
                paramPrice.ParameterName = "@Price";
                paramPrice.Value = productDetails.Price;
                cmd.Parameters.Add(paramPrice);

                SqlParameter paramColor = new SqlParameter();
                paramColor.ParameterName = "@Color";
                paramColor.Value = productDetails.Color;
                cmd.Parameters.Add(paramColor);

                SqlParameter paramStorage = new SqlParameter();
                paramStorage.ParameterName = "@Storage";
                paramStorage.Value = productDetails.Storage;
                cmd.Parameters.Add(paramStorage);

                SqlParameter paramProcessor = new SqlParameter();
                paramProcessor.ParameterName = "@Processor";
                paramProcessor.Value = productDetails.Processor;
                cmd.Parameters.Add(paramProcessor);

                SqlParameter paramMemory = new SqlParameter();
                paramMemory.ParameterName = "@Memory";
                paramMemory.Value = productDetails.Memory;
                cmd.Parameters.Add(paramMemory);

                SqlParameter paramDisplay = new SqlParameter();
                paramDisplay.ParameterName = "@Display";
                paramDisplay.Value = productDetails.Display;
                cmd.Parameters.Add(paramDisplay);

                SqlParameter paramProductId = new SqlParameter();
                paramProductId.ParameterName = "@ProductId";
                paramProductId.Value = productDetails.ProductId;
                cmd.Parameters.Add(paramProductId);

                SqlParameter paramCreatedBy = new SqlParameter();
                paramCreatedBy.ParameterName = "@CreatedBy";
                paramCreatedBy.Value = productDetails.CreatedBy;
                cmd.Parameters.Add(paramCreatedBy);

                SqlParameter paramCreatedDate = new SqlParameter();
                paramCreatedDate.ParameterName = "@CreatedDate";
                paramCreatedDate.Value = productDetails.CreatedDate;
                cmd.Parameters.Add(paramCreatedDate);

                SqlParameter paramPhotoPath = new SqlParameter();
                paramPhotoPath.ParameterName = "@Path";
                paramPhotoPath.Value = productDetails.PhotoPath;
                cmd.Parameters.Add(paramPhotoPath);

                SqlParameter paramPhotoTitle = new SqlParameter();
                paramPhotoTitle.ParameterName = "@Title";
                paramPhotoTitle.Value = productDetails.PhotoTitle;
                cmd.Parameters.Add(paramPhotoTitle);

                SqlParameter paramPhotoSrc = new SqlParameter();
                paramPhotoSrc.ParameterName = "@Src";
                paramPhotoSrc.Value = productDetails.PhotoSrc;
                cmd.Parameters.Add(paramPhotoSrc);

                con.Open();
                cmd.ExecuteNonQuery();                                                                                                                                                  
            }
        }
        public IEnumerable<ProductDetailsViewModel> GetProductDetails(int Id)
        {
            string cs = ConfigurationManager.ConnectionStrings["EComMgt"].ConnectionString;
            List<ProductDetailsViewModel> productsDetails = new List<ProductDetailsViewModel>();

            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("getProductsDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@ProductId";
                paramId.Value = Id;

                cmd.Parameters.Add(paramId);



                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ProductDetailsViewModel productDetails = new ProductDetailsViewModel();
                    productDetails.Name = rdr["Name"].ToString();
                    productDetails.Details = rdr["Details"].ToString();
                    productDetails.Brand = rdr["Brand"].ToString();
                    productDetails.Category = rdr["Category"].ToString();
                    productDetails.Price = Convert.ToDouble(rdr["Price"]);
                    productDetails.Color = rdr["Color"].ToString();
                    productDetails.Storage = rdr["Storage"].ToString();
                    productDetails.Processor = rdr["Processor"].ToString();
                    productDetails.Memory = rdr["Memory"].ToString();
                    productDetails.Display = rdr["Display"].ToString();
                    productDetails.ProductId = Convert.ToInt32(rdr["DetailsId"]);
                    

                    productsDetails.Add(productDetails);
                }
            }
            return productsDetails;
            
        }
        public IEnumerable<ProductPhotoViewModel> GetProductPhotos(int Id)
        {
            string cs = ConfigurationManager.ConnectionStrings["EComMgt"].ConnectionString;
            List<ProductPhotoViewModel> productPhotos = new List<ProductPhotoViewModel>();

            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("getProductPhoto", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlParameter paramDetailsId = new SqlParameter();
                paramDetailsId.ParameterName = "@DetailsId";
                paramDetailsId.Value = Id;

                cmd.Parameters.Add(paramDetailsId);

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ProductPhotoViewModel productPhoto = new ProductPhotoViewModel();
                    if (!rdr.HasRows)
                    {
                        productPhoto.Id = Id;
                        productPhoto.PhotoPath = "pathToNoImage";
                        productPhoto.PhotoTitle = "No Image";
                        productPhotos.Add(productPhoto);
                    }
                    else
                    {
                        productPhoto.Id = Convert.ToInt32(rdr["Id"]);
                        productPhoto.PhotoPath = rdr["Path"].ToString();
                        productPhoto.PhotoTitle = rdr["Title"].ToString();

                        productPhotos.Add(productPhoto);
                    }
                }
            }
            return productPhotos;
        } 
    }
}
