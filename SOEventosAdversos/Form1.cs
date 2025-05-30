﻿using System;
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
        CN_Registro objetoCN = new CN_Registro();
        private Boolean combosCargados;
        private DataTable dt;
        private DataSet ds;
        private Boolean Editar;
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
            CargarGrilla();
            valoresPorDefecto();
        }

        private void CargarGrilla()
        {
            CN_Registro objeto = new CN_Registro();
            dgvDatos.DataSource = objeto.MostrarReg();
            dgvDatos.Columns["OID"].Visible = false;
            dgvDatos.Columns["IDR"].Width = 40;
            dgvDatos.Columns["FECHA"].Width = 80;
            dgvDatos.Columns["ID"].Width = 100;

            dgvDatos.Columns["NOMBRE_PACIENTE"].Width = 140;
            dgvDatos.Columns["EPS"].Width = 80;
            dgvDatos.Columns["EDAD"].Width = 40;
            dgvDatos.Columns["DESCRIPCION"].Width = 140;

            dgvDatos.Columns["MED"].Width = 40;
            dgvDatos.Columns["ROL"].Width = 120;
            dgvDatos.Columns["REPORTADO_POR"].Width = 140;
            dgvDatos.Columns["SEDE"].Width = 120;

            dgvDatos.Columns["FECHA_REG"].Width = 100;

            cantidadReg();
        }

        private void CargarGrillaPM()
        {
            CN_Registro objeto = new CN_Registro();
            dgvPM.DataSource = objeto.MostrarRegPM(int.Parse(txtOidActual.Text));
        }

        private void CargarGrillaPMCorreos()
        {
            CN_Registro objeto = new CN_Registro();
            dgvPMCorreos.DataSource = objeto.MostrarRegPMCorreos(int.Parse(txtOidActual.Text));
            dgvPMCorreos.Columns["OID"].Visible = false;
            dgvPMCorreos.Columns["PMCORREO"].Visible = false;
            dgvPMCorreos.Columns["CECORREO"].Visible = false;
        }
        private void LimpiarCamposRegistroSuceso()
        {
                dtFecha.Value = DateTime.Now;
                txtIdPac.Text = string.Empty;
                txtNomPac.Text = string.Empty;
                txtEdad.Text = string.Empty;
                cbAseguradora.SelectedValue = 0;
                txtDescrip.Text = string.Empty;
                cbMedicamento.SelectedValue = 0;
                txtRelMed.Text = string.Empty;
                txtRelInv.Text = string.Empty;
                txtRelLot.Text = string.Empty;
                dpRelFec.Text = string.Empty;
                cbCargoRol.SelectedValue = 0;
                txtRepNom.Text = string.Empty;
                cbRegionalSede.SelectedValue = 0;

                txtIdActual.Text = string.Empty;
                txtPacActual.Text = string.Empty;
        }


        private void cantidadReg()
        {
            txtReg.Text = Convert.ToString(dgvDatos.Rows.Count);

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
            Cargar_Combos(cbCumplio, "sp_GENMENUME", 16);
            Cargar_Combos(cbVerificado, "sp_GENMENUME", 16);
            Cargar_Combos(cbRegionalSede, "sp_GENMENUME", 3);
            Cargar_Combos(cbTipoReporte, "sp_GENMENUME", 18);
            Cargar_Combos(cbMedicamento, "sp_GENMENUME", 16);
            Cargar_Combos(cbComponente, "sp_GENMENUME", 19);
            Cargar_Combos(cbCargoRol, "sp_GENMENUME", 8);
            Cargar_Combos(cbRolImplicado, "sp_GENMENUME", 11);
            Cargar_Combos(cbEstado, "sp_GENMENUME", 17);
            Cargar_Combos(cbAseguradora, "sp_GENMENUME", 23);
            Cargar_Combos(cbNotificar, "sp_GENMENUME", 27);
            Cargar_Combos(cbCausaRaiz, "sp_GENMENUME", 99);
            Cargar_Combos(cbAcciones, "sp_GENMENUME", 99);

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
            if (combosCargados)
            {
                //string opCombo = (cbComponente.SelectedValue.ToString());
                //txtQue.Text = opCombo;
                Cargar_Combos(cbCausaRaiz, "sp_GENMENUME", int.Parse((cbComponente.SelectedValue.ToString())));
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

        private void button1_Click(object sender, EventArgs e)
        {
            //VALIDAR CAMPOS
            if (txtIdPac.Text.Length < 1 || txtNomPac.Text.Length < 4 || txtDescrip.Text.Length < 20 || txtRepNom.Text.Length < 5 || txtEdad.Text.Length < 0)
            {
                MessageBox.Show("Datos inconsistentes. Revisar!");
            }
            else
            {
                //INSERTAR
                if (Editar == false)
                {

                    try
                    {
                        objetoCN.InsertarReg(dtFecha.Value, txtIdPac.Text, txtNomPac.Text, int.Parse(cbAseguradora.SelectedValue.ToString()),
                            int.Parse(txtEdad.Text), txtDescrip.Text, int.Parse(cbMedicamento.SelectedValue.ToString()), txtRelMed.Text, txtRelInv.Text,
                            txtRelLot.Text, dpRelFec.Value, int.Parse(cbCargoRol.SelectedValue.ToString()), txtRepNom.Text,
                            int.Parse(cbRegionalSede.SelectedValue.ToString()));

                        MessageBox.Show("Evento Registrado");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("no se pudo insertar los datos por: " + ex);
                    }
                }
                //EDITAR
                //if (Editar == true)
                //{

                //    try
                //    {
                //        objetoCN.EditarReg(dtFecha.Value, cbMunicipio.SelectedItem.ToString(), txtId.Text, txtReporta.Text, txtEvento.Text, oid);
                //        //MessageBox.Show("Editado correctamente");
                //        MostrarProdctos();
                //        limpiarForm();
                //        Editar = false;
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show("No se pudo editar los datos por: " + ex);
                //    }
                //}
            }
        }

        private void cbAseguradora_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbAseguradora_Leave(object sender, EventArgs e)
        {
            txtOut.AppendText(cbAseguradora.SelectedValue.ToString());
            txtOut.Refresh();
        }

        private void tabControl2_Selected(object sender, TabControlEventArgs e)
        {
            CargarGrilla();
        }

        private void btRegNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCamposRegistroSuceso();
            txtIdActual.Text = string.Empty;
            txtPacActual.Text = string.Empty;
            EAP.SelectTab("tabPage1");
            gbRegSucesos.Enabled = true;
            btRegSuceso.Enabled = true;
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            CN_Registro objeto = new CN_Registro();
            dgvDatos.DataSource = objeto.MostrarReg();
        }

        private void dgvDatos_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                dtFecha.Text = dgvDatos.CurrentRow.Cells["FECHA"].Value.ToString();
                txtIdPac.Text = dgvDatos.CurrentRow.Cells["ID"].Value.ToString();
                txtNomPac.Text = dgvDatos.CurrentRow.Cells["NOMBRE_PACIENTE"].Value.ToString();
                cbAseguradora.Text = dgvDatos.CurrentRow.Cells["EPS"].Value.ToString();
                txtEdad.Text = dgvDatos.CurrentRow.Cells["EDAD"].Value.ToString();
                txtDescrip.Text = dgvDatos.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                cbMedicamento.Text = dgvDatos.CurrentRow.Cells["MED"].Value.ToString();
                txtRelMed.Text = dgvDatos.CurrentRow.Cells["EARELMED"].Value.ToString();
                txtRelInv.Text = dgvDatos.CurrentRow.Cells["EARELINV"].Value.ToString();
                txtRelLot.Text = dgvDatos.CurrentRow.Cells["EARELLOT"].Value.ToString();
                dpRelFec.Text = dgvDatos.CurrentRow.Cells["EARELFEC"].Value.ToString();
                cbCargoRol.Text = dgvDatos.CurrentRow.Cells["ROL"].Value.ToString();
                txtRepNom.Text = dgvDatos.CurrentRow.Cells["REPORTADO_POR"].Value.ToString();
                cbRegionalSede.Text = dgvDatos.CurrentRow.Cells["SEDE"].Value.ToString();

                txtIdActual.Text = dgvDatos.CurrentRow.Cells["ID"].Value.ToString();
                txtPacActual.Text = dgvDatos.CurrentRow.Cells["NOMBRE_PACIENTE"].Value.ToString();
                txtOidActual.Text = dgvDatos.CurrentRow.Cells["OID"].Value.ToString();
                txtIdrActual.Text = dgvDatos.CurrentRow.Cells["IDR"].Value.ToString();
                txtDescripActual.Text = dgvDatos.CurrentRow.Cells["DESCRIPCION"].Value.ToString();

                CargarGrillaPM();
                CargarGrillaPMCorreos();

                btRegSuceso.Enabled = false;

                gbRegSucesos.Enabled = false;

            }
            else
                MessageBox.Show("Debe seleccionar una fila");
        }

        private void txtIdPac_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIdPac_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir sólo números y la tecla de retroceso (Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true; // Cancela la entrada
            }
            // Limitar la longitud a 2 caracteres
            if (txtIdPac.Text.Length >= 20 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Impide más caracteres si ya tiene 2 dígitos
            }
        }

        private void txtEdad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir sólo números y la tecla de retroceso (Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true; // Cancela la entrada
            }
            // Limitar la longitud a 2 caracteres
            if (txtEdad.Text.Length >= 2 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Impide más caracteres si ya tiene 2 dígitos
            }
        }

        private void txtNomPac_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras y la tecla de retroceso (Backspace)
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ' ')
            {
                e.Handled = true; // Cancela la entrada si no es letra
            }
        }

        private void txtRepNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras y la tecla de retroceso (Backspace)
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ' ')
            {
                e.Handled = true; // Cancela la entrada si no es letra
            }
        }

        private void btGnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtNomPac_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            //VALIDAR CAMPOS
            if (txtQue.Text.Length < 5 || txtQuien.Text.Length < 5 || txtComo.Text.Length < 5 || txtDonde.Text.Length < 5 || txtCuando.Text.Length < 0)
            {
                MessageBox.Show("Datos incompletos. Revisar!");
            }
            else
            {
                //INSERTAR
                if (Editar == false)
                {

                    try
                    {
                        objetoCN.InsertarRegPlan(int.Parse(txtOidActual.Text), txtQue.Text, txtQuien.Text, txtComo.Text, txtDonde.Text, txtCuando.Text, int.Parse(cbCumplio.SelectedValue.ToString()),
                            txtResponsable.Text, int.Parse(cbVerificado.SelectedValue.ToString()));
                        CargarGrillaPM();
                        MessageBox.Show("Evento Registrado");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("no se pudo insertar los datos por: " + ex);
                    }
                }
                //EDITAR
                //if (Editar == true)
                //{

                //    try
                //    {
                //        objetoCN.EditarReg(dtFecha.Value, cbMunicipio.SelectedItem.ToString(), txtId.Text, txtReporta.Text, txtEvento.Text, oid);
                //        //MessageBox.Show("Editado correctamente");
                //        MostrarProdctos();
                //        limpiarForm();
                //        Editar = false;
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show("No se pudo editar los datos por: " + ex);
                //    }
                //}
            }
        }

        private void btnAddNot_Click(object sender, EventArgs e)
        {
            //VALIDAR CAMPOS
            if (int.Parse(cbNotificar.SelectedValue.ToString())==0)
            {
                MessageBox.Show("Seleccionar destinatario!");
            }
            else
            {
                //INSERTAR
                if (Editar == false)
                {

                    try
                    {
                        objetoCN.InsertarRegCor(int.Parse(txtOidActual.Text),int.Parse(cbNotificar.SelectedValue.ToString()));
                        CargarGrillaPMCorreos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Es posible que el correo ya este adicionado, si no es así, consulte con el área de Sistemas! "); 
                        //+ex);
                    }
                }
                //EDITAR
                //if (Editar == true)
                //{

                //    try
                //    {
                //        objetoCN.EditarReg(dtFecha.Value, cbMunicipio.SelectedItem.ToString(), txtId.Text, txtReporta.Text, txtEvento.Text, oid);
                //        //MessageBox.Show("Editado correctamente");
                //        MostrarProdctos();
                //        limpiarForm();
                //        Editar = false;
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show("No se pudo editar los datos por: " + ex);
                //    }
                //}
            }
        }

        private void btnDelNot_Click(object sender, EventArgs e)
        {

            //Parámetros correo de origen
            string wHost = "smtp.gmail.com";
            int wPort = 587;
            string wEmail = "hsvp.facele.1@gmail.com";
            string wPassword = "tpmhjhnhovwoqdos";

            //Recorrer Grilla de correos
            string wAsunto = @"ID Suceso de Seguridad : "+ txtIdrActual.Text+"   Paciente : "+txtPacActual.Text;

            string wMensaje = @" <!DOCTYPE html>
                <html lang='en'>
                <head>
                <meta charset = 'UTF-8'>
                <meta name = 'viewport' content = 'width=device-width, initial-scale=1.0'>
                <style>
                    h3 {
                        padding: 0;
                        margin: 0;
                    }
                    table {
                        border: 2px solid black;
                        border - collapse: collapse;
                        width: 60 %;
                        margin: 20px auto;
                    }
                    th, td {
                        border: 1px solid #333; 
                        padding: 8px 12px;
                    }
                    th {
                        background - color: #f2f2f2;
                }
                </style>
                <title> Document </title>
                </head>
                                                <body>
                <body style = 'font-family: Arial; color: #333;'>
                <table>
                    <tbody>
                        <tr>
                            <td> ID Evento </td>
                            <td><h3> " + txtIdrActual.Text + " </h3></td>"+
                        "</tr>" +
                        "<tr>"+
                            "<td> ID Paciente </td>"+
                            "<td><h3> " + txtIdActual.Text + " </h3></td>"+
                        "</tr>" +
                        "<tr>" +
                            "<td> Nombre Paciente </td>"+
                            "<td><h3> " + txtPacActual.Text + " </td>"+
                        "</tr>" +
                        "<tr>" +
                             "<td> Descripción Evento </td>"+
                             "<td><h3> " + txtDescripActual.Text + " </td>"+
                        "</tr>" +
                     "</tbody>"+
                    "</table>" +
             "</body>"+
             "</html>";

            foreach (DataGridViewRow row in dgvPMCorreos.Rows)
            {
                // Omitir la fila nueva (en modo edición)
                if (row.IsNewRow) continue;
                var wCorreo = row.Cells["CECORREO"].Value.ToString();
                enviarCorreosNotificacion(wHost, wPort, wEmail, wPassword, wAsunto,wMensaje,wCorreo);
               // MessageBox.Show("Correo: " + wCorreo);
            }
        }
        private void enviarCorreosNotificacion(string ceHost, int cePort, string ceEmail, string cePassword, string asunto, string mensaje, string correo)
        {
            CN_Correos objetoCNCorreoS = new CN_Correos();
            objetoCNCorreoS.enviarCorreos(ceHost, cePort, ceEmail, cePassword, asunto, mensaje, correo);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //VALIDAR CAMPOS
            if (int.Parse(cbTipoReporte.SelectedValue.ToString())==0 || int.Parse(cbComponente.SelectedValue.ToString()) == 0 || int.Parse(cbCausaRaiz.SelectedValue.ToString()) == 0 || int.Parse(cbRolImplicado.SelectedValue.ToString()) == 0 || int.Parse(cbEstado.SelectedValue.ToString()) == 0)
            {
                MessageBox.Show("Datos incompletos. Revisar!");
            }
            else
            {
                //UPDATE
                if (Editar == false)
                {

                    try
                    {
                        objetoCN.UpdateRegAnalisis(int.Parse(txtOidActual.Text), int.Parse(cbTipoReporte.SelectedValue.ToString()),
                            int.Parse(cbComponente.SelectedValue.ToString()),
                            int.Parse(cbCausaRaiz.SelectedValue.ToString()),
                            int.Parse(cbRolImplicado.SelectedValue.ToString()),
                            int.Parse(cbEstado.SelectedValue.ToString()));

                        MessageBox.Show("Analisis Registrado");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Datos NO Registrados!! : " + ex);
                    }
                }
                //EDITAR
                //if (Editar == true)
                //{

                //    try
                //    {
                //        objetoCN.EditarReg(dtFecha.Value, cbMunicipio.SelectedItem.ToString(), txtId.Text, txtReporta.Text, txtEvento.Text, oid);
                //        //MessageBox.Show("Editado correctamente");
                //        MostrarProdctos();
                //        limpiarForm();
                //        Editar = false;
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show("No se pudo editar los datos por: " + ex);
                //    }
                //}
            }
        }

        private void btnRegProtocolo_Click(object sender, EventArgs e)
        {
            //VALIDAR CAMPOS
            if (txtPLPaciente.Text.Length < 5)
            {
                MessageBox.Show("Datos incompletos. Revisar!");
            }
            else
            {
                //UPDATE
                if (Editar == false)
                {

                    try
                    {
                        objetoCN.UpdateRegProtocolo(int.Parse(txtOidActual.Text), 
                            txtPLPaciente.Text,
                            txtPLTarea.Text,
                            txtPLIndividuo.Text,
                            txtPLEquipo.Text,
                            txtPLAmbiente.Text,
                            txtPLOrganizacion.Text,
                            txtPLContexto.Text)
                            ;

                        MessageBox.Show("Analisis Registrado");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Datos NO Registrados!! : " + ex);
                    }
                }
                //EDITAR
                //if (Editar == true)
                //{

                //    try
                //    {
                //        objetoCN.EditarReg(dtFecha.Value, cbMunicipio.SelectedItem.ToString(), txtId.Text, txtReporta.Text, txtEvento.Text, oid);
                //        //MessageBox.Show("Editado correctamente");
                //        MostrarProdctos();
                //        limpiarForm();
                //        Editar = false;
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show("No se pudo editar los datos por: " + ex);
                //    }
                //}
            }
        }
    }
}