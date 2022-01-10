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
using System.Diagnostics;

namespace SistemaInventario
{
    public partial class FrmFactura : Form
    {

        private int validador = -1;
        private int codigo = 0;
        ListaFactura lista = new ListaFactura();


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
        public FrmFactura()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void ActualizarDataGrid(ListaFactura lista)
        {
            dgvmostrar.DataSource = null;

            dgvmostrar.DataSource = lista.Mostrar().ToList();
            dgvmostrar.ClearSelection();
            btnborrar.Enabled = false;
        }

        private void reseteo()
        {
            txtCrepuesto.Clear();
            txtValormano.Clear();
            txtdescripcion.Clear(); txtCantidad.Clear();
            cmbProductos.SelectedIndex = -1;
        }

        List<Inventario> ImportarProductos()
        {
            List<Inventario> lista = new List<Inventario>();
            string nombrearchivo = "..\\..\\Datos\\productos.xlsx";

            try
            {
                SLDocument sl = new SLDocument(nombrearchivo);

                int iRow = 2;
                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                {
                    Inventario inventario = new Inventario();

                    inventario.Descripcion = sl.GetCellValueAsString(iRow, 2);

                    lista.Add(inventario);
                    iRow++;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al importar " + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;
        }

        private void llenarCombo()
        {
            try
            {
                List<Inventario> lista = new List<Inventario>();
                lista = ImportarProductos();

                foreach (Inventario item in lista)
                {
                    cmbProductos.Items.Add(item.Descripcion);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al cargar datos " + Ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Alumno_Load(object sender, EventArgs e)
        {
            BorrarMensaje();
            try
            {
                string nombrearchivo = "..\\..\\Datos\\facturas.xlsx";
                InsertarImportacion(nombrearchivo);
                llenarCombo();
                btnborrar.Enabled = false;
                btnEditar.Enabled = false;
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al mostrar datos " + Ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //validar que la fecha de nacimiento no sea mayor a la fecha del sistema

        private void picBMinimizar_Click(object sender, EventArgs e)
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

        private bool validaciones()
        {
            bool validacion = true;
            if (txtCantidad.Text == "")
            {
                validacion = false;
                errorProvider1.SetError(txtCantidad, "Por favor ingrese la cantidad de articulos");
            }
            if (txtCrepuesto.Text == "")
            {
                validacion = false;
                errorProvider1.SetError(txtCrepuesto, "Por favor ingrese el costo del repuesto");
            }
            if (txtValormano.Text == "")
            {
                validacion = false;
                errorProvider1.SetError(txtValormano, "Por favor ingrese el precio de la mano de obra");
            }

            if (txtdescripcion.Text == "")
            {
                validacion = false;
                errorProvider1.SetError(txtdescripcion, "Por favor ingrese una descripción del articulo");
            }

            if (cmbProductos.Text == "")
            {
                validacion = false;
                errorProvider1.SetError(txtdescripcion, "Por favor seleccione un producto");
            }

            return validacion;
        }



        //borrar los mensajes que provee el error provider
        private void BorrarMensaje()
        {
            errorProvider1.SetError(txtCrepuesto, "");
            errorProvider1.SetError(txtValormano, "");

            errorProvider1.SetError(txtCantidad, "");
            errorProvider1.SetError(txtdescripcion, "");
            errorProvider1.SetError(cmbProductos, "");
        }



        private void btnGuardarA_Click(object sender, EventArgs e)
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

            int contIdFac = 0;
            foreach (DataGridViewRow row in dgvmostrar.Rows)
            {
                sl.SetCellValue(contIdFac, 1, Convert.ToInt32(row.Cells[0].Value.ToString()));
                contIdFac++;
            }

            //ASIGNAMOS EL VALOR DE ID DE MANERA CORRECTA
            contid.Text = Convert.ToString(contIdFac + 1);



            //validaciones
            BorrarMensaje();
            if (validaciones())
            {
                //creo un objeto de la clase persona y guardo a través de las propiedades 
                try
                {
                    //Faltan validaciones
                    //Ahorita no las he activado porque sino hay que ingresar toooodos estos datos y es tedioso para hacer pruebas

                    //Creo un objeto del tipo trabajador y lleno los datos de este

                    Factura factura = new Factura();
                    factura.Idfactura = Convert.ToInt32(contid.Text);
                    factura.Cantidad = int.Parse(txtCantidad.Text);
                    factura.Costo = double.Parse(txtCrepuesto.Text);
                    factura.Valor_mano_obra = double.Parse(txtValormano.Text);
                    factura.Costo_total = Math.Round((factura.Costo * factura.Cantidad ) + factura.Valor_mano_obra, 2);
                    factura.Descripcion_mano_obra = txtdescripcion.Text;
                    factura.Producto = cmbProductos.Text;
                    //Si el validador == -1 significa que un dato será INGRESADO

                    //De ser así, ocupo el método InsertarF y le mando el objeto de tipo trabajador
                    lista.InsertarF(factura);
                    //Actualizo el datagrid mandandole la lista con el nuevo dato ingresado
                    ActualizarDataGrid(lista);

                    //Limpio pantalla
                    reseteo();

                    //Actualizamos el archivo
                    //actualizamos el archivo de inventario
                    string nombrearchivo = "..\\..\\Datos\\facturas.xlsx";
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void picBMinimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
        private void btnEliminarA_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel | *.xls;*.xlsx;",

                Title = "Seleccionar Archivo"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                InsertarImportacion(openFileDialog.FileName);
            }
        }

        public void InsertarImportacion(string ruta)
        {
            try
            {
                List<Factura> lst = new List<Factura>();
                lst = ImportarDatos(ruta);
                bool excelVacio = false;
                bool idCodigo = false;
                foreach (var item in lst)
                {
                    excelVacio = true;
                    Factura factura = new Factura();
                    factura.Idfactura = Convert.ToInt32(item.Idfactura.ToString());
                    factura.Cantidad = Convert.ToInt32(item.Cantidad.ToString());
                    factura.Costo = Convert.ToDouble(item.Costo.ToString());
                    factura.Valor_mano_obra = Convert.ToDouble(item.Valor_mano_obra.ToString());
                    factura.Costo_total = Convert.ToDouble(item.Costo_total.ToString());
                    factura.Descripcion_mano_obra = item.Descripcion_mano_obra.ToString();
                    factura.Producto = item.Producto.ToString();


                    //Esto es para validar que no se ingrese un registro con codigo ya existente en la lista
                    Queue<Factura> cola = new Queue<Factura>();
                    cola = lista.Mostrar();

                    if (cola.Count == 0)
                    {
                        lista.InsertarF(factura);
                    }
                    else
                    {

                        if (cola.Contains(item))
                        {

                        }
                        foreach (var item2 in cola)
                        {
                            if (item2.Idfactura == factura.Idfactura)
                            {
                                idCodigo = true;
                                break;
                            }
                        }
                        if (idCodigo == false)
                        {
                            lista.InsertarF(factura);
                        }
                    }
                }

                if (ruta != "..\\..\\Datos\\facturas.xlsx")
                {
                    if (excelVacio == true && idCodigo == false)
                    {
                        ActualizarDataGrid(lista);
                        MessageBox.Show("Archivo importado correctamente", "¡Enhorabuea!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Actualizamos el archivo
                        //actualizamos el archivo de inventario
                        string nombrearchivo = "..\\..\\Datos\\facturas.xlsx";
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
                        MessageBox.Show("Archivo importado correctamente, pero algunos registros se omitieron porque el codigo ya existe", "¡Enhorabuea!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        List<Factura> ImportarDatos(string nombrearchivo)
        {
            List<Factura> lista = new List<Factura>();

            try
            {
                SLDocument sl = new SLDocument(nombrearchivo);

                int iRow = 2;
                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                {
                    Factura factura = new Factura();
                    factura.Idfactura = sl.GetCellValueAsInt32(iRow, 1);
                    factura.Cantidad = sl.GetCellValueAsInt32(iRow, 2);
                    factura.Costo = sl.GetCellValueAsDouble(iRow, 3);
                    factura.Producto = sl.GetCellValueAsString(iRow, 4);
                    factura.Descripcion_mano_obra = sl.GetCellValueAsString(iRow, 5);
                    factura.Valor_mano_obra = sl.GetCellValueAsDouble(iRow, 6);
                    factura.Costo_total = sl.GetCellValueAsDouble(iRow, 7);

                    lista.Add(factura);
                    iRow++;
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Error al importar " + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
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
                errorProvider1.SetError(txtCantidad, "En este campo sólo se permiten numeros");
            }
        }

        private void txtexistencia_KeyPress(object sender, KeyPressEventArgs e)
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
                errorProvider1.SetError(txtCrepuesto, "En este campo sólo se permiten numeros");
            }
        }

        private void txtpcompra_KeyPress(object sender, KeyPressEventArgs e)
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
                errorProvider1.SetError(txtValormano, "En este campo sólo se permiten numeros");
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
                        sl.SetCellValue(iR, 1, Convert.ToInt32(row.Cells[0].Value.ToString()));
                        sl.SetCellValue(iR, 2, Convert.ToInt32(row.Cells[1].Value.ToString()));
                        sl.SetCellValue(iR, 3, Convert.ToDouble(row.Cells[2].Value.ToString()));
                        sl.SetCellValue(iR, 4, row.Cells[3].Value.ToString());
                        sl.SetCellValue(iR, 5, row.Cells[4].Value.ToString());
                        sl.SetCellValue(iR, 6, Convert.ToDouble(row.Cells[5].Value.ToString()));
                        sl.SetCellValue(iR, 7, Convert.ToDouble(row.Cells[6].Value.ToString()));

                        iR++;
                    }
                    sl.SaveAs(outputFile);
                    if (outputFile != "..\\..\\Datos\\facturas.xlsx")
                    {
                        MessageBox.Show("Archivo exportado correctamente", "¡Enhorabuea!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnexportar_Click(object sender, EventArgs e)
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //validaciones
            BorrarMensaje();
            if (validaciones())
            {
                if (validador != -1)
                {
                    try
                    {
                        Factura factura = new Factura();
                        codigo = Convert.ToInt32(contid.Text);
                        factura.Idfactura = Convert.ToInt32(contid.Text);
                        factura.Cantidad = int.Parse(txtCantidad.Text);
                        factura.Costo = Convert.ToDouble(txtCrepuesto.Text);
                        factura.Valor_mano_obra = Double.Parse(txtValormano.Text);
                        factura.Costo_total = Math.Round((factura.Costo * factura.Cantidad) + factura.Valor_mano_obra, 2);
                        factura.Descripcion_mano_obra = txtdescripcion.Text;
                        factura.Producto = cmbProductos.Text;
                        //Esto lo tenía para ver que el dato correcto se estaba borrando  MessageBox.Show(dui);

                        //Creo un nuevo objeto del tipo lista
                        lista.Editar(codigo, factura);
                        //Reinicio los validadores
                        ActualizarDataGrid(lista);
                        reseteo();
                        //Hago que el validador sea nuevamente -1 y el dui le doy un valor nulo
                        validador = -1;
                        codigo = 0;
                        btnagregar.Enabled = true;
                        btnEditar.Enabled = false;

                        //Actualizamos el archivo
                        //actualizamos el archivo de inventario
                        string nombrearchivo = "..\\..\\Datos\\facturas.xlsx";
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
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una row primero");
                }
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos", "¡Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        
        private void dgvmostrar_DoubleClick(object sender, EventArgs e)
        {
            if (dgvmostrar.Rows.Count > 0)
            {
                
                if (FormLogin.user == "ADMIN")
                {
                    try
                    {
                        btnagregar.Enabled = false;
                        btnEditar.Enabled = true;
                        string Chosen_file2 = "";
                        //Le paso los datos del datagrid a los textbox
                        validador = dgvmostrar.Rows.IndexOf(dgvmostrar.SelectedRows[0]);
                        contid.Text = dgvmostrar.Rows[validador].Cells[0].Value.ToString();
                        txtCantidad.Text = dgvmostrar.Rows[validador].Cells[1].Value.ToString();
                        txtCrepuesto.Text = dgvmostrar.Rows[validador].Cells[2].Value.ToString();
                        cmbProductos.Text = dgvmostrar.Rows[validador].Cells[3].Value.ToString();
                        txtdescripcion.Text = dgvmostrar.Rows[validador].Cells[4].Value.ToString();
                        txtValormano.Text = dgvmostrar.Rows[validador].Cells[5].Value.ToString();


                        btnEditar.Enabled = true;
                        btnborrar.Enabled = false;
                        btnagregar.Enabled = false;

                        //lblruta.Text = Chosen_file2;

                        //Hago que estos datos no puedan ser modificados, porque son los identificadores unicos de cada trabajador
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error doble click: " + ex.Message);
                    }
                }
            }
        }

        private void dgvmostrar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (FormLogin.user == "ADMIN")
            {
                if (dgvmostrar.SelectedRows.Count > 0 && e.RowIndex != -1)
                {
                    try
                    {
                        reseteo();
                        btnborrar.Enabled = true;
                        btnagregar.Enabled = false;
                        btnEditar.Enabled = false;
                        codigo = int.Parse(dgvmostrar.CurrentRow.Cells["Idfactura"].Value.ToString());

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            if (dgvmostrar.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("¿Seguro que desea eliminar el articulo con codigo " + codigo + "?", "SALIR", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        //Esto lo tenía para ver que el dato correcto se estaba borrando  MessageBox.Show(dui);

                        //Creo un nuevo objeto del tipo lista
                        ListaFactura lista2 = new ListaFactura();

                        //Le paso todos los valores que no sean los que se quieren borrar de la lista global
                        foreach (Factura factura in lista.EnCola(codigo))
                        {
                            lista2.InsertarF(factura);
                        }
                        //Hago que la lista global sea igual a la nueva lista, es decir, que tenga los valores nuevos excepto el borrado
                        lista = lista2;


                        //Actualizo el datagrid
                        ActualizarDataGrid(lista);
                        //Reinicio los validadores
                        validador = -1;
                        reseteo();
                        codigo = 0;
                        btnagregar.Enabled = true;
                        btnEditar.Enabled = false;

                        //Actualizamos el archivo
                        //actualizamos el archivo de inventario
                        string nombrearchivo = "..\\..\\Datos\\facturas.xlsx";
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
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (resultado == DialogResult.No)
                {
                    btnborrar.Enabled = false;
                    dgvmostrar.ClearSelection();
                    reseteo();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila", "¡Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombrearchivo = "..\\..\\Datos\\productos.xlsx";

            try
            {
                SLDocument sl = new SLDocument(nombrearchivo);

                int iRow = 2;
                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                {
                    Inventario inventario = new Inventario();
                    if (cmbProductos.Text == sl.GetCellValueAsString(iRow, 2))
                    {
                        txtCrepuesto.Text = Convert.ToString(sl.GetCellValueAsDouble(iRow, 5));
                    }
                    iRow++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al importar " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contid_Click(object sender, EventArgs e)
        {

        }
    }
}
