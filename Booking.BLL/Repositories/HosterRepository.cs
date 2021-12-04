﻿using Booking.BLL.Contracts;
using Booking.DAL;
using Booking.DAL.Models;

namespace Booking.BLL.Repositories
{
    public class HosterRepository : BaseRepository<Hoster>, IHosterRepository
    {
        public HosterRepository(AppDbContext db) : base(db)
        { }
    }
}
