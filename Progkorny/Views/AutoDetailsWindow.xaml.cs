using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Progkorny
{
    public class AutoDetailsWindow : Window
    {
        public AutoDetailsWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {

            AvaloniaXamlLoader.Load(this);
        }


        private void back(object sender, RoutedEventArgs e)
        {
            AutoFormWindow window = new AutoFormWindow()
            {
                DataContext = this.DataContext
            };
            this.Close();
        }

    }
}