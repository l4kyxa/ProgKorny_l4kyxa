using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Progkorny.Models;
using Progkorny.ViewModels;


namespace Progkorny.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }


        public void sideopen(object sender, RoutedEventArgs e)
        {
            AutoFormWindow window = new AutoFormWindow()
            {
                DataContext = this.DataContext
            };
            window.ShowDialog(this);
        }

        public void selectedAuto(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                ListBox senderbox = (ListBox)sender;
                AutoDetailsWindow details = new AutoDetailsWindow()
                {

                    DataContext = new AutoView((Auto)senderbox.SelectedItem)

                };
                senderbox.SelectedItem = null;
                details.Show();
            }
        }
    }
}