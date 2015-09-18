using System;
using System.Linq;
using System.Linq.Expressions;

namespace TheKids.Domain.Interfaces
{
    public interface IRepository
    {
        /// <summary>
        /// adding the entity
        /// </summary>
        /// <typeparam name="TAggregate"></typeparam>
        /// <param name="aggregate"></param>
        void Add<TAggregate>(TAggregate aggregate) where TAggregate : class;

        /// <summary>
        /// loading the entity
        /// </summary>
        /// <typeparam name="TAggregate"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        TAggregate Load<TAggregate>(Expression<Func<TAggregate, bool>> predicate, params Expression<Func<TAggregate, object>>[] includes) where TAggregate : class;

        /// <summary>
        /// perform projection on the entity
        /// </summary>
        /// <typeparam name="TAggregate"></typeparam>
        /// <typeparam name="TProjection"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        TProjection Project<TAggregate, TProjection>(Func<IQueryable<TAggregate>, TProjection> query) where TAggregate : class;

        /// <summary>
        /// loading a list of the entity
        /// </summary>
        /// <typeparam name="TAggregate"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        IQueryable<TAggregate> LoadList<TAggregate>(Expression<Func<TAggregate, bool>> predicate, params Expression<Func<TAggregate, object>>[] includes) where TAggregate : class;

        /// <summary>
        /// checking if an entity exist or not
        /// </summary>
        /// <typeparam name="TAggregate"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Exists<TAggregate>(Expression<Func<TAggregate, bool>> predicate) where TAggregate : class;

        /// <summary>
        /// this is specific for NSB just to make sure the NSB is re-using the connection from service bus
        /// </summary>
        /// <param name="unitOfWork"></param>
        void UseExistingUnitOfWork(Lazy<IUnitOfWork> unitOfWork);

        void CommitChanges();
    }
}
