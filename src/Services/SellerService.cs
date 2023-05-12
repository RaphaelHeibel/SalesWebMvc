using SalesWebMvcApp.Data;
using src.Models;

namespace src.Services
{
    public class SellerService
    {
        private readonly SalesContext _context;

        public SellerService(SalesContext context) => _context = context;

        public List<Seller> FindAll() => _context.Seller.ToList();

        public void Insert(Seller obj)
        {
            obj.Department = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(Seller obj)
        {
            _context.Remove(obj);
            _context.SaveChanges();
        }
    }
}