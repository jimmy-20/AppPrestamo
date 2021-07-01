using PrestamosApp.Clases.Models;
using PrestamosApp.Clases.Poco;
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
        private DataTable dt;
        private bool flag;
        public PrestamoModel Prestamos { get; set; }
        public FrmPrestamos()
        {
            InitializeComponent();
        }

        private void FrmPrestamos_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add("Monto");
            dt.Columns.Add("Plazo");
            dt.Columns.Add("Periodos");
            dt.Columns.Add("Tasa");
            dgvPrestamos.DataSource = dt;

            if (Prestamos.FindAll() == null)
            {
                return;
            }

            foreach(Prestamo p in Prestamos.FindAll())
            {
                DataRow dr = dt.NewRow();

                dr["Monto"] = p.Monto;
                dr["Plazo"] = p.Plazo;
                dr["Periodos"] = p.Periodo;
                dr["Tasa"] = p.Tasa;

                dt.Rows.Add(dr);

            }

            dgvPrestamos.DataSource = dt;


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            flag = true;

            frmPago = new FrmCalendarioPago();
            frmPago.Prestamos = Prestamos;
            frmPago.Flag = flag;
            frmPago.Show();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            int row = dgvPrestamos.Rows.Count;

            if (row <= 0)
            {
                MessageBox.Show("Seleccione una fila por favor", "Mensaje de informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            flag = false;
            frmPago = new FrmCalendarioPago();
            frmPago.Prestamos = Prestamos;
            frmPago.Flag = flag;
            frmPago.btnCalcular.Enabled = false;
            frmPago.Show();
        }
    }
}
