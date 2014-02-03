using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace SmsManager.DataLayer.Entities
{
    [global::System.Data.Linq.Mapping.TableAttribute(Name = "Telephones")]
    public partial class Telephone : INotifyPropertyChanging, INotifyPropertyChanged,IDetail
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private long _Id;

        private long _ContactId;

        private string _TelephoneNumber;

        private long _KindId;

        private EntityRef<Contact> _Contact;

        private EntityRef<TelephoneKind> _TelephoneKind;

        private EntitySet<SmsShedule> _SmsShedules;

        #region Определения метода расширяемости
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(long value);
        partial void OnIdChanged();
        partial void OnContactIdChanging(long value);
        partial void OnContactIdChanged();
        partial void OnTelephoneNumberChanging(string value);
        partial void OnTelephoneNumberChanged();
        partial void OnKindIdChanging(long value);
        partial void OnKindIdChanged();
        #endregion

        public Telephone()
        {
            this._Contact = default(EntityRef<Contact>);
            this._TelephoneKind = default(EntityRef<TelephoneKind>);
            this._SmsShedules = new EntitySet<SmsShedule>(new Action<SmsShedule>(this.attach_SmsShedules), new Action<SmsShedule>(this.detach_SmsShedules));
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TelephoneNumber", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
        public string TelephoneNumber
        {
            get
            {
                return this._TelephoneNumber;
            }
            set
            {
                if ((this._TelephoneNumber != value))
                {
                    this.OnTelephoneNumberChanging(value);
                    this.SendPropertyChanging();
                    this._TelephoneNumber = value;
                    this.SendPropertyChanged("TelephoneNumber");
                    this.OnTelephoneNumberChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_KindId", DbType = "BigInt NOT NULL")]
        public long KindId
        {
            get
            {
                return this._KindId;
            }
            set
            {
                if ((this._KindId != value))
                {
                    if (this._TelephoneKind.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnKindIdChanging(value);
                    this.SendPropertyChanging();
                    this._KindId = value;
                    this.SendPropertyChanged("KindId");
                    this.OnKindIdChanged();
                }
            }
        }

        [global::System.Runtime.Serialization.IgnoreDataMember]
        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "FK__Telephones__0000000000000061", Storage = "_Contact", ThisKey = "ContactId", OtherKey = "Id", IsForeignKey = true)]
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
                        previousValue.Telephones.Remove(this);
                    }
                    this._Contact.Entity = value;
                    if ((value != null))
                    {
                        value.Telephones.Add(this);
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
        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "FK__Telephones__0000000000000065", Storage = "_TelephoneKind", ThisKey = "KindId", OtherKey = "Id", IsForeignKey = true, DeleteOnNull = true)]
        public TelephoneKind TelephoneKind
        {
            get
            {
                return this._TelephoneKind.Entity;
            }
            set
            {
                TelephoneKind previousValue = this._TelephoneKind.Entity;
                if (((previousValue != value)
                            || (this._TelephoneKind.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._TelephoneKind.Entity = null;
                        previousValue.Telephones.Remove(this);
                    }
                    this._TelephoneKind.Entity = value;
                    if ((value != null))
                    {
                        value.Telephones.Add(this);
                        this._KindId = value.Id;
                    }
                    else
                    {
                        this._KindId = default(long);
                    }
                    this.SendPropertyChanged("TelephoneKind");
                }
            }
        }

        [global::System.Runtime.Serialization.IgnoreDataMember]
        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "PK_TelephoneId", Storage = "_SmsShedules", ThisKey = "Id", OtherKey = "TelephoneId", DeleteRule = "CASCADE")]
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

        private void attach_SmsShedules(SmsShedule entity)
        {
            this.SendPropertyChanging();
            entity.Telephone = this;
        }

        private void detach_SmsShedules(SmsShedule entity)
        {
            this.SendPropertyChanging();
            entity.Telephone = null;
        }
    }
}

