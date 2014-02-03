using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SmsManager.DataLayer.Entities
{
    [global::System.Data.Linq.Mapping.TableAttribute(Name = "Contacts")]
    public partial class Contact : INotifyPropertyChanging, INotifyPropertyChanged,IDetail
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _DisplayName;

        private System.Nullable<System.DateTime> _BirthdayDate;

        private string _EmailAddress;

        private System.Data.Linq.Binary _Photo;

        private long _Id;

        private EntitySet<Telephone> _Telephones;

        private EntitySet<CelebrityNotification> _CelebrityNotifications;

        private EntitySet<SmsShedule> _SmsShedules;

        #region Определения метода расширяемости
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnDisplayNameChanging(string value);
        partial void OnDisplayNameChanged();
        partial void OnBirthdayDateChanging(System.Nullable<System.DateTime> value);
        partial void OnBirthdayDateChanged();
        partial void OnEmailAddressChanging(string value);
        partial void OnEmailAddressChanged();
        partial void OnPhotoChanging(System.Data.Linq.Binary value);
        partial void OnPhotoChanged();
        partial void OnIdChanging(long value);
        partial void OnIdChanged();
        #endregion

        public Contact()
        {
            this._Telephones = new EntitySet<Telephone>(new Action<Telephone>(this.attach_Telephones), new Action<Telephone>(this.detach_Telephones));
            this._CelebrityNotifications = new EntitySet<CelebrityNotification>(new Action<CelebrityNotification>(this.attach_CelebrityNotifications), new Action<CelebrityNotification>(this.detach_CelebrityNotifications));
            this._SmsShedules = new EntitySet<SmsShedule>(new Action<SmsShedule>(this.attach_SmsShedules), new Action<SmsShedule>(this.detach_SmsShedules));
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DisplayName", DbType = "NVarChar(100)")]
        public string DisplayName
        {
            get
            {
                return this._DisplayName;
            }
            set
            {
                if ((this._DisplayName != value))
                {
                    this.OnDisplayNameChanging(value);
                    this.SendPropertyChanging();
                    this._DisplayName = value;
                    this.SendPropertyChanged("DisplayName");
                    this.OnDisplayNameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BirthdayDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> BirthdayDate
        {
            get
            {
                return this._BirthdayDate;
            }
            set
            {
                if ((this._BirthdayDate != value))
                {
                    this.OnBirthdayDateChanging(value);
                    this.SendPropertyChanging();
                    this._BirthdayDate = value;
                    this.SendPropertyChanged("BirthdayDate");
                    this.OnBirthdayDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_EmailAddress", DbType = "NVarChar(100)")]
        public string EmailAddress
        {
            get
            {
                return this._EmailAddress;
            }
            set
            {
                if ((this._EmailAddress != value))
                {
                    this.OnEmailAddressChanging(value);
                    this.SendPropertyChanging();
                    this._EmailAddress = value;
                    this.SendPropertyChanged("EmailAddress");
                    this.OnEmailAddressChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Photo", DbType = "Image", CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public System.Data.Linq.Binary Photo
        {
            get
            {
                return this._Photo;
            }
            set
            {
                if ((this._Photo != value))
                {
                    this.OnPhotoChanging(value);
                    this.SendPropertyChanging();
                    this._Photo = value;
                    this.SendPropertyChanged("Photo");
                    this.OnPhotoChanged();
                }
            }
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

        [global::System.Runtime.Serialization.IgnoreDataMember]
        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "FK__Telephones__0000000000000061", Storage = "_Telephones", ThisKey = "Id", OtherKey = "ContactId", DeleteRule = "NO ACTION")]
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

        [global::System.Runtime.Serialization.IgnoreDataMember]
        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "FK_Celebrity_Contact", Storage = "_CelebrityNotifications", ThisKey = "Id", OtherKey = "ContactId", DeleteRule = "CASCADE")]
        public EntitySet<CelebrityNotification> CelebrityNotifications
        {
            get
            {
                return this._CelebrityNotifications;
            }
            set
            {
                this._CelebrityNotifications.Assign(value);
            }
        }

        [global::System.Runtime.Serialization.IgnoreDataMember]
        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "FK_SmsShedules_CONTACTS", Storage = "_SmsShedules", ThisKey = "Id", OtherKey = "ContactId", DeleteRule = "CASCADE")]
        public EntitySet<SmsShedule> SmsShedules
        {
            get
            {
                return this._SmsShedules;
            }
            set
            {
                this._SmsShedules.Assign(value);
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
            entity.Contact = this;
        }

        private void detach_Telephones(Telephone entity)
        {
            this.SendPropertyChanging();
            entity.Contact = null;
        }

        private void attach_CelebrityNotifications(CelebrityNotification entity)
        {
            this.SendPropertyChanging();
            entity.Contact = this;
        }

        private void detach_CelebrityNotifications(CelebrityNotification entity)
        {
            this.SendPropertyChanging();
            entity.Contact = null;
        }

        private void attach_SmsShedules(SmsShedule entity)
        {
            this.SendPropertyChanging();
            entity.Contact = this;
        }

        private void detach_SmsShedules(SmsShedule entity)
        {
            this.SendPropertyChanging();
            entity.Contact = null;
        }
    }
	
}
