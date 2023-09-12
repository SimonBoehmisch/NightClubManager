using FluentValidation;
using NightClubManager.Common.Dtos.RoleRequirement;

namespace NightClubManager.Business.Validation;

public class RoleRequirementCreateValidator : AbstractValidator<RoleRequirementCreate>
{
    public RoleRequirementCreateValidator()
    {
        RuleFor(roleRequirementCreate => roleRequirementCreate.EventId).NotEmpty();
        RuleFor(roleRequirementCreate => roleRequirementCreate.RoleId).NotEmpty();
        RuleFor(roleRequirementCreate => roleRequirementCreate.RequiredEmployees).NotEmpty();
    }
}