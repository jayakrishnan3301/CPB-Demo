using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPB.Core.Facades
{
    public interface IBaseDAL :IDisposable
    {
        string DataSource { get; }
        string InitialCatalog { get; }
        string UserID { get; }
        string Password { get; }
        void SaveChanges();
        void DisableChangeTracking();
        void EnableChangeTracking();
        DbContextTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void CommitTransaction(DbContextTransaction transaction);
        void DetectChangesAndSave();
    }
}
