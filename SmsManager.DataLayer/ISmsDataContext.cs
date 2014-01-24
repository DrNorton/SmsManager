using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO;
using SmsManager.DataLayer.Entities;
using SmsManager.Infrastructure.Entities;

namespace SmsManager.DataLayer
{
    public interface ISmsDataContext
    {
        Table<Category> Categories { get; }
        Table<Message> Messages { get; }
        TextWriter Log { get; set; }
        bool ObjectTrackingEnabled { get; set; }
        bool DeferredLoadingEnabled { get; set; }
        MetaModel Mapping { get; }
        DataLoadOptions LoadOptions { get; set; }
        ChangeConflictCollection ChangeConflicts { get; }
        void Dispose();
         Table<TEntity> GetTable<TEntity>() where TEntity : class;
        
        ITable GetTable(Type type);
        bool DatabaseExists();
        void CreateDatabase();
        void DeleteDatabase();
        void SubmitChanges();
        void SubmitChanges(ConflictMode failureMode);
        void Refresh(RefreshMode mode, object entity);
        void Refresh(RefreshMode mode, params object[] entities);
        void Refresh(RefreshMode mode, IEnumerable entities);
        ChangeSet GetChangeSet();
    }
}
