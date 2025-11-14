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
        CN_Registro objetoCN = new CN_Registro();
        private Boolean combosCargados, comboSecundarioCargado;
        private DataTable dt;
        private DataSet ds;
        private Boolean Editar;
        private Boolean selEvento = false;
        int valCbCauzaRaiz;
       
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
            //Datos temporales para prueba
            txtId.Text = "52915469";
            txtPassword.Text = "52915469*";

            CargarCombos();
            CargarGrilla(0);
            valoresPorDefecto();
            tabsHabilitados(3);
        }

        private void tabsHabilitados(int perfil)
        {
            EAP.TabPages.Remove(tabGrilla);
            EAP.TabPages.Remove(tabAnalisis);
            EAP.TabPages.Remove(tabLondres);
            EAP.TabPages.Remove(tabLondres2);
            EAP.TabPages.Remove(tabAdjuntos);
            gbNotificar.Visible = false;

            EAP.SelectTab("tabRegistro");


            switch (perfil)
            {
                case 1:
                    EAP.TabPages.Add(tabGrilla);
                    EAP.TabPages.Add(tabAnalisis);
                    EAP.TabPages.Add(tabLondres);
                    EAP.TabPages.Add(tabLondres2);
                    EAP.TabPages.Add(tabAdjuntos);

                    gbClasificacion.Enabled = true;
                    gbNotificar.Visible = true;
                    // Se habilita al seleccionar registro en la grilla
                    //gbNotificar.Enabled = true;
                    gbPlanMejoramiento.Enabled = true;
                    break;
                case 2:
                    EAP.TabPages.Add(tabGrilla);
                    EAP.TabPages.Add(tabAnalisis);
                    EAP.TabPages.Add(tabAdjuntos);
                    gbClasificacion.Enabled = false;
                    gbNotificar.Enabled = false;
                    gbPlanMejoramiento.Enabled = true;
                    break;
                case 3:
                    btRegSuceso.Enabled = true;
                    break;
             }
            ordenarTabs();

        }
        private void ordenarTabs()
        {
            var tabsOrdenadas = EAP.TabPages.Cast<TabPage>()
                                   .OrderBy(t => t.Text)
                                   .ToList();
            EAP.TabPages.Clear();

            foreach (var tab in tabsOrdenadas)
            {
                EAP.TabPages.Add(tab);
            }
            EAP.SelectedIndex = 1;
        }
        private void CargarGrilla( int usuario)
        {
            CN_Registro objeto = new CN_Registro();
            dgvDatos.DataSource = objeto.MostrarReg( usuario );

            // Registro suceso
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

            // Registro Analisis

            // Registro Protocolo Londres 1

            // Registro Protocolo Londres 2

            dgvDatos.Refresh();
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
            //Tab registro sucesos
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

            //Tab analisis
            cbTipoReporte.SelectedValue = 0;
            cbComponente.SelectedValue = 0;
            cbCausaRaiz.SelectedValue = 0;
            cbEstado.SelectedValue = 0;
            cbCumplio.SelectedValue = 0;
            cbVerificado.SelectedValue = 0;
            cbNotificar.SelectedValue = 0;
            cbCorreoOrigen.SelectedValue = 0;
            cbProtocoloLondres.SelectedValue = 0;

            txtQue.Text = string.Empty;
            txtQuien.Text = string.Empty;
            txtComo.Text = string.Empty;
            txtDonde.Text = string.Empty;
            txtCuando.Text = string.Empty;
            txtAnalizado.Text = string.Empty;
            txtResponsable.Text = string.Empty;

            //falso para poder borrar la grilla
           
           // dgvPM.Rows.Clear();
            dgvPM.DataSource = null;

            //Tab Protocolo de Londres
            txtPLPaciente.Text = string.Empty;
            txtPLTarea.Text = string.Empty;
            txtPLIndividuo.Text = string.Empty;
            txtPLEquipo.Text = string.Empty;
            txtPLAmbiente.Text = string.Empty;
            txtPLOrganizacion.Text = string.Empty;
            txtPLContexto.Text = string.Empty;

            //Tab Protocolo de Londres 2
            txtPL2Equipo.Text = string.Empty;
            txtPL2Historia.Text = string.Empty;
            txtPL2Protocolo.Text = string.Empty;
            txtPL2Declaraciones.Text = string.Empty;
            txtPL2Entrevista.Text = string.Empty;
            txtPL2Acciones.Text = string.Empty;
            txtPL2Comunicacion.Text = string.Empty;
            txtPL2Lecciones.Text = string.Empty;

            cbAcciones.SelectedValue = 0;
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
            cbEstado.SelectedValue = 0;
            gbMedicamentos.Enabled = false;
            gbNotificar.Enabled = false;
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
            Cargar_Combos(cbEstado, "sp_GENMENUME", 17);
            Cargar_Combos(cbAseguradora, "sp_GENMENUME", 23);
            Cargar_Combos(cbNotificar, "sp_GENMENUME", 27);
            //Cargar_Combos(cbCausaRaiz, "sp_GENMENUME", 99);
            //Cargar_Combos(cbAcciones, "sp_GENMENUME", 99);
            Cargar_Combos(cbProtocoloLondres, "sp_GENMENUME", 16);

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
                    // algo excepcional
                    if (criterio == 27)
                    {
                        cbUsuarios.DataSource = ds.Tables[0].DefaultView;
                        cbUsuarios.ValueMember = ds.Tables[0].Columns[0].Caption;
                        cbUsuarios.DisplayMember = ds.Tables[0].Columns[2].Caption;
                    }
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
                //bandera componente
                //string opCombo = (cbComponente.SelectedValue.ToString());
                //txtQue.Text = opCombo;
                comboSecundarioCargado = false;
                Cargar_Combos(cbCausaRaiz, "sp_GENMENUME", int.Parse((cbComponente.SelectedValue.ToString())));
                comboSecundarioCargado = true;
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
            // NO HABILITAR POR QUE ACTUALIZA CON EL ROWCOUNT
            //if (selEvento)
            //{
            //    CargarGrilla(int.Parse(txtOidUsAutenticado.Text));
            //}
            
        }

        private void btRegNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCamposRegistroSuceso();
            txtIdActual.Text = string.Empty;
            txtPacActual.Text = string.Empty;
            EAP.SelectTab("tabRegistro");
            gbRegSucesos.Enabled = true;
            btRegSuceso.Enabled = true;
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            CN_Registro objeto = new CN_Registro();
            dgvDatos.DataSource = objeto.MostrarReg(int.Parse(txtOidUsAutenticado.Text));
        }

        private void dgvDatos_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                selEvento = true;
                gbNotificar.Enabled = true;
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

                
                cbEstado.Text = dgvDatos.CurrentRow.Cells["ESTADO"].Value.ToString();

                //Variables de Control y visualización del registro actual
                txtIdActual.Text = dgvDatos.CurrentRow.Cells["ID"].Value.ToString();
                txtPacActual.Text = dgvDatos.CurrentRow.Cells["NOMBRE_PACIENTE"].Value.ToString();
                txtOidActual.Text = dgvDatos.CurrentRow.Cells["OID"].Value.ToString();
                txtIdrActual.Text = dgvDatos.CurrentRow.Cells["IDR"].Value.ToString();
                txtDescripActual.Text = dgvDatos.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                txtEstadoActual.Text = cbEstado.Text;

                //Analisis
                cbTipoReporte.Text = dgvDatos.CurrentRow.Cells["TIPO_REPORTE"].Value.ToString();
                cbComponente.SelectedValue = dgvDatos.CurrentRow.Cells["EAACOMPO"].Value;
                cbCausaRaiz.SelectedValue = dgvDatos.CurrentRow.Cells["EAACAURA"].Value;
                txtAnalizado.Text = dgvDatos.CurrentRow.Cells["ANALIZADO"].Value.ToString();
                cbProtocoloLondres.Text = dgvDatos.CurrentRow.Cells["LONDRES"].Value.ToString();

                //Protocolo Londres 1

                txtPLPaciente.Text = dgvDatos.CurrentRow.Cells["EAPPACIE"].Value.ToString();
                txtPLTarea.Text = dgvDatos.CurrentRow.Cells["EAPTAREA"].Value.ToString();
                txtPLIndividuo.Text = dgvDatos.CurrentRow.Cells["EAPINDIV"].Value.ToString();
                txtPLEquipo.Text = dgvDatos.CurrentRow.Cells["EAPEQUTR"].Value.ToString();
                txtPLAmbiente.Text = dgvDatos.CurrentRow.Cells["EAPAMBIE"].Value.ToString();
                txtPLOrganizacion.Text = dgvDatos.CurrentRow.Cells["EAPORGAN"].Value.ToString();
                txtPLContexto.Text = dgvDatos.CurrentRow.Cells["EAPCONTE"].Value.ToString();

                //Protocolo Londres 2

                txtPL2Equipo.Text = dgvDatos.CurrentRow.Cells["EAPEQUIP"].Value.ToString();
                //dpPL2Fecha.Value = dgvDatos.CurrentRow.Cells["EAPFECHA"].Value.ToString();
                txtPL2Historia.Text = dgvDatos.CurrentRow.Cells["EAPHISTO"].Value.ToString();
                txtPL2Protocolo.Text = dgvDatos.CurrentRow.Cells["EAPPROTO"].Value.ToString();
                txtPL2Declaraciones.Text = dgvDatos.CurrentRow.Cells["EAPDECLA"].Value.ToString();
                txtPL2Entrevista.Text = dgvDatos.CurrentRow.Cells["EAPENTRE"].Value.ToString();
                txtPL2Acciones.Text = dgvDatos.CurrentRow.Cells["EAPACCIO"].Value.ToString();
                //txtPLEquipo.Text = dgvDatos.CurrentRow.Cells["EAPINSEG"].Value.ToString();
                txtPL2Comunicacion.Text = dgvDatos.CurrentRow.Cells["EAPCOMUN"].Value.ToString();
                txtPL2Lecciones.Text = dgvDatos.CurrentRow.Cells["EAPLECCI"].Value.ToString();

                CargarGrillaPM();
                CargarGrillaPMCorreos();

                btRegSuceso.Enabled = false;

                gbRegSucesos.Enabled = false;

                //cbEstado registrado

                //if (int.Parse(cbEstado.SelectedValue.ToString())== 1) 
                //{
                //    //Perfil que llena el plan de mantenimiento
                //    if (int.Parse(dgvLogin.CurrentRow.Cells["PERFIL"].Value.ToString()) == 2)
                //    {
                //        EAP.TabPages.Remove(tabAnalisis);
                //    }
                // }
                //else
                //{
                //    if (!EAP.TabPages.Contains(tabAnalisis))
                //    {
                //        EAP.TabPages.Add(tabAnalisis);
                //    }

                //}
                //ordenarTabs();
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
                    //MessageBox.Show(txtOidActual.Text + " ** " + cbNotificar.SelectedValue.ToString());
                    try
                    {
                        //oid del evento, oid del correo
                        objetoCN.InsertarRegCor(int.Parse(txtOidActual.Text),int.Parse(cbNotificar.SelectedValue.ToString()), int.Parse(cbUsuarios.Text));
                        CargarGrillaPMCorreos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Es posible que el correo ya este adicionado, o que no haya seleccionado el evento! " +ex); 
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
            // eliminar registro
        }
        private void enviarCorreosNotificacion(string ceHost, int cePort, string ceEmail, string cePassword, string asunto, string mensaje, string correo)
        {
            CN_Correos objetoCNCorreoS = new CN_Correos();
            objetoCNCorreoS.enviarCorreos(ceHost, cePort, ceEmail, cePassword, asunto, mensaje, correo);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //VALIDAR CAMPOS
            if (int.Parse(cbTipoReporte.SelectedValue.ToString())==0 || int.Parse(cbComponente.SelectedValue.ToString()) == 0 || int.Parse(cbCausaRaiz.SelectedValue.ToString()) == 0 || int.Parse(cbEstado.SelectedValue.ToString()) == 0)
            {
                MessageBox.Show("Datos incompletos. Revisar!");
            }
            else
            {
                //UPDATE
                if (Editar == false)
                {
                    // EN ESTADO SE COLOCA 2 PARA INDICAR QUE FUE ANALIZADO
                    try
                    {
                        objetoCN.UpdateRegAnalisis(int.Parse(txtOidActual.Text), 
                            int.Parse(cbTipoReporte.SelectedValue.ToString()),
                            int.Parse(cbComponente.SelectedValue.ToString()),
                            int.Parse(cbCausaRaiz.SelectedValue.ToString()),
                            txtAnalizado.Text,2, int.Parse(cbProtocoloLondres.SelectedValue.ToString()));
                        // int.Parse(cbEstado.SelectedValue.ToString()));
                        //cbEstado.ValueMember = "2";
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
                            txtPLContexto.Text,
                            txtPL2Equipo.Text,
                            dpPL2Fecha.Value,
                            txtPL2Historia.Text,
                            txtPL2Protocolo.Text,
                            txtPL2Declaraciones.Text,
                            txtPL2Entrevista.Text,
                            txtPL2Acciones.Text,
                            int.Parse(cbAcciones.SelectedValue.ToString()),
                            txtPL2Comunicacion.Text,
                            txtPL2Lecciones.Text
                            );

                        MessageBox.Show("Protocolo Registrado");
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

        private void btnEnviarNotificacion_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(cbTipoReporte.SelectedValue.ToString());

            if ((int.Parse(cbTipoReporte.SelectedValue.ToString())>=2) && (dgvPMCorreos.Rows.Count >0))
            {
                //string wHost = "smtp.office365.com";
                //int wPort = 587;
                //string wEmail = "serviciosmedicosweb@sosaludvisual.com";
                //string wPassword = "ychfypcxjsswfqsh";

                //string wHost = "smtp.office365.com";
                //int wPort = 587;
                //string wEmail = "auditoria@sosaludvisual.com";
                //string wPassword = "pdvmyzyzyvrbyxdk";


                string wHost = txtGCSERVIDOR.Text;
                int wPort = int.Parse(txtGCPUERTO.Text);
                string wEmail = txtCECORREO.Text;
                string wPassword = txtCEPASSMASIVO.Text;

                //MessageBox.Show(wHost + "*" + wEmail + "*" + wPassword);

                //Recorrer Grilla de correos
                string wAsunto = @"ID Suceso de Seguridad : " + txtIdrActual.Text + "   Paciente : " + txtPacActual.Text;

                string wMensaje = @" <!DOCTYPE html>
                <html lang='en'>
                <head>
                <meta charset = 'UTF-8'>
                <meta name = 'viewport' content = 'width=device-width, initial-scale=1.0'>
                <style>
                    h5 {
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
                            <td> ID Suceso </td>
                            <td><h5> " + txtIdrActual.Text + " </h5></td>" +
                            "</tr>" +
                            "<tr>" +
                                "<td> ID Paciente </td>" +
                                "<td><h5> " + txtIdActual.Text + " </h5></td>" +
                            "</tr>" +
                            "<tr>" +
                                "<td> Nombre Paciente </td>" +
                                "<td><h5> " + txtPacActual.Text + " </td>" +
                            "</tr>" +
                            "<tr>" +
                                 "<td> Descripción Evento </td>" +
                                 "<td><h5> " + txtDescripActual.Text + " </td>" +
                            "</tr>" +
                            "<tr>" +
                                 "<td> Estado </td>" +
                                 "<td><h5> " + txtEstadoActual.Text + " </td>" +
                            "</tr>" +
                         "</tbody>" +
                        "</table>" +
                 "</body>" +
                 "</html>";


                // enviarCorreosNotificacion(wHost, wPort, wEmail, wPassword, wAsunto, wMensaje, "jhgonzalezm@gmail.com");

                foreach (DataGridViewRow row in dgvPMCorreos.Rows)
                {
                    // Omitir la fila nueva (en modo edición)
                    if (row.IsNewRow) continue;
                    var wCorreo = row.Cells["CECORREO"].Value.ToString();
                    enviarCorreosNotificacion(wHost, wPort, wEmail, wPassword, wAsunto, wMensaje, wCorreo);
                    MessageBox.Show("Correo: " + wCorreo);
                    // ACTUALIZAR TABLA DE EANREAUSU Y EANMREGIS

                }
            }
            else
            {
                MessageBox.Show("No se puede notificar. Motivos: Registro No analizado o Correo no seleccionado.");
            }
            
        }

        private void dgvDatos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            


        }

        private void dgvDatos_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var fila = dgvDatos.Rows[e.RowIndex];
            var valor = int.Parse(fila.Cells["IESTADO"].Value?.ToString());
                
            //1:Registrado 2: Notificado 3: Abierto  4: Cerrado
            switch (valor) {
                case 1:
                    dgvDatos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    break;
                case 2:
                    dgvDatos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                    break;
                case 3:
                    dgvDatos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSalmon;
                    break;
                case 4:
                    dgvDatos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                    break;
            }
           
        }

        private void cbComponente_Enter(object sender, EventArgs e)
        {
                    }

        private void btnRegProtocolo2_Click(object sender, EventArgs e)
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
                            txtPLContexto.Text,
                            txtPL2Equipo.Text,
                            dpPL2Fecha.Value,
                            txtPL2Historia.Text,
                            txtPL2Protocolo.Text,
                            txtPL2Declaraciones.Text,
                            txtPL2Entrevista.Text,
                            txtPL2Acciones.Text,
                            0,
                            txtPL2Comunicacion.Text,
                            txtPL2Lecciones.Text)
                            ;

                        MessageBox.Show("Protocolo Registrado");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Datos NO Registrados!! : " + ex);
                    }
                }
            }
        }

        private void txtPLTarea_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if ((txtId.Text.Length > 1) & (txtPassword.Text.Length > 3)){
                CN_Users objeto = new CN_Users();
                //((DataTable)dgvLogin.DataSource).Clear();
                dgvLogin.DataSource = objeto.AutenticarUsuario(txtId.Text, txtPassword.Text);
                //MessageBox.Show(dgvLogin.Rows.Count.ToString());
                if (dgvLogin.Rows.Count > 0)
                {
                    txtPerfil.Text = dgvLogin.CurrentRow.Cells["EAPERDES"].Value.ToString();
                    txtNombre.Text = dgvLogin.CurrentRow.Cells["USUNOMBRE"].Value.ToString();
                    txtRolNom.Text = dgvLogin.CurrentRow.Cells["USUROLNOM"].Value.ToString();
                    tabsHabilitados(int.Parse(dgvLogin.CurrentRow.Cells["PERFIL"].Value.ToString()));
                    txtOidUsAutenticado.Text = dgvLogin.CurrentRow.Cells["OID_US_AUT"].Value.ToString();

                    // Información para envío de correos
                    txtCECORREO.Text = dgvLogin.CurrentRow.Cells["CECORREO"].Value.ToString();
                    txtCEPASSMASIVO.Text = dgvLogin.CurrentRow.Cells["CEPASSMASIVO"].Value.ToString();
                    txtGCSERVIDOR.Text = dgvLogin.CurrentRow.Cells["GCSERVIDOR"].Value.ToString();
                    txtGCPUERTO.Text = dgvLogin.CurrentRow.Cells["GCPUERTO"].Value.ToString();
                    CargarGrilla(int.Parse(txtOidUsAutenticado.Text));

                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña Errados");
                }
            }
            else
            {
                MessageBox.Show("Longitud de Usuario o Contraseña Errados");
            }
 
        }

        private void EAP_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 3 )
            {
                if (int.Parse(cbEstado.SelectedValue.ToString()) == 1)
                {
                    //Perfil que llena el plan de mantenimiento
                    if (int.Parse(dgvLogin.CurrentRow.Cells["PERFIL"].Value.ToString()) == 2)
                    {
                        MessageBox.Show("Esta pestaña no se habilita hasta que no se notifique el evento.");
                        e.Cancel = true; // Cancela el cambio de pestaña
                    }
                }
            }
            //if (e.TabPageIndex == 3 || !selEvento)
            //{
            //    MessageBox.Show("Esta pestaña no se habilita hasta que no se seleccione un evento.");
            //    e.Cancel = true; // Cancela el cambio de pestaña
            //}
        }

        private void btnActualizarGrillaPpal_Click(object sender, EventArgs e)
        {
            CargarGrilla(int.Parse(txtOidUsAutenticado.Text));
        }

        private void cbNotificar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label55_Click_1(object sender, EventArgs e)
        {

        }

        private void label62_Click(object sender, EventArgs e)
        {

        }

        private void txtPLAmbiente_TextChanged(object sender, EventArgs e)
        {

        }

        private void label59_Click(object sender, EventArgs e)
        {

        }

        private void label66_Click(object sender, EventArgs e)
        {

        }

        private void cbCausaRaiz_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
                if (combosCargados && comboSecundarioCargado)
                {
                    //string opCombo = (cbComponente.SelectedValue.ToString());
                    //txtQue.Text = opCombo;

                    Cargar_Combos(cbAcciones, "sp_GENMENUME", int.Parse((cbCausaRaiz.SelectedValue.ToString())));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Descripcion Error: " + ex);
            }
        }
    }
}