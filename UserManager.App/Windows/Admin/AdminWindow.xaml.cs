using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using UserManager.Models.Item;
using UserManager.Models.Table;

namespace UserManager.App.Windows.Admin;

public partial class AdminWindow : Window
{
    public ObservableCollection<Account> Accounts { get; set; }
    public AdminWindow()
    {
        Accounts = new ObservableCollection<Account>(new TableAccount().GetTable());
        
        InitializeComponent();
    }

    private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //var account = (Account)((ListView)sender).SelectedItem;
        var account = (sender as ListView).SelectedItem as Account;
        var user = new TableUser().GetTable().Find(u => u.Id == account.Id);

        Login.InputText = account.Login;
        Password.InputText = account.Password;
        LastName.InputText = user.LastName;
        FirstName.InputText = user.FirstName;
        Email.InputText = user.Email;
    }
}

