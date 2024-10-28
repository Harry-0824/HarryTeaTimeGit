using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaTimeDemo.DataAccess.Data;
using TeaTimeDemo.DataAccess.Repository.IRepository;
using TeaTimeDemo.Models;

namespace TeaTimeDemo.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository  
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        //public void Save()
        //{
        //    _db.SaveChanges();
        //}
        public void Update(Product obj)
        {
            var objFromdb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromdb != null) 
            {
                objFromdb.Name = obj.Name;
                objFromdb.Size = obj.Size;
                objFromdb.Price = obj.Price;
                objFromdb.Description = obj.Description;
                objFromdb.CategoryId = obj.CategoryId;
            }
            if (objFromdb.ImageUrl != null) 
            {
                objFromdb.ImageUrl = obj.ImageUrl;
            }

        }
    }
}
