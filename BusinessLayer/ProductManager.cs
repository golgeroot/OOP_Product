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
        public int DlDelete(int de)
        {
            if (de==0)
            {
                return -1;
            }
            Product p = repoproduct.Find(c => c.ProductID == de);
            return repoproduct.Delete(p);
        }
        public int DlUpdate(Product u)
        {
            if (u.ProductID==0)
            {
                return -1;
            }
            Product p = repoproduct.Find(x => x.ProductID == u.ProductID);
            p.ProductName = u.ProductName;
            p.CategoryID = u.CategoryID;
            return repoproduct.Update(p);
        }
    }  
}
