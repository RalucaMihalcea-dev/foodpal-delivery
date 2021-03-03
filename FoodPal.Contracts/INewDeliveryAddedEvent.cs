using FoodPal.Deliveries.Common.Enums;
using System;
namespace FoodPal.Contracts
{
    public interface INewDeliveryAddedEvent
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string CreateBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset CreateAt { get; set; }
        public DateTimeOffset ModifiedAt { get; set; }
        public DeliveryStatusEnum Status { get; set; }
        public string Info { get; set; }
    }
}
