using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Media.TextFormatting;
using WpfApp6.Command;
using WpfApp6.Model;
using static WpfApp6.AdapterPattern;

namespace WpfApp6.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        private Person person;

        public Person Person
        {
            get { return person; }
            set { person = value; OnPropertyChanged(); }
        }
        public RelayCommand  JsonCommand { get; set; }
        public RelayCommand XmlCommand { get; set; }
      
      
        public MainViewModel()
        {
            Person = new Person();
           

            JsonCommand = new RelayCommand((e) =>
            {
                IAdapter adapter;
                Json json=new Json();
                adapter = new JsonAdapter(json);
                adapter.Write(Person);
            });

            XmlCommand = new RelayCommand((e) =>
            {
                IAdapter adapter;
                Xml xml = new Xml();
                adapter= new XmlAdapter(xml);
                adapter.Write(Person);

            });
        }
    }
    
}
