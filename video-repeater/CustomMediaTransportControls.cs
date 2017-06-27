using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using VideoRepeater;

namespace VideoRepeater
{
    public sealed class CustomMediaTransportControls : MediaTransportControls 
    {
        public event EventHandler<EventArgs> MarkEntry;
        public event EventHandler<EventArgs> MarkExit;

        public CustomMediaTransportControls()
        {
            this.DefaultStyleKey = typeof(CustomMediaTransportControls);
        }

        protected override void OnApplyTemplate()
        {
            Button MarkEntryButton = GetTemplateChild("MarkEntryButton") as Button;
            MarkEntryButton.Click += MarkEntryButton_Click;
            Button MarkExitButton = GetTemplateChild("MarkExitButton") as Button;
            MarkExitButton.Click += MarkExitButton_Click;
            base.OnApplyTemplate();
        }

        private void MarkEntryButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MarkEntry?.Invoke(this, EventArgs.Empty);
        }

        private void MarkExitButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MarkExit?.Invoke(this, EventArgs.Empty);
        }
    }
}
