namespace src.Models
{
    public class Seller
    {
        public Seller() { }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            this.Id = id;
            this.Name = name;
            this.email = email;
            this.BirthDate = birthDate;
            this.BaseSalary = baseSalary;
            this.Department = department;

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

       
        public void AddSales(SalesRecord sr) => Sales.Add(sr);
        public void RemoveSales(SalesRecord sr) => Sales.Remove(sr);
        
        //filtra o período e faz a soma do Ammount de cada elemento da lista
        public double TotalSales(DateTime start, DateTime end) => Sales.Where(sr => sr.Date >= start && sr.Date <= end).Sum(sr => sr.Ammount);

    }
}