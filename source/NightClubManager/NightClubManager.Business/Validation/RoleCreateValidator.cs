using FluentValidation;
using NightClubManager.Common.Dtos.Role;

namespace NightClubManager.Business.Validation;

public class RoleCreateValidator : AbstractValidator<RoleCreate>
{
    public RoleCreateValidator()
    {
        RuleFor(roleCreate => roleCreate.Name).NotEmpty().MaximumLength(20);
    }
}
