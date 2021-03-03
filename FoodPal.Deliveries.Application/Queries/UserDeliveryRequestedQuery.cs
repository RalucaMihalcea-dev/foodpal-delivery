using FoodPal.Deliveries.Dto;
using MediatR;

namespace FoodPal.Deliveries.Application.Queries
{
    public class UserDeliveryRequestedQuery : IRequest<DeliveriesDto>
    {
        public int UserId { get; set; }
    }
}