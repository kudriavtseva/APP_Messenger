using System;
using System.Data.Entity.ModelConfiguration;

namespace KMA.APP_Messenger.DBModels
{
    [Serializable]
    public class Message
    {
        #region Fields
        private Guid _guid;
        private string _text;
        private string _sender;
        private Guid _userGuid;
        private User _user;
        #endregion

        #region Proprties
        public Guid Guid
        {
            get => _guid;
            set => _guid = value;
        }

        public string Text
        {
            get => _text;
            set => _text = value;
        }

        public string Sender
        {
            get => _sender;
            set => _sender = value;
        }

        public Guid UserGuid
        {
            get => _userGuid;
            set => _userGuid = value;
        }

        public User User
        {
            get => _user;
            set => _user = value;
        }
        #endregion

        #region Constructor

        public Message(User user, string text, string sender) : this()
        {
            Guid = Guid.NewGuid();
            Text = text;
            Sender = sender;
            User = user;
            UserGuid = user.Guid;
            user.Messages.Add(this);
        }

        private Message()
        {
        }
        #endregion

        public override string ToString()
        {
            return Sender + " " + Text;
        }

        #region EntityFrameworkConfiguration
        public class MessageEntityConfiguration : EntityTypeConfiguration<Message>
        {
            public MessageEntityConfiguration()
            {
                ToTable("Message");
                HasKey(s => s.Guid);

                Property(p => p.Guid)
                    .HasColumnName("Guid")
                    .IsRequired();
                Property(p => p.Text)
                    .HasColumnName("Text")
                    .IsRequired();
                Property(s => s.Sender)
                    .HasColumnName("Sender")
                    .IsRequired();
            }
        }
        #endregion
        public void DeleteDatabaseValues()
        {
            User = null;
        }
    }
}