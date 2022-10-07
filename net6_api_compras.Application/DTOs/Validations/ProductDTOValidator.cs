using FluentValidation;

namespace net6_api_compras.Application.DTOs.Validations
{
    // Agora usando o FluentValidations para validar os dados que vem de fora.
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome do produto deve ser informado");

            RuleFor(x => x.CodErp)
                .NotEmpty()
                .NotNull()
                .WithMessage("Código do produto deve ser informado!");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Preço do produto deve ser informado");
        }
    }
}
