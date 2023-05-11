using SalesWebMvcApp.Data;
using src.Models;
using src.Models.Enums;

namespace src.Data
{
    public class SeedingService
    {
        private SalesContext _context;

        public SeedingService(SalesContext context) => _context = context;

        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Seller.Any()     ||
                _context.SalesRecord.Any())
            {
                return; //DB has been seeded
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Bob Gray", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d2);
            Seller s3 = new Seller(3, "Bob Yellow", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d3);
            Seller s4 = new Seller(4, "Bob Red", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d4);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2018,9,25), 1000.0, SaleStatus.Billed, s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2018,9,25), 1000.0, SaleStatus.Billed, s2);
            SalesRecord sr3 = new SalesRecord(3, new DateTime(2018,9,25), 1000.0, SaleStatus.Billed, s3);
            SalesRecord sr4 = new SalesRecord(4, new DateTime(2018,9,25), 1000.0, SaleStatus.Billed, s4);

            _context.Department.AddRange(d1,d2,d3,d4);
            _context.Seller.AddRange(s1,s2,s3,s4);
            _context.SalesRecord.AddRange(sr1,sr2,sr3,sr4);

            _context.SaveChanges();
        }
    }
}