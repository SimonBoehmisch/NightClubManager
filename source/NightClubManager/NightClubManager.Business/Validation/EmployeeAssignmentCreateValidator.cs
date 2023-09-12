using FluentValidation;
using NightClubManager.Common.Dtos.EmployeeAssignment;

namespace NightClubManager.Business.Validation;

public class EmployeeAssignmentCreateValidator : AbstractValidator<EmployeeAssignmentCreate>
{
    public EmployeeAssignmentCreateValidator()
    {
        RuleFor(employeeAssignmentCreate => employeeAssignmentCreate.EmployeeId).NotEmpty();
        RuleFor(employeeAssignmentCreate => employeeAssignmentCreate.EventId).NotEmpty();
    }
}
