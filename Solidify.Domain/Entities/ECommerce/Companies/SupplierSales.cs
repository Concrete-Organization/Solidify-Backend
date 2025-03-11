namespace Solidify.Domain.Entities.ECommerce.Companies
{
    public class SupplierSales
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime SalesDate { get; set; }
        public string OrderId { get; set; }
        public Order Order { get; set; }
        public string SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
