using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Interfaces;

namespace Shop.BaseClass
{
    class CustomersCollection<T> : IEnumerable, ICustomersCollection<T> where T : ICustomer
    {
        public CustomersCollection()
        {
            List = new Dictionary<T, ICart>();
            Count = 0;
        }

        public Dictionary<T, ICart> List { get; private set; }

        public int Count { get; private set; }

        public IEnumerator GetEnumerator()
        {
            foreach (KeyValuePair<T, ICart> item in List)
                yield return item.Key;
        }

        public void AddCustomer(T customer)
        {
            if (!(customer is null))
                List.TryAdd(customer, new Cart());
        }

        public void ExamineCustomer(T customer)
        {
            ICart cart = GetCart(customer);

            if (cart is null)
                Console.WriteLine("Такого покупателя нет!");
            else
            {
                Console.WriteLine(customer);
                cart.Examine();
            }
        }

        public void GetCustomerByCategory(Category category)
        {
            if (!(category is null))
            {
                Console.WriteLine($"Покупатели которые имеют в корзине продукт категории {category.Name}:");
                foreach (KeyValuePair<T, ICart> customer in List)
                {
                    if (customer.Value.IsContainingCategory(category))
                        Console.WriteLine(customer.Key);
                }
            }
        }

        public void AddProduct(T customer, Product product)
        {
            if (!List.ContainsKey(customer))
                AddCustomer(customer);

            ICart cart = GetCart(customer);

            if (cart is null)
                Console.WriteLine("Такого покупателя нет!");
            else
                Console.WriteLine(cart.AddProduct(product) ? "Продукт успешно добавлен" : "Такой продукт уже есть");
        }

        public ICart GetCart(T customer)
        {
            if (!(customer is null) | List.TryGetValue(customer, out ICart cart))
            {
                return cart;
            }
            else return null;
        }

        public void RemoveProduct(T customer, Product product)
        {
            ICart cart = GetCart(customer);

                if (cart is null)
                    Console.WriteLine("Такого покупателя нет!");
                else
                    Console.WriteLine(cart.RemoveProduct(product) ? "Продукт успешно удалён" : "Такого продукта нет!");
        }
    }
}
