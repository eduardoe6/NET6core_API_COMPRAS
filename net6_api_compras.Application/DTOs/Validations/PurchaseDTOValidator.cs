using FluentValidation;

namespace net6_api_compras.Application.DTOs.Validations
{
    public class PurchaseDTOValidator : AbstractValidator<PurchaseDTO>
    {
        public PurchaseDTOValidator()
        {
            RuleFor(x => x.PersonId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Código da pessoa vinculada a compra deve ser informado");

            RuleFor(x => x.ProductId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Código do produto vinculado a compra deve ser informado!");

            RuleFor(x => x.Date)
                .NotEmpty()
                .NotNull()
                .WithMessage("Data da compra deve ser informado");
        }
    }
}
