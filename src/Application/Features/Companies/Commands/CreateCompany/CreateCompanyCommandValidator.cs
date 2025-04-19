using HrmBaharu.Application.Features.Companies.Commands.CreateCompany;

namespace HrmBaharu.Application.Features.Companies.Commands.CreateDepartment;

public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(100)
            .NotEmpty();

        RuleFor(v => v.Address)
            .MaximumLength(200);
    }
}
