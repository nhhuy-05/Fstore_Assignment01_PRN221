using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderResponsitory:IOrderResponsitory
    {
        public List<Order> GetOrders()=> OrderDAO.Instance.GetOrders();
        public void AddOrder(Order order) => OrderDAO.Instance.AddOrder(order);
        public void UpdateOrder(Order order) => OrderDAO.Instance.UpdateOrder(order);
        public void DeleteOrder(Order order) => OrderDAO.Instance.RemoveOrder(order);
    }
}
