using net6_api_compras.Domain.Validations;

namespace net6_api_compras.Domain.Entities
{
    public abstract class Base
    {
        public int Id { get; set; }

        public void Validate(int id)
        {
            DomainValidationException.When(id < 0, "Id da pessoa deve ser informado!");
            Id = id;
        }
    }
}
