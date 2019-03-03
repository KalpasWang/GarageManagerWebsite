using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GarageManagerWebsite.Entities;

namespace GarageManagerWebsite.Models
{
    public class ProductModel
    {
        private GarageDBEntities garageDBEntities;

        public ProductModel()
        {
            garageDBEntities = new GarageDBEntities();
        }

        ~ProductModel()
        {
            garageDBEntities.Dispose();
        }


        public string AddProduct(Product product)
        {
            try
            {
                garageDBEntities.Products.Add(product);
                garageDBEntities.SaveChanges();

                return product.Name + " is successfully added";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string UpdateProduct(int id, Product newProduct)
        {
            try
            {
                Product product = garageDBEntities.Products.Find(id);
                product.Name = newProduct.Name;
                product.Image = newProduct.Image;
                product.Price = newProduct.Price;
                product.TypeId = newProduct.TypeId;
                product.Description = product.Description;

                garageDBEntities.SaveChanges();
                return product.Name + " is successfully updated";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DeleteProduct(int id)
        {
            try
            {
                Product product = garageDBEntities.Products.Find(id);
                garageDBEntities.Products.Attach(product);
                garageDBEntities.Products.Remove(product);
                garageDBEntities.SaveChanges();

                return product.Name + " is succesfully deleted";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Product GetOneProduct(int id)
        {
            try
            {
                Product product = garageDBEntities.Products.Find(id);
                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Product> GetAllProducts()
        {
            try
            {
                var products = (from x in garageDBEntities.Products
                                select x).ToList();
                return products;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Product> GetProductsByType(int typeId)
        {
            try
            {
                var products = (from x in garageDBEntities.Products
                                where x.TypeId == typeId
                                select x).ToList();
                return products;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}