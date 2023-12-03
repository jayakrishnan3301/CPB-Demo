using CPB.Core.Facades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CPB.Repository
{
    public class BaseDAL : IBaseDAL
    {
        internal Slot_BookingEntities CurrentDataContext { get; }
        private bool _isDisposed;
        public BaseDAL(string connectionName)
        {
            var connStringSetting = ConfigurationManager.ConnectionStrings[connectionName];
            if (connStringSetting == null)
            {
                throw new ArgumentException("Connection string for database: " + connectionName + " is not found");
            }
            const string providerName = "System.Data.SqlClient";
            var entityBuilder = new EntityConnectionStringBuilder
            {
                Provider = providerName,
                ProviderConnectionString = connStringSetting.ConnectionString + ";MultipleActiveResultSets=True;App=EntityFramework",
                Metadata = @"res://*/CPBContext.csdl|res://*/CPBContext.ssdl|res://*/CPBContext.msl",
            };
            CurrentDataContext = new Slot_BookingEntities(entityBuilder.ToString());

            var connBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder
            {
                ConnectionString = connStringSetting.ConnectionString
            };

            DataSource = connBuilder.DataSource;
            InitialCatalog = connBuilder.InitialCatalog;
            UserID = connBuilder.UserID;
            Password = connBuilder.Password;
        }

        public DbContextTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return CurrentDataContext.Database.BeginTransaction(isolationLevel);
        }

        public void CommitTransaction(DbContextTransaction transaction)
        {
            transaction.Commit();
        }

        public void DisableChangeTracking()
        {
            CurrentDataContext.Configuration.AutoDetectChangesEnabled = false;
        }

        public void EnableChangeTracking()
        {
            CurrentDataContext.Configuration.AutoDetectChangesEnabled = true;
        }

        public void DetectChangesAndSave()
        {
            CurrentDataContext.Configuration.AutoDetectChangesEnabled = true;
            CurrentDataContext.ChangeTracker.DetectChanges();
            CurrentDataContext.SaveChanges();
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
                CurrentDataContext.Dispose();
            }
        }

        public void SaveChanges()
        {
            CurrentDataContext.SaveChanges();
        }

        protected ObjectContext ObjectContext => ((IObjectContextAdapter)CurrentDataContext).ObjectContext;

        public string DataSource { get; }

        public string InitialCatalog { get; }

        public string UserID { get; }

        public string Password { get; }
        
    }
}
