namespace net6_api_compras.Application.DTOs
{
    public class PurchaseDTO
    {
        public int Id { get; set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }
    }
}
