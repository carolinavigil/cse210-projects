using System;

class Program
{
    static void Main(string[] args)
    {
        // First order
        Address address1 = new Address("123 Apple St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Smith", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "LPT123", 999.99m, 1));
        order1.AddProduct(new Product("Mouse", "MSE456", 25.50m, 2));

        DisplayOrder(order1);

        // Second order
        Address address2 = new Address("45 Maple Lane", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Alice Johnson", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Monitor", "MON789", 150.00m, 1));
        order2.AddProduct(new Product("Keyboard", "KBD321", 40.00m, 1));
        order2.AddProduct(new Product("USB Drive", "USB111", 10.00m, 3));

        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}");
        Console.WriteLine(new string('-', 40));
    }
}
