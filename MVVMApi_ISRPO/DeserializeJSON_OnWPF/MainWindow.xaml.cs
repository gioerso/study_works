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

namespace DeserializeJSON_OnWPF
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string query = $"INSERT INTO contacts(Name,Surname,Phone) values ('{surnameTextBox}', '{contact.Surname}', '{contact.Phone}');";

            using (var client = new System.Net.WebClient())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(query);
                client.UploadData("", "PUT", bytes);
            }
        }
    }
}
