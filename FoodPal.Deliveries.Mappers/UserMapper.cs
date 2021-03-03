using FoodPal.Contracts;
using FoodPal.Deliveries.Application.Commands;
using FoodPal.Deliveries.Domain;
using FoodPal.Deliveries.Processor.Commands;

namespace FoodPal.Deliveries.Mappers
{
    public class UserMapper : InternalProfile
    {
        public UserMapper()
        {
            this.CreateMap<INewUserAddedEvent, NewUserAddedCommand>();
            this.CreateMap<NewUserAddedCommand, User>();

            this.CreateMap<IUserUpdatedEvent, UserUpdatedCommand>();
            this.CreateMap<UserUpdatedCommand, User>();
        }
    }
}
