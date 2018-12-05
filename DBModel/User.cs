using System;
using KMA.C2018.Tools;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;

namespace KMA.APP_Messenger.DBModels
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class User
    {
        #region Fields
        [DataMember]
        private Guid _guid;
        [DataMember]
        private string _login;
        [DataMember]
        private string _firstName;
        [DataMember]
        private string _lastName;
        [DataMember]
        private string _email;
        [DataMember]
        private string _password;
        [DataMember]
        private DateTime _lastLoginDate;
        [DataMember]
        private List<Message> _messages;

        #endregion

        #region Properties
        public Guid Guid
        {
            get => _guid;
            private set => _guid = value;
        }
        private string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }
        private string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }
        private string Email
        {
            get => _email;
            set => _email = value;
        }

        public string Login
        {
            get => _login;
            private set => _login = value;
        }
        private string Password
        {
            get => _password;
            set => _password = value;
        }
        private DateTime LastLoginDate
        {
            get => _lastLoginDate;
            set => _lastLoginDate = value;
        }

        public List<Message> Messages
        {
            get
            {
                return _messages;
            }
            set
            {
                _messages = value;
            }
        }

        #endregion

        #region Constructor

        public User(string firstName, string lastName, string email, string login, string password) : this()
        {
            Guid = Guid.NewGuid();
            FirstName= firstName;
            LastName = lastName;
            Email = email;
            Login = login;
            LastLoginDate = DateTime.Now;

            SetPassword(password);
        }

        private User()
        {
            Messages = new List<Message>();
        }

        #endregion

        private void SetPassword(string password)
        {
            Password = Encrypting.GetMd5HashForString(password);
        }
        public bool CheckPassword(string password)
        {
            try
            {
                string res2 = Encrypting.GetMd5HashForString(password);
                return _password == res2;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CheckPassword(User userCandidate)
        {
            try
            {
                return _password == userCandidate._password;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }

        #region EntityConfiguration

        public class UserEntityConfiguration : EntityTypeConfiguration<User>
        {
            public UserEntityConfiguration()
            {
                ToTable("Users");
                HasKey(s => s.Guid);

                Property(p => p.Guid)
                    .HasColumnName("Guid")
                    .IsRequired();
                Property(p => p.FirstName)
                    .HasColumnName("FirstName")
                    .IsRequired();
                Property(p => p.LastName)
                    .HasColumnName("LastName")
                    .IsRequired();
                Property(p => p.Email)
                    .HasColumnName("Email")
                    .IsOptional();
                Property(p => p.Login)
                    .HasColumnName("Login")
                    .IsRequired();
                Property(p => p.Password)
                    .HasColumnName("Password")
                    .IsRequired();
                Property(p => p.LastLoginDate)
                    .HasColumnName("LastLoginDate")
                    .IsRequired();

                HasMany(s => s.Messages)
                    .WithRequired(w => w.User)
                    .HasForeignKey(w => w.UserGuid)
                    .WillCascadeOnDelete(true);
            }
        }
        #endregion

    }
}
