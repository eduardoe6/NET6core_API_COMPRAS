using FluentValidation;

namespace net6_api_compras.Application.DTOs.Validations
{
    // Agora usando o FluentValidations para validar os dados que vem de fora.
    public class PersonDTOValidator : AbstractValidator<PersonDTO>
    {
        public PersonDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome da pessoa deve ser informado");

            RuleFor(x => x.Document)
                .NotEmpty()
                .NotNull()
                .WithMessage("Documento da pessoa deve ser informado!");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .NotNull()
                .WithMessage("Telefone da pessoa deve ser informado");
        }
    }
}
