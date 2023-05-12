using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Linq;
using static Lab14_ISRPO.DateTimeChart;

namespace Lab14_ISRPO
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
        private void Run_Click(Object sender, RoutedEventArgs e)
        {
            DateTime? dtStart = Start.SelectedDate;
            DateTime? dtEnd = End.SelectedDate;

            if(dtStart == null || dtEnd == null)
            {
                MessageBox.Show("Установите обе даты");
                return;
            }
            if(dtStart >= dtEnd)
            {
                MessageBox.Show("Дата начала торговли должна быть меньше даты конца торговли");
                return;
            }

            string stStart = dtStart.Value.ToString("dd/MM/yyyy");
            string stEnd = dtEnd.Value.ToString("dd/MM/yyyy");


            Regex regex = new Regex("\\([A-Za-z0-9]+\\)", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(Valuta.SelectedItem.ToString());
            string buf = matches[0].Value.ToString();
            buf = buf.Replace("(", "");
            string valutaCode = buf.Replace(")","");
            string valutaName = Valuta.SelectedItem.ToString();

            string query = string.Concat("http://www.cbr.ru/scripts/XML_dynamic.asp?date_req1=", stStart, "&date_req2=", stEnd, "&VAL_NM_RQ=", valutaCode);
            XDocument xdoc = XDocument.Load(query);

            currencyChart.Clear();
            dgData.Items.Clear();
            currencyChart.ChartName = valutaName;

            foreach(XElement elem in xdoc.Element("ValCurs").Elements("Record"))
            {
                XAttribute date = elem.Attribute("Date");
                XElement value = elem.Element("Value");
                double val = double.Parse(value.Value.ToString());
                string strDate = date.Value.ToString();
                CultureInfo provider = CultureInfo.InvariantCulture;
                DateTime dt = DateTime.ParseExact(strDate, "dd.MM.yyyy", provider);

                currencyChart.AddItem(val, dt);
                dgData.Items.Add(new DataModel() { Value = val, DateTime = dt });
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            XDocument xdoc = XDocument.Load("http://www.cbr.ru/scripts/XML_daily.asp?date_req=06/03/2023");
            foreach (XElement element in xdoc.Element("ValCurs").Elements("Valute"))
            {
                XAttribute id = element.Attribute("ID");
                XElement name = element.Element("Name");
                XElement priceElement = element.Element("Value");

                Valuta.Items.Add(string.Concat(name.Value.ToString(), "(", id.Value.ToString(), ")"));
            }

            DataGridTextColumn c1 = new DataGridTextColumn();
            c1.Header = "Value";
            c1.Binding = new Binding("Value");
            c1.Width = 110;
            dgData.Columns.Add(c1);
            DataGridTextColumn c2 = new DataGridTextColumn();
            c2.Header = "Date";
            c2.Binding = new Binding("DateTime");
            c2.Width = 110;
            dgData.Columns.Add(c2);
        }

        private void RSS_Click(object sender, RoutedEventArgs e)
        {
            RSSReader rssReader = new RSSReader();
            rssReader.Show();
        }

        private void XML_Click(object sender, RoutedEventArgs e)
        {
            XMLParser xml = new XMLParser();
            xml.Show();
        }
    }
}
