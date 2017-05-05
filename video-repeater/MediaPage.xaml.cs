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
// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace video_repeater
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MediaPage : Page
    {
        public MediaPage()
        {
            this.InitializeComponent();
        }

        private async void openBtn_Click(object sender, RoutedEventArgs e)
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
                Frame.Navigate(typeof(PlayerPage), file);

            }
        }
    }
}
