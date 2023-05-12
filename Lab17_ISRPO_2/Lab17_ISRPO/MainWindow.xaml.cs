using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace Lab17_ISRPO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool done = true;
        private UdpClient client;
        private IPAddress groupAdress;
        private int localPort;
        private int remotePort;
        private int ttl;
        private bool exit = false;

        private IPEndPoint remoteEP;
        private string message;

        private readonly SynchronizationContext _syncContext;

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                NameValueCollection config = ConfigurationSettings.AppSettings;
                groupAdress = IPAddress.Parse(config["GroupAddress"]);
                localPort = int.Parse("7777");
                remotePort = int.Parse("8080");
                ttl = int.Parse(config["TTL"]);
            }
            catch
            {
                MessageBox.Show(this, "Error config file!", "Error multicast chart", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            _syncContext = SynchronizationContext.Current;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Name = textName.Text;
            textName.IsReadOnly = true;

            try
            {
                client = new UdpClient(localPort);
                client.JoinMulticastGroup(groupAdress, ttl);

                remoteEP = new IPEndPoint(groupAdress, remotePort);

                Thread receiver = new Thread(new ThreadStart(Listener));
                receiver.IsBackground = true;
                receiver.Start();

                byte[] data = Encoding.UTF8.GetBytes(Name + "has joined the chat");
                client.Send(data, data.Length, remoteEP);

                btnStart.IsEnabled = false;
                btnStop.IsEnabled = true;
                btnSend.IsEnabled = true;
            }
            catch (SocketException ex)
            {
                MessageBox.Show(this, ex.Message, "Error multicastChart", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Listener()
        {
            done = false;

            try
            {
                while (true)
                {
                    IPEndPoint ep = null;
                    byte[] buffer = client.Receive(ref ep);

                    message = Encoding.UTF8.GetString(buffer);

                    _syncContext.Post(o => DisplayReceivedMessage(), null);

                    if (exit == true) break;
                }
            }
            catch (Exception ex)
            {
                if (done) return;
                else
                {
                    MessageBox.Show(this, ex.Message, "Error multicastChart", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void DisplayReceivedMessage()
        {
            string time = DateTime.Now.ToString("t");
            textMessages.Text = time + " " + message + "\r\n" + textMessages.Text;
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(Name + ": " + textMessage.Text);
                client.Send(data, data.Length, remoteEP);
                textMessage.Clear();
                textMessage.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error multicastChart", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            StopListener();
        }
        private void StopListener()
        {
            byte[] data = Encoding.UTF8.GetBytes(Name + " has left the chat");
            client.Send(data, data.Length, remoteEP);

            client.DropMulticastGroup(groupAdress);
            client.Close();

            done = true;
            exit = true;

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
            btnSend.IsEnabled = false;
        }
        private void Window_Clossing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!done)
                StopListener();
        }
    }
}
