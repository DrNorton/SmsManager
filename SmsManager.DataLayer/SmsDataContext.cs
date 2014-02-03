using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Reflection;
using SmsManager.DataLayer.Entities;

namespace SmsManager.DataLayer
{
    public class DebugWriter : TextWriter
    {
        private const int DefaultBufferSize = 256;
        private System.Text.StringBuilder _buffer;

        public DebugWriter()
        {
            BufferSize = 256;
            _buffer = new System.Text.StringBuilder(BufferSize);
        }

        public int BufferSize
        {
            get;
            private set;
        }

        public override System.Text.Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }

        #region StreamWriter Overrides
        public override void Write(char value)
        {
            _buffer.Append(value);
            if (_buffer.Length >= BufferSize)
                Flush();
        }

        public override void WriteLine(string value)
        {
            Flush();

            using (var reader = new StringReader(value))
            {
                string line;
                while (null != (line = reader.ReadLine()))
                    System.Diagnostics.Debug.WriteLine(line);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                Flush();
        }

        public override void Flush()
        {
            if (_buffer.Length > 0)
            {
                System.Diagnostics.Debug.WriteLine(_buffer);
                _buffer.Clear();
            }
        }
        #endregion
    }

    public partial class SmsDataContext : System.Data.Linq.DataContext, ISmsDataContext
    {

     

            public bool CreateIfNotExists()
            {
                bool created = false;
                if (!this.DatabaseExists())
                {
                    string[] names = this.GetType().Assembly.GetManifestResourceNames();
                    string name = names.Where(n => n.EndsWith(FileName)).FirstOrDefault();
                    if (name != null)
                    {
                        using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
                        {
                            if (resourceStream != null)
                            {
                                using (
                                    IsolatedStorageFile myIsolatedStorage =
                                        IsolatedStorageFile.GetUserStoreForApplication())
                                {
                                    using (
                                        IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream(FileName,
                                            FileMode.Create, myIsolatedStorage))
                                    {
                                        using (BinaryWriter writer = new BinaryWriter(fileStream))
                                        {
                                            long length = resourceStream.Length;
                                            byte[] buffer = new byte[32];
                                            int readCount = 0;
                                            using (BinaryReader reader = new BinaryReader(resourceStream))
                                            {
                                                // read file in chunks in order to reduce memory consumption and increase performance
                                                while (readCount < length)
                                                {
                                                    int actual = reader.Read(buffer, 0, buffer.Length);
                                                    readCount += actual;
                                                    writer.Write(buffer, 0, actual);
                                                }
                                            }
                                        }
                                    }
                                }
                                created = true;
                            }
                            else
                            {
                                this.CreateDatabase();
                                created = true;
                            }
                        }
                    }
                    else
                    {
                        this.CreateDatabase();
                        created = true;
                    }
                }
                return created;
            }

            public bool LogDebug
            {
                set
                {
                    if (value)
                    {
                        this.Log = new DebugWriter();
                    }
                }
            }

            public static string ConnectionString = "Data Source=isostore:/db.sdf";

            public static string ConnectionStringReadOnly = "Data Source=appdata:/db.sdf;File Mode=Read Only;";

            public static string FileName = "db.sdf";

            public SmsDataContext(string connectionString) : base(connectionString)
            {
                OnCreated();
            }

            #region Определения метода расширяемости

            partial void OnCreated();
            partial void InsertCategory(Category instance);
            partial void UpdateCategory(Category instance);
            partial void DeleteCategory(Category instance);
            partial void InsertCelebrityNotification(CelebrityNotification instance);
            partial void UpdateCelebrityNotification(CelebrityNotification instance);
            partial void DeleteCelebrityNotification(CelebrityNotification instance);
            partial void InsertContact(Contact instance);
            partial void UpdateContact(Contact instance);
            partial void DeleteContact(Contact instance);
            partial void InsertMessage(Message instance);
            partial void UpdateMessage(Message instance);
            partial void DeleteMessage(Message instance);
            partial void InsertPeriodic(Periodic instance);
            partial void UpdatePeriodic(Periodic instance);
            partial void DeletePeriodic(Periodic instance);
            partial void InsertSmsShedule(SmsShedule instance);
            partial void UpdateSmsShedule(SmsShedule instance);
            partial void DeleteSmsShedule(SmsShedule instance);
            partial void InsertSmsTask(SmsTask instance);
            partial void UpdateSmsTask(SmsTask instance);
            partial void DeleteSmsTask(SmsTask instance);
            partial void InsertTelephoneKind(TelephoneKind instance);
            partial void UpdateTelephoneKind(TelephoneKind instance);
            partial void DeleteTelephoneKind(TelephoneKind instance);
            partial void InsertTelephone(Telephone instance);
            partial void UpdateTelephone(Telephone instance);
            partial void DeleteTelephone(Telephone instance);

            #endregion

            public System.Data.Linq.Table<Category> Categories
            {
                get
                {
                    return this.GetTable<Category>();
                }
            }

            public System.Data.Linq.Table<CelebrityNotification> CelebrityNotifications
            {
                get
                {
                    return this.GetTable<CelebrityNotification>();
                }
            }

            public System.Data.Linq.Table<Contact> Contacts
            {
                get
                {
                    return this.GetTable<Contact>();
                }
            }

            public System.Data.Linq.Table<Message> Messages
            {
                get
                {
                    return this.GetTable<Message>();
                }
            }

            public System.Data.Linq.Table<Periodic> Periodics
            {
                get
                {
                    return this.GetTable<Periodic>();
                }
            }

            public System.Data.Linq.Table<SmsShedule> SmsShedules
            {
                get
                {
                    return this.GetTable<SmsShedule>();
                }
            }

            public System.Data.Linq.Table<SmsTask> SmsTasks
            {
                get
                {
                    return this.GetTable<SmsTask>();
                }
            }

            public System.Data.Linq.Table<TelephoneKind> TelephoneKinds
            {
                get
                {
                    return this.GetTable<TelephoneKind>();
                }
            }

            public System.Data.Linq.Table<Telephone> Telephones
            {
                get
                {
                    return this.GetTable<Telephone>();
                }
            }
        
    }
}