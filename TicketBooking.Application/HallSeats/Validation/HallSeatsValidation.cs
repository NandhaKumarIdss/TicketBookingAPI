using FluentValidation;

namespace TicketBooking.Application.HallSeats.Validation
{
    public class HallSeatsValidation : AbstractValidator<TicketBooking.Entities.HallSeats>
    {
        public HallSeatsValidation()
        {

            RuleFor(m => m.SeatNumber)
                .NotNull()
                .NotEmpty();

            RuleFor(m => m.SeatRow)
                .NotNull()
                .NotEmpty();

            RuleFor(m => m.SeatColumn)
                .NotNull()
                .NotEmpty();

            RuleFor(m => m.SeatStatus)
                .NotNull()
                .NotEmpty();

            RuleFor(m => m.HallId)
                .NotNull()
                .NotEmpty();
        }
    }
}
