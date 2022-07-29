using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using UserManager.Models.Table;

namespace UserManager.App.Windows.User;

public partial class UserWindow : Window, INotifyPropertyChanged
{
    private int _id;

    public UserWindow(int id)
    {
        _id = id;
        
        InitializeComponent();
        
        Init();
    }

    private void Init()
    {
        var account = new TableAccount().GetTable().Find(a => a.Id == _id);
        var user = new TableUser().GetTable().Find(u => u.Id == _id);

        Login.InputText = account.Login;
        Password.InputText = account.Password;
        FirstName.InputText = user.FirstName;
        LastName.InputText = user.LastName;
        Email.InputText = user.Email;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(LastName.InputText);
    }
}

