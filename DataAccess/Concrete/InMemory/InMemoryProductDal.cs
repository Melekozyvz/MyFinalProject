﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>() { 
                new Product(){ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInstock=15},
                new Product(){ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInstock=3},
                new Product(){ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInstock=2},
                new Product(){ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInstock=65},
                new Product(){ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInstock=1},

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //Foreach ile ve if yerine Linq ile aşağıdaki gibi kullanılır.
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();

        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInstock = product.UnitsInstock;
        }
    }
}
