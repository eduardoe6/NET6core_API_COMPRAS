using net6_api_compras.Domain.Validations;

namespace net6_api_compras.Domain.Entities
{
    // Sealed não pode ser herdada
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CodErp { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }

        public Product(int id, string name, string codErp, decimal price)
        {
            DomainValidationException.When(id < 0, "Id do produto deve ser maior que zero!");

            Id = id;

            Validate(name, codErp, price);
            Purchases = new List<Purchase>();
        }
        public Product(string name, string codErp, decimal price)
        {
            Validate(name, codErp, price);
            Purchases = new List<Purchase>();
        }

        public void Validate(string name, string codErp, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(Name), "Nome do produto deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(CodErp), "Código do produto deve ser informado!");
            DomainValidationException.When(Price < 0, "Preço do produto deve ser informado!");

            Name = name;
            CodErp = codErp;
            Price = price;
        }
    }
}
