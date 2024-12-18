using Taxi.Models;

namespace Taxi
{
    /// <summary>
    /// Логика взаимодействия для LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        
        SoccerContext db;
        public LoginScreen()
        {
            InitializeComponent();
            db = new SoccerContext();
            db.Users.Load(); // загружаем данные
            db.Drivers.Load();
            db.Administrators.Load();

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            foreach (Driver driver in db.Drivers.Local)
            {
                //string Password = Encrypt(txtPassword.Password, "1337");
                string Password = txtPassword.Password;
                if (driver.Password == Password && driver.Mail == txtUserName.Text)
                {
                    int idDriver = driver.DriverID;
                    DriverScreen driverScreen = new DriverScreen(idDriver);
                    driverScreen.Show();
                    this.Close();
                }
            }
            foreach (Administrator administrator in db.Administrators.Local)
            {
                string Password = txtPassword.Password;
                //testtxt.Text += txtUserName.Text + administrator.Login + " administrator.Password: " + administrator.Password + " Password: " + Password + "\n ";
                if (administrator.Password == Password && administrator.Login == txtUserName.Text)
                {

                    string Login = administrator.Login;
                    AdminScreen adminScreen = new AdminScreen(Login);
                    adminScreen.Show();
                    this.Close();
                }
            }

            foreach (User user in db.Users.Local)
            {
                string Password = Encrypt(txtPassword.Password, "1337");
                if (user.Password == Password && user.Mail == txtUserName.Text)
                {
                    int id = user.UserID;
                    MainUser mainUser = new MainUser(id);
                    mainUser.Show();
                    this.Close();
                }
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        public static string Encrypt(string plainText, string password,
                    string salt = "Kosher", string hashAlgorithm = "SHA1",
                    int passwordIterations = 2, string initialVector = "OFRna73m*aze01xY",
                    int keySize = 256)
        {
            if (string.IsNullOrEmpty(plainText))
                return "";

            byte[] initialVectorBytes = Encoding.ASCII.GetBytes(initialVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(salt);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            PasswordDeriveBytes derivedPassword = new PasswordDeriveBytes(password, saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = derivedPassword.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;

            byte[] cipherTextBytes = null;

            using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initialVectorBytes))
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        cipherTextBytes = memStream.ToArray();
                        memStream.Close();
                        cryptoStream.Close();
                    }
                }
            }

            symmetricKey.Clear();
            return Convert.ToBase64String(cipherTextBytes);
        }

        private void Power_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void GridBottomBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterScreen loginScreen = new RegisterScreen();
            loginScreen.Show();
            this.Close();
        }

        private void CheckBox2_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
