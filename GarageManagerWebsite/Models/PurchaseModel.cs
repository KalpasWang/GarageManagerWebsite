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

        public List<Purchase> GetOrdersInCart(string customerId)
        {
            try
            {
                var orders = (from x in garageDBEntities.Purchases
                              where x.CustomerId == customerId
                              && x.IsInCart
                              orderby x.DatePurchased
                              select x).ToList();
                return orders;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetAmountOfOrders(string customerId)
        {
            try
            {
                var amount = (from x in garageDBEntities.Purchases
                              where x.CustomerId == customerId
                              && x.IsInCart
                              select x.Amount).Sum();
                return amount;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void UpdataAmount(int purchaseId, int amount)
        {
            try
            {
                var Purchase = garageDBEntities.Purchases.Find(purchaseId);
                Purchase.Amount = amount;
                garageDBEntities.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void MarkOrdersAsPaid(List<Purchase> orders)
        {
            try
            {
                if(orders != null)
                {
                    foreach(var order in orders)
                    {
                        var purchase = garageDBEntities.Purchases.Find(order.Id);
                        purchase.IsInCart = false;
                        purchase.DatePurchased = DateTime.Now;
                        garageDBEntities.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}