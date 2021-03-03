using FluentValidation;
using FoodPal.Deliveries.Application.Queries;

namespace FoodPal.Deliveries.Validations
{
    public class UserDeliveryRequestedQueryValidator : InternalValidator<UserDeliveryRequestedQuery>
    {
        public UserDeliveryRequestedQueryValidator()
        {
            this.RuleFor(x => x.UserId).NotEmpty();
        }
    }
}