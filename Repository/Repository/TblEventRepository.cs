using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class TblEventRepository : RepositoryBase<TblEvent>
    {
        private readonly EventScheduleContext _context;
        private readonly DbSet<TblEvent> _dbSet;
        public TblEventRepository() {
            _context = new EventScheduleContext();
            _dbSet = _context.Set<TblEvent>();
        }
        public IQueryable<TblEvent> GetEventsByAdminId(int id)
        {

            return _dbSet.Where(e => e.AdminId == id);
        }
        public TblEvent GetEventByAdminId(int id)
        {

            return _dbSet.FirstOrDefault(e => e.AdminId == id);
        }
    }
}
