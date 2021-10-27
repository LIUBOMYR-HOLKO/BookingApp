using Domain.Entities;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence.Repositories
{
    class WorkplaceBookingRepository : IRepository<WorkplaceBooking>
    {
        private readonly ApplicationDbContext _context;

        public WorkplaceBookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(WorkplaceBooking item)
        {
            await _context.WorkplaceBookings.AddAsync(item);
        }

        public async Task Delete(int id)
        {
            var item = await _context.WorkplaceBookings.FindAsync(id);
            _context.WorkplaceBookings.Remove(item);
        }

        public IEnumerable<WorkplaceBooking> Find(Func<WorkplaceBooking, bool> predicate)
        {
            return _context.WorkplaceBookings.Where(predicate).ToList();
        }

        public async Task<WorkplaceBooking> Get(int id)
        {
            return await _context.WorkplaceBookings.FindAsync(id);
        }

        public async Task<IEnumerable<WorkplaceBooking>> GetAll()
        {
            return await _context.WorkplaceBookings.ToListAsync();
        }

        public void Update(WorkplaceBooking item)
        {
            _context.WorkplaceBookings.Update(item);
        }
    }
}
