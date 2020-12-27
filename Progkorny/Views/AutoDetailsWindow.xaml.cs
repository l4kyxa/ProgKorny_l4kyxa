using Avalonia;
using Avalonia.Controls;
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
    }
}