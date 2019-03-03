using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GarageManagerWebsite.Entities;

namespace GarageManagerWebsite.Models
{
    public class PurchaseModel
    {
        private GarageDBEntities garageDBEntities;

        public PurchaseModel()
        {
            garageDBEntities = new GarageDBEntities();
        }

        ~PurchaseModel()
        {
            garageDBEntities.Dispose();
        }

        public string AddPurchase(Purchase purchase)
        {
            try
            {
                garageDBEntities.Purchases.Add(purchase);
                garageDBEntities.SaveChanges();

                return "The Purchase: " + purchase.DatePurchased + " is successfully added";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string UpdatePurchase(int id, Purchase newPurchase)
        {
            try
            {
                Purchase purchase = garageDBEntities.Purchases.Find(id);
                purchase.Amount = newPurchase.Amount;
                purchase.DatePurchased = newPurchase.DatePurchased;


                garageDBEntities.SaveChanges();
                return "The purchase: " + purchase.DatePurchased+ " is successfully updated";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string DeletePurchase(int id)
        {
            try
            {
                Purchase purchase = garageDBEntities.Purchases.Find(id);
                garageDBEntities.Purchases.Attach(purchase);
                garageDBEntities.Purchases.Remove(purchase);
                garageDBEntities.SaveChanges();

                return "The purchase: " + purchase.DatePurchased + " is succesfully deleted";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}