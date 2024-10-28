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
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private ApplicationDbContext _db;
        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(OrderHeader obj)
        {
            _db.OrderHeaders.Update(obj);
        }

        public void UpdateStatus(int id, string orderstatus, string? paymentStatus = null)
        {
            var orderFromdb = _db.OrderHeaders.FirstOrDefault(u =>u.Id == id);
            if (orderFromdb != null)
            {
                orderFromdb.OrderStatus = orderstatus;
                if (!string.IsNullOrEmpty(paymentStatus))
                {
                    orderFromdb.PaymentStatus = paymentStatus;
                }
            }
        }
    }
}
