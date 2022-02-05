﻿using SunriseClothingStore.Models.Pages;

namespace SunriseClothingStore.Models.Repositories.Interfaces;

public interface IProductRepository
{
    IQueryable<Product> Products { get; }
    PagedList<Product> GetProducts(QueryOptions options);
    Product FindProduct(Guid key);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void RemoveProduct(Guid key);
}