using AutoMapper;
using FluentValidation;
using FoodPal.Deliveries.Application.Extensions;
using FoodPal.Deliveries.Application.Queries;
using FoodPal.Deliveries.Data.Abstractions;
using FoodPal.Deliveries.Domain;
using FoodPal.Deliveries.Dto;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPal.Deliveries.Application.Handlers
{
    public class UserDeliveriesRequestedQueryHandler : IRequestHandler<UserDeliveryRequestedQuery, DeliveriesDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UserDeliveryRequestedQuery> _validator;
        private readonly IMapper _mapper;

        public UserDeliveriesRequestedQueryHandler(IUnitOfWork unitOfWork, IValidator<UserDeliveryRequestedQuery> validator, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._validator = validator;
        }

        public async Task<DeliveriesDto> Handle(UserDeliveryRequestedQuery request, CancellationToken cancellationToken)
        {
            this._validator.ValidateAndThrowEx(request);

            var deliveries = this._unitOfWork.GetRepository<Delivery>().Find(x => x.UserId == request.UserId &&
                                                                                    x.Status == Common.Enums.DeliveryStatusEnum.InProgress
                                                                                ).ToList();
            var deliveriesDtos = this._mapper.Map<List<DeliveryDto>>(deliveries);

            return new DeliveriesDto
            {
                Deliveries = deliveriesDtos
            };
        }
    }
}