using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Application.Users.Validation
{
    public class UserValidation : AbstractValidator<TicketBooking.Entities.Users>
    {
        public UserValidation()
        {

            RuleFor(m => m.FirstName)
                .NotNull()
                .NotEmpty();

            RuleFor(m => m.LastName)
                .NotNull()
                .NotEmpty();

            RuleFor(m => m.EmailId)
                .NotNull()
                .NotEmpty();

            RuleFor(m => m.PhoneNumber)
                .NotNull()
                .NotEmpty();

            RuleFor(m => m.Password)
                .NotNull()
                .NotEmpty();

            RuleFor(m => m.ConfirmPassword)
                .NotNull()
                .NotEmpty();
        }
    }
}