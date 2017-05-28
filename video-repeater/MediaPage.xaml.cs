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
using System.Collections.ObjectModel;
using VideoRepeater.Model;

namespace VideoRepeater
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MediaPage : Page
    {
        private ObservableCollection<MediaFile> MediaFiles;
        
        public MediaPage()
        {
            MediaFiles = new ObservableCollection<MediaFile>();
            MediaFiles.Add(new MediaFile("OpenFile", null));
            MediaFiles.Add(new MediaFile("OpenFolder", null));
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
                //Frame.Navigate(typeof(PlayerPage), file);
                MediaFiles.Add(new MediaFile(file.Name, file));
            }
        }

        private async void MediaGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = (MediaFile)e.ClickedItem;
            if (item.Name == "OpenFile")
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
                    //Frame.Navigate(typeof(PlayerPage), file);
                    MediaFiles.Add(new MediaFile(file.Name, file));
                }
            }
            else if (item.Name == "OpenFolder")
            {
                var folderPicker = new FolderPicker();
                folderPicker.SuggestedStartLocation = PickerLocationId.Desktop;
                folderPicker.FileTypeFilter.Add("*");

                StorageFolder folder = await folderPicker.PickSingleFolderAsync();
                IReadOnlyList<StorageFile> filelist = await folder.GetFilesAsync();
                foreach (StorageFile file in filelist)
                {
                    MediaFiles.Add(new MediaFile(file.Name, file));
                }
            }
            else
            {
                Frame.Navigate(typeof(PlayerPage), item);
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var folderPicker = new FolderPicker();
            folderPicker.SuggestedStartLocation = PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*");

            StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            IReadOnlyList<StorageFile> filelist = await folder.GetFilesAsync();
            foreach (StorageFile file in filelist)
            {
                MediaFiles.Add(new MediaFile(file.Name, file));
            }
        }
    }
}
