using FluentValidation;
using NightClubManager.Common.Dtos.Employee;

namespace NightClubManager.Business.Validation;

public class EmployeeCreateValidator : AbstractValidator<EmployeeCreate>
{
    public EmployeeCreateValidator()
    {
        RuleFor(employeeCreate => employeeCreate.FirstName).NotEmpty().MaximumLength(20);
        RuleFor(employeeCreate => employeeCreate.LastName).NotEmpty().MaximumLength(20);
        RuleFor(employeeCreate => employeeCreate.Roles).NotEmpty();
    }
}
