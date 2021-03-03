using FluentValidation;
using FoodPal.Deliveries.Processor.Commands;

namespace FoodPal.Deliveries.Validations
{
    public class NewUserAddedCommandValidator : InternalValidator<NewUserAddedCommand>
    {
        public NewUserAddedCommandValidator()
        {
            this.RuleFor(x => x.Id).NotEmpty();
            this.RuleFor(x => x.Email).NotEmpty();
            this.RuleFor(x => x.FirstName).NotEmpty();
            this.RuleFor(x => x.LastName).NotEmpty();
            this.RuleFor(x => x.PhoneNo).NotEmpty();
            this.RuleFor(x => x.Address).NotEmpty();
        }
    }
}