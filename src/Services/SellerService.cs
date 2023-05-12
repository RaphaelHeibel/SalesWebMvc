using SalesWebMvcApp.Data;
using src.Models;

namespace src.Services
{
    public class SellerService 
    {
        private readonly SalesContext _context;
        
        public SellerService(SalesContext context) => _context = context;

        public List<Seller> FindAll() => _context.Seller.ToList();
    }
}