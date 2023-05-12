using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMApi_ISRPO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Contact con;
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ApplicationViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string query = $"INSERT INTO contacts(Name,Surname,Phone) values ('{nameTextBox.Text}','{surnameTextBox.Text}','{phoneTextBox.Text}');";
            con = new Contact { Name = nameTextBox.Text, Surname = surnameTextBox.Text, Phone = phoneTextBox.Text };

            var url = "http://localhost:5278/Contacts";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "PUT";

            httpRequest.ContentType = "application/json";

            var data = JsonConvert.SerializeObject(con);
            
            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }

            //using (var client = new System.Net.WebClient())
            //{
            //    byte[] data = Encoding.UTF8.GetBytes(query);
            //    client.UploadData("http://localhost:5278/Contacts", "PUT", data);
            //}

            //Contact contact = new Contact{ Name = nameTextBox.Text, Surname = surnameTextBox.Text, Phone = phoneTextBox.Text };
            //ApplicationViewModel appVMM = new ApplicationViewModel();


            //appVMM.AddCommand = new RelayCommand(obj =>
            //{
            //    appVMM.Contacts.Insert(0, con);
            //    appVMM.SelectedContact = con;
            //});
        }
    }
}
