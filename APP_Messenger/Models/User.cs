using System;
using APP_Messenger.Tools;

namespace APP_Messenger.Models
{
    [Serializable]

    public class User
    {
        #region Const
        private const string PrivateKey = "<RSAKeyValue><Modulus>sr4l8EwMgPqPhRTK+dPTwGs9uYhDeUohSRL48ZDf85/5/Lo469WltKFaQvA2Msy92xq14YPPN6p6mQD7stVbinRd+hihnYoqfclYRMe+FG6jqu/QACl0N6JgwM7iKGiyzBjL1vkvcSoaqwbxD8QPHgrdNlkyP0z6Vz7j79PFEos=</Modulus><Exponent>AQAB</Exponent><P>6OkjEhjlvbDCuOl8e0Ep2zACTxkfSta8WFBmdvrinhQSowkT5xDXL0EFa/Z03XNUmjJ0xGe1aNCgG+6dDpTnSw==</P><Q>xHZTH4hXAv7uJsb/VHrcYOM5l4AyC+OxP7bhmAoGJGf4TpPxh+B0RhMxssrkc1d/72TIfRpuPbSLEqkqCSk5wQ==</Q><DP>SKFzK1CSTB4UCv/crr76Y3zMK4hlBryCDXQ9D7ta8frGeQr6puLMh9LZ8vnvJaOybUdwvFKu8pmkZDF7zrFGkw==</DP><DQ>J3ZNBAxyzds/IvLd3q4/DgcWTmQlqVW3CMFHVy7MRQvNSJtW7KAdOuYoGW2/rZtpy0BHNTnV4vcc6EaqduSdAQ==</DQ><InverseQ>4/jjapjJHdDqr5FG5a29ISgO6mRnjty6nrOisPNDi4336JdEKfAdtZvDUQoBAwKsV0oMvJ9RtPB2tS0hf5i8pA==</InverseQ><D>qcnyY/b5kbNxjasYvIQ5i3jTY2BLJ/YA9FcvXtiNw/DdGPMUiwGhrJnxEdD4yvyuBGm1CAmbV3d7icfjUBdYIe9VaZqPQ2FgYzI5DbB401+4z6Di7uKBVajLIOawlnufW4+K68T0EAFO2l9eo1RcU66W921G/pz6hObeUXt65QE=</D></RSAKeyValue>";
        private const string PublicKey = "<RSAKeyValue><Modulus>sr4l8EwMgPqPhRTK+dPTwGs9uYhDeUohSRL48ZDf85/5/Lo469WltKFaQvA2Msy92xq14YPPN6p6mQD7stVbinRd+hihnYoqfclYRMe+FG6jqu/QACl0N6JgwM7iKGiyzBjL1vkvcSoaqwbxD8QPHgrdNlkyP0z6Vz7j79PFEos=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        #endregion

        #region Fields
        private Guid _guid;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _login;
        private string _password;
        private DateTime _lastLoginDate;
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

        #endregion

        #region Constructor

        public User(string firstName, string lastName, string email, string login, string password) : this()
        {
            _guid = Guid.NewGuid();
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _login = login;
            _lastLoginDate = DateTime.Now;

            SetPassword(password);
        }

        private User()
        {
        }

        #endregion

        private void SetPassword(string password)
        {
            _password = Encrypting.GetMd5HashForString(password);
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


    }
}
