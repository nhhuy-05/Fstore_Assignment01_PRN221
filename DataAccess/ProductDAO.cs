using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        public static readonly object instanceLock = new object();

        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new ProductDAO();
                }
                return instance;
            }
        }
        public List<Product> GetProducts()
        {
            List<Product> products = null;
            try
            {
                var context = new FStoreContext();
                products = context.Products.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return products;
        }
        public Product GetProductByID(int productId)
        {
            Product product = null;
            try
            {
                var myStockDB = new FStoreContext();
                product = myStockDB.Products.SingleOrDefault(p=>p.ProductId == productId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }
        public void AddProduct(Product product)
        {
            try
            {
                Product p = GetProductByID(product.ProductId);
                if (p != null)
                {
                    var myStockDB = new FStoreContext();
                    myStockDB.Products.Add(product);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The order is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateProduct(Product product)
        {
            try
            {
                Product p = GetProductByID(product.ProductId);
                if (p != null)
                {
                    var myStockDB = new FStoreContext();
                    myStockDB.Entry<Product>(p).State = EntityState.Modified;
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The order does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void RemoveProduct(Product product)
        {
            try
            {
                Product m = GetProductByID(product.ProductId);
                if (m != null)
                {
                    var myStockDB = new FStoreContext();
                    myStockDB.Products.Remove(product);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The order does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
