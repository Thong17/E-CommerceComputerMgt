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
    }
}
