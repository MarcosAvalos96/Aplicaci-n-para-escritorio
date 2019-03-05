using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace registro_medicamentos_v1
{
    public partial class Login : Form
    {


        private static string servidor = "localhost"; //IPMODEM F1DBEB1
        private static string puerto = "3306";
        private static string usuario = "root";
        private static string password = "";


        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //condicion para validar que los campos no esten vacios
            if (string.IsNullOrEmpty(textBox_usuario.Text)|| string.IsNullOrEmpty(textBox_pass.Text))
            {
                MessageBox.Show("campos vacios" ,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //se coloca el return para si estan vacios no se brinque al else y muestre otro "mensaje de error"
                return;
            }

                //debido a que la variable "connection" está en la otra clase del form se creo de nuevo la conexion aqui
                MySqlConnection conectar = new MySqlConnection("datasource=" + servidor + ";port=" + puerto + ";username=" + usuario + ";password=" + password);
            //abrimos la conexion de MYQSL
            conectar.Open();
            //creacion de la variable "codigo" de tipo command 
            MySqlCommand codigo = new MySqlCommand();
            //creacio  de la variable "conectanos" para establecer la conexion 
            MySqlConnection conectanos = new MySqlConnection();
            codigo.Connection = conectar;
            //consulta para seleecionar el usuario y pass de la tabla usuario
            codigo.CommandText = ("SELECT usuario,contrasena FROM almacen1.usuarios WHERE usuario = '" + textBox_usuario.Text + "' AND contrasena = '" + textBox_pass.Text + "'; ");
            //variable de tipo datareader para leer los datos
            MySqlDataReader leer = codigo.ExecuteReader();
            //condicion para leer 
            if (leer.Read())
            {
                MessageBox.Show("Usuario registrado");
                Principal abrir = new Principal();
                abrir.Show();
                
                this.Hide();

            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");

            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==Convert.ToChar(Keys.Enter))

            {

                if (string.IsNullOrEmpty(textBox_usuario.Text) || string.IsNullOrEmpty(textBox_pass.Text))
                {




                    MessageBox.Show("campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                MySqlConnection conectar = new MySqlConnection("datasource=" + servidor + ";port=" + puerto + ";username=" + usuario + ";password=" + password);

                conectar.Open();

                MySqlCommand codigo = new MySqlCommand();
                MySqlConnection conectanos = new MySqlConnection();
                codigo.Connection = conectar;
                codigo.CommandText = ("SELECT usuario,contrasena FROM almacen1.usuarios WHERE usuario = '" + textBox_usuario.Text + "' AND contrasena = '" + textBox_pass.Text + "'; ");
                MySqlDataReader leer = codigo.ExecuteReader();
                if (leer.Read())
                {
                    MessageBox.Show("Usuario registrado");
                    Principal abrir = new Principal();
                    abrir.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");

                }


            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
