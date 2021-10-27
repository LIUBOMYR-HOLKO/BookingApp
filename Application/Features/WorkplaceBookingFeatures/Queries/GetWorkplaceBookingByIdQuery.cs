using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WorkplaceBookingFeatures.Queries
{
    public class GetWorkplaceBookingByIdQuery : IRequest<WorkplaceBooking>
    {
        public int Id { get; set; }
        public class GetWorkplaceBookingByIdQueryHandler : IRequestHandler<GetWorkplaceBookingByIdQuery, WorkplaceBooking>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetWorkplaceBookingByIdQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<WorkplaceBooking> Handle(GetWorkplaceBookingByIdQuery query, CancellationToken cancellationToken)
            {
                var workplaceBooking = await _unitOfWork.WorkplaceBookings.Get(query.Id);
                return workplaceBooking;
            }
        }
    }
}
