using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace SmsManager.DataLayer.Entities
{
    [global::System.Data.Linq.Mapping.TableAttribute(Name = "Periodics")]
    public partial class Periodic : INotifyPropertyChanging, INotifyPropertyChanged,IDetail
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private long _Id;

        private string _Name;

        private int _Days;

        private int _Hours;

        private int _Minutes;

        private int _Seconds;

        private System.Nullable<int> _Year;

        private System.Nullable<int> _Mounth;

        private System.Nullable<System.DateTime> _StartDate;

        private bool _IsPeriodic;

        private EntitySet<SmsShedule> _SmsShedules;

        #region Определения метода расширяемости
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(long value);
        partial void OnIdChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        partial void OnDaysChanging(int value);
        partial void OnDaysChanged();
        partial void OnHoursChanging(int value);
        partial void OnHoursChanged();
        partial void OnMinutesChanging(int value);
        partial void OnMinutesChanged();
        partial void OnSecondsChanging(int value);
        partial void OnSecondsChanged();
        partial void OnYearChanging(System.Nullable<int> value);
        partial void OnYearChanged();
        partial void OnMounthChanging(System.Nullable<int> value);
        partial void OnMounthChanged();
        partial void OnStartDateChanging(System.Nullable<System.DateTime> value);
        partial void OnStartDateChanged();
        partial void OnIsPeriodicChanging(System.Nullable<bool> value);
        partial void OnIsPeriodicChanged();
        #endregion

        public Periodic()
        {
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Days", DbType = "Int NOT NULL")]
        public int Days
        {
            get
            {
                return this._Days;
            }
            set
            {
                if ((this._Days != value))
                {
                    this.OnDaysChanging(value);
                    this.SendPropertyChanging();
                    this._Days = value;
                    this.SendPropertyChanged("Days");
                    this.OnDaysChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Hours", DbType = "Int NOT NULL")]
        public int Hours
        {
            get
            {
                return this._Hours;
            }
            set
            {
                if ((this._Hours != value))
                {
                    this.OnHoursChanging(value);
                    this.SendPropertyChanging();
                    this._Hours = value;
                    this.SendPropertyChanged("Hours");
                    this.OnHoursChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Minutes", DbType = "Int NOT NULL")]
        public int Minutes
        {
            get
            {
                return this._Minutes;
            }
            set
            {
                if ((this._Minutes != value))
                {
                    this.OnMinutesChanging(value);
                    this.SendPropertyChanging();
                    this._Minutes = value;
                    this.SendPropertyChanged("Minutes");
                    this.OnMinutesChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Seconds", DbType = "Int NOT NULL")]
        public int Seconds
        {
            get
            {
                return this._Seconds;
            }
            set
            {
                if ((this._Seconds != value))
                {
                    this.OnSecondsChanging(value);
                    this.SendPropertyChanging();
                    this._Seconds = value;
                    this.SendPropertyChanged("Seconds");
                    this.OnSecondsChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Year", DbType = "Int")]
        public System.Nullable<int> Year
        {
            get
            {
                return this._Year;
            }
            set
            {
                if ((this._Year != value))
                {
                    this.OnYearChanging(value);
                    this.SendPropertyChanging();
                    this._Year = value;
                    this.SendPropertyChanged("Year");
                    this.OnYearChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Mounth", DbType = "Int")]
        public System.Nullable<int> Mounth
        {
            get
            {
                return this._Mounth;
            }
            set
            {
                if ((this._Mounth != value))
                {
                    this.OnMounthChanging(value);
                    this.SendPropertyChanging();
                    this._Mounth = value;
                    this.SendPropertyChanged("Mounth");
                    this.OnMounthChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_StartDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> StartDate
        {
            get
            {
                return this._StartDate;
            }
            set
            {
                if ((this._StartDate != value))
                {
                    this.OnStartDateChanging(value);
                    this.SendPropertyChanging();
                    this._StartDate = value;
                    this.SendPropertyChanged("StartDate");
                    this.OnStartDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsPeriodic", DbType = "Bit NOT NULL")]
        public bool IsPeriodic
        {
            get
            {
                return this._IsPeriodic;
            }
            set
            {
                if ((this._IsPeriodic != value))
                {
                    this.OnIsPeriodicChanging(value);
                    this.SendPropertyChanging();
                    this._IsPeriodic = value;
                    this.SendPropertyChanged("IsPeriodic");
                    this.OnIsPeriodicChanged();
                }
            }
        }

        [global::System.Runtime.Serialization.IgnoreDataMember]
        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "FK_SmsShedules_PERIODICS", Storage = "_SmsShedules", ThisKey = "Id", OtherKey = "PeriodicId", DeleteRule = "CASCADE")]
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
            entity.Periodic = this;
        }

        private void detach_SmsShedules(SmsShedule entity)
        {
            this.SendPropertyChanging();
            entity.Periodic = null;
        }
    }
}
