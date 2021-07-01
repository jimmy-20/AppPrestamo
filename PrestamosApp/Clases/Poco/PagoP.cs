using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosApp.Clases.Poco
{
    public class PagoP
    {
        public int No { get; set; }
        public decimal Cuota { get; set; }
        public decimal Abono { get; set; }
        public decimal Interes { get; set; }
        public decimal Saldo { get; set; }
    }
}
