using System;

namespace StorageApp.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public void Show()
        {
            Console.WriteLine("Название: {0}\n" +
                "Производитель: {1}\n" +
                "Цена: {2}\n" +
                "Количество: {3}",
                Name, Manufacturer, Price, Quantity);
        }
    }
}
