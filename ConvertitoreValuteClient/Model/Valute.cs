using ConvertitoreValuteClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertitoreValuteClient.Model
{
    class Valute
    {
        ServiceClient service = new ServiceClient();
        public double TassoConversione { get; set; }
        private ObservableCollection<Valuta> _valute;

        public ObservableCollection<Valuta> ListaValute
        {
            get 
            { 
                return _valute; 
            }
            set 
            { 
                _valute = value; 
            }
        }

        public Valute()
        {
            ListaValute = new ObservableCollection<Valuta>(service.GetValute());
        }

        public ObservableCollection<Valuta> GetAll()
        {
            return ListaValute;
        }

        public double Conversione(double importo,string da, string a)
        {
            return service.Converti(importo, da, a);
        }

        public string TassoConversioneLabel(string da,double tasso, string a)
        {
            return $"Tasso di scambio: 1 {da} = {tasso} {a}";
        }
    }
}
