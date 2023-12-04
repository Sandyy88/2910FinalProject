using Demo5.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using System.Diagnostics;
using Windows.Storage.Streams;
using Windows.UI;
using Microsoft.UI.Xaml.Media;
using Microsoft.Xaml.Interactivity;
using Windows.UI.Composition;
using Windows.Media.Devices;
using Microsoft.Toolkit.Uwp.UI;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Demo5.Views
{
    public sealed partial class Gallery : Page
    {
        public MemoriesViewModel ViewModel { get; } = new MemoriesViewModel();

        public List<Image> Images { get; set; }
        public List<StorageFile> Files { get; set; }

        public Button closeButton;

        public double TotalHeight;

        BitmapImage XBitmap;


        public Gallery()
        {
            this.InitializeComponent();
            Gallery_Loaded();
        }

        public void Gallery_Loaded()
        {
            XBitmap = new BitmapImage(new Uri("ms-appx:///Assets/xButton.png"));
            XBitmap.ImageOpened += (sender, e) => Debug.WriteLine("Image opened successfully.");
            Files = new List<StorageFile>();
            imageStackPanel.Height = Window.Current.Bounds.Height;
            mainGrid.Height = imageStackPanel.Height;
            mainCanvas.Height = mainGrid.Height;
            PopulateGallery();
        }

        public async void AddImage(object sender, RoutedEventArgs e)
        {
            Images = new List<Image>();
            FileOpenPicker picturePicker = new FileOpenPicker();

            picturePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picturePicker.FileTypeFilter.Add(".png");
            picturePicker.FileTypeFilter.Add(".jpg");
            picturePicker.FileTypeFilter.Add(".jpeg");

            Files = (await picturePicker.PickMultipleFilesAsync()).ToList();

            if (Files.Count > 0)
            {
                CreateImagesFromFiles();
            }

            SaveFiles();
        }

        public async void SaveFiles()
        {
            var fileName = "galleryImages.txt";

            // Get the LocalFolder
            var localFolder = ApplicationData.Current.LocalFolder;

            var galleryImages = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);

            using (var stream = await galleryImages.OpenStreamForWriteAsync())
            {
                // Write content using StreamWriter
                using (var writer = new StreamWriter(stream))
                {
                    foreach (var file in Files)
                    {
                        await writer.WriteLineAsync(file.Path);
                    }
                }
            }
        }

        //code from https://stackoverflow.com/questions/1245243/delete-specific-line-from-a-text-file
        public async void RemoveEntryFromFiles(string filePath)
        {
            var fileName = "galleryImages.txt";

            // Get the LocalFolder
            var localFolder = ApplicationData.Current.LocalFolder;

            var galleryImages = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);

            var lines = new List<string>();

            // Read existing content into memory
            using (var stream = await galleryImages.OpenStreamForReadAsync())
            {
                using (var reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        lines.Add(await reader.ReadLineAsync());
                    }
                }
            }

            // Modify the content
            lines.RemoveAll(line => String.Compare(line, filePath) == 0);

            // Write modified content back to the file
            using (var stream = await galleryImages.OpenStreamForWriteAsync())
            {
                using (var writer = new StreamWriter(stream))
                {
                    foreach (var line in lines)
                    {
                        await writer.WriteLineAsync(line);
                    }
                }
            }
        }

        private Button CreateCloseButton(Border br, Grid gr, Image img, string filePath)
        {
            Button closeButton = new Button();

            //styling
            closeButton.FontSize = 8;
            closeButton.Click += (sender, e) => RemoveImage(br, gr, img, closeButton, filePath);
            closeButton.HorizontalAlignment = HorizontalAlignment.Right;
            closeButton.VerticalAlignment = VerticalAlignment.Top;

            var brush = new ImageBrush();
            brush.ImageSource = XBitmap;
            brush.Stretch = Stretch.Fill;
            closeButton.Background = brush;
            closeButton.Foreground = brush;
            closeButton.Padding = new Thickness(0);
            closeButton.BorderThickness = new Thickness(0);

            closeButton.Height = 12;
            closeButton.Width = 30;
            closeButton.CornerRadius = new CornerRadius(0, 0, 0, 0);

            return closeButton;
        }

        //make sure to remove image from the file as well
        private void RemoveImage(Border borderToRemove, Grid gr, Image imageToRemove, Button closeButton, string filePath)
        {
            imageStackPanel.Children.Remove(borderToRemove);
            imageStackPanel.Children.Remove(gr);
            Images.Remove(imageToRemove);
            imageStackPanel.Children.Remove(closeButton);
            imageStackPanel.Height -= imageToRemove.Height;
            RemoveEntryFromFiles(filePath);
        }

        public async void PopulateGallery()
        {
            var fileName = "galleryImages.txt";

            // Get the LocalFolder
            var localFolder = ApplicationData.Current.LocalFolder;

            var galleryImages = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);

            using (StreamReader str = new StreamReader(await galleryImages.OpenStreamForReadAsync()))
            {
                while (!str.EndOfStream)
                {
                    try
                    {
                        var filePath = await str.ReadLineAsync();
                        Debug.WriteLine(filePath);
                        StorageFile file = await StorageFile.GetFileFromPathAsync(filePath);
                        Files.Add(file);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Invalid filepath!");
                    }
                }

            }

            if (Files.Count > 0)
            {
                CreateImagesFromFiles();
            }
        }

        public async void CreateImagesFromFiles()
        {
            foreach (var file in Files)
            {
                Compositor compositor = Window.Current.Compositor;
                var light = compositor.CreateAmbientLight();
                light.Color = Colors.White;
                //following code from https://stackoverflow.com/questions/65478732/how-to-display-an-image-chosen-by-a-file-open-picker-in-uwp-c
                using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read))
                {
                    Image img = new Image();
                    BitmapImage bitmapImage = new BitmapImage();
                    await bitmapImage.SetSourceAsync(fileStream);

                    //creating the image
                    img.Source = bitmapImage;
                    img.MaxHeight = 500;
                    img.MaxWidth = 500;
                    img.HorizontalAlignment = HorizontalAlignment.Center;
                    imageStackPanel.Height += img.Height;

                    //fix this border stuff to make it seem like it's an old windows border around all the images
                    // Create a LinearGradientBrush for the border
                    Border outerBorder = new Border();
                    outerBorder.BorderBrush = new SolidColorBrush(Colors.Gray);
                    outerBorder.BorderThickness = new Thickness(0.5); // Adjust as needed
                    outerBorder.Margin = new Thickness(20);

                    //creating a grid. This will allow me to add multiple children so I can have an x button on the border.
                    Grid gr = new Grid();


                    // Create the inner Border for the translucent border
                    Border innerBorder = new Border();
                    innerBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(50, 54, 192, 255)); // Adjust alpha for transparency
                    innerBorder.BorderThickness = new Thickness(12); // Adjust as needed

                    // Set the inner Border as the Child of the outer Border
                    outerBorder.Child = gr;
                    innerBorder.Child = img;

                    //light.Targets.Add(innerBorder.GetVisual());
                    light.ExclusionsFromTargets.Add(img.GetVisual());
                    light.Intensity = 0.5f;

                    ///adding a button to the image ('x' button if you want to remove it)
                    Button closeButton = CreateCloseButton(outerBorder, gr, img, file.Path);
                    light.ExclusionsFromTargets.Add(closeButton.GetVisual());

                    gr.Children.Add(innerBorder);
                    gr.Children.Add(closeButton);

                    //adding images to the screen
                    imageStackPanel.Children.Add(outerBorder);
                }
            }

        }
    }
}
