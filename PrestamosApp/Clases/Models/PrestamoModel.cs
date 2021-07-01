using PrestamosApp.Clases.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosApp.Clases.Models
{
    public class PrestamoModel
    {
        private Prestamo[] prestamos;

        public PrestamoModel()
        {

        }

        public void Add(Prestamo p)
        {
            if (prestamos == null)
            {
                prestamos = new Prestamo[1];
                prestamos[0] = p;
                return;
            }

            Prestamo[] temp = new Prestamo[prestamos.Length + 1];
            Array.Copy(prestamos,temp,prestamos.Length);

            prestamos = temp;
        }

        public Prestamo[] FindAll()
        {
            return prestamos;
        }

    }
}
