using Bot.Abstractions;
using Bot.Models;
using GalaSoft.MvvmLight;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using Bot.Repository;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Configuration;

namespace Bot.ViewModel
{
   
    public class MainViewModel : ViewModelBase
    {
       private readonly ITelegramBot _telegramBot;
        private Chat chat;
       public Chat Chat { 
            get { return chat; }

            set { 
                chat = value;
                Messenger.Default.Send(chat);
            } 
        }

        private ICommand _add_Message_Click;
        public ICommand Add_Message_Click => _add_Message_Click ?? (_add_Message_Click = new RelayCommand(() => {
            _telegramBot.SendMessage(Chat.User.Id_User, _messageText);
            MessageText = "";
            Messenger.Default.Send(chat);
        }));

        private string _messageText = "";
        public string MessageText
        {
            get { return _messageText; }
            set
            {
                _messageText = value;
                RaisePropertyChanged();

            }
        }

        private ObservableCollection<Chat> chats;
        public ObservableCollection<Chat> Chats
        {
            set
            {
                chats = value;
                chats.OrderByDescending(c => c.TimeNewMessage);
                RaisePropertyChanged();
            }
            get { return chats; }
        }
        public MainViewModel(ITelegramBot telegram)
        {
            _telegramBot = telegram;
            JsonService<Chat> chatJson = new JsonService<Chat>();
            Chats =new ObservableCollection<Chat>(chatJson.GetItems(ConfigurationManager.AppSettings["Chats"]));
            Chat = Chats.FirstOrDefault();
            Messenger.Default.Send(chat);
        }
    }
}