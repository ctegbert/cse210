using System;
using System.Collections.Generic;

// Class to represent a product
public class Product
{
    public string Name { get; private set; }
    public string ProductId { get; private set; }
    public double PricePerUnit { get; private set; }
    public int Quantity { get; private set; }

    // Constructor
    public Product(string name, string productId, double pricePerUnit, int quantity)
    {
        Name = name;
        ProductId = productId;
        PricePerUnit = pricePerUnit;
        Quantity = quantity;
    }

    // Method to calculate the total cost of the product
    public double CalculateTotalCost()
    {
        return PricePerUnit * Quantity;
    }
}

// Class to represent an address
public class Address
{
    public string StreetAddress { get; private set; }
    public string City { get; private set; }
    public string StateProvince { get; private set; }
    public string Country { get; private set; }

    // Constructor
    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        StreetAddress = streetAddress;
        City = city;
        StateProvince = stateProvince;
        Country = country;
    }

    // Method to check if the address is in the USA
    public bool IsInUSA()
    {
        return Country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    // Method to return the address as a string
    public override string ToString()
    {
        return $"{StreetAddress}\n{City}, {StateProvince}\n{Country}";
    }
}

// Class to represent a customer
public class Customer
{
    public string Name { get; private set; }
    public Address Address { get; private set; }

    // Constructor
    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    // Method to check if the customer lives in the USA
    public bool LivesInUSA()
    {
        return Address.IsInUSA();
    }
}

// Class to represent an order
public class Order
{
    private List<Product> products;
    private Customer customer;

    // Constructor
    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    // Method to add a product to the order
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    // Method to calculate the total cost of the order
    public double CalculateTotalCost()
    {
        double totalCost = 0;
        foreach (var product in products)
        {
            totalCost += product.CalculateTotalCost();
        }

        // Add shipping cost based on customer's location
        if (customer.LivesInUSA())
        {
            totalCost += 5; // Shipping cost within USA
        }
        else
        {
            totalCost += 35; // Shipping cost outside USA
        }

        return totalCost;
    }

    // Method to generate the packing label
    public string GeneratePackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (var product in products)
        {
            packingLabel += $"{product.Name} ({product.ProductId})\n";
        }
        return packingLabel;
    }

    // Method to generate the shipping label
    public string GenerateShippingLabel()
    {
        return $"Shipping Label:\n{customer.Name}\n{customer.Address}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create address
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Address address2 = new Address("456 Oak St", "Otherville", "TX", "Mexico");

        // Create customers
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create products
        Product product1 = new Product("Product 1", "12345", 10.50, 2);
        Product product2 = new Product("Product 2", "67890", 20.75, 3);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);

        // Display order details
        Console.WriteLine("Order 1 Details:");
        Console.WriteLine(order1.GeneratePackingLabel());
        Console.WriteLine(order1.GenerateShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():F2}\n");

        Console.WriteLine("Order 2 Details:");
        Console.WriteLine(order2.GeneratePackingLabel());
        Console.WriteLine(order2.GenerateShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():F2}");
    }
}
