using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Progkorny.Models;
using Progkorny.ViewModels;
using Progkorny.Views;

namespace Progkorny
{
    public class AutoFormWindow : Window
    {
        public AutoFormWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void storno(object sender, RoutedEventArgs e)
        {
            TextBox tipus = this.Find<TextBox>("tipusmezo");
            TextBox ar = this.Find<TextBox>("armezo");
            TextBox rendszam = this.Find<TextBox>("rendszammezo");
            DatePicker evjarat = this.Find<DatePicker>("evjaratmezo");
            tipus.Text = "";
            ar.Text = "";
            rendszam.Text = "";
            evjarat.Text = "";

        }

        private void back(object sender, RoutedEventArgs e)
        {
            AutoFormWindow window = new AutoFormWindow()
            {
                DataContext = this.DataContext
            };
            //window.ShowDialog(this);
            window.Hide();
        }
           


        private void validateForm(object sender, RoutedEventArgs e)
        {
            TextBox tipus = this.Find<TextBox>("tipusmezo");
            TextBox ar = this.Find<TextBox>("armezo");
            TextBox rendszam = this.Find<TextBox>("rendszammezo");
            DatePicker evjarat = this.Find<DatePicker>("evjaratmezo");
            tipus.Background = null;
            ar.Background = null;
            rendszam.Background = null;
            evjarat.Background = null;
            bool validTipus = this.validTipus(tipus.Text);
            bool validAr = this.validAr(ar.Text);
            bool validRendszam = this.validRendszam(rendszam.Text);
            bool validEvjarat = this.validEvjarat(evjarat.Text);

            
            if (!validTipus)
            {
                tipus.Background = Brushes.Red;
            }
       

            if (!validAr)
            {
                ar.Background = Brushes.Red;
            }
            if (!validRendszam)
            {
                rendszam.Background = Brushes.Red;
            }
            if (!validEvjarat)
            {
                evjarat.Background = Brushes.Red;
            }

            if (validTipus && validAr && validRendszam && validEvjarat)
            {
                Auto auto = new Auto();
                auto.Tipus = tipus.Text;
                auto.Ar = Int64.Parse(ar.Text);
                auto.Rendszam = rendszam.Text;
                auto.Evjarat = DateTime.Parse(evjarat.Text);
                Console.WriteLine(auto);
                MainWindowViewModel mvvm = (MainWindowViewModel) this.DataContext;
                mvvm.List.Autok.Add(auto);
            }
 
            
            
        }

        private bool validTipus(string tipus)
        {
            Auto d = new Auto();
            try
            {
                d.Tipus = tipus;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }

        private bool validAr(string ar)
        {
            Auto d = new Auto();
            try
            {
                d.Ar = Int64.Parse(ar);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }

        private bool validEvjarat(string evjarat)
        {
            Auto d = new Auto();
            try
            {
                d.Evjarat = DateTime.Parse(evjarat);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;

        }

        private bool validRendszam(string rendszam)
        {
            Auto d = new Auto();
            try
            {
                d.Rendszam = rendszam;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }
    }
}