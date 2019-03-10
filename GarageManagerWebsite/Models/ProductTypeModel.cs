using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GarageManagerWebsite.Entities;

namespace GarageManagerWebsite.Models
{
    public class ProductTypeModel
    {
        private GarageDBEntities garageDBEntities;

        public ProductTypeModel()
        {
            garageDBEntities = new GarageDBEntities();
        }

        ~ProductTypeModel()
        {
            garageDBEntities.Dispose();
        }

        public string AddProductType(ProductType productType)
        {
            try
            {
                garageDBEntities.ProductTypes.Add(productType);
                garageDBEntities.SaveChanges();

                return productType.Name + " is successfully added";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string UpdateProductType(int id, ProductType newProductType)
        {
            try
            {
                ProductType productType = garageDBEntities.ProductTypes.Find(id);
                productType.Name = newProductType.Name;

                garageDBEntities.SaveChanges();
                return productType.Name + " is successfully updated";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DeleteProductType(int id)
        {
            try
            {
                ProductType productType = garageDBEntities.ProductTypes.Find(id);
                garageDBEntities.ProductTypes.Attach(productType);
                garageDBEntities.ProductTypes.Remove(productType);
                garageDBEntities.SaveChanges();

                return productType.Name + " is succesfully deleted";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProductType GetProductTypeById(int id)
        {
            try
            {
                var productType = garageDBEntities.ProductTypes.Find(id);
                return productType;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}