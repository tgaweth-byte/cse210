using System;
using System.Collections.Generic;

class Order
{
  private List<Product> _products;
  private Customer _customer;
  private const double US_SHIPPING = 5.00;
  private const double INTERNATIONAL_SHIPPING = 35.00;

  public Order(Customer customer)
  {
    _products = new List<Product>();
    _customer = customer;
  }

  public void AddProduct(Product product)
  {
    _products.Add(product);
  }

  public double GetTotalPrice()
  {
    double total = 0;
    foreach (Product product in _products)
    {
      total += product.GetTotalCost();
    }

    if (_customer.LivesInUSA())
    {
      total += US_SHIPPING;
    }
    else
    {
      total += INTERNATIONAL_SHIPPING;
    }

    return total;
  }

  public string GetPackingLabel()
  {
    string label = "PACKING LABEL:\n";
    foreach (Product product in _products)
    {
      label += $"- {product.GetName()} (ID: {product.GetProductId()})\n";
    }
    return label;
  }

  public string GetShippingLabel()
  {
    return $"SHIPPING LABEL:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
  }
}