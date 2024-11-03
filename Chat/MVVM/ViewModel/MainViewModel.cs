using Chat.Core;
using Chat.MVVM.Model;
using Chat.Net;
using Chat.Net.IO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Chat.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel>  Messages { get; set; }
        public ObservableCollection<ContactModel>  Contacts { get; set; }

        private Server _server;
        public string Username { get; }

        /* Commands */
        public RelayCommand ConnectToServerCommand { get; set; }
        public RelayCommand SendCommand { get; set; }

        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set {
                _selectedContact = value;
                OnPropertyChanged();
            }
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value;
                OnPropertyChanged();
            }
        }

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
        public MainViewModel(string username, ImageSource userPhoto)
        {
            Username = username;
            UserImage = userPhoto;
            _server = new Server();
            _server.connectedEvent += UserConnected;
            _server.msgReceivedEvent += MessageReceived;
            _server.disconnectedEvent += UserDisconnected;
            ConnectToServerCommand = new RelayCommand(o => _server.ConnectToServer(username,userPhoto.ToString()));
            ConnectToServerCommand.Execute(null);
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RelayCommand(o =>
            {
                _server.SendMessageToServer(Message,Username);
                Message = "";
            },o => !string.IsNullOrEmpty(Message));
        }

        private void UserDisconnected()
        {
            var uid = _server.PacketReader.ReadMessage();
            var user = Contacts.Where(x=>x.UID == uid).FirstOrDefault();
            Application.Current.Dispatcher.Invoke(() => {Contacts.Remove(user); });
        }

        private void MessageReceived()
        {
            var msgWithUsername = _server.PacketReader.ReadMessage();
            var parts = msgWithUsername.Split(new[] { ':' }, 2); 

            if (parts.Length == 2)
            {
                var username = parts[0].Trim();
                var message = parts[1].Trim();

                Application.Current.Dispatcher.Invoke(() => {
                    Messages.Add(new MessageModel
                    {
                        Username = username,
                        UsernameColor = "#409aff",
                        ImageSource = UserImage.ToString(),
                        Message = message,
                        Time = DateTime.Now,
                        isNativeOrigin = true
                    });
                });
            }
        }

        private void UserConnected()
        {
            var username = _server.PacketReader.ReadMessage();
            var uid = _server.PacketReader.ReadMessage();
            var imageUri = _server.PacketReader.ReadMessage();

            var user = new ContactModel
            {
                Username = username,
                UID = uid,
                ImageSource = imageUri // Присваиваем URI изображения
            };

            Application.Current.Dispatcher.Invoke(() =>
            {
                if (!Contacts.Any(x => x.UID == user.UID))
                {
                    Contacts.Add(user);
                }
            });
        }
    } 
}
