using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Interfaces;

namespace Shop.BaseClass
{
    class Customer : ICustomer, IEquatable<Customer>
    {
        public Customer(string name = "Unknown name") => (Name, Id) = (name, Guid.NewGuid());

        public string Name { get; }

        public Guid Id { get; private set; }

        public bool Equals(Customer other) => Id.Equals(other.Id);

        public void Pay(int sum) => Console.WriteLine($"{Name} заплатил {sum} тугриков");

        public override string ToString() => $"Имя покупателя - {Name}, уникальный id = {Id}";

        public override bool Equals(object obj) => Equals((Customer)obj);

        public override int GetHashCode() => Id.GetHashCode();
    }
}
