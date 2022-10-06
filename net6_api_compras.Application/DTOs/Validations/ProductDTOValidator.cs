using FluentValidation;

namespace net6_api_compras.Application.DTOs.Validations
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(n => n.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome do produto deve ser informado");

            RuleFor(p => p.CodErp)
                .NotEmpty()
                .NotNull()
                .WithMessage("Código do produto deve ser informado!");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Preço do produto deve ser informado");
        }
    }
}
