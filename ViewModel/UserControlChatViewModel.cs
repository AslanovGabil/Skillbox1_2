using Bot.Models;
using Bot.Repository;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.ViewModel
{
    public class UserControlChatViewModel : ViewModelBase
    {
        public UserControlChatViewModel()
        {
            JsonService<Chat> json = new JsonService<Chat>();
           var chat= json.GetItems(ConfigurationManager.AppSettings["Chats"]).OrderByDescending(c=>c.TimeNewMessage).FirstOrDefault();
            EditChat(chat);
            Messenger.Default.Register<Chat>(this, message => { EditChat(message); });
        }
        private void EditChat(Chat chat)
        {
            JsonService<Message> mesJson = new JsonService<Message>();
            Messages=new ObservableCollection<Message>( mesJson.GetItems(chat.Path));
        }
        private ObservableCollection<Message> messages;
        public ObservableCollection<Message> Messages
        {
            set
            {
                messages = value;
                RaisePropertyChanged();
            }
            get { return messages; }
        }

    }
}
