using System;
using System.Collections.Generic;
using System.Text;

namespace FoodPal.Contracts
{
    public interface IDeliveryCompletedEvent
    {
        public int Id { get; set; }
    } 
}
