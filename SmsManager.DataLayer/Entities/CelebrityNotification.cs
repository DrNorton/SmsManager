using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace SmsManager.DataLayer.Entities
{
    [global::System.Data.Linq.Mapping.TableAttribute(Name = "CelebrityNotifications")]
    public partial class CelebrityNotification : INotifyPropertyChanging, INotifyPropertyChanged,IDetail
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private long _Id;

        private bool _IsNotify;

        private long _ContactId;

        private System.Nullable<long> _MessageId;

        private System.DateTime? _CelebrityTime;

        private EntityRef<Contact> _Contact;

        private EntityRef<Message> _Message;

        #region Определения метода расширяемости
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(long value);
        partial void OnIdChanged();
        partial void OnIsNotifyChanging(bool value);
        partial void OnIsNotifyChanged();
        partial void OnContactIdChanging(long value);
        partial void OnContactIdChanged();
        partial void OnMessageIdChanging(System.Nullable<long> value);
        partial void OnMessageIdChanged();
        partial void OnCelebrityTimeChanging(System.DateTime? value);
        partial void OnCelebrityTimeChanged();
        #endregion

        public CelebrityNotification()
        {
            this._Contact = default(EntityRef<Contact>);
            this._Message = default(EntityRef<Message>);
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsNotify", DbType = "Bit NOT NULL")]
        public bool IsNotify
        {
            get
            {
                return this._IsNotify;
            }
            set
            {
                if ((this._IsNotify != value))
                {
                    this.OnIsNotifyChanging(value);
                    this.SendPropertyChanging();
                    this._IsNotify = value;
                    this.SendPropertyChanged("IsNotify");
                    this.OnIsNotifyChanged();
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_MessageId", DbType = "BigInt")]
        public System.Nullable<long> MessageId
        {
            get
            {
                return this._MessageId;
            }
            set
            {
                if ((this._MessageId != value))
                {
                    if (this._Message.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnMessageIdChanging(value);
                    this.SendPropertyChanging();
                    this._MessageId = value;
                    this.SendPropertyChanged("MessageId");
                    this.OnMessageIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CelebrityTime", DbType = "DateTime")]
        public System.DateTime? CelebrityTime
        {
            get
            {
                return this._CelebrityTime;
            }
            set
            {
                if ((this._CelebrityTime != value))
                {
                    this.OnCelebrityTimeChanging(value);
                    this.SendPropertyChanging();
                    this._CelebrityTime = value;
                    this.SendPropertyChanged("CelebrityTime");
                    this.OnCelebrityTimeChanged();
                }
            }
        }

        [global::System.Runtime.Serialization.IgnoreDataMember]
        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "FK_Celebrity_Contact", Storage = "_Contact", ThisKey = "ContactId", OtherKey = "Id", IsForeignKey = true, DeleteOnNull = true)]
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
                        previousValue.CelebrityNotifications.Remove(this);
                    }
                    this._Contact.Entity = value;
                    if ((value != null))
                    {
                        value.CelebrityNotifications.Add(this);
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
        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "FK_Celebrity_MESSAGES", Storage = "_Message", ThisKey = "MessageId", OtherKey = "Id", IsForeignKey = true)]
        public Message Message
        {
            get
            {
                return this._Message.Entity;
            }
            set
            {
                Message previousValue = this._Message.Entity;
                if (((previousValue != value)
                            || (this._Message.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Message.Entity = null;
                        previousValue.CelebrityNotifications.Remove(this);
                    }
                    this._Message.Entity = value;
                    if ((value != null))
                    {
                        value.CelebrityNotifications.Add(this);
                        this._MessageId = value.Id;
                    }
                    else
                    {
                        this._MessageId = default(Nullable<long>);
                    }
                    this.SendPropertyChanged("Message");
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
    }
}
