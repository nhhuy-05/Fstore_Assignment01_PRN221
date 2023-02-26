using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailResponsitory :IOrderDetailResponsitory
    {
        public OrderDetail GetOrderDetail(int orderId)=> OrderDetailDAO.Instance.GetOrderDetail(orderId);
        public void RemoveOrderDetailByOrderId(OrderDetail order)=>OrderDetailDAO.Instance.RemoveOrderDetailByOrderId(order);
        public List<OrderDetail> GetOrderDetailByProductId(int productId)=>OrderDetailDAO.Instance.GetOrderDetailByProductId(productId);
        public void RemoveOrderDetailByProductId(int productId) => OrderDetailDAO.Instance.RemoveOrderDetailByProductId(productId);
    }
}
