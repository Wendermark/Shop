using System;
using Shop.BaseClass;
using Shop.Interfaces;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstCustomer = new Customer("Ваня");

            var secondCustomer = new Customer("Женя");

            ICustomersCollection<Customer> collection = new CustomCollection<Customer>();

            collection.AddCustomer(firstCustomer);

            var milkCategory = new Category("Молочные продукты");

            var milk = new Product(milkCategory, "Молоко");

            var meatCategory = new Category("Мясные продукты");

            var sausages = new Product(meatCategory, "Сосиски");

            collection.AddProduct(firstCustomer, milk);

            Console.WriteLine();

            collection.ExamineCustomer(firstCustomer);

            Console.WriteLine();

            collection.AddProduct(secondCustomer, milk);

            collection.AddProduct(secondCustomer, sausages);

            Console.WriteLine();

            collection.GetCustomerByCategory(milkCategory);

            Console.WriteLine();

            collection.GetCustomerByCategory(meatCategory);

            Console.WriteLine();

            collection.ExamineCustomer(secondCustomer);

            Console.ReadKey();
        }
    }
}
