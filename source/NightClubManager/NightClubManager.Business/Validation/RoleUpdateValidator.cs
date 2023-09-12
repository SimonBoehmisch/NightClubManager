using FluentValidation;
using NightClubManager.Common.Dtos.Role;

namespace NightClubManager.Business.Validation;

public class RoleUpdateValidator : AbstractValidator<RoleUpdate>
{
    public RoleUpdateValidator()
    {
        RuleFor(roleUpdate => roleUpdate.Name).NotEmpty().MaximumLength(20);
    }
}