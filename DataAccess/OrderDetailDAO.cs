using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        public static readonly object instanceLock = new object();

        private OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new OrderDetailDAO();
                }
                return instance;
            }
        }
        public OrderDetail GetOrderDetail(int OrderId)
        {
            OrderDetail orderDetail = null;
            try
            {
                var myStockDB = new FStoreContext();
                orderDetail = myStockDB.OrderDetails.SingleOrDefault(car => car.OrderId == OrderId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetail;
        }
        public void RemoveOrderDetailByOrderId(OrderDetail order)
        {
            try
            {
                OrderDetail m = GetOrderDetail(order.OrderId);
                if (m != null)
                {
                    var myStockDB = new FStoreContext();
                    myStockDB.OrderDetails.Remove(order);
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
        public List<OrderDetail> GetOrderDetailByProductId(int productId)
        {
            List<OrderDetail> orderDetails = null;
            try
            {
                var myStockDB = new FStoreContext();
                orderDetails = myStockDB.OrderDetails.Where(x=>x.ProductId==productId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }
        public void RemoveOrderDetailByProductId(int productId)
        {
            try
            {
                List<OrderDetail> m = GetOrderDetailByProductId(productId);
                if (m != null)
                {
                    var myStockDB = new FStoreContext();
                    foreach(OrderDetail o in m)
                    {
                        myStockDB.OrderDetails.Remove(o);
                    }
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
