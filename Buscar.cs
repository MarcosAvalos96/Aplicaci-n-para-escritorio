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
using System.Globalization;

namespace registro_medicamentos_v1
{
    public partial class Buscar : Form
    {
        public Buscar()
        {
            InitializeComponent();
        }

        private static string servidor = "localhost"; //ipcompu de mi carnal
        private static string puerto = "3306";
        private static string usuario = "jj";
        private static string password = "jotajota";
        //Aquí se crea la conexion //Conexion con el local host
        private static MySqlConnection connection = new MySqlConnection("datasource=" + servidor + ";port=" + puerto + ";username=" + usuario + ";password=" + password);


        //variables para los resultados de busqueda en tiempo real
        DataSet resultados = new DataSet();
        DataView mifiltro;


        //metodo para la busqueda en tiempo real
        public void leer_datos(string query, ref DataSet dstprincipal, string tabla)

        {

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dstprincipal, tabla);
                da.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }


        private void Buscar_Load(object sender, EventArgs e)
        {

            //al momento  de que el programa carga el form se llena el datagridview con los datos de la tabla especificada
            this.leer_datos("SELECT ID,Clave_Producto,Nombre_Producto,Presentacion,Inventario_Final  FROM almacen1.inventario", ref resultados, "inventario");
            this.mifiltro = ((DataTable)resultados.Tables["inventario"]).DefaultView;
            this.dataGridView1.DataSource = mifiltro;

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {


            string salida_datos = "";
            string[] palabras_busqueda = this.textBox1.Text.Split(' ');
            //ciclo for 
            foreach (string palabra in palabras_busqueda)
            {
                if (salida_datos.Length == 0)
                {
                    salida_datos = "(Nombre_Producto LIKE '%" + palabra + "%')";

                }

                else
                {
                    salida_datos += "AND (Nombre_Producto LIKE '%" + palabra + "%')";

                }
            }

            this.mifiltro.RowFilter = salida_datos;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //AQUI VOY A LLAMAR A LA CLASE DEL KEYPRESS
            Validar.SoloLetras(e);
        }
    }
}
