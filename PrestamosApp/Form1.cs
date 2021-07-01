using PrestamosApp.Clases.Models;
using PrestamosApp.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrestamosApp
{
    public partial class Form1 : Form
    {
        private PrestamoModel prestamos;
        private FrmPrestamos frmPrestamos;
        
        public Form1()
        {
            InitializeComponent();
            prestamos = new PrestamoModel();
        }

        private void prestacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrestamos = new FrmPrestamos();
            frmPrestamos.Prestamos = prestamos;
            frmPrestamos.MdiParent = this;
            frmPrestamos.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
