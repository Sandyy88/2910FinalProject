using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.Media.Core;

namespace _06CorePlayer
{
    public class CustomMediaTransportControls : MediaTransportControls
    {
        public event EventHandler<EventArgs> Liked;

        public event EventHandler<EventArgs> Files;
        public CustomMediaTransportControls()
        {
            this.DefaultStyleKey = typeof(CustomMediaTransportControls);
        }

        protected override void OnApplyTemplate()
        {
            // This is where you would get your custom button and create an event handler for its click method.
            Button likeButton = GetTemplateChild("LikeButton") as Button;
            likeButton.Click += LikeButton_Click;

            Button fileButton = GetTemplateChild("FileButton") as Button;
            fileButton.Click += PickFile_Click;

            base.OnApplyTemplate();
        }

        private void LikeButton_Click(object sender, RoutedEventArgs e)
        {
            // Raise an event on the custom control when 'like' is clicked
            Liked?.Invoke(this, EventArgs.Empty);
        }

        //Finish implementation here. Not sure how to do this yet
        
        private void PickFile_Click(object sender, RoutedEventArgs e)
        {
           Files?.Invoke(this, EventArgs.Empty);
        }
        
    }
}

