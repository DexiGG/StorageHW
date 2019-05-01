using StorageApp.DataAccess;
using System;

namespace StorageApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int choice = 0;
                bool check = false;
                while (!check)
                {
                    System.Console.Clear();
                    System.Console.Write("\tСклад продуктов\n" + 
                                        "1) Добавить\n" +
                                        "2) Изменить\n" +
                                        "3) Удалить\n" +
                                        "4) Выход\n" +
                                        "Выберите действие: ");
                    check = int.TryParse(System.Console.ReadLine(), out choice);
                    if (choice < 1 || choice > 4)
                        check = false;
                    if (choice == 4)
                        Environment.Exit(0);
                }
                System.Console.Clear();

                string productName = "";
                if (choice > 1)
                {
                    System.Console.WriteLine("Введите название продукта которое хотите изменить: ");
                    productName = System.Console.ReadLine();
                }

                switch (choice)
                {
                    case 1: ProductsTableDataService.InsertProduct(); break;
                    case 2: ProductsTableDataService.UpdateProduct(productName); break;
                    case 3: ProductsTableDataService.DeleteProduct(productName); break;
                }
            }
        }
    }
}
