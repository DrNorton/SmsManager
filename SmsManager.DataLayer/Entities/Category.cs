using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Data.Linq.Mapping;
using SmsManager.Infrastructure.Entities;

namespace SmsManager.DataLayer.Entities
{
    [global::System.Data.Linq.Mapping.TableAttribute(Name = "Categories")]
    public partial class Category : INotifyPropertyChanging, INotifyPropertyChanged,IDetail
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private long _Id;

        private string _Name;

        private System.Data.Linq.Binary _Image;

        private EntitySet<Message> _Messages;

        #region Определения метода расширяемости
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(long value);
        partial void OnIdChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        partial void OnImageChanging(System.Data.Linq.Binary value);
        partial void OnImageChanged();
        #endregion

        public Category()
        {
            this._Messages = new EntitySet<Message>(new Action<Message>(this.attach_Messages), new Action<Message>(this.detach_Messages));
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Id", AutoSync = AutoSync.OnInsert, DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public long Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if ((this._Id != value))
                {
                    this.OnIdChanging(value);
                    this.SendPropertyChanging();
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                    this.OnIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Name", DbType = "NVarChar(100)")]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if ((this._Name != value))
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._Name = value;
                    this.SendPropertyChanged("Name");
                    this.OnNameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Image", DbType = "VarBinary(8000)", CanBeNull = true)]
        public System.Data.Linq.Binary Image
        {
            get
            {
                return this._Image;
            }
            set
            {
                if ((this._Image != value))
                {
                    this.OnImageChanging(value);
                    this.SendPropertyChanging();
                    this._Image = value;
                    this.SendPropertyChanged("Image");
                    this.OnImageChanged();
                }
            }
        }

        [global::System.Runtime.Serialization.IgnoreDataMember]
        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "FK_CATEGORIES_MESSAGES", Storage = "_Messages", ThisKey = "Id", OtherKey = "CategoryId", DeleteRule = "CASCADE")]
        public EntitySet<Message> Messages
        {
            get
            {
                return this._Messages;
            }
            set
            {
                this._Messages.Assign(value);
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_Messages(Message entity)
        {
            this.SendPropertyChanging();
            entity.Category = this;
        }

        private void detach_Messages(Message entity)
        {
            this.SendPropertyChanging();
            entity.Category = null;
        }
    }
}
