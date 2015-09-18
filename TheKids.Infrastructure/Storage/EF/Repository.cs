using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TheKids.Domain.Interfaces;

namespace TheKids.Infrastructure.Storage.EF
{

    public class Repository : IRepository
    {
        private Lazy<IUnitOfWork> _context;

        public Repository()
        {

        }

        public Repository(IUnitOfWork context)
        {
            _context = new Lazy<IUnitOfWork>(() => context);
        }

        public void Add<TAggregate>(TAggregate aggregate) where TAggregate : class
        {
            GetDbSet<TAggregate>().Add(aggregate);
        }

        public TAggregate Load<TAggregate>(Expression<Func<TAggregate, bool>> predicate,
            params Expression<Func<TAggregate, object>>[] includes)
            where TAggregate : class
        {
            var q = GetDbSet<TAggregate>().AsQueryable();

            if (includes != null)
            {
                q = includes.Aggregate(q, (set, inc) => set.Include(inc));
            }

            return q.SingleOrDefault(predicate);
        }

        public TProjection Project<TAggregate, TProjection>(Func<IQueryable<TAggregate>, TProjection> query) where TAggregate : class
        {
            return query(((DbContext)_context.Value).Set<TAggregate>().AsQueryable());
        }

        public void UseExistingUnitOfWork(Lazy<IUnitOfWork> unitOfWork)
        {
            _context = unitOfWork;
        }

        public void CommitChanges()
        {
            if (_context.IsValueCreated)
                ((DbContext) _context.Value).SaveChanges();
        }

        private DbSet<TAggregate> GetDbSet<TAggregate>() where TAggregate : class
        {
            return ((DbContext) _context.Value).Set<TAggregate>();
        }

        public IQueryable<TAggregate> LoadList<TAggregate>(Expression<Func<TAggregate, bool>> predicate,
            params Expression<Func<TAggregate, object>>[] includes) where TAggregate : class
        {
            IQueryable<TAggregate> q = GetDbSet<TAggregate>().AsQueryable();
            if (includes != null)
            {
                q = includes.Aggregate(q, (set, inc) => set.Include(inc));
            }
            return q.Where(predicate).AsQueryable();
        }

        public bool Exists<TAggregate>(Expression<Func<TAggregate, bool>> predicate) where TAggregate : class
        {
            return GetDbSet<TAggregate>().Any(predicate);
        }
    }
}
