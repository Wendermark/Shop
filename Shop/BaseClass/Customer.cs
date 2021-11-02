using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Interfaces;

namespace Shop.BaseClass
{
    class Customer : ICustomer, IEquatable<ICustomer>
    {
        public Customer(string name = "Unknown name") => (Name, Id) = (name, Guid.NewGuid());

        public string Name { get; }

        public Guid Id { get; private set; }

        public void Pay(int sum) => Console.WriteLine($"{Name} заплатил {sum} тугриков");

        public override string ToString() => $"Имя покупателя - {Name}, уникальный id = {Id}";

        public bool Equals(ICustomer other) => Id.Equals(other.Id);

        public override bool Equals(object obj) => Equals((ICustomer)obj);

        public override int GetHashCode() => Id.GetHashCode();
    }
}
