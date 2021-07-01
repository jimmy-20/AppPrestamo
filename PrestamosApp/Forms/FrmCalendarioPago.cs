using PrestamosApp.Clases.Enums;
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
    public partial class FrmCalendarioPago : Form
    {
        public PrestamoModel Prestamos { get; set; }
        public FrmCalendarioPago()
        {
            InitializeComponent();
        }

        private void FrmCalendarioPago_Load(object sender, EventArgs e)
        {
            cmbPeriodo.Items.AddRange(Enum.GetValues(typeof(Periodo)).Cast<object>().ToArray());
            cmbPeriodo.SelectedIndex = 0;
        }
    }
}
