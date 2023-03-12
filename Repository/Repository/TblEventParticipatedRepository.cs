using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class TblEventParticipatedRepository : RepositoryBase<TblEventParticipated>
    {
        private readonly EventScheduleContext _context;
        private readonly DbSet<TblEventParticipated> _dbSet;
        public TblEventParticipatedRepository()
        {
            _context = new EventScheduleContext();
            _dbSet = _context.Set<TblEventParticipated>();
        }
        public IQueryable<TblEventParticipated> GetEventParticipatedById(int id)
        {

            return _dbSet.Where(e => e.EventId == id);
        }
        public TblEventParticipated GetEventParticipatedByEventIdAndUserId(int userId, int eventId)
        {

            return _dbSet.Where(p => p.EventId.Equals(eventId) && p.UsersId.Equals(userId)).FirstOrDefault();
        }
    }
}
