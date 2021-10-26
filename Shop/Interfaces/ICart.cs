using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.BaseClass;

namespace Shop.Interfaces
{
    interface ICart
    {
        public bool AddProduct(Product product);
        public void Examine();
        public bool IsContainingCategory(Category category);
    }
}
