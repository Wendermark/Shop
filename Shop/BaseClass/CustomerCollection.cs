using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Interfaces;

namespace Shop.BaseClass
{
    class CustomerCollection : IEnumerable, ICustomerCollection<ICustomer>
    {
        public CustomerCollection()
        {
            List = new Dictionary<ICustomer, ICart>();
            Count = 0;
        }
        public Dictionary<ICustomer, ICart> List { get; private set; }

        public int Count { get; private set; }

        public IEnumerator GetEnumerator()
        {
            foreach (KeyValuePair<ICustomer, ICart> item in List)
                yield return item.Key;
        }

        public void AddCustomer(ICustomer customer)
        {
            if (!(customer is null))
                List.TryAdd(customer, new Cart());
        }

        public void ExamineCustomer(ICustomer customer)
        {
            if (List.ContainsKey(customer))
            {
                ICart cart = GetCart(customer);

                Console.WriteLine(customer);

                cart.Examine();
            }
        }

        public void GetCustomerByCategory(Category category)
        {
            if (!(category is null))
            {
                Console.WriteLine($"Покупатели которые имеют в корзине продукт категории {category.Name}:");
                foreach (KeyValuePair<ICustomer, ICart> customer in List)
                {
                    if (customer.Value.IsContainingCategory(category))
                        Console.WriteLine(customer.Key);
                }
            }
        }

        public void AddProduct(ICustomer customer, Product product)
        {
            if (!List.ContainsKey(customer))
                AddCustomer(customer);

            ICart cart = GetCart(customer);

            Console.WriteLine(cart.AddProduct(product) ? "Продукт успешно добавлен" : "Такой продукт уже есть");
        }

        public ICart GetCart(ICustomer customer) => (customer != null && List.TryGetValue(customer, out ICart cart)) ? cart : null;
    }
}
