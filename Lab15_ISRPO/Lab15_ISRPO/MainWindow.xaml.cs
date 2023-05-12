using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Window = System.Windows.Window;
using Word = Microsoft.Office.Interop.Word;

namespace Lab15_ISRPO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Shop> Shop { get; set; }
        int summary;
        public MainWindow()
        {
            InitializeComponent();
            Shop = new Shop().Initialize();
            // связываем коллекцию Shop и таблицу dgData
            dgData.ItemsSource = Shop;
            for (int i = 2; i < Shop.Count + 2; i++)
            {
                summary += int.Parse(Shop[i - 2].Sum.ToString());
            }
            SummaryTextBlock.Text = "Итого: " + summary;
        }
        private void Excel_Click(object sender, RoutedEventArgs e)
        {
            ExcelParser exl = new ExcelParser();
            exl.Show();
        }
            private void Button_Click(object sender, RoutedEventArgs e)
        {
            // создаем приложение ворд
            Word.Application winword = new Word.Application();
            //winword.Visible = true;

            // добавляем документ
            Word.Document document = winword.Documents.Add();

            // добавляем параграф с номером накладной и выбранной датой
            Word.Paragraph invoicePar = document.Content.Paragraphs.Add();
            DateTime? selectDate = invoiceDate.SelectedDate;
            if (selectDate != null)
                invoicePar.Range.Text = string.Concat("Расходная накладная № ", invoiceNumber.Text, " от ", selectDate.Value.ToString("dd.MM.yyyy"));
            else
                invoicePar.Range.Text = string.Concat("Расходная накладная № ", invoiceNumber.Text);
            invoicePar.Range.Font.Name = "Times new roman";
            invoicePar.Range.Font.Size = 14;
            invoicePar.Range.InsertParagraphAfter();

            // добавляем параграф с поставщиком
            Word.Paragraph providerPar = document.Content.Paragraphs.Add();
            providerPar.Range.Text = string.Concat("Поставщик: ", PurchasertxtBox.Text);
            providerPar.Range.Font.Name = "Times new roman";
            providerPar.Range.Font.Size = 14;
            providerPar.Range.InsertParagraphAfter();

            // добавляем параграф с потребителем
            Word.Paragraph customerPar = document.Content.Paragraphs.Add();
            customerPar.Range.Text = "Покупатель: " + ProvidertxtBox.Text;
            customerPar.Range.Font.Name = "Times new roman";
            customerPar.Range.Font.Size = 14;
            customerPar.Range.InsertParagraphAfter();

            // формируем таблицу
            // количество колонок - 5
            // количество строк - nRows
            int nRows = dgData.Items.Count;
            Word.Table myTable = document.Tables.Add(customerPar.Range, nRows, 5);
            myTable.Borders.Enable = 1;
            // устанавливаем названия колонок
            var headerRow = myTable.Rows[1].Cells;
            headerRow[1].Range.Text = "Id";
            headerRow[2].Range.Text = "Продукт";
            headerRow[3].Range.Text = "Количество";
            headerRow[4].Range.Text = "Цена";
            headerRow[5].Range.Text = "Сумма";
            // добавляем данные из таблицы в ворд
            for (int i = 2; i < Shop.Count + 2; i++)
            {
                var dataRow = myTable.Rows[i].Cells;
                dataRow[1].Range.Text = Shop[i - 2].Id.ToString();
                dataRow[2].Range.Text = Shop[i - 2].Product;
                dataRow[3].Range.Text = Shop[i - 2].Count.ToString();
                dataRow[4].Range.Text = Shop[i - 2].Price.ToString();
                dataRow[5].Range.Text = Shop[i - 2].Sum.ToString();
            }
            // добавляем параграф с потребителем
            Word.Paragraph sumPar = document.Content.Paragraphs.Add();
            sumPar.Range.Text = "Итого: " + summary;
            sumPar.Range.Font.Name = "Times new roman";
            sumPar.Range.Font.Size = 14;
            sumPar.Range.InsertParagraphAfter();

            // сохраняем

            object filename = @"D:\Lab1\Lab15_ISRPO\order.docx";
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".docx";
            dlg.Filter = "MS Word files (*.docx)|*.docx|All files (*.*)|*.*";
            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();
            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                filename = dlg.FileName;
            }
            else
            {
                MessageBox.Show("Ошибка!", @"Вы закрыли диалог с выбором пути файла. Файл сохранен по стандартному пути - D:\Lab1\Lab15_ISRPO\order.docx", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            document.SaveAs(filename);
            document.Close();
            winword.Quit();
        }
    }
}
