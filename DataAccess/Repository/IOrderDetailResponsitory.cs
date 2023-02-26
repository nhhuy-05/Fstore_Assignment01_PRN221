using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailResponsitory
    {
        OrderDetail GetOrderDetail(int orderId);
        void RemoveOrderDetailByOrderId(OrderDetail order);
        List<OrderDetail> GetOrderDetailByProductId(int productId);
        void RemoveOrderDetailByProductId(int productId);
    }
}
