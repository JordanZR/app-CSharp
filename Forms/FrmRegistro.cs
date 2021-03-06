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

namespace SistemaInventario
{

    public partial class FrmRegistro : Form
    {   
        //VARIABLES GLOBALES
        

        string password;

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

        public FrmRegistro()
        {
            InitializeComponent();
           this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void picBSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
            //texto
        }

        private void picBMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        
        
        private void BtnIngresar(object sender, EventArgs e)
        {
            try
            {
                string usuario = txtUsuario.Text.ToUpper(); //capturamos los valores de usuario y contraseña string 
                password = txtContra.Text;
              
                string url = "..\\..\\usuarios\\" + usuario + ".txt";
                if (File.Exists(url)) //verifica si existe 
                {
                    string contra = "";
                    contra = File.ReadAllText(url);//lee el texto almacenado dentro del archivo 
                    
                    if (contra.Equals(password)) //verifica si contraseña es igual al archivo 
                    {
                        FrmMenu formMenu = new FrmMenu();
                        formMenu.Visible = true;
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("¡Contraseña incorrecta!", "¡Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("¡Usuario incorrecto!", "¡Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();            
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void TxtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //IniciarSesion();
            }
        }

        private void TxtContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //IniciarSesion();
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string contra = txtContra.Text;
            string usuario = txtUsuario.Text.ToUpper();
            if (txtUsuario.Text.Length == 0)
            {
                MessageBox.Show("Debes ingresar un usuario", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if(txtContra.Text.Length == 0)
            {
                MessageBox.Show("Debes completar informacion", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string url = "..\\..\\usuarios\\" + usuario + ".txt";
                if (File.Exists(url)) //verifica que el archive exista 
                {
                    MessageBox.Show("¡Usuario ya existe!", "¡Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtUsuario.Clear(); //limpiamos todos los textbox 
                    txtContra.Clear();
                }
                else
                {
                    File.WriteAllText(url, contra); /*Crea un Nuevo archivo con ese nombre y guarda dentro del archivo el valor del segundo parámetro*/

                    MessageBox.Show("Usuario Registrado con éxito", "¡Enhorabuena!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsuario.Clear();
                    txtContra.Clear();
                }
            }
        }
        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FrmMenu frm = new FrmMenu();
            frm.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
