using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Windows.Media;
using Windows.Media.Audio;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Media.Render;

using jcFUS.PCL.Handlers;
using jcFUS.PCL.Transports;
using jcFUS.PCL.Transports.TextChat;

namespace jcFUS.UWP.ViewModels {
    public class MainPageModel : INotifyPropertyChanged {

        private ObservableCollection<TextChatLogResponseItem> _chatlog;

        public ObservableCollection<TextChatLogResponseItem> ChatLog {
            get { return _chatlog; }
            set { _chatlog = value; OnPropertyChanged(); }
        }

        private ObservableCollection<PersonItem> _connectedPeople;

        public ObservableCollection<PersonItem> ConnectedPeople {
            get { return _connectedPeople; }
            set { _connectedPeople = value; OnPropertyChanged(); }
        }

        public MainPageModel() {
            ChatLog = new ObservableCollection<TextChatLogResponseItem>();

            ConnectedPeople = new ObservableCollection<PersonItem>();

            ConnectedPeople.Add(new PersonItem {
                Color = App.CURRENT_USER.ColorString,
                GUID = Guid.NewGuid(),
                Name = App.CURRENT_USER.DisplayName
            });
        }

        private string _chatEntry;

        public string ChatEntry {
            get { return _chatEntry; }
            set { _chatEntry = value; OnPropertyChanged(); }
        }

        public async Task<bool> SubmitChat() {
            var textChatHandler = new TextChatHandler(App.CURRENT_USER.Token);

            var result = await textChatHandler.SubmitNewEntry(new TextChatCreationRequestItem {
                ChannelGUID = App.CURRENT_USER.DefaultChannelGUID,
                Entry = ChatEntry
            });
            
            ChatEntry = string.Empty;

            return result;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void EnableMicrophone() {
            AudioGraphSettings settings = new AudioGraphSettings(AudioRenderCategory.Communications);

            settings.DesiredRenderDeviceAudioProcessing = Windows.Media.AudioProcessing.Default;
            settings.QuantumSizeSelectionMode = QuantumSizeSelectionMode.LowestLatency;


            var result = await AudioGraph.CreateAsync(settings);

            var audioGraph = result.Graph;

            await audioGraph.CreateDeviceInputNodeAsync(MediaCategory.Communications,
                AudioEncodingProperties.CreateMp3(44100, 2, 128));

            frameOutputNode = audioGraph.CreateFrameOutputNode();

            audioGraph.QuantumProcessed += AudioGraphy_QuantumProcessed;

            audioGraph.Start();

        }

        private AudioFrameOutputNode frameOutputNode;

        private void AudioGraphy_QuantumProcessed(AudioGraph sender, object args) {
            AudioFrame frame = frameOutputNode.GetFrame();
        }
    }
}