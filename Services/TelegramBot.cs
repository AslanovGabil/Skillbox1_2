using Bot.Abstractions;
using Bot.Models;
using Bot.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using System.Configuration;

namespace Bot.Services
{
    public class TelegramBot : ITelegramBot
    {
        // private readonly JsonService _userJson;
        private readonly TelegramBotClient _bot;
        private readonly string _pathVideo = ConfigurationManager.AppSettings["pathVideo"];
        private readonly string _pathImage = ConfigurationManager.AppSettings["pathImage"];
        private readonly string _pathAudio = ConfigurationManager.AppSettings["pathAudio"];
        private readonly string _pathUsers = ConfigurationManager.AppSettings["User"];
        private readonly string _pathSaveItem = ConfigurationManager.AppSettings["SaveItem"];
        private readonly string _pathChats = ConfigurationManager.AppSettings["Chats"];
        private readonly string _token = ConfigurationManager.AppSettings["Token"];
        public TelegramBot()
        {


            _bot = new TelegramBotClient(_token);
            _bot.OnMessage += MessageListener;

            _bot.StartReceiving();

        }


        private void MessageListener(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            string text = $"{DateTime.Now.ToLongTimeString()}: {e.Message.Chat.FirstName} {e.Message.Chat.Id} {e.Message.Text}";

            Console.WriteLine($"{text} TypeMessage: {e.Message.Type.ToString()}");

            if (e.Message != null)
            {
               
                if (e.Message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                {
                    if (e.Message.Caption?.FirstOrDefault() == '/')
                    {

                        string path;

                        switch (e.Message.Type)
                        {
                            case Telegram.Bot.Types.Enums.MessageType.Photo:
                                var photo = e.Message.Photo[e.Message.Photo.Length - 1];
                                path = $"{_pathImage}{photo.FileId}";
                                saveItem(photo.FileId, path, e.Message.Caption);
                                break;

                            case Telegram.Bot.Types.Enums.MessageType.Audio:
                                path = $"{_pathAudio}{e.Message.Audio.Title}";
                                saveItem(e.Message.Audio.FileId, path, e.Message.Caption);
                                break;

                            case Telegram.Bot.Types.Enums.MessageType.Video:
                                path = $"{_pathVideo}{e.Message.Video.FileId}";
                                saveItem(e.Message.Video.FileId, path, e.Message.Caption);
                                break;


                            default:
                                SendMessage(e.Message.Chat.Id, "тип файла не поддерживается!");
                                
                                break;
                        }
                    }

                }

                else if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                {
                    AddMessageInChat(Convert.ToInt32(e.Message.Chat.Id), e.Message.Text, false, e.Message.Chat.FirstName);
                    if (e.Message.Text == "/start")
                    {
                        SendMessage(e.Message.Chat.Id, "С ботом можно поздороваться, написав '/Привет'");
                        SendMessage(e.Message.Chat.Id, "Также ему можно отправлять фото, аудио и документы, если вы отправите заголовок  которое начинается со символа \"/\" ,то бот сохранит его в базе");
                        SendMessage(e.Message.Chat.Id, "Для того чтобы получить фаил обратно нузно написать заголовок");
                        

                    }

                    else if (e.Message.Text.ToLower() == "/привет")
                    {
                        SendMessage(e.Message.Chat.Id, $"Здравствуй {e.Message.Chat.FirstName}!!!");
                       
                    }
                    else if (e.Message.Text.FirstOrDefault() == '/')
                    {
                        JsonService<SaveItem> saveItemJson = new JsonService<SaveItem>();
                        var item = saveItemJson.GetItems(_pathSaveItem).FirstOrDefault(i=>i.Caption.ToUpper()== e.Message.Text.ToUpper());
                        if (item!=null)
                        {
                        Stream fstream = new FileStream(item.Path, FileMode.Open, FileAccess.Read);
                        _bot.SendVideoAsync(e.Message.Chat.Id, fstream);

                        }
                        else
                        {
                            SendMessage(e.Message.Chat.Id, "К сожалению я не нашел фаил (((");
                           
                        }
                    }
                    else
                    {
                        SendMessage(e.Message.Chat.Id, "Даже, не знаю что сказать(((");
                        
                    }

                }

                
            }

        }
        public void SendMessage(long id, string text)
        {
            _bot.SendTextMessageAsync(id, text);
            AddMessageInChat(Convert.ToInt32(id), text, true);
        }

        public void AddMessageInChat(int id,string text,bool isMy, string name="No Name")
        {
            JsonService<Chat> chatJson = new JsonService<Chat>();
            var chat = chatJson.GetItems(_pathChats).FirstOrDefault(c=>c.User.Id_User== id);
            if (chat==null)
            {
                chat = new Chat();
                JsonService<User> userJson = new JsonService<User>();

                
                    var users = userJson.GetItems(_pathUsers);
                    chat.User = users.FirstOrDefault(u => u.Id_User == id);
                if (chat.User==null)
                {

                chat.User = 
                    AddUser(name, id).Result;
                }
               
               
                
                chat.Path = @"..\..\Media\Json\" + chat.User.Name + "_" + chat.User.Id_User + ".json";
                chatJson.AddItems(chat,_pathChats);

            }
            JsonService<Message> mesJson = new JsonService<Message>();
            Message message = new Message();
            message.Text = text;
            message.IsMy = isMy;
            mesJson.AddItems(message,chat.Path);
            if (!isMy)
            {
                chat.TimeNewMessage = DateTime.Now;
                chat.CountNewMessage += 1;
            }

           

        }

        public void SendMessage(string  text, int userId)
        {
            _bot.SendTextMessageAsync(userId, text);
        }
        private async Task saveItem(string fileId, string path, string caption)
        {


            JsonService<SaveItem> saveItemJson = new JsonService<SaveItem>();
            SaveItem saveItem = new SaveItem();
            saveItem.Caption = caption;

            saveItem.Path = await DownLoad(fileId, path);
             saveItemJson.AddItems(saveItem, _pathSaveItem);

        }
        private async Task<User> AddUser(string name, int userId)
        {

            string path = _pathImage + name + "_" + userId;
            path = await DownloadUserAvatar(userId, path);
            User user = new User()
            {
                Name = name,
                Id_User = userId,
                Photo = path
            };
            JsonService<User> userJson = new JsonService<User>();
             userJson.AddItems(user, _pathUsers);
            return user;


        }
        private async Task<string> DownloadUserAvatar(int userId, string path)
        {
            var files = await _bot.GetUserProfilePhotosAsync(userId);

            var file = files.Photos.FirstOrDefault().FirstOrDefault();
            return
            await DownLoad(file.FileId, path);
        }

        private async Task<string> DownLoad(string fileId, string path)
        {

            var file = await _bot.GetFileAsync(fileId);
            path = path + "." + file.FilePath.Split('.')[1];
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {

                await _bot.DownloadFileAsync(file.FilePath, fs);

            }
            return path;

        }
    }
}

