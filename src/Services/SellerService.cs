using Microsoft.EntityFrameworkCore;
using SalesWebMvcApp.Data;
using src.Models;

namespace src.Services
{
    public class SellerService
    {
        private readonly SalesContext _context;

        public SellerService(SalesContext context) => _context = context;

        public List<Seller> FindAll() => _context.Seller.ToList();
        public Seller FindById(int id) => _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = FindById(id);
            _context.Remove(obj);
            _context.SaveChanges();
        }
    }
}