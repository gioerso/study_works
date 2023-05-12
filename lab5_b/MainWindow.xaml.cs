using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace lab5_b
{
    public partial class MainWindow : Window
    {
        private int MaxFloor = 1;
        private int CurrentFloor = 1;
        private bool CurrentDoorStatus = false;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            tbFloor.Text = tbFloor.Text + "0";
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            tbFloor.Text = tbFloor.Text + "1";
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            tbFloor.Text = tbFloor.Text + "2";
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            tbFloor.Text = tbFloor.Text + "3";
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            tbFloor.Text = tbFloor.Text + "4";
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            tbFloor.Text = tbFloor.Text + "5";
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            tbFloor.Text = tbFloor.Text + "6";
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            tbFloor.Text = tbFloor.Text + "7";
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            tbFloor.Text = tbFloor.Text + "8";
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            tbFloor.Text = tbFloor.Text + "9";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbFloor.Text = "1";
        }

        private void btnBackSpace_Click(object sender, RoutedEventArgs e)
        {
            if(tbFloor.Text != "")
                tbFloor.Text = tbFloor.Text.Remove(1, tbFloor.Text.Length - 1);
        }

        private void tbMaxFloor1_Click(object sender, RoutedEventArgs e)
        {
            MaxFloor = int.Parse(tbMaxFloor.Text);
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            int floor = int.Parse(tbFloor.Text);
            
            if (floor < 1 || floor > MaxFloor)
            {
                MessageBox.Show($"Никуда мы не поедем. Выберите этаж не менее 1 и не более {MaxFloor}");
            }
            else
            {


            }
        }
    }
}
