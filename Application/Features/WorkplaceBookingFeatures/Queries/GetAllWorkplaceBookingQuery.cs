using Application.Common.Interfaces;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WorkplaceBookingFeatures.Queries
{
    public class GetAllWorkplaceBookingQuery : IRequest<IEnumerable<WorkplaceBooking>>
    {
        public class GetAllWorkplaceBookingQueryHandler : IRequestHandler<GetAllWorkplaceBookingQuery, IEnumerable<WorkplaceBooking>>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetAllWorkplaceBookingQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<IEnumerable<WorkplaceBooking>> Handle(GetAllWorkplaceBookingQuery query, CancellationToken cancellationToken)
            {
                var workplaceBookingsList = await _unitOfWork.WorkplaceBookings.GetAll();
                return workplaceBookingsList;
            }
        }
    }
}
