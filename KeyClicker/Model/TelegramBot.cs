using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KeyClicker.Model
{
    class TelegramBot
    {
        public TelegramBotClient client = new TelegramBotClient("токен");
        private ObservableCollection<TelegramUser> _telegramUsers = new ObservableCollection<TelegramUser>();
        public ObservableCollection<TelegramUser> TelegramUsers
        {
            get { return _telegramUsers; }
            set 
            { 
                _telegramUsers = value; 
                OnPropetyChanged(); 
            }
        }
        public TelegramBot()
        {
            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { },
            };
            client.StartReceiving(
                Update,
                Error,
                receiverOptions,
                cancellationToken
            );
        }
        private Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        async Task Update(ITelegramBotClient client, Update update, CancellationToken token)
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                    switch (update.Message.Text)
                    {
                        case "/start":
                            await client.SendTextMessageAsync(update.Message.Chat.Id, "Hello", cancellationToken: token);
                            break;
                        default:
                            // обрабатываем и добавляем данные
                            TelegramUser person = new TelegramUser(update.Message.Chat.FirstName, update.Message.Chat.Id);
                            if (!TelegramUsers.Contains(person))
                            {
                                TelegramUsers.Add(person);
                            }
                            TelegramUsers[TelegramUsers.IndexOf(person)].AddMessage($"{DateTime.Now.ToShortTimeString()} | {person.UserName}: {update.Message.Text}");
                            break;
                    }
                    break;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropetyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        

    }
}
