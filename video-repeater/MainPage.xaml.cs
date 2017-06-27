using System;
using System.Collections.ObjectModel;
using VideoRepeater.Model;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace VideoRepeater
{

    public sealed partial class MainPage : Page
    {
        public ObservableCollection<MediaSlice> MediaSlices = App.MediaSlices;
        public MainPage()
        {
            this.InitializeComponent();
            subFrame.Navigate(typeof(MediaPage));
        }

        private void HamburgerBtn_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }

        private void MenuItemListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (e.ClickedItem);
        }

        private void MediaSliceListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var mediaSlice = (MediaSlice)e.ClickedItem;
            var playerPage = (PlayerPage)subFrame.Content;
            playerPage.PlaySlice(mediaSlice);
        }
    }
}
