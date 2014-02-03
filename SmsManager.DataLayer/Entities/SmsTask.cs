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
    public partial class SmsTask : INotifyPropertyChanging, INotifyPropertyChanged,IDetail
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private long _Id;

        private long _SheduleId;

        private System.Nullable<long> _MessageId;

        private bool _IsGeocoding;

        private bool _IsExecuted;

        private EntityRef<Message> _Message;

        private EntityRef<SmsShedule> _SmsShedule;

        #region Определения метода расширяемости
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(long value);
        partial void OnIdChanged();
        partial void OnSheduleIdChanging(long value);
        partial void OnSheduleIdChanged();
        partial void OnMessageIdChanging(System.Nullable<long> value);
        partial void OnMessageIdChanged();
        partial void OnIsGeocodingChanging(bool value);
        partial void OnIsGeocodingChanged();
        partial void OnIsExecutedChanging(bool value);
        partial void OnIsExecutedChanged();
        #endregion

        public SmsTask()
        {
            this._Message = default(EntityRef<Message>);
            this._SmsShedule = default(EntityRef<SmsShedule>);
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SheduleId", DbType = "BigInt NOT NULL")]
        public long SheduleId
        {
            get
            {
                return this._SheduleId;
            }
            set
            {
                if ((this._SheduleId != value))
                {
                    if (this._SmsShedule.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnSheduleIdChanging(value);
                    this.SendPropertyChanging();
                    this._SheduleId = value;
                    this.SendPropertyChanged("SheduleId");
                    this.OnSheduleIdChanged();
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsGeocoding", DbType = "Bit NOT NULL")]
        public bool IsGeocoding
        {
            get
            {
                return this._IsGeocoding;
            }
            set
            {
                if ((this._IsGeocoding != value))
                {
                    this.OnIsGeocodingChanging(value);
                    this.SendPropertyChanging();
                    this._IsGeocoding = value;
                    this.SendPropertyChanged("IsGeocoding");
                    this.OnIsGeocodingChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsExecuted", DbType = "Bit NOT NULL")]
        public bool IsExecuted
        {
            get
            {
                return this._IsExecuted;
            }
            set
            {
                if ((this._IsExecuted != value))
                {
                    this.OnIsExecutedChanging(value);
                    this.SendPropertyChanging();
                    this._IsExecuted = value;
                    this.SendPropertyChanged("IsExecuted");
                    this.OnIsExecutedChanged();
                }
            }
        }

        [global::System.Runtime.Serialization.IgnoreDataMember]
        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "FK_SmsTask_MESSAGES", Storage = "_Message", ThisKey = "MessageId", OtherKey = "Id", IsForeignKey = true)]
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
                        previousValue.SmsTasks.Remove(this);
                    }
                    this._Message.Entity = value;
                    if ((value != null))
                    {
                        value.SmsTasks.Add(this);
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

        [global::System.Runtime.Serialization.IgnoreDataMember]
        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "FK_SmsTask_SmsShedules", Storage = "_SmsShedule", ThisKey = "SheduleId", OtherKey = "Id", IsForeignKey = true, DeleteOnNull = true)]
        public SmsShedule SmsShedule
        {
            get
            {
                return this._SmsShedule.Entity;
            }
            set
            {
                SmsShedule previousValue = this._SmsShedule.Entity;
                if (((previousValue != value)
                            || (this._SmsShedule.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._SmsShedule.Entity = null;
                        previousValue.SmsTasks.Remove(this);
                    }
                    this._SmsShedule.Entity = value;
                    if ((value != null))
                    {
                        value.SmsTasks.Add(this);
                        this._SheduleId = value.Id;
                    }
                    else
                    {
                        this._SheduleId = default(long);
                    }
                    this.SendPropertyChanged("SmsShedule");
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
