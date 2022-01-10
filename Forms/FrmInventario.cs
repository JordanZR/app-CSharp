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
    public partial class FrmInventario : Form
    {

        private int validador = -1;
        private int codigo = 0;
        ListaInventario lista = new ListaInventario();

        private string nombre_imagen = "";


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
        public FrmInventario()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void ActualizarDataGrid(ListaInventario lista)
        {
            dgvmostrar.DataSource = null;
            dgvmostrar.DataSource = lista.Mostrar().ToList();
            dgvmostrar.ClearSelection();
            btnborrar.Enabled = false;
        }

        private void reseteo()
        {
            txtCodigo.Focus();
            txtCodigo.ReadOnly = false;
            txtCodigo.Enabled = true;
            txtdescripcion.Clear();
            txtexistencia.Clear();
            txtpcompra.Clear();
            txtpventa.Clear();
            txtCodigo.Clear();
            pbFotoProducto.Image = Image.FromFile("..\\..\\Imagenes\\subir.png");
            btncargar.Text = "Seleccionar foto...";
        }

        
        private void Alumno_Load(object sender, EventArgs e)
        {
            BorrarMensaje();
            try
            {
                string nombrearchivo = "..\\..\\Datos\\productos.xlsx";
                InsertarImportacion(nombrearchivo);
                btnborrar.Enabled = false;
                btnEditar.Enabled = false;
                btnCancelar.Enabled = false;
                pbFotoProducto.Image = Image.FromFile("..\\..\\Imagenes\\subir.png");
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
            if (txtCodigo.Text == "")
            {
                validacion = false;
            }
            if (txtCodigo.MaskFull) { }
            else
            {
                validacion = false;
                errorProvider1.SetError(txtCodigo, "Por favor ingrese el codigo del articulo");
            }
            if (txtexistencia.Text == "")
            {
                validacion = false;
                errorProvider1.SetError(txtexistencia, "Por favor ingrese la cantidad de existencia del articulo");
            }
            if (txtpcompra.Text == "")
            {
                validacion = false;
                errorProvider1.SetError(txtpcompra, "Por favor ingrese el precio de compra del articulo");
            }
            if (txtpventa.Text == "")
            {
                validacion = false;
                errorProvider1.SetError(txtpventa, "Por favor ingrese el precio de venta del articulo");
            }

            if (txtdescripcion.Text == "")
            {
                validacion = false;
                errorProvider1.SetError(txtdescripcion, "Por favor ingrese una descripción del articulo");
            }
           
            return validacion;
        }

        //borrar los mensajes que provee el error provider
        private void BorrarMensaje()
        {
            errorProvider1.SetError(txtCodigo, "");
            errorProvider1.SetError(txtdescripcion, "");
            errorProvider1.SetError(txtexistencia, "");
            errorProvider1.SetError(txtpcompra, "");
            errorProvider1.SetError(txtpventa, "");
            errorProvider1.SetError(txtCodigo, "");
        }
        
        private void btnGuardarA_Click(object sender, EventArgs e)
        {
            //validaciones
            BorrarMensaje();
            if (validaciones())
            {
                //creo un objeto de la clase persona y guardo a través de las propiedades 
                if (btncargar.Text == "Seleccionar foto...")
                {
                    MessageBox.Show("Debe seleccionar una foto", "¡Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Queue<Inventario> cola = new Queue<Inventario>();
                    cola = lista.Mostrar();
                    bool idCodigo = false;

                    foreach (var item in cola)
                    {
                        if (item.Codigo == int.Parse(txtCodigo.Text))
                        {
                            idCodigo = true;
                        }
                    }

                    try
                    {
                        //Faltan validaciones
                        //Ahorita no las he activado porque sino hay que ingresar toooodos estos datos y es tedioso para hacer pruebas

                        //Creo un objeto del tipo trabajador y lleno los datos de este
                        Inventario inventario = new Inventario();
                        inventario.Codigo = int.Parse(txtCodigo.Text);
                        inventario.Descripcion = txtdescripcion.Text;
                        inventario.Existencia = Convert.ToInt32(txtexistencia.Text);
                        inventario.Precio_compra = Math.Round(Double.Parse(txtpcompra.Text), 2);
                        inventario.Precio_venta = Math.Round(Double.Parse(txtpventa.Text), 2);
                        inventario.Ruta_imagen = "..\\..\\Imagenes\\" + (txtCodigo.Text + "-" + txtdescripcion.Text + ".jpg");
                        
                        //Si el validador == -1 significa que un dato será INGRESADO
                        /*if (validador == -1)
                        {*/
                        if (idCodigo == false)
                        {
                            //De ser así, ocupo el método InsertarF y le mando el objeto de tipo trabajador
                            lista.InsertarF(inventario);

                            //COPIAMOS IMAGEN
                            String sourceFile = btncargar.Text;
                            String destinationFile = inventario.Ruta_imagen;
                            try
                            {

                                if (!File.Exists(inventario.Ruta_imagen))
                                {
                                    File.Copy(sourceFile, destinationFile);
                                }
                                else
                                {
                                    MessageBox.Show("Imagen ya existe");
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error " + ex.Message);
                            }
                            
                            //Actualizo el datagrid mandandole la lista con el nuevo dato ingresado
                            ActualizarDataGrid(lista);

                            //Limpio pantalla
                            reseteo();

                            //Actualizamos el archivo
                            //actualizamos el archivo de inventario
                            string nombrearchivo = "..\\..\\Datos\\productos.xlsx";

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
                        else
                        {
                            MessageBox.Show("El codigo ingresado ya existe", "¡Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            else
            {
                MessageBox.Show("Debe ingresar todos los datos", "¡Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        
        private void picBMinimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
        private void txtFoto_Click(object sender, EventArgs e)
        {
            openFD.Title = "Seleccione una imagen";
            openFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFD.FileName = "";
            openFD.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif";

            try
            {
                if (openFD.ShowDialog() == DialogResult.OK)
                {
                    string sourceFile = openFD.FileName;
                    btncargar.Text = sourceFile;

                    FileStream fs = new FileStream(sourceFile, FileMode.Open, FileAccess.Read);
                    pbFotoProducto.Image = Image.FromStream(fs);
                    fs.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        

        private void dgvDatosAlumnos_DoubleClick(object sender, EventArgs e)
        {
            if (dgvmostrar.Rows.Count > 0)
            {
                try
                {
                    string Chosen_file2 = "";
                    //Le paso los datos del datagrid a los textbox
                    validador = dgvmostrar.Rows.IndexOf(dgvmostrar.SelectedRows[0]);

                    codigo = Convert.ToInt32(dgvmostrar.Rows[validador].Cells[0].Value.ToString());
                    txtdescripcion.Text = dgvmostrar.Rows[validador].Cells[1].Value.ToString();

                    nombre_imagen = Path.GetFileName(dgvmostrar.Rows[validador].Cells[2].Value.ToString());
                    Chosen_file2 = dgvmostrar.Rows[validador].Cells[2].Value.ToString();

                    try
                    {
                        System.IO.FileStream fs = new System.IO.FileStream(Chosen_file2, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        pbFotoProducto.Image = System.Drawing.Image.FromStream(fs);
                        fs.Close();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show("La ruta de la imagen no existe. Modifique la imagen del producto " + Ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    lblruta.Text = Chosen_file2;

                    txtCodigo.Text = Convert.ToString(codigo);


                    txtpcompra.Text = dgvmostrar.Rows[validador].Cells[3].Value.ToString();
                    txtpventa.Text = dgvmostrar.Rows[validador].Cells[4].Value.ToString();
                    txtexistencia.Text = dgvmostrar.Rows[validador].Cells[5].Value.ToString();

                    btnEditar.Enabled = true;
                    btnborrar.Enabled = false;
                    btnagregar.Enabled = false;
                    btnCancelar.Enabled = true;
                    //Hago que estos datos no puedan ser modificados, porque son los identificadores unicos de cada trabajador
                    txtCodigo.ReadOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        
        private void btnexportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtArchivo.TextLength != 0)
                {
                    Exportar(dgvmostrar,"C:\\" + txtArchivo.Text + ".xlsx");
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

        List<Inventario> ImportarDatos(string nombrearchivo)
        {
            List<Inventario> lista = new List<Inventario>();

            try
            {
                SLDocument sl = new SLDocument(nombrearchivo);
              
                int iRow = 2;
                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow,1)))
                {
                    Inventario inventario = new Inventario();
                    inventario.Codigo = int.Parse(sl.GetCellValueAsString(iRow, 1));
                    inventario.Descripcion = sl.GetCellValueAsString(iRow, 2);
                    inventario.Ruta_imagen = sl.GetCellValueAsString(iRow, 3);
                    inventario.Precio_compra = sl.GetCellValueAsDouble(iRow, 4);
                    inventario.Precio_venta = sl.GetCellValueAsDouble(iRow, 5);
                    inventario.Existencia = int.Parse(sl.GetCellValueAsString(iRow, 6));
                    
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

        private void Exportar(DataGridView datalistado, string outputFile)
        {
            if (datalistado.RowCount > 0 && File.Exists(outputFile)!= true)
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
                        sl.SetCellValue(iR, 2, row.Cells[1].Value.ToString());
                        sl.SetCellValue(iR, 3, row.Cells[2].Value.ToString());
                        sl.SetCellValue(iR, 4, Convert.ToDouble(row.Cells[3].Value.ToString()));
                        sl.SetCellValue(iR, 5, Convert.ToDouble(row.Cells[4].Value.ToString()));
                        sl.SetCellValue(iR, 6, Convert.ToInt32(row.Cells[5].Value.ToString()));
                        iR++;
                    }

                    sl.SaveAs(outputFile);
                    if (outputFile != "..\\..\\Datos\\productos.xlsx")
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
                /*MessageBox.Show("Solo se admiten numeros", "validación de numeros",
               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);*/
                errorProvider1.SetError(txtCodigo, "En este campo sólo se permiten numeros");
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
            //si no cumple nada de lo anterior que no lo deje pasar
            else
            {
                e.Handled = true;
                /*MessageBox.Show("Solo se admiten numeros", "validación de numeros",
               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);*/
                errorProvider1.SetError(txtexistencia, "En este campo sólo se permiten numeros");
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
                /*MessageBox.Show("Solo se admiten numeros", "validación de texto",
               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);*/
                errorProvider1.SetError(txtpcompra, "En este campo sólo se permiten numeros");
            }
        }

        private void txtpventa_KeyPress(object sender, KeyPressEventArgs e)
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
                /*MessageBox.Show("Solo se admiten numeros", "validación de texto",
               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);*/
                errorProvider1.SetError(txtpventa, "En este campo sólo se permiten numeros");
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
                        ListaInventario lista2 = new ListaInventario();

                        //Le paso todos los valores que no sean los que se quieren borrar de la lista global
                        foreach (Inventario inventario in lista.EnCola(codigo))
                        {
                            lista2.InsertarF(inventario);
                        }
                        //Hago que la lista global sea igual a la nueva lista, es decir, que tenga los valores nuevos excepto el borrado
                        lista = lista2;


                        //Borramos imagen
                        try
                        {
                            if (System.IO.File.Exists(dgvmostrar.CurrentRow.Cells["Ruta_imagen"].Value.ToString()))
                            {
                                System.IO.File.Delete(dgvmostrar.CurrentRow.Cells["Ruta_imagen"].Value.ToString());
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al borrar imagen " + ex.Message);
                        }


                        //Actualizo el datagrid
                        ActualizarDataGrid(lista);
                        //Reinicio los validadores
                        validador = -1;
                        reseteo();
                        codigo = 0;
                        btnagregar.Enabled = true;
                        btnEditar.Enabled = false;
                        btnborrar.Enabled = false;

                        //Actualizamos el archivo
                        //actualizamos el archivo de inventario
                        string nombrearchivo = "..\\..\\Datos\\productos.xlsx";

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //validaciones
            BorrarMensaje();
            if (validaciones())
            {
                try
                {
                    Inventario inventario = new Inventario();
                    inventario.Codigo = int.Parse(txtCodigo.Text);
                    inventario.Descripcion = txtdescripcion.Text;
                    inventario.Existencia = Convert.ToInt32(txtexistencia.Text);
                    inventario.Precio_compra = Math.Round(Double.Parse(txtpcompra.Text), 2);
                    inventario.Precio_venta = Math.Round(Double.Parse(txtpventa.Text), 2);
                    inventario.Ruta_imagen = "..\\..\\Imagenes\\" + (txtCodigo.Text + "-" + txtdescripcion.Text + ".jpg");

                    
                    if (btncargar.Text != "Seleccionar foto...")
                    {
                        try
                        {
                            if (File.Exists(lblruta.Text))
                            {
                                File.Delete(lblruta.Text);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al borrar imagen " + ex.Message);
                        }
                        
                        String sourceFile = btncargar.Text;
                        String destinationFile = inventario.Ruta_imagen;

                        try
                        {
                            if (!File.Exists(inventario.Ruta_imagen))
                            {
                                File.Copy(sourceFile, destinationFile);
                            }
                            else
                            {
                                MessageBox.Show("Imagen ya existe");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        inventario.Ruta_imagen = lblruta.Text;
                    }

                    //Caso contrario, significa que el usuario está modificando un trabajador existente
                    //Hago que estos campos ahora sean modificables para cuando quiere ingresar un nuevo dato
                    txtCodigo.ReadOnly = false;
                    txtdescripcion.ReadOnly = false;
                    txtexistencia.ReadOnly = false;
                    txtpcompra.ReadOnly = false;
                    txtpventa.ReadOnly = false;

                    //Ocupo el método editar y le mando como parametro el DUI del trabajador a modificar y el objeto de tipo trabajador
                    lista.Editar(codigo, inventario);
                    //Actualizo el datagrid
                    ActualizarDataGrid(lista);
                    reseteo();
                    //Hago que el validador sea nuevamente -1 y el dui le doy un valor nulo
                    validador = -1;
                    codigo = 0;
                    
                    //Actualizamos el archivo
                    //actualizamos el archivo de inventario
                    string nombrearchivo = "..\\..\\Datos\\productos.xlsx";

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
                catch (Exception Ex)
                {
                    MessageBox.Show("Error al modificar registro " + Ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos", "¡Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void InsertarImportacion(string ruta)
        {
            try
            {
                List<Inventario> lst = new List<Inventario>();
                lst = ImportarDatos(ruta);
                bool excelVacio = false;
                bool idCodigo = false;
                foreach (var item in lst)
                {
                    excelVacio = true;
                    Inventario inventario = new Inventario();
                    inventario.Codigo = Convert.ToInt32(item.Codigo.ToString());
                    inventario.Descripcion = item.Descripcion.ToString();
                    inventario.Ruta_imagen = item.Ruta_imagen.ToString();
                    inventario.Precio_compra = item.Precio_compra;
                    inventario.Precio_venta = item.Precio_venta;
                    inventario.Existencia = Convert.ToInt32(item.Existencia.ToString());

                    //Esto es para validar que no se ingrese un registro con codigo ya existente en la lista
                    Queue<Inventario> cola = new Queue<Inventario>();
                    cola = lista.Mostrar();

                    if (cola.Count == 0)
                    {
                        lista.InsertarF(inventario);
                    }
                    else
                    {

                        if (cola.Contains(item))
                        {

                        }
                        foreach (var item2 in cola)
                        {
                            if (item2.Codigo == inventario.Codigo)
                            {
                                idCodigo = true;
                                break;
                            }
                        }
                        if (idCodigo == false)
                        {
                            lista.InsertarF(inventario);
                        }
                    }
                    //***********************************************************
                }

                if (ruta != "..\\..\\Datos\\productos.xlsx")
                {
                    if (excelVacio == true && idCodigo == false)
                    {
                        ActualizarDataGrid(lista);
                        MessageBox.Show("Archivo importado correctamente", "¡Enhorabuea!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        //Actualizamos el archivo
                        //actualizamos el archivo de inventario
                        string nombrearchivo = "..\\..\\Datos\\productos.xlsx";

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

        private void btnimportar_Click(object sender, EventArgs e)
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

        private void dgvmostrar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvmostrar.SelectedRows.Count > 0 && e.RowIndex != -1)
            {
                try
                {
                    reseteo();
                    btnCancelar.Enabled = true;
                    btnborrar.Enabled = true;
                    btnagregar.Enabled = false;
                    btnEditar.Enabled = false;
                    txtCodigo.Enabled = true;
                    txtCodigo.ReadOnly = false;
                    codigo = int.Parse(dgvmostrar.CurrentRow.Cells["Codigo"].Value.ToString());
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            reseteo();
            btnagregar.Enabled = true;
            btnEditar.Enabled = false;
            btnborrar.Enabled = false;
            btnCancelar.Enabled = false;
            dgvmostrar.ClearSelection();
        }
    }
}
