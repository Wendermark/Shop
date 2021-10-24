using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Interfaces;

namespace Shop.BaseClass
{
    class Category
    {
        public Category(string name = "Unknown category") => Name = name;
        public string Name { get; private set; }
    }
}
