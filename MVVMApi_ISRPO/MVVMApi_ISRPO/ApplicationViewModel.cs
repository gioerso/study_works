using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMApi_ISRPO
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        public Contact selectedContact;
        public ObservableCollection<Contact> Contacts { get; set; }
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand(obj =>
                {
                    MainWindow mw = new MainWindow();

                    Contact contact = MainWindow.con;
                    Contacts.Insert(0, contact);
                    SelectedContact = contact;
                }));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ?? (removeCommand = new RelayCommand(obj =>
                {
                    Contact phone = obj as Contact;
                    if (phone != null)
                    {
                        Contacts.Remove(phone);

                        var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5278/Contacts");

                        string json;
                        httpWebRequest.ContentType = "text/json";
                        httpWebRequest.Method = "DELETE";
    
                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    }
                },
                (obj) => Contacts.Count > 0));
            }
        }

        public Contact SelectedContact
        {
            get { return selectedContact; }
            set
            {
                selectedContact = value;
                OnPropertyChanged("SelectedContact");
            }
        }

        public ApplicationViewModel()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5278/Contacts");

            string json;
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "GET";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                //ответ от сервера
                var result = streamReader.ReadToEnd();
                json = result.ToString();
                json = json.Replace("[", "");
                json = json.Replace("]", "");
                json = json.Replace(@"\", "");
                json = json.Replace(@"},", "} ");
                Contacts = new ObservableCollection<Contact>();
            }
            string[] json1;
            json1 = json.Split(' ');
            foreach (string jsonParsed in json1)
            {
                Contacts.Add(JsonConvert.DeserializeObject<Contact>(jsonParsed));
            };
                //new Contact{Name="Альберт", Surname = "Макаров", Phone = "88005553535"},
                //new Contact{Name="Мария", Surname = "Кузнецова", Phone = "88005553535"},
                //new Contact{Name="Татьяна", Surname = "Смирнова", Phone = "88005553535"},
                //new Contact{Name="Александр", Surname = "Тихонов", Phone = "88005553535"}
        }

        public event  PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
