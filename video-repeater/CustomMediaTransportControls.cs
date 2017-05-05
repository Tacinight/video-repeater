using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using video_repeater;

namespace video_repeater
{
    public sealed class CustomMediaTransportControls : MediaTransportControls 
    {
        public event EventHandler<EventArgs> Liked;
        public CustomMediaTransportControls()
        {
            this.DefaultStyleKey = typeof(CustomMediaTransportControls);
        }

        protected override void OnApplyTemplate()
        {
            Button likeButton = GetTemplateChild("LikeButton") as Button;
            likeButton.Click += LikeButton_Click;
            base.OnApplyTemplate();
        }

        private void LikeButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Liked?.Invoke(this, EventArgs.Empty);
        }
    }
}
