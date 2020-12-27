using System;
using System.Data;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Progkorny.Models;
using Progkorny.ViewModels;
using ReactiveUI;

namespace Progkorny.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
            StackPanel panel = new StackPanel();
            

         
            Button b2 = new Button();
            b2.Content = "Autó Hozzáadása";
            b2.Background = Brushes.LightSkyBlue;
            b2.Name = "btn2";
            b2.Click += formMegnyitasa;

            Grid grid = new Grid();
            grid.Width = 500;
            grid.Background = Brushes.Beige;
            grid.Margin = Thickness.Parse("20,10,20,10");
            grid.ShowGridLines = true;
            ColumnDefinition column1 = new ColumnDefinition(GridLength.Parse("1*"));
         
            grid.ColumnDefinitions.Add(column1);
           
            RowDefinition row = new RowDefinition();
            grid.RowDefinitions.Add(row);
           
            Grid.SetColumn(b2, 0);
          
            grid.Children.Add(b2);

            panel.Children.Add(grid);
            WrapPanel root = this.Find<WrapPanel>("wrappanel");
            root.Orientation = Orientation.Vertical;
            root.Children.Add(panel);
            NameScope scope = new NameScope();
            b2.RegisterInNameScope(scope);
            root.RegisterInNameScope(scope);
            Button sayhibutton = this.Find<Button>("listabutton");
            sayhibutton.RegisterInNameScope(scope);
            sayhibutton.Click += lista;
            NameScope.SetNameScope(this, scope);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void lista(object sender, RoutedEventArgs e)
        {
            if (this.Find<TextBlock>("hiblock") == null)
            {
                TextBlock block = new TextBlock();
                block.Name = "hiblock";
                block.RegisterInNameScope(this.FindNameScope());
                WrapPanel panel = this.Find<WrapPanel>("wrappanel");
                panel.Children.Add(block);
            }

            ((MainWindowViewModel)DataContext).Message = "";
            ((MainWindowViewModel)DataContext).List.Autok.Add(new Auto
            { Tipus = "Mustang", Evjarat = new DateTime(1992, 4, 30) });
        }

        private void enlargeBox(object sender, GotFocusEventArgs e)
        {
            TextBox senderbox = (TextBox) sender;
            senderbox.Width = 700;
            senderbox.FontSize = senderbox.FontSize * 2;
        }

        public void defaultFont(object sender, RoutedEventArgs e)
        {
            TextBox senderbox = (TextBox) sender;
            senderbox.FontSize = senderbox.FontSize / 2;
        }

        public void formMegnyitasa(object sender, RoutedEventArgs e)
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
                ListBox senderbox = (ListBox) sender;
                Console.WriteLine("Selection changed");
                Console.WriteLine(senderbox.SelectedItem);


                AutoDetailsWindow details = new AutoDetailsWindow()
                {
                    DataContext = new AutoView( (Auto) senderbox.SelectedItem )
                };
                senderbox.UnselectAll();
                details.ShowDialog(this);
            }
        }
    }
}