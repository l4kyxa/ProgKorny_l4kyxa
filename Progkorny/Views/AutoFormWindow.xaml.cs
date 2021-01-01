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
            tipus.Background = Brushes.White;
            ar.Background = Brushes.White;
            rendszam.Background = Brushes.White;
            evjarat.Background = Brushes.White;
           

        }

        private void back(object sender, RoutedEventArgs e)
        {
            AutoFormWindow window = new AutoFormWindow()
            {DataContext = this.DataContext};
            this.Close();
        }

  
        private void validateForm(object sender, RoutedEventArgs e)
        {
  
            TextBox tipus = this.Find<TextBox>("tipusmezo");
            TextBox ar = this.Find<TextBox>("armezo");
            TextBox rendszam = this.Find<TextBox>("rendszammezo");
            DatePicker evjarat = this.Find<DatePicker>("evjaratmezo");
            tipus.Background = Brushes.White;
            ar.Background = Brushes.White;
            rendszam.Background = Brushes.White;
            evjarat.Background = Brushes.White;
            bool validTipus = this.validTipus(tipus.Text);
            bool validAr = this.validAr(ar.Text);
            bool validRendszam = this.validRendszam(rendszam.Text);
            bool validEvjarat = this.validEvjarat(evjarat.Text);

            
            if (!validTipus)
            {tipus.Background = Brushes.Red;}
            else
            {tipus.Background = Brushes.Green;}

            if (!validAr)
            {ar.Background = Brushes.Red;}
            else
            {ar.Background = Brushes.Green;}

            if (!validRendszam)
            {rendszam.Background = Brushes.Red;}
            else
            {rendszam.Background = Brushes.Green;}

            if (!validEvjarat)
            {evjarat.Background = Brushes.Red;}
            else 
            {evjarat.Background = Brushes.Green;}

            if (validTipus && validAr && validRendszam && validEvjarat)
            {
                Auto auto = new Auto();
                auto.Tipus = tipus.Text;
                auto.Ar = Int64.Parse(ar.Text);
                auto.Rendszam = rendszam.Text;
                auto.Evjarat = DateTime.Parse(evjarat.Text);
                MainWindowViewModel mvvm = (MainWindowViewModel)this.DataContext;
                mvvm.List.Autok.Add(auto);
                AutoFormWindow window = new AutoFormWindow()
                {
                    DataContext = this.DataContext
                };
                this.Close();
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