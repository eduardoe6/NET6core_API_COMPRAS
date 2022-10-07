using FluentValidation;

namespace net6_api_compras.Application.DTOs.Validations
{
    // Agora usando o FluentValidations para validar os dados que vem de fora.
    public class PurchaseDTOValidator : AbstractValidator<PurchaseDTO>
    {
        public PurchaseDTOValidator()
        {
            RuleFor(x => x.Document)
                .NotEmpty()
                .NotNull()
                .WithMessage("Documento da pessoa vinculada a compra deve ser informado");

            RuleFor(x => x.CodErp)
                .NotEmpty()
                .NotNull()
                .WithMessage("Código do produto vinculado a compra deve ser informado!");
        }
    }
}
