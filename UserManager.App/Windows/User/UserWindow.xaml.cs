using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using UserManager.Models.Item;
using UserManager.Models.Table;

namespace UserManager.App.Windows.User;

public partial class UserWindow : Window, INotifyPropertyChanged
{
    private int _id;
    private string _photo;
    private Account _account;
    private Models.Item.User _user;

    public UserWindow(int id)
    {
        _id = id;
        
        InitializeComponent();
        
        Init();
    }

    private void Init()
    {
        _account = new TableAccount().GetTable().Find(a => a.Id == _id);
        _user = new TableUser().GetTable().Find(u => u.Id == _id);

        Login.InputText = _account.Login;
        Password.InputText = _account.Password;
        FirstName.InputText = _user.FirstName;
        LastName.InputText = _user.LastName;
        Email.InputText = _user.Email;
        
        var ext = _user.PhotoUrl.Substring(_user.PhotoUrl.LastIndexOf('.'));
        var url = $@"{Directory.GetCurrentDirectory()}\photos\{_account.Id}_{_user.LastName}_{_user.FirstName}{ext}";
        File.Copy(_user.PhotoUrl, url, true);
        UserPhoto.Source = new BitmapImage(new Uri(url));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
    {
        var ext = _photo.Substring(_photo.LastIndexOf('.'));
        File.Copy(_photo, $@"D:\photos\{_account.Id}_{_user.LastName}_{_user.FirstName}{ext}", true);
    }

    private void ButtonChangePhoto_OnClick(object sender, RoutedEventArgs e)
    {
        var file = new OpenFileDialog();
        file.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
        file.ShowDialog();
        _photo = file.FileName;
        
        UserPhoto.Source = new BitmapImage(new Uri(_photo));
    }
}

