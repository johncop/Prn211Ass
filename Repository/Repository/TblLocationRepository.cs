using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class TblLocationRepository : RepositoryBase<TblLocation>
    {
        private readonly EventScheduleContext _context;
        private readonly DbSet<TblEvent> _dbSet;
        public TblLocationRepository() {
            _context = new EventScheduleContext();
            _dbSet = _context.Set<TblEvent>();

        }
    }
}
