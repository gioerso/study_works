using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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

namespace Lab14_ISRPO
{
    /// <summary>
    /// Логика взаимодействия для DateTimeChart.xaml
    /// </summary>
    public partial class DateTimeChart : UserControl
    {
        public ChartValues<DataModel> ChartData { get; set; }

        public void AddItem(double value, DateTime time)
        {
            ChartData.Add(new DataModel()
            {
                DateTime = time,
                Value = value
            });
        }

        public void Clear()
        {
            ChartData.Clear();
        }

        public DateTimeChart()
        {
            InitializeComponent();

            ChartData = new ChartValues<DataModel>();
            var dayConfig = Mappers.Xy<DataModel>()
                .X(dayModel => dayModel.DateTime.Ticks)
                .Y(dayModel => dayModel.Value);

            Series = new SeriesCollection(dayConfig)
            {
                new LineSeries
                {
                    Title = ChartName,
                    Values = ChartData
                },
            };

            Formatter = value => new DateTime((long)value).ToString("yyyy-MM-dd HH:mm:ss");
            DataContext = this;
        }

        public string ChartName { get; set; }
        public Func<double, string> Formatter { get; set; }
        public SeriesCollection Series { get; set; }

        public class DataModel
        {
            public DateTime DateTime { get; set; }
            public double Value { get; set; }
        }

    }
}
