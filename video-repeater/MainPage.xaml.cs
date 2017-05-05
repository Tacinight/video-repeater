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
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.Media.Core;
// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace video_repeater
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MediaSource mediaSource;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            var filePicker = new FileOpenPicker();

            filePicker.FileTypeFilter.Add(".wmv");
            filePicker.FileTypeFilter.Add(".mp4");
            filePicker.FileTypeFilter.Add(".mkv");
            filePicker.FileTypeFilter.Add(".avi");

            filePicker.SuggestedStartLocation = PickerLocationId.VideosLibrary;

            StorageFile file = await filePicker.PickSingleFileAsync();

            if (file != null)
            {
                mediaSource = MediaSource.CreateFromStorageFile(file);
                myMediaElement.SetPlaybackSource(mediaSource);
                myMediaElement.AreTransportControlsEnabled = true;
            }
        }

        private void IconListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void HamburgerBtn_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }
    }
}
