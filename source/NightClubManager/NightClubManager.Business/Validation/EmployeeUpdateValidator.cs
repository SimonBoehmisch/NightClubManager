using FluentValidation;
using NightClubManager.Common.Dtos.Employee;

namespace NightClubManager.Business.Validation;

public class EmployeeUpdateValidator : AbstractValidator<EmployeeUpdate>
{
    public EmployeeUpdateValidator()
    {
        RuleFor(employeeUpdate => employeeUpdate.FirstName).NotEmpty().MaximumLength(20);
        RuleFor(employeeUpdate => employeeUpdate.LastName).NotEmpty().MaximumLength(20);
        RuleFor(employeeUpdate => employeeUpdate.Roles).NotEmpty();
    }
}