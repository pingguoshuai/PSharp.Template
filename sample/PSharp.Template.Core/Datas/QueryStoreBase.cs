using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Util.Datas.Ef.Core;
using Util.Datas.Stores;
using Util.Domains;
using Util.Domains.Repositories;

namespace PSharp.Template.Core.Datas
{
    public abstract class QueryStoreBase<TEntity> : QueryStoreBase<TEntity, Guid>, IQueryStore<TEntity> where TEntity : class, IKey<Guid>
    {
    }

    public abstract class QueryStoreBase<TEntity, TKey> : IQueryStore<TEntity, TKey> where TEntity : class, IKey<TKey>
    {

        /// <summary>
        /// 读工作单元
        /// </summary>
        protected UnitOfWorkBase ReadUnitOfWork { get; }

        public IQueryable<TEntity> FindAsNoTracking()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Find()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Find(ICriteria<TEntity> criteria)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(object id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindAsync(object id, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public List<TEntity> FindByIds(params TKey[] ids)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> FindByIds(IEnumerable<TKey> ids)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> FindByIds(string ids)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> FindByIdsAsync(params TKey[] ids)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> FindByIdsAsync(IEnumerable<TKey> ids, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> FindByIdsAsync(string ids)
        {
            throw new NotImplementedException();
        }

        public TEntity FindByIdNoTracking(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindByIdNoTrackingAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public List<TEntity> FindByIdsNoTracking(params TKey[] ids)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> FindByIdsNoTracking(IEnumerable<TKey> ids)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> FindByIdsNoTracking(string ids)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> FindByIdsNoTrackingAsync(params TKey[] ids)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> FindByIdsNoTrackingAsync(IEnumerable<TKey> ids, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> FindByIdsNoTrackingAsync(string ids)
        {
            throw new NotImplementedException();
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public List<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> FindAllNoTracking(Expression<Func<TEntity, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> FindAllNoTrackingAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public bool Exists(params TKey[] ids)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(params TKey[] ids)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> Query(IQueryBase<TEntity> query)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> QueryAsNoTracking(IQueryBase<TEntity> query)
        {
            throw new NotImplementedException();
        }

        public PagerList<TEntity> PagerQuery(IQueryBase<TEntity> query)
        {
            throw new NotImplementedException();
        }

        public PagerList<TEntity> PagerQueryAsNoTracking(IQueryBase<TEntity> query)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> QueryAsync(IQueryBase<TEntity> query)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> QueryAsNoTrackingAsync(IQueryBase<TEntity> query)
        {
            throw new NotImplementedException();
        }

        public Task<PagerList<TEntity>> PagerQueryAsync(IQueryBase<TEntity> query)
        {
            throw new NotImplementedException();
        }

        public Task<PagerList<TEntity>> PagerQueryAsNoTrackingAsync(IQueryBase<TEntity> query)
        {
            throw new NotImplementedException();
        }
    }
}
