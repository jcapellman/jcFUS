using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using jcFUS.PCL.Transports;

namespace jcFUS.UWP.ViewModels {
    public class MainPageModel : INotifyPropertyChanged {
        private ObservableCollection<ChatLogItem> _chatlog;
        
        public ObservableCollection<ChatLogItem> ChatLog {
            get { return _chatlog; }
            set { _chatlog = value; OnPropertyChanged(); }
        }

        public MainPageModel() {
            ChatLog = new ObservableCollection<ChatLogItem>();
        }

        private string _chatEntry;

        public string ChatEntry {
            get { return _chatEntry; }
            set { _chatEntry = value; OnPropertyChanged(); }
        }

        public void SubmitChat() {
            ChatLog.Add(new ChatLogItem {
                Entry = ChatEntry,
                Timestamp = DateTime.Now,
                Username = "Jarred"
            });

            ChatEntry = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}