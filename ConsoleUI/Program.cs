using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        //SOLİD
        //O -> Open closed principle (yapıyı değişritmeden yeni bir özellik eklemek.)
        static void Main(string[] args)
        {

            ProductManager manager = new ProductManager(new EfProductDal());
            foreach (var product in manager.GetByUnitPrice(40,100))
            {
                Console.WriteLine(product.ProductName);

            }
        }
    }
}
