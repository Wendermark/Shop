using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
    interface ICustomer
    {
        public string Name { get; }
        public Guid Id { get; }
        void Pay(int sum);
    }
}
