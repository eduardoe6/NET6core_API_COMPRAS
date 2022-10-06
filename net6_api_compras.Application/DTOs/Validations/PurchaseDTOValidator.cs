using FluentValidation;

namespace net6_api_compras.Application.DTOs.Validations
{
    public class PurchaseDTOValidator : AbstractValidator<PurchaseDTO>
    {
        public PurchaseDTOValidator()
        {
            RuleFor(n => n.PersonId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Código da pessoa vinculada a compra deve ser informado");

            RuleFor(p => p.ProductId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Código do produto vinculado a compra deve ser informado!");

            RuleFor(p => p.Date)
                .NotEmpty()
                .NotNull()
                .WithMessage("Data da compra deve ser informado");
        }
    }
}
