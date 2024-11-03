using Chat.Core;
using Chat.MVVM.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Chat.MVVM.ViewModel
{
    internal class AuthWindowModel : ObservableObject
    {
        private string _username;
        private ImageSource _userImage;

        public ImageSource UserImage
        {
            get => _userImage;
            set
            {
                _userImage = value;
                OnPropertyChanged(nameof(UserImage));
            }
        }
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public ICommand ConfirmCommand { get; }
        public ICommand SelectImageCommand { get; }
        public AuthWindowModel()
        {
            UserImage = new BitmapImage(new Uri("pack://application:,,,/Icons/ProfilePicBase.png"));
            ConfirmCommand = new RelayCommand(Confirm, CanConfirm);
            SelectImageCommand = new RelayCommand(SelectImage);
        }
        private void SelectImage(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Выберите фотографию пользователя",
                Filter = "Image Files|*.jpg;*.jpeg;*.png"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                UserImage = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }
        private bool CanConfirm(object parameter)
        {
            return !string.IsNullOrWhiteSpace(Username);
        }

        private void Confirm(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(Username))
            {
                var mainWindow = new MainWindow
                {
                    DataContext = new MainViewModel(Username, UserImage)
                };

                mainWindow.Show();
                Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w is AuthWindow)?.Close();
            }
        }
    }
}
