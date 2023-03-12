using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class TblAdminRepository : RepositoryBase<TblAdmin>
    {
        private readonly EventScheduleContext _context;
        private readonly DbSet<TblAdmin> _dbSet;
        public TblAdminRepository()
        {
            _context = new EventScheduleContext();
            _dbSet = _context.Set<TblAdmin>();
        }
        public TblAdmin GetAdminByEventId(int id)
        {

            return _dbSet.FirstOrDefault(e => e.AdminId == id);
        }
    }
}
