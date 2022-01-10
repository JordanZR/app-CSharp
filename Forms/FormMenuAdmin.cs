using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace SistemaInventario
{
    public partial class FrmMenu : Form
    {
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

        public FrmMenu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void FormMenuPrueba_Load(object sender, EventArgs e)
        {
            lblUser.Text = FormLogin.user;
            if (FormLogin.user != "ADMIN")
            {
                btnRegistrar.Enabled = false;
            }
            else
            {
                btnRegistrar.Enabled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Seguro que desea salir?", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(resultado == DialogResult.Yes)
            {
                this.Hide();
                FormLogin login = new FormLogin();
                login.Show();
            }
            else if(resultado == DialogResult.No)
            {
                MessageBox.Show("Continue con su sesión...", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormMenuPrueba_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void picBMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnTrabajadores_Click(object sender, EventArgs e)
        {
            FrmTrabajadores form = new FrmTrabajadores();
            form.Show();
            this.Hide();
        }
        
       

      

        

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            FormCreditos form = new FormCreditos();
            form.Show();
            this.Hide();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            FrmInventario form = new FrmInventario();
            form.Show();
            this.Hide();
        }

        private void btnFacturas_Click_1(object sender, EventArgs e)
        {
            FrmFactura form = new FrmFactura();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmRegistro form = new FrmRegistro();
            form.Show();
            this.Hide();
        }
    }
}
