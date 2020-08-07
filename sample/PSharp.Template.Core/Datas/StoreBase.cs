using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Util.Datas.Ef.Core;
using Util.Datas.Stores;
using Util.Domains;

namespace PSharp.Template.Core.Datas
{
    /// <summary>
    /// 存储器
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    public abstract class StoreBase<TEntity> : StoreBase<TEntity, Guid>, IStore<TEntity>
        where TEntity : class, IKey<Guid>, IVersion
    {
        
    }

    /// <summary>
    /// 存储器
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public abstract class StoreBase<TEntity, TKey> : QueryStoreBase<TEntity, TKey>, IStore<TEntity, TKey>
        where TEntity : class, IKey<TKey>
    {

        /// <summary>
        /// 读工作单元
        /// </summary>
        protected UnitOfWorkBase WriteReadUnitOfWork { get; }

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Remove(object id)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(IEnumerable<TKey> ids)
        {
            throw new NotImplementedException();
        }

        public void Remove(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(object id, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(IEnumerable<TKey> ids, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
