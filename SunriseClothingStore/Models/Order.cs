﻿namespace SunriseClothingStore.Models;

public class Order
{
    public Guid Id { get; set; }
    public string CustomerName { get; set; }
    public string Address { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public bool Shipped { get; set; }
    public IEnumerable<OrderLine> Lines { get; set; }
}