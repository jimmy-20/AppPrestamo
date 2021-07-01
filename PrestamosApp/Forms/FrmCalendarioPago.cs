using PrestamosApp.Clases.Enums;
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
    public partial class FrmCalendarioPago : Form
    {
        public PrestamoModel Prestamos { get; set; }
        public bool Flag { get; set; }
        private DataTable dt;
        public FrmCalendarioPago()
        {
            InitializeComponent();
            dt = new DataTable();
            
        }

        private void FrmCalendarioPago_Load(object sender, EventArgs e)
        {
            cmbPeriodo.Items.AddRange(Enum.GetValues(typeof(Periodo)).Cast<object>().ToArray());
            cmbPeriodo.SelectedIndex = 0;

            dt.Columns.Add("Año");
            dt.Columns.Add("Cuota");
            dt.Columns.Add("Abono");
            dt.Columns.Add("Interes");
            dt.Columns.Add("Saldo");

            dgvPago.DataSource = dt;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            decimal monto = Convert.ToDecimal(txtMonto.Text);
            int plazo = Convert.ToInt32(nudPlazo.Value);

            int index = cmbPeriodo.SelectedIndex;
            Periodo periodo = Enum.GetValues(typeof(Periodo)).Cast<Periodo>().ToArray()[index];
            decimal tasa = Convert.ToDecimal(txtTasa.Text) / 100m;

            decimal abonoV = monto / plazo;

            decimal interesP = 0;
            decimal saldoP = 0;

            for(int i = 0; i<=plazo; i++)
            {
                int plazoV = i;
                decimal cuotaV = 0;
                decimal interesV = saldoP * tasa;
                
                decimal saldoV = saldoP - abonoV;

                DataRow dr = dt.NewRow();
                
                if (i == 0)
                {
                    dr["Año"] = plazoV;
                    dr["Saldo"] = monto;
                    saldoP = monto;
                    dt.Rows.Add(dr);
                    continue;
                }

                saldoP = saldoV;



                dr["Año"] = plazoV;
                dr["Cuota"] = cuotaV;
                dr["Abono"] = abonoV;
                dr["Interes"] = interesV;
                dr["Saldo"] = saldoV;

                dt.Rows.Add(dr);
            }

            MessageBox.Show("Se añadio Correctamente los datos", "Mensaje de informacion", 
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Flag == false)
            {
                this.Close();
                return;
            }

            if (ValidateText() == false)
            {
                MessageBox.Show("Rellene todos los datos del prestamo", "Mensaje de Información",
                                 MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            if (nudPlazo.Value <= 0)
            {
                MessageBox.Show("Ingrese un plazo diferente de 0", "Mensaje de error", 
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal monto = Convert.ToDecimal(txtMonto.Text);
            int plazo = Convert.ToInt32(nudPlazo.Value);

            int index = cmbPeriodo.SelectedIndex;
            Periodo periodo = Enum.GetValues(typeof(Periodo)).Cast<Periodo>().ToArray()[index];
            decimal tasa = Convert.ToDecimal(txtTasa.Text);

            Prestamo p = new Prestamo()
            {
                Monto = monto,
                Plazo = plazo,
                Periodo = periodo,
                Tasa = tasa
            };

            Prestamos.Add(p);

            this.Close();
        }

        public bool ValidateText()
        {
            if ( txtMonto.Text.Equals("") || txtTasa.Text.Equals("") )
            {
                return false;
            }

            return true;
        }
    }
}
