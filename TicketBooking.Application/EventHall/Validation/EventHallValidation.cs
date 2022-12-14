using FluentValidation;

namespace TicketBooking.Application.EventHall.Validation
{
    public class EventHallValidation : AbstractValidator<TicketBooking.Entities.EventHall>
    {
        public EventHallValidation()
        {

            RuleFor(m => m.HallName)
                .NotNull()
                .NotEmpty();

            RuleFor(m => m.HallStatus)
                .NotNull()
                .NotEmpty();
        }
    }
}
