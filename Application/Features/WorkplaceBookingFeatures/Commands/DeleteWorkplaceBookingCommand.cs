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
    public class DeleteWorkplaceBookingCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteWorkplaceBookingCommandHandler : IRequestHandler<DeleteWorkplaceBookingCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteWorkplaceBookingCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(DeleteWorkplaceBookingCommand command, CancellationToken cancellationToken)
            {
                await _unitOfWork.WorkplaceBookings.Delete(command.Id);
                await _unitOfWork.Save();

                return command.Id;
            }

        }
    }
}
