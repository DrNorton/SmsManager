using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SmsManager.Infrastructure.Entities;

namespace SmsManager.Infrastructure.IRepositories
{
    public interface ISmsDataContext
    {
        IEnumerable<ICategoryDetail> Categories { get; }
        IEnumerable<IMessageDetail> Messages { get; }
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
