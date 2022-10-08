using net6_api_compras.Domain.Validations;

namespace net6_api_compras.Domain.Entities
{
    // Sealed não pode ser herdada
    public sealed class Product : Base
    {
        public string Name { get; private set; }
        public string CodErp { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }

        public Product(string name, string codErp, decimal price)
        {
            Validate(name, codErp, price);
            Purchases = new List<Purchase>();
        }

        public void Validate(string name, string codErp, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome do produto deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(codErp), "Código do produto deve ser informado!");
            DomainValidationException.When(price < 0, "Preço do produto deve ser informado!");

            Name = name;
            CodErp = codErp;
            Price = price;
        }
    }
}
