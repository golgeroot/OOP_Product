using BusinessLayer;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Product
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string islemTuru = "Product";
            string testTuru = "ListWhere";

            if (islemTuru == "Category")
            {
                CategoryManager cm = new CategoryManager();
                Category c = new Category();
                if (testTuru == "Update")
                {
                    c.CategoryID = 99;
                    c.CategoryName = "Güncellenen Satır";
                    cm.BLUpdate(c);
                }
                else if (testTuru == "List")
                {
                    foreach (var item in cm.GetAll())
                    {
                        Console.WriteLine("ID: " + item.CategoryID + " - Kategori Adı: " + item.CategoryName);
                    }
                }
                else if (testTuru == "Insert")
                {
                    Category ct = new Category();
                    ct.CategoryName = "Ütü Masası";
                    cm.BLAdd(ct);
                }
                else if (testTuru == "Delete")
                {
                    cm.BLDelete(7);
                }
            }

            if (islemTuru == "Product")
            {
                ProductManager pm = new ProductManager();
                Product pu = new Product();
                if (testTuru == "Update")
                {

                }
                else if (testTuru == "List")
                {
                    foreach (var item in pm.GetAll())
                    {
                        Console.WriteLine("Ürün ID= " + item.ProductID + "\nÜrün: " + item.ProductName
                            + "\nKategori ID: " + "\nStok: " + item.Stock +"\nKategoryi Id: "+ item.CategoryID 
                            + "\nKategori: " + item.Category);
                        Console.WriteLine();
                    }
                }
                else if (testTuru=="ListWhere")
                {
                    string productName = "Laptop";
                    foreach (var item in pm.GetByName(productName))
                    {
                        Console.WriteLine("Ürün ID= " + item.ProductID + "\nÜrün: " + item.ProductName
                            + "\nKategori ID: " + "\nStok: " + item.Stock + "\nKategoryi Id: " + item.CategoryID
                            + "\nKategori: " + item.Category);
                        Console.WriteLine();
                    }
                }
                else if (testTuru == "Insert")
                {

                }
                else if (testTuru == "Delete")
                {
                }
            }
        }
    }
}
