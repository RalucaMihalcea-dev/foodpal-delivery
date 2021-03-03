using FoodPal.Contracts;
using FoodPal.Deliveries.Application.Queries;
using FoodPal.Deliveries.Domain;
using FoodPal.Deliveries.Dto;
using FoodPal.Deliveries.Processor.Commands;

namespace FoodPal.Deliveries.Mappers
{
    public class DeliveryMapper : InternalProfile
    {
        public DeliveryMapper()
        {
            this.CreateMap<IDeliveryCompletedEvent, NewDeliveryAddedCommand>();
            this.CreateMap<INewDeliveryAddedEvent, NewDeliveryAddedCommand>();
            this.CreateMap<NewDeliveryAddedCommand, Delivery>();

            this.CreateMap<Delivery, DeliveryDto>();
            this.CreateMap<IUserDeliveriesRequested, UserDeliveryRequestedQuery>();
        }
    }
}