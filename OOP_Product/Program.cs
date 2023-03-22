using BusinessLayer;
using BusinessLayer.ValidationRules;
using EntityLayer.Entities;
using FluentValidation.Results;
using System;

namespace OOP_Product
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string islemTuru = "Category";
            string testTuru = "Insert";

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
                    c.CategoryName = "Test Yeni";
                    CategoryValidator categoryValidator = new CategoryValidator();
                    ValidationResult results = categoryValidator.Validate(c);
                    if (results.IsValid)
                    {
                        cm.BLAdd(c);
                        Console.WriteLine("Eklendi");
                    }
                    else
                    {
                        foreach (var item in results.Errors)
                        {
                            Console.WriteLine(item.ErrorMessage);
                        }
                    }
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
                    pu.ProductID = 9;
                    pu.CategoryID = 1;
                    pu.ProductName = "Masa Laptop";
                    pm.DlUpdate(pu);
                }
                else if (testTuru == "List")
                {
                    foreach (var item in pm.GetAll())
                    {
                        Console.WriteLine("Ürün ID= " + item.ProductID + "\nÜrün: " + item.ProductName
                            + "\nKategori ID: " + "\nStok: " + item.Stock + "\nKategoryi Id: " + item.CategoryID
                            + "\nKategori: " + item.Category);
                        Console.WriteLine();
                    }
                }
                else if (testTuru == "ListWhere")
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
                    string kelime = "";
                    var rnd = new Random();
                    while (true)
                    {
                        Random sayi = new Random();
                        for (int i = 0; i < 6; i++)
                        {
                            kelime += ((char)rnd.Next('A', 'Z')).ToString();
                        }
                        pu.ProductName = kelime;
                        pu.Stock = sayi.Next(1, 500);
                        pu.CategoryID = 1;
                        pm.DLAdd(pu);
                        kelime = "";

                    }

                }
                else if (testTuru == "Delete")
                {
                    pm.DlDelete(8);
                }
            }
        }
    }
}
