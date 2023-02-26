﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderResponsitory
    {
        List<Order> GetOrders();
        void AddOrder(Order order); 
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
