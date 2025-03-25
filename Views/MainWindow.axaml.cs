using System;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;

namespace wwe.Views
{
    public partial class MainWindow : Window
    {
        public int i = 0;
        string[]? files;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void previous(object sender, RoutedEventArgs e)
        {
            i -= 1;
            if (i >= 0)
            {
                Scaling.Source = new Bitmap(files[i]);
                UpdateImageDetails(files[i]);
            }
        }

        public void next(object sender, RoutedEventArgs e)
        {
            string? fotos_directory = Id.Text;
            files = Directory.GetFiles(fotos_directory ?? string.Empty);

            i += 1;
            if (i < files.Length)
            {
                Scaling.Source = new Bitmap(files[i]);
                UpdateImageDetails(files[i]);
            }
        }

        public void update()
        {
            string? fotos_directory = Id.Text;
            files = Directory.GetFiles(fotos_directory ?? string.Empty);

            if (i == 0)
            {
                Scaling.Source = new Bitmap(files[i]);
                UpdateImageDetails(files[i]);
            }
            else
            {
                next(null, null);
            }
        }

        private void UpdateImageDetails(string filePath)
        {
            // FileName
            FileName.Text = Path.GetFileName(filePath);

            // Creation Date
            CreationDate.Text = File.GetCreationTime(filePath).ToString();

            // Size
            var fileInfo = new FileInfo(filePath);
            Size.Text = $"{fileInfo.Length / 1024} KB";

            // Resolution
            using (var bitmap = new Bitmap(filePath))
            {
                Resolution.Text = $"{bitmap.PixelSize.Width}x{bitmap.PixelSize.Height}";
            }

            // Format
            Format.Text = Path.GetExtension(filePath).ToUpperInvariant();
        }

        private void Button2Click(object? sender, RoutedEventArgs e)
        {
            Close(); // Closes the current window
        }

        public void load(object source, RoutedEventArgs args)
        {
            string? fotos_directory = Id.Text;
            MainWrap.Children.Clear();

            files = Directory.GetFiles(fotos_directory ?? string.Empty);
            waiting.Source = null;

            foreach (string path in files)
            {
                Console.WriteLine("Path: " + path);

                // Load thumbnails into MainWrap
                Bitmap bitmap = new Bitmap(path);
                Image image = new Image();
                image.Source = bitmap;
                image.Height = 100;

                MainWrap.Children.Add(image);
            }
            i = 0;
            update();
        }
    }
}