﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Interfaces;

namespace Shop.BaseClass
{
    class Cart : ICart
    {
        public Cart() => Products = new List<Product>();

        public List<Product> Products { get; private set; }

        public uint Count { get; private set; }

        public bool AddProduct(Product product)
        {
            if (product != null && !Products.Contains(product))
            {
                Products.Add(product);
                Count++;
                return true;
            }
            return false;
        }

        public void Examine()
        {
            if (Products.Count > 0)
            {
                Console.WriteLine("В корзине:");
                foreach (Product product in Products)
                    Console.WriteLine(product);
            }
            else
                Console.WriteLine("В корзине нет продуктов!");
        }

        public bool IsContainingCategory(Category category)
        {
            foreach (Product product in Products)
            {
                if (product.Category.Name.ToLower().Equals(category.Name.ToLower()))
                    return true;
            }
            return false;
        }

        public override string ToString() => $"В корзине {Count} продуктов";

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var produxt in Products)
                yield return produxt;
        }
    }
}
