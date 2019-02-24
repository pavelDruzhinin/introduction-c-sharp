namespace SaleProgresses.Domain
{
    public class SaleProgress
    {
        public short Id { get; set; }
        public short? ParentId { get; set; }
        public TaskType? TaskType { get; set; }
        public InvoiceType? InvoiceType { get; set; }
    }
}