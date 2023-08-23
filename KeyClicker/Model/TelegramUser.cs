using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KeyClicker.Model
{
    class TelegramUser : IEquatable<TelegramUser>, INotifyPropertyChanged
    {
        private string _userName;
        private long _id;

        // свойства
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropetyChanged();
            }
        }
        public long Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropetyChanged();
            }
        }

        // конструктор
        public TelegramUser(string userName, long id)
        {
            _userName = userName;
            _id = id;
            Messages = new ObservableCollection<string>();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropetyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<string> Messages { get; set; }

        // чтобы понимать с каким пользователем мы работаем нужно создать метод для сравнения id
        public bool Equals(TelegramUser? other) => other?.Id == _id;

        // у каждого пользователя свой лист сообщений, нужен метод для добавления сообщений
        public void AddMessage(string message) => Messages.Add(message);
    }
}
