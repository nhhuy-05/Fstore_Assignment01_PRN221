using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        public static readonly object instanceLock = new object();

        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new OrderDAO();
                }
                return instance;
            }
        }

        public List<Order> GetOrders()
        {
            List<Order> orders;
            try
            {
                var context = new FStoreContext();
                orders = context.Orders.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orders;

        }

        public Order GetOrderByID(int orderId)
        {
            Order order = null;
            try
            {
                var myStockDB = new FStoreContext();
                order = myStockDB.Orders.SingleOrDefault(car => car.OrderId == orderId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public void AddOrder(Order order)
        {
            try
            {
                Order o = GetOrderByID(order.OrderId);
                if (o != null)
                {
                    var myStockDB = new FStoreContext();
                    myStockDB.Orders.Add(order);
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
        public void UpdateOrder(Order order)
        {
            try
            {
                Order m = GetOrderByID(order.OrderId);
                if (m != null)
                {
                    var myStockDB = new FStoreContext();
                    myStockDB.Entry<Order>(m).State = EntityState.Modified;
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
        public void RemoveOrder(Order order)
        {
            try
            {
                Order m = GetOrderByID(order.OrderId);
                if (m != null)
                {
                    var myStockDB = new FStoreContext();
                    myStockDB.Orders.Remove(order);
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
