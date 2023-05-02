namespace SalesWebMvcApp.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //lista de ICollection instanciada 
        public ICollection<Seller> Sallers { get; set; } = new List<Seller>();

        //adição do construtor sem argumentos
        public Department() { }

        //adição do construtor sem argumentos
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller(Seller seller) 
        {
            Sallers.Add(seller);
        }

        public double TotalSales(DateTime start, DateTime end) 
        {
            //somando o total de vendas de cada vendedor do departamento reutilizando o método TotalSales
            return Sallers.Sum(seller => seller.TotalSales(start,end));
        }
    }
}
