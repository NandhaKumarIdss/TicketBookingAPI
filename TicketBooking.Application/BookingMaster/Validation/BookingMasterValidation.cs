using FluentValidation;

namespace TicketBooking.Application.BookingMaster.Validation
{
    public class BookingMasterValidation : AbstractValidator<TicketBooking.Entities.BookingMaster>
    {
        public BookingMasterValidation()
        {
            RuleFor(m => m.CustomerName)
              .NotNull()
              .NotEmpty();

            RuleFor(m => m.NumberOfSeats)
                .NotNull()
                .NotEmpty();

            RuleFor(m => m.HallId)
                .NotNull()
                .NotEmpty();
        }
    }
}
