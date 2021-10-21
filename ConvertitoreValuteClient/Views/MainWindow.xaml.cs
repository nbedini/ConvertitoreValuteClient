using ConvertitoreValuteClient.Model;
using ConvertitoreValuteClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace ConvertitoreValuteClient
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public double Importo { get; set; }
        private double _risultatoconversione;

        public double RisultatoConversione
        {
            get { return _risultatoconversione; }
            set 
            { 
                _risultatoconversione = value; 
                onPropertyChanged("RisultatoConversione"); 
            }
        }

        public ObservableCollection<Valuta> ListaValute { get; set; }
        private Valuta _tipovaluta1;

        public Valuta TipoValuta1
        {
            get { return _tipovaluta1; }
            set { _tipovaluta1 = value; onPropertyChanged("TipoValuta1"); }
        }
        private Valuta _tipovaluta2;

        public Valuta TipoValuta2
        {
            get { return _tipovaluta2; }
            set { _tipovaluta2 = value; onPropertyChanged("TipoValuta2"); }
        }
        private string _tassoconversione;

        public string TassoConversione
        {
            get { return _tassoconversione; }
            set { _tassoconversione = value; onPropertyChanged("TassoConversione"); }
        }

        Valute valute = new Valute();

        public MainWindow()
        {
            InitializeComponent();
            ListaValute = valute.GetAll();
            TassoConversione = "Tasso di scambio: ";
            this.DataContext = this;
        }

        private void Calcola_Click(object sender, RoutedEventArgs e)
        {
            RisultatoConversione = valute.Conversione(Importo, TipoValuta1.Sigla, TipoValuta2.Sigla);
            if (TassoConversione != null)
                TassoConversione = valute.TassoConversioneLabel(TipoValuta1.Sigla, (RisultatoConversione / Importo), TipoValuta2.Sigla);
            else
                TassoConversione = "Tasso di scambio: ";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void onPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ScambiaValute_Click(object sender, RoutedEventArgs e)
        {
            Valuta tipovaluta1 = TipoValuta1;
            Valuta tipovaluta2 = TipoValuta2;

            TipoValuta1 = tipovaluta2;
            TipoValuta2 = tipovaluta1;

            if (TassoConversione != null)
                TassoConversione = valute.TassoConversioneLabel(TipoValuta1.Sigla, (RisultatoConversione / Importo), TipoValuta2.Sigla);
            else
                TassoConversione = "Tasso di scambio: ";
        }
    }
}
