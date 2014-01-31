using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace SmsManager.DataLayer.Entities
{
    [global::System.Data.Linq.Mapping.TableAttribute()]
    public partial class TelephoneKind : INotifyPropertyChanging, INotifyPropertyChanged,IDetail
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private long _Id;

        private string _Name;

        private EntitySet<Telephone> _Telephones;

        #region Определения метода расширяемости
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(long value);
        partial void OnIdChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        #endregion

        public TelephoneKind()
        {
            this._Telephones = new EntitySet<Telephone>(new Action<Telephone>(this.attach_Telephones), new Action<Telephone>(this.detach_Telephones));
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Name", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
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

        [global::System.Runtime.Serialization.IgnoreDataMember]
        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "FK__Telephones__0000000000000065", Storage = "_Telephones", ThisKey = "Id", OtherKey = "KindId", DeleteRule = "CASCADE")]
        public EntitySet<Telephone> Telephones
        {
            get
            {
                return this._Telephones;
            }
            set
            {
                this._Telephones.Assign(value);
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

        private void attach_Telephones(Telephone entity)
        {
            this.SendPropertyChanging();
            entity.TelephoneKind = this;
        }

        private void detach_Telephones(Telephone entity)
        {
            this.SendPropertyChanging();
            entity.TelephoneKind = null;
        }
    }
}
