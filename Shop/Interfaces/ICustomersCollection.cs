﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.BaseClass;

namespace Shop.Interfaces
{
    interface ICustomersCollection<T>
    {
        public ICart GetCart(T customer);

        public void AddCustomer(T customer);

        public void ExamineCustomer(T customer);

        public void GetCustomerByCategory(Category category);

        public void RemoveProduct(T customer, Product product);

        public void AddProduct(T customer, Product product);
    }
}
