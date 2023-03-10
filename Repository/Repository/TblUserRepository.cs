﻿using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class TblUserRepository : RepositoryBase<TblUser>
    {
        private readonly EventScheduleContext _context;
        private readonly DbSet<TblUser> _dbSet;
        public TblUserRepository()
        {
            _context = new EventScheduleContext();
            _dbSet = _context.Set<TblUser>();
        }

    }
}
