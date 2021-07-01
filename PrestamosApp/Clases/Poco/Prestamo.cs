using PrestamosApp.Clases.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosApp.Clases.Poco
{
    public class Prestamo
    {
        public decimal Monto { get; set; }
        public int Plazo { get; set; }
        public Periodo Periodo { get; set; }
        public decimal Tasa { get; set; }
    }
}
