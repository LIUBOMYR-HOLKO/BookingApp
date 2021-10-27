using Application.Common.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private WorkplaceBookingRepository _workplaceBookingRepository;
        private bool disposed = false;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

        }
        public IRepository<WorkplaceBooking> WorkplaceBookings
        {
            get
            {
                if (_workplaceBookingRepository == null)
                {
                    _workplaceBookingRepository = new WorkplaceBookingRepository(_context);
                }
                return _workplaceBookingRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
