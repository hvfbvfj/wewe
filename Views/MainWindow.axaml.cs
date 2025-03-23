using System;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;

namespace wwe.Views
{

    public partial class MainWindow : Window
    {
        public int number_foto = 0;
        string[]? files;
        public MainWindow()
        {
            InitializeComponent();
        }

           public void AnotherButtonClick(object sender, RoutedEventArgs e)
{
    Console.WriteLine("Another Button clicked!");
}


        public void NewButtonClick(object sender, RoutedEventArgs e)
{
    Console.WriteLine("New Button clicked!");
}
          public void Button2Click(object source, RoutedEventArgs args)
{
    Console.WriteLine("New Button clicked");
}
        public void load(object source, RoutedEventArgs args)
        {
          string? fotos_directory = Id.Text;
            MainWrap.Children.Clear();
            Console.WriteLine("Button 1 Clicked");

            files = Directory.GetFiles(fotos_directory ?? string.Empty);
            waiting.Source = null;

            foreach (string path in files)
            {
                Console.WriteLine("Path: " + path);

                // Завантаження мініатюр в MainWrap
                Bitmap bitmap = new Bitmap(path);
                Image image = new Image();
                image.Source = bitmap;
                image.Height = 100;

                MainWrap.Children.Add(image);
            }
        }








    }
}