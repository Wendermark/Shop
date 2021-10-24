using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BaseClass
{
    class Product
    {
        public Product(Category category, string name = "Unknown Product") => (Name, Category) = (name, category);
        public string Name { get; private set; }
        public Category Category { get; private set; }
        public override string ToString() => $"Название продукта - {Name}, Категория - {Category.Name}";
    }
}
