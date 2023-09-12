using FluentValidation;
using NightClubManager.Common.Dtos.Event;

namespace NightClubManager.Business.Validation;

public class EventUpdateValidator : AbstractValidator<EventUpdate>
{
    public EventUpdateValidator()
    {
        RuleFor(eventUpdate => eventUpdate.Title).NotEmpty().MaximumLength(20);
        RuleFor(eventUpdate => eventUpdate.Start).NotEmpty();
        RuleFor(eventUpdate => eventUpdate.End).NotEmpty();
    }
}