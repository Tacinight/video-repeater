using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.Media.Core;
using VideoRepeater.Model;
namespace VideoRepeater
{

    public sealed partial class PlayerPage : Page
    {
        MediaSource mediaSource;
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
    }
}
