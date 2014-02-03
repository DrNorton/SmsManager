using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace SmsManager.DataLayer.Entities
{
    [global::System.Data.Linq.Mapping.TableAttribute(Name = "Messages")]
    public partial class Message : INotifyPropertyChanging, INotifyPropertyChanged,IDetail
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private long _Id;

        private string _Text;

        private System.Nullable<long> _Usages;

        private long _CategoryId;

        private EntityRef<Category> _Category;

        private EntitySet<CelebrityNotification> _CelebrityNotifications;

        private EntitySet<SmsTask> _SmsTasks;

        #region Определения метода расширяемости
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(long value);
        partial void OnIdChanged();
        partial void OnTextChanging(string value);
        partial void OnTextChanged();
        partial void OnUsagesChanging(System.Nullable<long> value);
        partial void OnUsagesChanged();
        partial void OnCategoryIdChanging(long value);
        partial void OnCategoryIdChanged();
        #endregion

        public Message()
        {
            this._Category = default(EntityRef<Category>);
            this._CelebrityNotifications = new EntitySet<CelebrityNotification>(new Action<CelebrityNotification>(this.attach_CelebrityNotifications), new Action<CelebrityNotification>(this.detach_CelebrityNotifications));
            this._SmsTasks = new EntitySet<SmsTask>(new Action<SmsTask>(this.attach_SmsTasks), new Action<SmsTask>(this.detach_SmsTasks));
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Text", DbType = "NText", UpdateCheck = UpdateCheck.Never)]
        public string Text
        {
            get
            {
                return this._Text;
            }
            set
            {
                if ((this._Text != value))
                {
                    this.OnTextChanging(value);
                    this.SendPropertyChanging();
                    this._Text = value;
                    this.SendPropertyChanged("Text");
                    this.OnTextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Usages", DbType = "BigInt")]
        public System.Nullable<long> Usages
        {
            get
            {
                return this._Usages;
            }
            set
            {
                if ((this._Usages != value))
                {
                    this.OnUsagesChanging(value);
                    this.SendPropertyChanging();
                    this._Usages = value;
                    this.SendPropertyChanged("Usages");
                    this.OnUsagesChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CategoryId", DbType = "BigInt NOT NULL")]
        public long CategoryId
        {
            get
            {
                return this._CategoryId;
            }
            set
            {
                if ((this._CategoryId != value))
                {
                    if (this._Category.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnCategoryIdChanging(value);
                    this.SendPropertyChanging();
                    this._CategoryId = value;
                    this.SendPropertyChanged("CategoryId");
                    this.OnCategoryIdChanged();
                }
            }
        }

        [global::System.Runtime.Serialization.IgnoreDataMember]
        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "FK_CATEGORIES_MESSAGES", Storage = "_Category", ThisKey = "CategoryId", OtherKey = "Id", IsForeignKey = true, DeleteOnNull = true)]
        public Category Category
        {
            get
            {
                return this._Category.Entity;
            }
            set
            {
                Category previousValue = this._Category.Entity;
                if (((previousValue != value)
                            || (this._Category.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Category.Entity = null;
                        previousValue.Messages.Remove(this);
                    }
                    this._Category.Entity = value;
                    if ((value != null))
                    {
                        value.Messages.Add(this);
                        this._CategoryId = value.Id;
                    }
                    else
                    {
                        this._CategoryId = default(long);
                    }
                    this.SendPropertyChanged("Category");
                }
            }
        }

        [global::System.Runtime.Serialization.IgnoreDataMember]
        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "FK_Celebrity_MESSAGES", Storage = "_CelebrityNotifications", ThisKey = "Id", OtherKey = "MessageId", DeleteRule = "CASCADE")]
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
        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "FK_SmsTask_MESSAGES", Storage = "_SmsTasks", ThisKey = "Id", OtherKey = "MessageId", DeleteRule = "CASCADE")]
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

        private void attach_CelebrityNotifications(CelebrityNotification entity)
        {
            this.SendPropertyChanging();
            entity.Message = this;
        }

        private void detach_CelebrityNotifications(CelebrityNotification entity)
        {
            this.SendPropertyChanging();
            entity.Message = null;
        }

        private void attach_SmsTasks(SmsTask entity)
        {
            this.SendPropertyChanging();
            entity.Message = this;
        }

        private void detach_SmsTasks(SmsTask entity)
        {
            this.SendPropertyChanging();
            entity.Message = null;
        }
    }
}
