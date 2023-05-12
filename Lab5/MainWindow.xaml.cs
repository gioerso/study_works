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

namespace lab5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            int PriceCapuchino = 50;
            int PriceCacao = 30;
            int PriceAmericano = 40;
            int PriceEspresso = 40;


            if (rbCapuchino.IsChecked == true)
            {
                if (int.Parse(lblEnteredMoney.Content.ToString()) > PriceCapuchino)
                {
                    MessageBox.Show("Спасибо что выбрали нас. Заберайте капучино в лотке внизу.");
                    lblSdacha.Content = int.Parse(lblEnteredMoney.Content.ToString()) - PriceCapuchino;
                    lblEnteredMoney.Content = "0";
                }
            }
            else if (rbAmericano.IsChecked == true)
            {
                if (int.Parse(lblEnteredMoney.Content.ToString()) > PriceAmericano)
                {
                    MessageBox.Show("Спасибо что выбрали нас. Заберайте американо в лотке внизу.");
                    lblSdacha.Content = int.Parse(lblEnteredMoney.Content.ToString()) - PriceAmericano;
                    lblEnteredMoney.Content = "0";
                }
            }
            else if (rbCacao.IsChecked == true)
            {
                if (int.Parse(lblEnteredMoney.Content.ToString()) > PriceCacao)
                {
                    MessageBox.Show("Спасибо что выбрали нас. Заберайте какао в лотке внизу.");
                    lblSdacha.Content = int.Parse(lblEnteredMoney.Content.ToString()) - PriceCacao;
                    lblEnteredMoney.Content = "0";
                }
            }
            else if (rbEspresso.IsChecked == true)
            {
                if (int.Parse(lblEnteredMoney.Content.ToString()) > PriceEspresso)
                {
                    MessageBox.Show("Спасибо что выбрали нас. Заберайте еспрессо в лотке внизу.");
                    lblSdacha.Content = int.Parse(lblEnteredMoney.Content.ToString()) - PriceEspresso;
                    lblEnteredMoney.Content = "0";
                }
            }

        }

        private void rbCapuchino_Checked(object sender, RoutedEventArgs e)
        {
            imgCup.Source = new BitmapImage(new Uri(@"C:\Users\Billy Herrington\Desktop\Учёба\МДК0202_ИСРПО\lab5\capuchino.jpg"));
        }

        private void rbAmericano_Checked(object sender, RoutedEventArgs e)
        {
            imgCup.Source = new BitmapImage(new Uri(@"C:\Users\Billy Herrington\Desktop\Учёба\МДК0202_ИСРПО\lab5\Americano.jpg"));
        }

        private void rbCacao_Checked(object sender, RoutedEventArgs e)
        {
            imgCup.Source = new BitmapImage(new Uri(@"C:\Users\Billy Herrington\Desktop\Учёба\МДК0202_ИСРПО\lab5\kakao.jpg"));
        }

        private void rbEspresso_Checked(object sender, RoutedEventArgs e)
        {
            imgCup.Source = new BitmapImage(new Uri(@"C:\Users\Billy Herrington\Desktop\Учёба\МДК0202_ИСРПО\lab5\espresso.jpg"));
        }

        private void cbMilk_Click(object sender, RoutedEventArgs e)
        {
            if (cbMilk.IsChecked == true)
            {
                imgMilk.Source = new BitmapImage(new Uri(@"C:\Users\Billy Herrington\Desktop\Учёба\МДК0202_ИСРПО\lab5\milk.jpg"));
            }
            else
            {
                imgMilk.Source = null;
            }
        }

        private void cbSugar_Click(object sender, RoutedEventArgs e)
        {
            if (cbSugar.IsChecked == true)
            {
                imgSugar.Source = new BitmapImage(new Uri(@"C:\Users\Billy Herrington\Desktop\Учёба\МДК0202_ИСРПО\lab5\sugar.jpg"));
            }
            else
            {
                imgSugar.Source = null;
            }
        }

        private void tbMoney_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void btnMoney_Click(object sender, RoutedEventArgs e)
        {
            string EnteredMoney = lblEnteredMoney.Content.ToString();
            lblEnteredMoney.Content = int.Parse(tbMoney.Text) + int.Parse(EnteredMoney);
        }
    }
}
