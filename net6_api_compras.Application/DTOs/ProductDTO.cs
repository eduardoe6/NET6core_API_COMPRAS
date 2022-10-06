namespace net6_api_compras.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string CodErp { get; private set; }
        public decimal Price { get; private set; }
    }
}
