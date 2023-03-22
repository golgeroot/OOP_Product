using DataAccessLayer;
using EntityLayer.Entities;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class ProductManager
    {
        Repository<Product> repoproduct = new Repository<Product>();

        public List<Product> GetAll()
        {
            return repoproduct.List();
        }
        public int DLAdd(Product T)
        {
            if (T.ProductName.Length <= 3)
            {
                return -1;
            }
            return repoproduct.Insert(T);
        }
        public List<Product> GetByName(string p)
        {
            return repoproduct.List(x => x.ProductName == p);
        }
    }  
}
