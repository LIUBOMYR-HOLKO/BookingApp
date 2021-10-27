using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WorkplaceBookingFeatures.Commands
{
    public class CreateWorkplaceBookingCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int WorkplaceId { get; set; }
        public Workplace Workplace { get; set; }
        public BookingType BookingType { get; set; }
        public DateTime BookingTimeFrom { get; set; }
        public DateTime BookingTimeTo { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public class CreateWorkplaceBookingCommandHandler : IRequestHandler<CreateWorkplaceBookingCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            public CreateWorkplaceBookingCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(CreateWorkplaceBookingCommand command, CancellationToken cancellationToken)
            {
                var workplaceBooking = new WorkplaceBooking();
                workplaceBooking.UserId = command.UserId;
                workplaceBooking.User = command.User;
                workplaceBooking.WorkplaceId = command.WorkplaceId;
                workplaceBooking.Workplace = command.Workplace;
                workplaceBooking.BookingType = command.BookingType;
                workplaceBooking.BookingTimeFrom = command.BookingTimeFrom;
                workplaceBooking.BookingTimeTo = command.BookingTimeTo;
                workplaceBooking.BookingStatus = command.BookingStatus;

                await _unitOfWork.WorkplaceBookings.Create(workplaceBooking);
                _unitOfWork.Save();

                return workplaceBooking.Id;
            }

        }
    }
}
