using net6_api_compras.Domain.Validations;

namespace net6_api_compras.Domain.Entities
{
    public sealed class Purchase
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }
        public Person Person { get; set; }
        public Product Product { get; set; }

        public Purchase(int id, int productId, int personId)
        {
            DomainValidationException.When(id < 0, "Id da compra deve ser informado!");

            Id = id;

            Validate(productId, personId);
        }
        public Purchase(int productId, int personId)
        {
            Validate(productId, personId);
        }

        public void Validate(int productId, int personId)
        {
            DomainValidationException.When(productId < 0, "Id do produto deve ser informado!");
            DomainValidationException.When(personId < 0, "Id do cliente deve ser informado!");

            ProductId = productId;
            PersonId = personId;
            Date = DateTime.Now;
        }
    }
}
