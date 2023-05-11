using src.Models.Enums;

namespace src.Models
{
    public class SalesRecord
    {
        public SalesRecord() { }
        public SalesRecord(int id, DateTime date, double ammount, SaleStatus status, Seller seller)
        {
            this.Id = id;
            this.Date = date;
            this.Ammount = ammount;
            this.Status = status;
            this.Seller = seller;

        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Ammount { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }
    }
}