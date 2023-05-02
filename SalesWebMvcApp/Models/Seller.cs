namespace SalesWebMvcApp.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSallar { get; set; }
        public Department Department { get; set; }
        //lista de ICollection instanciada 
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        //adição do construtor sem argumentos
        public Seller() { }

        //adição do construtor sem argumentos
        public Seller(int id, string name, string email, DateTime birthDate, double baseSallar, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSallar = baseSallar;
            Department = department;
        }

        public void AddSales(SalesRecord salesRecord) 
        {
            Sales.Add(salesRecord);
        }

        public void RemoveSales(SalesRecord salesRecord) 
        {
            Sales.Remove(salesRecord);
        }

        public double TotalSales(DateTime start, DateTime end) 
        {            
            return Sales.Where(sr => sr.Date >= start && sr.Date <= end).Sum(sr => sr.Amount);
        }
    }
}
