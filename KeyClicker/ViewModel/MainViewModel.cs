using KeyClicker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows.Threading;
using Telegram.Bot;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace KeyClicker.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private readonly TelegramBot _bot = new TelegramBot();
        public ObservableCollection<TelegramUser> TelegramUsers
        {
            get { return _bot.TelegramUsers; }
            set { _bot.TelegramUsers = value; OnPropetyChanged(); }
        }
        
        public TelegramUser SelectedUser { get; set; }

        private string _message;
        public string Message 
        { 
            get { return _message; }
            set 
            { 
                _message = value;
                OnPropetyChanged(); 
            }   
        }

        public RelayCommand SendCommand { get; set; }


        public MainViewModel() 
        {   
            SendCommand = new RelayCommand(o =>
            {

                SelectedUser?.Messages.Add(Message);
                Message = "";
            });
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropetyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
