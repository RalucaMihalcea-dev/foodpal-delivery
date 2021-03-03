using FoodPal.Contracts;
using FoodPal.Deliveries.Api.Exceptions;
using FoodPal.Deliveries.Dto;
using FoodPal.Deliveries.Dto.Intern;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FoodPal.Deliveries.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryController : ControllerBase
    {  
        private readonly ILogger<DeliveryController> _logger;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IRequestClient<IUserDeliveriesRequested> _requestClientUserDeliveriesRequested;

        public DeliveryController(ILogger<DeliveryController> logger, IPublishEndpoint publishEndpoint, IRequestClient<IUserDeliveriesRequested> requestClientUserDeliveriesRequested)
        {
            this._logger = logger;
            this._publishEndpoint = publishEndpoint;
            this._requestClientUserDeliveriesRequested = requestClientUserDeliveriesRequested;
        } 

        [HttpPost]
        public async Task<IActionResult> CreateDelivery(DeliveryDto deliveryDto)
        { 
            await this._publishEndpoint.Publish<INewDeliveryAddedEvent>(deliveryDto);

            return Accepted();
        }

        [Route("completed")]
        [HttpPatch]
        public async Task<IActionResult> CompletedDelivery(int id)
        {
            await this._publishEndpoint.Publish<IDeliveryCompletedEvent>(new { Id = id});

            return Accepted();
        }
         
    
        [HttpGet]
        public async Task<IActionResult> GetUserDeliveries(int userId)
        {
            var response = await this._requestClientUserDeliveriesRequested.GetResponse<DeliveriesDto, InternalErrorResponseDto>(new
            {
                UserId = userId
            });

            if (response.Is<InternalErrorResponseDto>(out var respError))
            {
                throw new HttpResponseException(respError.Message);
            }

            return Ok(response.Message);
        }
    }
}
