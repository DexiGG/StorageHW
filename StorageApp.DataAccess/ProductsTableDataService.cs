using StorageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageApp.DataAccess
{
    public class ProductsTableDataService
    {
        #region Обновление продукта
        public static void UpdateProduct(string name)
        {
            Guid id = GetId(name);

            var context = new ProductsContext();
            var product = context.Products.Where(p => p.Id == id).FirstOrDefault();

            Console.Clear();
            Console.Write("Введите обновленные даннные\n" +
                        "Название: ");
            product.Name = Console.ReadLine();
            Console.Write("Производитель: ");
            product.Manufacturer = Console.ReadLine();

            double price = 0;
            while (price <= 0)
            {
                Console.Write("Цена: ");
                double.TryParse(Console.ReadLine(), out price);
            }
            product.Price = price;

            int quantity = 0;
            while (quantity <= 0)
            {
                Console.Write("Количество: ");
                int.TryParse(Console.ReadLine(), out quantity);
            }
            product.Quantity = quantity;
            
            try
            {
                context.SaveChanges();
                Console.WriteLine("Запись изменена!");
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
            }
            Console.Write("Нажмите Enter чтобы продолжить...");
            Console.ReadLine();
        }
        #endregion

        #region Удаление продукта
        public static void DeleteProduct(string name)
        {
            Guid id = GetId(name);

            var context = new ProductsContext();
            var product = context.Products.Where(p => p.Id == id).FirstOrDefault();

            Console.Clear();
            try
            {
                context.Products.Remove(product);
                context.SaveChanges();
                Console.WriteLine("Запись удалена!");
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
            }
            Console.Write("Нажмите Enter чтобы продолжить...");
            Console.ReadLine();
        }
        #endregion

        #region Добавление продукта
        public static void InsertProduct()
        {
            var context = new ProductsContext();
            Product product = new Product();

            Console.Write("Введите даннные\n" +
                        "Название: ");
            product.Name = Console.ReadLine();
            Console.Write("Производитель: ");
            product.Manufacturer = Console.ReadLine();
            
            double price = 0;
            while (price <= 0)
            {
                Console.Write("Цена: ");
                double.TryParse(Console.ReadLine(), out price);
            }
            product.Price = price;
            
            int quantity = 0;
            while (quantity <= 0)
            {
                Console.Write("Количество: ");
                int.TryParse(Console.ReadLine(), out quantity);
            }
            product.Quantity = quantity;

            try
            {
                context.Products.Add(product);
                context.SaveChanges();
                Console.WriteLine("Запись добавлена!");
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
            }
            Console.Write("Нажмите Enter чтобы продолжить...");
            Console.ReadLine();
        }
        #endregion

        #region Получение Id продукта
        public static Guid GetId(string name)
        {
            var context = new ProductsContext();

            IEnumerable<Product> productIEnum = context.Products;
            var products = productIEnum.Where(p => p.Name == name).ToList();

            int choice = 0;
            bool check = false;

            while (!check)
            {
                System.Console.Clear();
                Console.WriteLine("Выберите запись для изменения/удаления: ");
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) Найденная запись");
                    products[i].Show();
                }

                check = int.TryParse(System.Console.ReadLine(), out choice);
                if (choice < 0 || choice > products.Count)
                    check = false;
            }
            return products[choice - 1].Id;
        }
        #endregion
    }
}
