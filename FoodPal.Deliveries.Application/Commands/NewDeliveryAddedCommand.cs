using FoodPal.Deliveries.Common.Enums;
using MediatR;

namespace FoodPal.Deliveries.Processor.Commands
{
    public class NewDeliveryAddedCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public string CreateBy { get; set; }
        public string ModifiedBy { get; set; }
        public DeliveryStatusEnum Status { get; set; }
        public string Info { get; set; }
    }
}
