using PrestamosApp.Clases.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosApp.Clases.Pago
{
    public interface IPago
    {
        PagoP[] calculosAnual();
    }
}
