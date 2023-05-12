using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15_ISRPO
{
    public class Shop : INotifyPropertyChanged
    {
        int id;
        string product;
        int count;
        int price;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Product
        {
            get { return product; }
            set
            {
                product = value;
                OnPropertyChanged("Product");
            }
        }
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }
        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }
        public int Sum
        {
            get { return Count * Price; }
            set
            {
                Sum = value;
                OnPropertyChanged("Sum");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public ObservableCollection<Shop> Initialize()
        {
            return new ObservableCollection<Shop>()
            {
              new Shop
              {
                Id=1,
                Product="Арбузы",
                Count=10,
                Price=16,
              },
              new Shop
              {
                Id=2,
                Product="Тыква",
                Count=7,
                Price=40,
              },
              new Shop
              {
                Id=3,
                Product="Яблоки",
                Count=20,
                Price=160,
              },
              new Shop
              {
                Id=4,
                Product="Лимоны",
                Count=35,
                Price=40,
              },

           };

        }
    }
}
