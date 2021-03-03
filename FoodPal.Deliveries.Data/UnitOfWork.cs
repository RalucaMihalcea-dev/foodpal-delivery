using FoodPal.Deliveries.Data.Abstractions;
using FoodPal.Deliveries.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPal.Deliveries.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DeliveryDbContext _deliveryDbContext;

        public UnitOfWork(DeliveryDbContext deliveryDbContext)
        {
            this._deliveryDbContext = deliveryDbContext;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity
        {
            return new Repository<TEntity>(this._deliveryDbContext);
        }

        public async Task<bool> SaveChangesAsnyc() => await this._deliveryDbContext.SaveChangesAsync() > 0;
    }
}
