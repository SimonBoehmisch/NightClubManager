using FluentValidation;
using NightClubManager.Common.Dtos.Event;

namespace NightClubManager.Business.Validation;

public class EventCreateValidator : AbstractValidator<EventCreate>
{
    public EventCreateValidator()
    {
        RuleFor(eventCreate => eventCreate.Title).NotEmpty().MaximumLength(20);
        RuleFor(eventCreate => eventCreate.Start).NotEmpty();
        RuleFor(eventCreate => eventCreate.End).NotEmpty();
    }
}
