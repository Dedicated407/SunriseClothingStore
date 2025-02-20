﻿using Microsoft.EntityFrameworkCore;
using SunriseClothingStore.Models.Pages;
using SunriseClothingStore.Models.Repositories.Interfaces;

namespace SunriseClothingStore.Models.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly StoreContext _context;
    public IQueryable<Product> Products => _context.Products.Include(product => product.Category);

    public ProductRepository(StoreContext context) => _context = context;

    #region Find

    public PagedList<Product> GetProducts(QueryOptions options, string? categoryName = null)
    {
        IQueryable<Product> query = _context.Products.Include(p => p.Category);
        if (categoryName != null)
        {
            query = query.Where(p => p.Category.Name.Equals(categoryName));
        }
        return new PagedList<Product>(query, options);
    }

    public IQueryable<Product> GetAllProducts()
    {
        return _context.Products;
    }

    public Product FindProduct(Guid key)
    {
        return _context.Products.Include(product => product.Category)
            .First(product => product.Id == key);
        // return _context.Products.Find(key);
    }

    #endregion

    #region Add

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    #endregion

    #region Update

    public void UpdateProduct(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    #endregion

    #region Remove

    public void RemoveProduct(Guid key)
    {
        _context.Products.Remove(FindProduct(key));
        _context.SaveChanges();
    }

    #endregion
}