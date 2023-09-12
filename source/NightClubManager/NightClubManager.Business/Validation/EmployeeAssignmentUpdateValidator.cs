using FluentValidation;
using NightClubManager.Common.Dtos.EmployeeAssignment;

namespace NightClubManager.Business.Validation;

public class EmployeeAssignmentUpdateValidator : AbstractValidator<EmployeeAssignmentUpdate>
{
    public EmployeeAssignmentUpdateValidator()
    {
        RuleFor(employeeAssignmentUpdate => employeeAssignmentUpdate.IsAssigned).NotEmpty();
    }
}