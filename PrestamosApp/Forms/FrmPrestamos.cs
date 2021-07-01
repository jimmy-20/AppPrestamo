using PrestamosApp.Clases.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrestamosApp.Forms
{
    public partial class FrmPrestamos : Form
    {
        private FrmCalendarioPago frmPago;
        public PrestamoModel Prestamos { get; set; }
        public FrmPrestamos()
        {
            InitializeComponent();
        }

        private void FrmPrestamos_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmPago = new FrmCalendarioPago();
            frmPago.Prestamos = Prestamos;
            frmPago.Show();
        }
    }
}
