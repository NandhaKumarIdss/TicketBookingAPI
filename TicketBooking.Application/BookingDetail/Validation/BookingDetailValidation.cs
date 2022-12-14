using FluentValidation;

namespace TicketBooking.Application.BookingDetail.Validation
{
    public class BookingDetailValidation : AbstractValidator<TicketBooking.Entities.BookingDetail>
    {
        public BookingDetailValidation()
        {
            RuleFor(m => m.SeatNumber)
              .NotNull()
              .NotEmpty();

            RuleFor(m => m.BookingId)
                .NotNull()
                .NotEmpty();

            RuleFor(m => m.HallSeatId)
                .NotNull()
                .NotEmpty();
        }
    }
}
