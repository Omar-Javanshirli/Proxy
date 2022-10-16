using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Command;
using WpfApp2.Repository;

namespace WpfApp2.ViewModel
{
    public class AppViewModel:BaseViewModel
    {
        public RelayCommand TextChangeCommand { get; set; }
        private string data;

        public string Data
        {
            get { return data; }
            set { data = value; OnPropertyChanged(); }
        }

        private List<string> getData;

        public List<string> GetData
        {
            get { return getData; }
            set { getData = value; OnPropertyChanged(); }
        }

        public AppViewModel()
        {
            TextChangeCommand = new RelayCommand((e) =>
              {
                  ICache cache = new CasheProxy();
                  GetData =cache.GetValue(Data);
              });
        }
    }
}
