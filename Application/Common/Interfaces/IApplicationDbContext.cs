﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Workplace> Workplaces { get; set; }
        DbSet<WorkplaceBooking> WorkplaceBookings { get; set; }

        Task<int> SaveChangesAsync();
    }
}
