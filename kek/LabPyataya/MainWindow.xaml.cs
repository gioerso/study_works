using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabPyataya
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public class Americano
    {
        public int Cost { get; set; } = 100;
    }

    public class Capucchino
    {
        public int Cost { get; set; } = 150;
    }

    public class Espresso
    {
        public int Cost { get; set; } = 75;
    }

    public class Cacao
    {
        public int Cost { get; set; } = 50;
    }

    public class Milk
    {
        public int Cost { get; set; } = 20;
    }

    public class Sugar
    {
        public int Cost { get; set; } = 10;
    }

    public partial class MainWindow : Window
    {
        int Summ = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (AmericanoradioButton.IsChecked == true)
            {
                Americano cup = new Americano();
                Summ = -cup.Cost;
            }

            if (CapucchinoradioButton.IsChecked == true)
            {
                Capucchino cup = new Capucchino();
                Summ = -cup.Cost;
            }

            if (EspressoradioButton.IsChecked == true)
            {
                Espresso cup = new Espresso();
                Summ = -cup.Cost;
            }

            if (CacaoradioButton.IsChecked == true)
            {
                Cacao cup = new Cacao();
                Summ = -cup.Cost;
            }

            if (MilkCheckBox.IsChecked == true)
            {
                Milk milks = new Milk();
                Summ = Summ - milks.Cost;
            }

            if (SugarCheckBox.IsChecked == true)
            {
                Sugar sugars = new Sugar();
                Summ = Summ - sugars.Cost;
            }

            AmericanoradioButton.IsEnabled = false;
            CapucchinoradioButton.IsEnabled = false;
            EspressoradioButton.IsEnabled = false;
            CacaoradioButton.IsEnabled = false;
            MilkCheckBox.IsEnabled = false;
            SugarCheckBox.IsEnabled = false;
            PayTextBox.IsEnabled = true;
            PayButton.IsEnabled = true;
            LabelWendingMachine.Content = "Для приготовления напитка внесите " + -Summ + "руб. в автомат. \nСдача выдается монетами.";
            OkButton.IsEnabled = false;
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            Summ = Summ + Int32.Parse(PayTextBox.Text);
            if (Summ>=0)
            {
                AmericanoradioButton.IsEnabled = true;
                CapucchinoradioButton.IsEnabled = true;
                EspressoradioButton.IsEnabled = true;
                CacaoradioButton.IsEnabled = true;
                MilkCheckBox.IsEnabled = true;
                SugarCheckBox.IsEnabled = true;
                PayTextBox.IsEnabled = false;
                PayButton.IsEnabled = false;
                LabelWendingMachine.Content = "Напиток начинает готовится.\nВаша сдача: " + Summ + "руб.";
                OkButton.IsEnabled = true;
            }
            else
            {
                LabelWendingMachine.Content = "Для приготовления напитка осталось \nвнести " + -Summ + "руб. в автомат.";
            }
        }

        private void AmericanoradioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (AmericanoradioButton.IsChecked == true)
            {
                Uri resourceUri = new Uri("/americano.jpg", UriKind.Relative);
                DrinkImage.Source = new BitmapImage(resourceUri);
                OkButton.IsEnabled = true;
            }
        }

        private void CapucchinoradioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (CapucchinoradioButton.IsChecked == true)
            {
                Uri resourceUri = new Uri("/capucchino.jpg", UriKind.Relative);
                DrinkImage.Source = new BitmapImage(resourceUri);
                OkButton.IsEnabled = true;
            }
        }

        private void EspressoradioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (EspressoradioButton.IsChecked == true)
            {
                Uri resourceUri = new Uri("/espresso.jpg", UriKind.Relative);
                DrinkImage.Source = new BitmapImage(resourceUri);
                OkButton.IsEnabled = true;
            }
        }

        private void CacaoradioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (CacaoradioButton.IsChecked == true) 
            { 
                Uri resourceUri = new Uri("/cacao.jpg", UriKind.Relative);
                DrinkImage.Source = new BitmapImage(resourceUri);
                OkButton.IsEnabled = true;
            }
        }
    }
}
