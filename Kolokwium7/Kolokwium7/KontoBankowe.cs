using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium7
{
    public class KontoBankowe
    {
        public string NumerKonta {  get; set; }
        public decimal Saldo {  get; set; }
        public List<Transakcja> HistoriaTransakcji { get; set; }

        public void NowaTransakcja(Transakcja t) 
        {
            HistoriaTransakcji.Add(t);
            Saldo += t.Kwota;
        }
    }
}
