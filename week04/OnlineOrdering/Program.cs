using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address usaAddress = new Address("123 Main St", "Springfield", "IL", "USA");
        Address internationalAddress = new Address("45 Maple Ave", "Toronto", "ON", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Smith", usaAddress);
        Customer customer2 = new Customer("Maria Garcia", internationalAddress);

        // Create products for order 1
        Product product1 = new Product("Laptop", "LAP123", 999.99, 1);
        Product product2 = new Product("Mouse", "MOU456", 24.99, 2);
        Product product3 = new Product("Keyboard", "KEY789", 79.99, 1);

        // Create order 1
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        // Create products for order 2
        Product product4 = new Product("Phone Case", "CAS001", 14.99, 3);
        Product product5 = new Product("Screen Protector", "SCR002", 9.99, 2);

        // Create order 2
        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // Display order 1
        Console.WriteLine("ORDER 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():0.00}");
        Console.WriteLine();

        // Display order 2
        Console.WriteLine("ORDER 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():0.00}");
    }
}