using System.Windows;
using UserManager.App.Windows.Admin;
using UserManager.App.Windows.User;
using UserManager.Models.Table;

namespace UserManager.App.Windows.Authorization
{
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void ButtonClear_OnClick(object sender, RoutedEventArgs e)
        {
            InputLogin.Clear();
            InputPassword.Clear();
        }

        private void ButtonLogIn_OnClick(object sender, RoutedEventArgs e)
        {
            var login = InputLogin.Text;
            var password = InputPassword.Password;
            
            var accounts = new TableAccount().GetTable();

            var account = accounts.Find(a => a.Login == login && a.Password == password);

            if (account is null)
            {
                MessageBox.Show("Неправильно ввели логин и пароль", 
                    "Ошибка авторизации", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Вы успешно авторизовались", 
                    "Успешная авторизация", 
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                
                var role = new TableRole().GetTable().Find(r => r.Id == account.RoleId)?.Name;

                switch (role)
                {
                    case "admin":
                        new AdminWindow().Show();
                        break;
                    case "user":
                        new UserWindow(account.Id).Show();
                        break;
                }
                Close();
            }
        }
    }
}

