using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace SmsManager.DataLayer.Entities
{
    [global::System.Data.Linq.Mapping.TableAttribute(Name = "SmsShedules")]
    public partial class SmsShedule : INotifyPropertyChanging, INotifyPropertyChanged,IDetail
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private long _Id;

        private string _Name;

        private long _ContactId;

        private System.Nullable<System.DateTime> _LastExecuted;

        private long _PeriodicId;

        private System.Nullable<long> _TelephoneId;

        private EntityRef<Contact> _Contact;

        private EntityRef<Periodic> _Periodic;

        private EntitySet<SmsTask> _SmsTasks;

        private EntityRef<Telephone> _Telephone;

        #region Определения метода расширяемости
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(long value);
        partial void OnIdChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        partial void OnContactIdChanging(long value);
        partial void OnContactIdChanged();
        partial void OnLastExecutedChanging(System.Nullable<System.DateTime> value);
        partial void OnLastExecutedChanged();
        partial void OnPeriodicIdChanging(long value);
        partial void OnPeriodicIdChanged();
        partial void OnTelephoneIdChanging(System.Nullable<long> value);
        partial void OnTelephoneIdChanged();
        #endregion

        public SmsShedule()
        {
            this._Contact = default(EntityRef<Contact>);
            this._Periodic = default(EntityRef<Periodic>);
            this._SmsTasks = new EntitySet<SmsTask>(new Action<SmsTask>(this.attach_SmsTasks), new Action<SmsTask>(this.detach_SmsTasks));
            this._Telephone = default(EntityRef<Telephone>);
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ContactId", DbType = "BigInt NOT NULL")]
        public long ContactId
        {
            get
            {
                return this._ContactId;
            }
            set
            {
                if ((this._ContactId != value))
                {
                    if (this._Contact.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnContactIdChanging(value);
                    this.SendPropertyChanging();
                    this._ContactId = value;
                    this.SendPropertyChanged("ContactId");
                    this.OnContactIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_LastExecuted", DbType = "DateTime")]
        public System.Nullable<System.DateTime> LastExecuted
        {
            get
            {
                return this._LastExecuted;
            }
            set
            {
                if ((this._LastExecuted != value))
                {
                    this.OnLastExecutedChanging(value);
                    this.SendPropertyChanging();
                    this._LastExecuted = value;
                    this.SendPropertyChanged("LastExecuted");
                    this.OnLastExecutedChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_PeriodicId", DbType = "BigInt NOT NULL")]
        public long PeriodicId
        {
            get
            {
                return this._PeriodicId;
            }
            set
            {
                if ((this._PeriodicId != value))
                {
                    if (this._Periodic.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnPeriodicIdChanging(value);
                    this.SendPropertyChanging();
                    this._PeriodicId = value;
                    this.SendPropertyChanged("PeriodicId");
                    this.OnPeriodicIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TelephoneId", DbType = "BigInt")]
        public System.Nullable<long> TelephoneId
        {
            get
            {
                return this._TelephoneId;
            }
            set
            {
                if ((this._TelephoneId != value))
                {
                    if (this._Telephone.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnTelephoneIdChanging(value);
                    this.SendPropertyChanging();
                    this._TelephoneId = value;
                    this.SendPropertyChanged("TelephoneId");
                    this.OnTelephoneIdChanged();
                }
            }
        }

        [global::System.Runtime.Serialization.IgnoreDataMember]
        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "FK_SmsShedules_CONTACTS", Storage = "_Contact", ThisKey = "ContactId", OtherKey = "Id", IsForeignKey = true, DeleteOnNull = true)]
        public Contact Contact
        {
            get
            {
                return this._Contact.Entity;
            }
            set
            {
                Contact previousValue = this._Contact.Entity;
                if (((previousValue != value)
                            || (this._Contact.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Contact.Entity = null;
                        previousValue.SmsShedules.Remove(this);
                    }
                    this._Contact.Entity = value;
                    if ((value != null))
                    {
                        value.SmsShedules.Add(this);
                        this._ContactId = value.Id;
                    }
                    else
                    {
                        this._ContactId = default(long);
                    }
                    this.SendPropertyChanged("Contact");
                }
            }
        }

        [global::System.Runtime.Serialization.IgnoreDataMember]
        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "FK_SmsShedules_PERIODICS", Storage = "_Periodic", ThisKey = "PeriodicId", OtherKey = "Id", IsForeignKey = true, DeleteOnNull = true)]
        public Periodic Periodic
        {
            get
            {
                return this._Periodic.Entity;
            }
            set
            {
                Periodic previousValue = this._Periodic.Entity;
                if (((previousValue != value)
                            || (this._Periodic.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Periodic.Entity = null;
                        previousValue.SmsShedules.Remove(this);
                    }
                    this._Periodic.Entity = value;
                    if ((value != null))
                    {
                        value.SmsShedules.Add(this);
                        this._PeriodicId = value.Id;
                    }
                    else
                    {
                        this._PeriodicId = default(long);
                    }
                    this.SendPropertyChanged("Periodic");
                }
            }
        }

        [global::System.Runtime.Serialization.IgnoreDataMember]
        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "FK_SmsTask_SmsShedules", Storage = "_SmsTasks", ThisKey = "Id", OtherKey = "SheduleId", DeleteRule = "CASCADE")]
        public EntitySet<SmsTask> SmsTasks
        {
            get
            {
                return this._SmsTasks;
            }
            set
            {
                this._SmsTasks.Assign(value);
            }
        }

        [global::System.Runtime.Serialization.IgnoreDataMember]
        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "PK_TelephoneId", Storage = "_Telephone", ThisKey = "TelephoneId", OtherKey = "Id", IsForeignKey = true)]
        public Telephone Telephone
        {
            get
            {
                return this._Telephone.Entity;
            }
            set
            {
                Telephone previousValue = this._Telephone.Entity;
                if (((previousValue != value)
                            || (this._Telephone.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Telephone.Entity = null;
                        previousValue.SmsShedules.Remove(this);
                    }
                    this._Telephone.Entity = value;
                    if ((value != null))
                    {
                        value.SmsShedules.Add(this);
                        this._TelephoneId = value.Id;
                    }
                    else
                    {
                        this._TelephoneId = default(Nullable<long>);
                    }
                    this.SendPropertyChanged("Telephone");
                }
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

        private void attach_SmsTasks(SmsTask entity)
        {
            this.SendPropertyChanging();
            entity.SmsShedule = this;
        }

        private void detach_SmsTasks(SmsTask entity)
        {
            this.SendPropertyChanging();
            entity.SmsShedule = null;
        }
    }
}
