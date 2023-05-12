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
using System.Windows.Shapes;
using System.Xml;

namespace Lab14_ISRPO
{
    /// <summary>
    /// Логика взаимодействия для XMLParser.xaml
    /// </summary>
    public partial class XMLParser : Window
    {
        public XMLParser()
        {
            InitializeComponent();
        }

        private void loadXML_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\\Lab1\\Lab14_ISRPO\\xml.xml");

            foreach (XmlNode node in doc.DocumentElement)
            {
                string name = node.Attributes[0].Value;
                int age = int.Parse(node["age"].InnerText);
                listBox.Items.Add("Name: " + name + "\n" + "Age: " + age);
            }
        }

        private void editXML_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\\Lab1\\Lab14_ISRPO\\xml.xml");
            XmlElement xRoot = doc.DocumentElement;

            XmlElement personElem = doc.CreateElement("person");
            XmlAttribute nameAttr = doc.CreateAttribute("name");
            XmlElement ageElem = doc.CreateElement("age");

            XmlText nameText = doc.CreateTextNode(nameTextBox.Text.ToString());
            XmlText ageText = doc.CreateTextNode(ageTextBox.Text.ToString());

            nameAttr.AppendChild(nameText);
            ageElem.AppendChild(ageText);

            personElem.Attributes.Append(nameAttr);
            personElem.AppendChild(ageElem);
            xRoot?.AppendChild(personElem);

            doc.Save(@"D:\\Lab1\\Lab14_ISRPO\\xml.xml");
        }

        private void DeleteXML_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"D:\\Lab1\\Lab14_ISRPO\\xml.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNode firstNode = xRoot.FirstChild;
            xRoot.RemoveChild(firstNode);
            xDoc.Save(@"D:\\Lab1\\Lab14_ISRPO\\xml.xml");
        }
    }
}
