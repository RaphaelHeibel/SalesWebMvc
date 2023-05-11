namespace src.Models
{
    public class Department
    {

        public Department() { }
        public Department(int id, string name)
        {
            this.Id = id;
            this.Name = name;

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public void AddSaler(Seller seller) => Sellers.Add(seller);

        //soma o total de vendas de cada vendedor dentro do período informado
        public double TotalSales(DateTime start, DateTime end) => Sellers.Sum(seller => seller.TotalSales(start, end));
    }
}