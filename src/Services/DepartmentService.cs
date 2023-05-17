using SalesWebMvcApp.Data;
using src.Models;

namespace src.Services
{
    public class DepartmentService
    {
        private readonly SalesContext _context;

        public DepartmentService(SalesContext context) => _context = context;

        public List<Department> ListAll() => _context.Department.OrderBy(d => d.Name).ToList();
        
         
    }
}