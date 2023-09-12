using FluentValidation;
using NightClubManager.Common.Dtos.RoleRequirement;

namespace NightClubManager.Business.Validation;

public class RoleRequirementUpdateValidator : AbstractValidator<RoleRequirementUpdate>
{
    public RoleRequirementUpdateValidator()
    {
        RuleFor(roleRequirementUpdate => roleRequirementUpdate.EventId).NotEmpty();
        RuleFor(roleRequirementUpdate => roleRequirementUpdate.RoleId).NotEmpty();
        RuleFor(roleRequirementUpdate => roleRequirementUpdate.RequiredEmployees).NotEmpty();
    }
}