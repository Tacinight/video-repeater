using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VideoRepeater.Model;
using Windows.Media.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace VideoRepeater
{

    public sealed partial class PlayerPage : Page
    {
        MediaSource mediaSource;
        TimeSpan entry, exit;
        
        public PlayerPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var file = (MediaFile)e.Parameter;
            mediaSource = MediaSource.CreateFromStorageFile(file.VideoFile);
            myMediaElement.SetPlaybackSource(mediaSource);
            myMediaElement.AreTransportControlsEnabled = true;
        }

        private async void MarkEntryButton_Click(object sender, EventArgs e)
        {
            entry = myMediaElement.Position;
            var messageDialog = new MessageDialog("Marked Entry");
            await messageDialog.ShowAsync();
        }

        private async void MarkExitButton_Click(object sender, EventArgs e)
        {
            exit = myMediaElement.Position;
            App.MediaSlices.Add(new MediaSlice(entry, exit));
            var messageDialog = new MessageDialog("Marked Exit");
            await messageDialog.ShowAsync();
        }

        public async void PlaySlice(MediaSlice slice)
        {
            myMediaElement.Position = slice.Entry;
            myMediaElement.Play();
            await Task.Delay((int)slice.Duration.TotalMilliseconds);
            myMediaElement.Position = slice.Entry;
            myMediaElement.Pause();
        }
    }
}
