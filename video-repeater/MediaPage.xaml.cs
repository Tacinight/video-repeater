using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VideoRepeater.Model;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace VideoRepeater
{

    public sealed partial class MediaPage : Page
    {
        private ObservableCollection<MediaFile> MediaFiles;
        
        public MediaPage()
        {
            MediaFiles = new ObservableCollection<MediaFile>();
            MediaFiles.Add(new MediaFile("OpenFile", null, "/Assets/add_file.png"));
            MediaFiles.Add(new MediaFile("OpenFolder", null, "/Assets/add_folder.png"));
            this.InitializeComponent();
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
                    MediaFiles.Add(new MediaFile(file.Name, file, "/Assets/pic.png"));
                }
            }
            else if (item.Name == "OpenFolder")
            {
                var folderPicker = new FolderPicker();
                folderPicker.SuggestedStartLocation = PickerLocationId.Desktop;
                folderPicker.FileTypeFilter.Add("*");

                StorageFolder folder = await folderPicker.PickSingleFolderAsync();
                IReadOnlyList<StorageFile> filelist = await folder.GetFilesAsync();
                if (filelist == null) return;
                foreach (StorageFile file in filelist)
                {
                    MediaFiles.Add(new MediaFile(file.Name, file, "/Assets/pic.png"));
                }
            }
            else
            {
                Frame.Navigate(typeof(PlayerPage), item);
            }
        }
    }
}
