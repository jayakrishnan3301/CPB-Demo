using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPB.Repository
{
    internal class BaseEntityRepository
    {
        protected Slot_BookingEntities CurrentDataContext { get; set; }

        public BaseEntityRepository(Slot_BookingEntities mainData)
        {
            if (mainData == null)
                throw new ArgumentNullException(nameof(Slot_BookingEntities));
            CurrentDataContext = mainData;
        }

        protected ObjectContext ObjectContext => ((IObjectContextAdapter)CurrentDataContext).ObjectContext;

        public DbContextTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return CurrentDataContext.Database.CurrentTransaction == null ? CurrentDataContext.Database.BeginTransaction(isolationLevel) : null;
        }

        public void CommitTransaction(DbContextTransaction tx)
        {
            tx?.Commit();
        }
    }
}
