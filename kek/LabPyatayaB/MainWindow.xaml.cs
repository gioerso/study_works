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

namespace LabPyatayaB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public class Lift
    {
        public int floor { get; set; } = 1;
        bool OpenDoorStatus { get; set; } = true;
        public int humancount { get; set; } = 0;
        public bool Up()
        {
            if (OpenDoorStatus == false)
            {
                floor = floor + 1;
                return true;
            }
            else return false;
        }

        public bool Down()
        {
            if (OpenDoorStatus == false)
            {
                floor = floor - 1;
                return true;
            }
            else return false;
        }
        public void OpenCloseDoors(int d)
        {
            if (d==0)
            {
                OpenDoorStatus = false;
            }
            else OpenDoorStatus = true;
        }

    }
    public partial class MainWindow : Window
    {
        int floors;
        Lift LiftMach = new Lift();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterFloorButton_Click(object sender, RoutedEventArgs e)
        {
            floors =  Int32.Parse(FloorNumberTextBox.Text);
            FloorNumberTextBox.IsEnabled = false;
            EnterFloorButton.IsEnabled = false;
            UpButton.IsEnabled = true;
            DownButton.IsEnabled = true;
            OpenButton.IsEnabled = true;
            CloseButton.IsEnabled = true;
            ResetButton.IsEnabled = true;
            SimulationLabel.Content = "Этаж - 1\nДвери - Открыты \nКоличество людей внутри - 0";
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            if (LiftMach.floor < floors)
            {
                bool t = LiftMach.Up();
                if (t == false)
                {
                    SimulationLabel.Content = "ДЛЯ ДВИЖЕНИЯ ЗАКРОЙТЕ ДВЕРИ!!!!\nЭтаж - " + LiftMach.floor + "\nДвери - Открыты \nКоличество людей внутри - " + LiftMach.humancount;
                }
                else SimulationLabel.Content = "Этаж - " + LiftMach.floor + "\nДвери - Закрыты \nКоличество людей внутри - " + LiftMach.humancount;
            }
            else SimulationLabel.Content = "ЛИФТ НЕ МОЖЕТ ДВИГАТЬСЯ ВЫШЕ ПОСЛЕДНЕГО ЭТАЖА!!!!\nЭтаж - " + LiftMach.floor + "\nДвери - Открыты \nКоличество людей внутри - " + LiftMach.humancount;
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            if (LiftMach.floor > 1)
            {
                bool t = LiftMach.Down();
                if (t == false)
                {
                    SimulationLabel.Content = "ДЛЯ ДВИЖЕНИЯ ЗАКРОЙТЕ ДВЕРИ!!!!\nЭтаж - " + LiftMach.floor + "\nДвери - Открыты \nКоличество людей внутри - " + LiftMach.humancount;
                }
                else SimulationLabel.Content = "Этаж - " + LiftMach.floor + "\nДвери - Закрыты \nКоличество людей внутри - " + LiftMach.humancount;
            }
            else SimulationLabel.Content = "ЛИФТ НЕ МОЖЕТ ДВИГАТЬСЯ НИЖЕ ПЕРВОГО ЭТАЖА!!!!\nЭтаж - " + LiftMach.floor + "\nДвери - Открыты \nКоличество людей внутри - " + LiftMach.humancount;
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            LiftMach.OpenCloseDoors(1);
            Random a = new Random();
            int d = a.Next(-1,2);
            if (d == 1)
                if  (LiftMach.humancount!=12)
                    LiftMach.humancount = LiftMach.humancount + 1;
            else
                    if (LiftMach.humancount != 0)
                        LiftMach.humancount = LiftMach.humancount - 1;
            SimulationLabel.Content = "Этаж - " + LiftMach.floor + "\nДвери -  Открыты\nКоличество людей внутри - " + LiftMach.humancount;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            LiftMach.OpenCloseDoors(0);
            SimulationLabel.Content = "Этаж - " + LiftMach.floor + "\nДвери -  Закрыты\nКоличество людей внутри - " + LiftMach.humancount;
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            FloorNumberTextBox.IsEnabled = true;
            EnterFloorButton.IsEnabled = true;
            UpButton.IsEnabled = false;
            DownButton.IsEnabled = false;
            OpenButton.IsEnabled = false;
            CloseButton.IsEnabled = false;
            ResetButton.IsEnabled = false;
        }
    }
}
