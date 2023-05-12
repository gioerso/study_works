using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;
using System.Xml;

namespace Lab14_ISRPO
{
    /// <summary>
    /// Логика взаимодействия для RSSReader.xaml
    /// </summary>
    public partial class RSSReader : Window
    {
        public RSSReader()
        {
            InitializeComponent();
        }
        private void OnGetFeed(object sender, RoutedEventArgs e)
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(textUrl.Text))
                {
                    var formatter = new Rss20FeedFormatter();
                    formatter.ReadFrom(reader);
                    this.DataContext = formatter.Feed;
                    this.feedContent.DataContext = formatter.Feed.Items;
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message, "Syndication Reader");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
