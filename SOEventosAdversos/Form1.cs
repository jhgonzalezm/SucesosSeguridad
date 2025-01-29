using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace SO_Paz_y_Salvo
{
    public partial class Form1 : Form
    {
        private Boolean combosCargados;
        private DataTable dt;
        private DataSet ds;
        public Form1()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarCombos();
            valoresPorDefecto();
        }

        private void valoresPorDefecto()
        {
            cbCumplio.SelectedValue = 0;
            cbVerificado.SelectedValue = 0;
            cbRegionalSede.SelectedValue = 0;
            cbTipoReporte.SelectedValue = 0;
            cbMedicamento.SelectedValue = 0;
            cbComponente.SelectedValue = 0;
            cbCargoRol.SelectedValue = 0;
            cbRolImplicado.SelectedValue = 0;
            cbEstado.SelectedValue = 0;
            gbMedicamentos.Enabled = false;
        }
        private void CargarCombos()
        {
            combosCargados = false;
            Cargar_Combos(cbCumplio, "sp_02CargarEnumeradores", 16);
            Cargar_Combos(cbVerificado, "sp_02CargarEnumeradores", 16);
            Cargar_Combos(cbRegionalSede, "sp_02CargarEnumeradores", 3);
            Cargar_Combos(cbTipoReporte, "sp_02CargarEnumeradores", 18);
            Cargar_Combos(cbMedicamento, "sp_02CargarEnumeradores", 16);
            Cargar_Combos(cbComponente, "sp_02CargarEnumeradores", 19);
            Cargar_Combos(cbCargoRol, "sp_02CargarEnumeradores", 8);
            Cargar_Combos(cbRolImplicado, "sp_02CargarEnumeradores", 11);
            Cargar_Combos(cbEstado, "sp_02CargarEnumeradores", 17);
            //Cargar_Combos(cbEstado, "sp_02CargarEnumeradores", 12);
            //Cargar_Combos(cbEficaciaTrat, "sp_02CargarEnumeradores", 13);
            //Cargar_Combos(cbCausaPpalCalidad, "sp_02CargarEnumeradores", 14);
            combosCargados = true;


        }
        // Cargar Combos (nombre combo, nombre del store procedure, criterio de seleccion)
        public void Cargar_Combos(ComboBox ComboBox, string sp_sql, int criterio)
        {
            try
            {
                ds = NEnumeradores.Consultar(sp_sql, criterio);
                //MessageBox(ds.Tables[0].Rows.Count.ToString);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ComboBox.DataSource = ds.Tables[0].DefaultView;
                    ComboBox.ValueMember = ds.Tables[0].Columns[0].Caption;
                    ComboBox.DisplayMember = ds.Tables[0].Columns[1].Caption;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No es posible cargar combo", "Aplicativo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("There was an error: {0}", ex.Message);
            }
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void cbMedicamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            //(cbMedicamento.SelectedItem.ToString());
            //if (cbMedicamento.SelectedItem.ToString()=="SI")
            //    gbMedicamentos.Enabled = true;
            //else
            //    gbMedicamentos.Enabled = false;

        }

        private void cbComponente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combosCargados) {
                //string opCombo = (cbComponente.SelectedValue.ToString());
                //txtQue.Text = opCombo;
                Cargar_Combos(cbCausaRaiz, "sp_02CargarEnumeradores", int.Parse((cbComponente.SelectedValue.ToString())));
            }


        }

        private void cbMedicamento_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (combosCargados)
            {
                if (cbMedicamento.SelectedValue.ToString() == "1")
                    gbMedicamentos.Enabled = true;
                else
                    gbMedicamentos.Enabled = false;
            }

        }
    }
}