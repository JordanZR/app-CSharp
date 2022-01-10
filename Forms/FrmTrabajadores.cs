using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Security.Permissions;
using System.Security;
using System.Data.OleDb;
using SpreadsheetLight;

namespace SistemaInventario
{
    public partial class FrmTrabajadores : Form
    {

        private int id_trabajador = 0;
        private int fecha_seleccionada = 0;
        private Boolean validacion = false;
        //El validador me permite saber si un dato va a ser ingresado, o caso contrario, va a ser modificado
        private int validador = -1;
        private string dui = "";
        public bool validado = true;
        ListaTrabajador lista = new ListaTrabajador();


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
         (
             int nLeftRect,
             int nTopRect,
             int nRightRect,
             int nBottomRect,
             int nWidthEllipse,
             int nHeightEllipse
         );

        public FrmTrabajadores()
        { 
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        //Metodos

        //El metodo tiene como parametro un objeto de tipo lista. El cual luego ocupo el método Mostrar la Lista
        //Esto me devuelve una cola y la uso como DataSource


        private void picBMinimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picBSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMenu frm = new FrmMenu();
            frm.Show();
            this.Hide();
        }


        private void ActualizarDataGrid(ListaTrabajador lista)
        {
            dgvmostrar.DataSource = null;
            dgvmostrar.DataSource = lista.Mostrar().ToList();
            dgvmostrar.ClearSelection();
        }
        private void reseteo()
        {
            txtnombre.Clear();
            txtafp.Clear();
            txtdireccion.Clear();
            txtdui.Clear();
            txtni.Clear();
            txtpago.Clear();
            txtseguro.Clear();
            txttelefono.Clear();
            cbtipo.SelectedIndex = -1;
            fechanacimiento.Value = DateTime.Today;
        }
        private void btnagregar_Click(object sender, EventArgs e)
        {
            BorrarMensaje();
            try
            {
                if (validaciones())
                {
                    Trabajadores trabajador = new Trabajadores();
                    trabajador.Nombre = txtnombre.Text;
                    trabajador.Dui = txtdui.Text;
                    trabajador.Nit = txtni.Text;
                    trabajador.Afp = txtafp.Text;
                    trabajador.Seguro = txtseguro.Text;
                    trabajador.Direccion = txtdireccion.Text;
                    trabajador.Telefono = txttelefono.Text;
                    trabajador.Tipo = cbtipo.SelectedItem.ToString();
                    trabajador.Pago = double.Parse(txtpago.Text);
                    trabajador.Fecha = Convert.ToString(fechanacimiento.Value.ToString("yyyy-MM-dd"));
                    //Si el validador == -1 significa que un dato será INGRESADO
                    if (validador == -1)
                    {
                        //De ser así, ocupo el método InsertarF y le mando el objeto de tipo trabajador
                        lista.InsertarF(trabajador);
                        //Actualizo el datagrid mandandole la lista con el nuevo dato ingresado
                        ActualizarDataGrid(lista);
                        //Limpio pantalla
                        reseteo();
                    }
                    else
                    {
                        //Caso contrario, significa que el usuario está modificando un trabajador existente
                        //Hago que estos campos ahora sean modificables para cuando quiere ingresar un nuevo dato
                        txtdui.ReadOnly = false;
                        txtafp.ReadOnly = false;
                        txtni.ReadOnly = false;
                        txtseguro.ReadOnly = false;
                        //Ocupo el método editar y le mando como parametro el DUI del trabajador a modificar y el objeto de tipo trabajador
                        lista.Editar(dui, trabajador);
                        //Actualizo el datagrid
                        ActualizarDataGrid(lista);
                        reseteo();
                        //Hago que el validador sea nuevamente -1 y el dui le doy un valor nulo
                        validador = -1;
                        dui = "";
                        reseteo();
                    }

                    //Actualizamos el archivo
                    //actualizamos el archivo de inventario
                    string nombrearchivo = "..\\..\\Datos\\trabajadores.xlsx";
                    try
                    {
                        if(File.Exists(nombrearchivo))
                        {
                            File.Delete(nombrearchivo);
                            Exportar(dgvmostrar, nombrearchivo);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex.Message);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            //Pruebo si ha sido seleccionado un dato del datagrid
            if (validador != -1)
            {
                try
                {
                    //Creo un nuevo objeto del tipo lista
                    ListaTrabajador lista2 = new ListaTrabajador();

                    //Le paso todos los valores que no sean los que se quieren borrar de la lista global
                    foreach (Trabajadores trabajador in lista.EnCola(dui))
                    {
                        lista2.InsertarF(trabajador);
                    }
                    //Hago que la lista global sea igual a la nueva lista, es decir, que tenga los valores nuevos excepto el borrado
                    lista = lista2;
                    //Actualizo el datagrid
                    ActualizarDataGrid(lista);
                    //Reinicio los validadores
                    validador = -1;
                    reseteo();
                    dui = "";
                    txtdui.ReadOnly = false;
                    txtafp.ReadOnly = false;
                    txtni.ReadOnly = false;
                    txtseguro.ReadOnly = false;

                    //Actualizamos el archivo
                    //actualizamos el archivo de inventario
                    string nombrearchivo = "..\\..\\Datos\\trabajadores.xlsx";
                    try
                    {
                        if(File.Exists(nombrearchivo))
                        {
                            File.Delete(nombrearchivo);
                            Exportar(dgvmostrar, nombrearchivo);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila", "¡Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        List<Trabajadores> ImportarDatos(string nombrearchivo)
        {
            List<Trabajadores> lista = new List<Trabajadores>();

            try
            {
                SLDocument sl = new SLDocument(nombrearchivo);

                int iRow = 2;
                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                {
                    Trabajadores trabajador = new Trabajadores();
                    trabajador.Nombre = sl.GetCellValueAsString(iRow, 1);
                    trabajador.Dui = sl.GetCellValueAsString(iRow, 2);
                    trabajador.Nit = sl.GetCellValueAsString(iRow, 3);
                    trabajador.Afp = sl.GetCellValueAsString(iRow, 4);
                    trabajador.Seguro = sl.GetCellValueAsString(iRow, 5);
                    trabajador.Direccion = sl.GetCellValueAsString(iRow, 6);
                    trabajador.Telefono = sl.GetCellValueAsString(iRow, 7);
                    trabajador.Tipo = sl.GetCellValueAsString(iRow, 8);
                    trabajador.Pago = sl.GetCellValueAsDouble(iRow, 9);
                    trabajador.Fecha = sl.GetCellValueAsString(iRow, 10);
                    lista.Add(trabajador);
                    iRow++;
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Error al importar " + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;
        }

        
        //Validaciones
        private bool validaciones()
        {
            validado = true;
            if (txtnombre.TextLength == 0)
            {
                validado = false;
                errorProvider1.SetError(txtnombre, "Ingresar el nombre");
            }
            if (txtdui.MaskFull) { }
            else
            {
                validado = false;
                errorProvider1.SetError(txtdui, "Ingresar el número de DUI");
            }

            if (txtni.MaskFull) { }
            else
            {
                validado = false;
                errorProvider1.SetError(txtni, "Ingresar el número de NIT");
            }
            if (txttelefono.MaskFull) { }
            else
            {
                validado = false;
                errorProvider1.SetError(txttelefono, "Ingresar el número de NIT");
            }

            if (txtafp.MaskFull) { }
            else
            {
                validado = false;
                errorProvider1.SetError(txtafp, "Ingresar el número de AFP");
            }
            
            if (txtseguro.Text == "")
            {
                validado = false;
                errorProvider1.SetError(txtseguro, "Ingresar número de seguro");
            }
            if (txtdireccion.Text == "")
            {
                validado = false;
                errorProvider1.SetError(txtdireccion, "Ingresar dirección");
            }
            if (txtpago.Text == "")
            {
                validado = false;
                errorProvider1.SetError(txtpago, "Ingresar pago diario");
            }
            
            if (cbtipo.Text == "")
            {
                validado = false;
                errorProvider1.SetError(cbtipo, "Seleccionar una opción");
            }
            if (fechanacimiento.Value.Date >= DateTime.Now.Date)
            {
                validado = false;
                errorProvider1.SetError(fechanacimiento, "Seleccione una fecha");
            }
            return validado;
        }

        private void BorrarMensaje()
        {
            errorProvider1.SetError(txtnombre, "");
            errorProvider1.SetError(txtseguro, "");
            errorProvider1.SetError(txtpago, "");
            errorProvider1.SetError(txtnit, "");
            errorProvider1.SetError(txtafp, "");
            errorProvider1.SetError(txttelefono, "");
            errorProvider1.SetError(fechanacimiento, "");
            errorProvider1.SetError(cbtipo, "");
        }


        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
                BorrarMensaje();
            }
            //para backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                BorrarMensaje();
            }
            //para que admita tecla de espacio
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
                BorrarMensaje();
            }
            //si no cumple nada de lo anterior que no lo deje pasar
            else
            {
                e.Handled = true;
                errorProvider1.SetError(txtnombre, "En este campo sólo se permiten letras");
            }
        }

        private void txtseguro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
                BorrarMensaje();
            }
            //para backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                BorrarMensaje();
            }
            //si no cumple nada de lo anterior que no lo deje pasar
            else
            {
                e.Handled = true;
                errorProvider1.SetError(txtseguro, "En este campo sólo se permiten numeros");
            }
        }
        

        private void txtnit_Click(object sender, EventArgs e)
        {
            if (id_trabajador == 0)
            {
                txtni.Clear();
            }
        }

        private void txtafp_Click(object sender, EventArgs e)
        {
            if (id_trabajador == 0)
            {
                txtafp.Clear();
            }
        }
        private void txttelefono_Click(object sender, EventArgs e)
        {
            if (id_trabajador == 0)
            {
                txttelefono.Clear();
            }
        }
        private void fechanacimiento_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (fechanacimiento.Value.Date >= DateTime.Now.Date)
            {
                MessageBox.Show("Fecha seleccionada no valida", "¡Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                fecha_seleccionada = 1;
            }
        }
        
        private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel | *.xls;*.xlsx;",

                Title = "Seleccionar Archivo"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                insertarImportacion(openFileDialog.FileName);
            }
        }

        public void insertarImportacion(string ruta)
        {
            try
            {
                List<Trabajadores> lst = new List<Trabajadores>();
                lst = ImportarDatos(ruta);
                bool excelVacio = false;
                bool idCodigo = false;
                foreach (var item in lst)
                {
                    excelVacio = true;
                    Trabajadores trabajador = new Trabajadores();
                    trabajador.Nombre = item.Nombre;
                    trabajador.Dui = item.Dui;
                    trabajador.Nit = item.Nit;
                    trabajador.Afp = item.Afp;
                    trabajador.Seguro = item.Seguro;
                    trabajador.Direccion = item.Direccion;
                    trabajador.Telefono = item.Telefono;
                    trabajador.Tipo = item.Tipo;
                    trabajador.Pago = item.Pago;
                    trabajador.Fecha = item.Fecha;

                    //Esto es para validar que no se ingrese un registro con codigo ya existente en la lista
                    Queue<Trabajadores> cola = new Queue<Trabajadores>();
                    cola = lista.Mostrar();

                    if (cola.Count == 0)
                    {
                        lista.InsertarF(trabajador);
                    }
                    else
                    {

                        if (cola.Contains(item))
                        {

                        }
                        foreach (var item2 in cola)
                        {
                            if (item2.Dui == trabajador.Dui)
                            {
                                idCodigo = true;
                                break;
                            }
                        }
                        if (idCodigo == false)
                        {
                            lista.InsertarF(trabajador);
                        }
                    }
                    //***********************************************************
                }

                if (ruta != "..\\..\\Datos\\trabajadores.xlsx")
                {
                    if (excelVacio == true && idCodigo == false)
                    {
                        ActualizarDataGrid(lista);
                        MessageBox.Show("Archivo importado correctamente", "¡Enhorabuena!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Actualizamos el archivo
                        //actualizamos el archivo de inventario
                        string nombrearchivo = "..\\..\\Datos\\trabajadores.xlsx";
                        try
                        {
                            if (File.Exists(nombrearchivo))
                            {
                                File.Delete(nombrearchivo);
                                Exportar(dgvmostrar, nombrearchivo);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error " + ex.Message);
                        }
                    }
                    else if (excelVacio == true && idCodigo == true)
                    {
                        ActualizarDataGrid(lista);
                        MessageBox.Show("Archivo importado correctamente, pero algunos registros se omitieron porque el codigo ya existe", "¡Enhorabuena!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("El archivo agregado no contiene datos", "¡Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    ActualizarDataGrid(lista);
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al importar  " + Ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        } 


        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtArchivo.TextLength != 0)
                {
                    Exportar(dgvmostrar, "C:\\" + txtArchivo.Text + ".xlsx");
                }
                else
                {
                    MessageBox.Show("Ingrese un nombre para el archivo por favor", "¡Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Exportar(DataGridView datalistado, string outputFile)
        {
            if (datalistado.RowCount > 0 && File.Exists(outputFile) != true)
            {
                try
                {
                    SLDocument sl = new SLDocument();

                    int iC = 1;
                    SLStyle style = new SLStyle();
                    style.Font.Bold = true;

                    foreach (DataGridViewColumn column in dgvmostrar.Columns)
                    {
                        sl.SetCellValue(1, iC, column.HeaderText.ToString());
                        sl.SetCellStyle(1, iC, style);
                        iC++;
                    }

                    int iR = 2;
                    foreach (DataGridViewRow row in dgvmostrar.Rows)
                    {
                        sl.SetCellValue(iR, 1, row.Cells[0].Value.ToString());
                        sl.SetCellValue(iR, 2, row.Cells[1].Value.ToString());
                        sl.SetCellValue(iR, 3, row.Cells[2].Value.ToString());
                        sl.SetCellValue(iR, 4, row.Cells[3].Value.ToString());
                        sl.SetCellValue(iR, 5, Convert.ToInt64(row.Cells[4].Value.ToString()));
                        sl.SetCellValue(iR, 6, row.Cells[5].Value.ToString());
                        sl.SetCellValue(iR, 7, row.Cells[6].Value.ToString());
                        sl.SetCellValue(iR, 8, row.Cells[7].Value.ToString());
                        sl.SetCellValue(iR, 9, double.Parse(row.Cells[8].Value.ToString()));
                        sl.SetCellValue(iR, 10, row.Cells[9].Value.ToString());
                        iR++;
                    }
                    sl.SaveAs(outputFile);
                    if (outputFile != "..\\..\\Datos\\trabajadores.xlsx")
                    {
                        MessageBox.Show("Archivo exportado correctamente", "¡Enhorabuena!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error al exportar " + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay Registros a Exportar o el nombre del documento ya existe", "¡Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FrmTrabajadores_Load(object sender, EventArgs e)
        {
            BorrarMensaje();
            string nombrearchivo = "..\\..\\Datos\\trabajadores.xlsx";
            insertarImportacion(nombrearchivo);
            fechanacimiento.Value.ToString("yyyy-MM-dd");
        }

        private void txtpago_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
                BorrarMensaje();
            }
            //para backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                BorrarMensaje();
            }
            //Para punto 
            else if (char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
                BorrarMensaje();
            }
            //si no cumple nada de lo anterior que no lo deje pasar
            else
            {
                e.Handled = true;
                errorProvider1.SetError(txtpago, "En este campo sólo se permiten numeros");
            }
        }

        private void txtdireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvmostrar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvmostrar.Rows.Count > 0 && e.RowIndex != -1)
            {
                try
                {
                    //Le paso los datos del datagrid a los textbox
                    validador = dgvmostrar.Rows.IndexOf(dgvmostrar.SelectedRows[0]);
                    dui = dgvmostrar.Rows[validador].Cells[1].Value.ToString();
                    txtnombre.Text = dgvmostrar.Rows[validador].Cells[0].Value.ToString();
                    txtdui.Text = dui;
                    txtni.Text = dgvmostrar.Rows[validador].Cells[2].Value.ToString();
                    txtafp.Text = dgvmostrar.Rows[validador].Cells[3].Value.ToString();
                    txtseguro.Text = dgvmostrar.Rows[validador].Cells[4].Value.ToString();
                    txtdireccion.Text = dgvmostrar.Rows[validador].Cells[5].Value.ToString();
                    txttelefono.Text = dgvmostrar.Rows[validador].Cells[6].Value.ToString();
                    cbtipo.SelectedItem = dgvmostrar.Rows[validador].Cells[7].Value.ToString();
                    txtpago.Text = dgvmostrar.Rows[validador].Cells[8].Value.ToString();
                    fechanacimiento.Value = Convert.ToDateTime(dgvmostrar.Rows[validador].Cells[9].Value.ToString());
                    //Hago que estos datos no puedan ser modificados, porque son los identificadores unicos de cada trabajador
                    txtdui.ReadOnly = true;
                    txtafp.ReadOnly = true;
                    txtni.ReadOnly = true;
                    txtseguro.ReadOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
