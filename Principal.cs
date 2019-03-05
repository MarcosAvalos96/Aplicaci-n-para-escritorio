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
using System.Drawing.Printing;
using System.Drawing;


namespace registro_medicamentos_v1
{
    public partial class Principal : Form
    {
        private static string servidor = "localhost"; //ipcompu de mi carnal
        private static string puerto = "3306";
        private static string usuario = "jj";
        private static string password = "jotajota";
        //Aquí se crea la conexion //Conexion con el local host
        private static MySqlConnection connection = new MySqlConnection
            ("datasource=" + servidor + ";port=" + puerto + ";username=" 
            + usuario + ";password=" + password);




        public Principal()
        {
            InitializeComponent();
        }



        private void Principal_Load(object sender, EventArgs e)
        {
            //llenar el datagrid al cargar el form
            llenargrid(MySql.obtenerdata());


        }




        private void button3_Click_2(object sender, EventArgs e)
        {


        }



        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            if (string.IsNullOrEmpty(textBox_clave_delete.Text))
            {
                MessageBox.Show("Primero debes indicar que producto desea eliminar");
                return;
            }



            if (MessageBox.Show("estás seguro que quieres borrar el producto?", " ",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                MySql.conectar();
                MySql.eliminar(Convert.ToInt32(textBox_clave_delete.Text));
                llenargrid(MySql.obtenerdata());
                MySql.cerrarconexion();

            }
            else
                return;






        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_clave_pro_update.Text) || String.IsNullOrEmpty(textBoxCantidad_total_update.Text))
            {
                MessageBox.Show("Debe llenar la informacion para actualizar la cantidad total de un producto");
                return;
            }

            MySql.conectar();
            MySql.actualizar_total(Convert.ToInt32(textBox_clave_pro_update.Text), Convert.ToInt32(textBoxCantidad_total_update.Text));
            llenargrid(MySql.obtenerdata());
            MySql.cerrarconexion();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            llenargrid(MySql.obtenerdata());

        }






        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {


        }



        private void button5_Click(object sender, EventArgs e)
        {


        }





        //BOTON DE SALIDAS INVENTARIO
        private void button6_Click(object sender, EventArgs e)


        {



        }


        //BOTON DE SUMAR ENTRADAS AL INVENTARIO
        private void button5_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox_entradas.Text))

            {

                MessageBox.Show("No has asignado cantidad");
                return;

            }

            //aqui me qUQEDEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE
            MySql.conectar();
            MySql.actualizar_sumar(Convert.ToInt32(textBox_Clave_Pro_Ent.Text), this.dateTimePicker1.Text,textBox_Procendencia.Text, textBox_Descripcion.Text , Convert.ToInt32(textBox_entradas.Text));
            llenargrid(MySql.obtenerdata());
            //limpiar las cajas de texto
            textBox_Clave_Pro_Ent.Clear();
            textBox_entradas.Clear();

            textBox_Descripcion.Clear();

            MySql.cerrarconexion();


        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }




        public void llenargrid(MySqlDataAdapter da)
        {
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        public void llenargrid_salidas(MySqlDataAdapter ob_salidas)
        {
            DataTable tabla_Salidas = new DataTable();
            ob_salidas.Fill(tabla_Salidas);
            dataGridView1.DataSource = tabla_Salidas;


        }

        public void llenargrid_entradas(MySqlDataAdapter ob_entradas)
        {
            DataTable tabla_entrada = new DataTable();
            ob_entradas.Fill(tabla_entrada);
            dataGridView1.DataSource = tabla_entrada;
        }
        public void llenargrid_usuarios(MySqlDataAdapter ob_usuarios)
        {
            DataTable tabla_usuarios = new DataTable();
            ob_usuarios.Fill(tabla_usuarios);
            dataGridView1.DataSource = tabla_usuarios;
        }







        private void button7_Click(object sender, EventArgs e)
        {

        }



        //boton para mostrar todas las salidas
        private void button3_Click_1(object sender, EventArgs e)
        {
            llenargrid_salidas(MySql.obtener_salidas());
        }

        //boton para mostrar todo el inventario
        private void button8_Click(object sender, EventArgs e)
        {
            llenargrid(MySql.obtenerdata());
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login abrir = new Login();
            abrir.Show();
            this.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Application.Exit();
        }

        private void verUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            llenargrid_usuarios(MySql.obtener_usuario());








        }

        private void eliminarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

            eliminar_usuario abrir = new eliminar_usuario();
            abrir.Show();

        }

        private void agregarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregar_Usuario abrir = new Agregar_Usuario();
            abrir.Show();
        }

        private void reporteInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

            llenargrid(MySql.obtenerdata());

        }

        private void reporteEntradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            llenargrid_entradas(MySql.obtener_entradas());
        }

        private void reporteSalidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            llenargrid_salidas(MySql.obtener_salidas());
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {


            PrintDocument doc = new PrintDocument();
            doc.DefaultPageSettings.Landscape = false;
            doc.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            PrintPreviewDialog ppd = new PrintPreviewDialog { Document = doc };
            ((Form)ppd).WindowState = FormWindowState.Maximized;

            doc.PrintPage += delegate (object ev, PrintPageEventArgs ep)
            {
                const int DGV_ALTO = 35;
                int left = ep.MarginBounds.Left, top = ep.MarginBounds.Top;

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {

                    ep.Graphics.DrawString(col.HeaderText, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, left, top);
                    left += col.Width;

                    if (col.Index < dataGridView1.ColumnCount)
                        ep.Graphics.DrawLine(Pens.Gray, left - 5, top, left - 5, top + 43 + (dataGridView1.RowCount + 1) * DGV_ALTO);
                }
                left = ep.MarginBounds.Left;
                ep.Graphics.FillRectangle(Brushes.Black, left, top + 40, ep.MarginBounds.Right - left, 3);
                top += 43;


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Index == dataGridView1.RowCount) break;
                    left = ep.MarginBounds.Left;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        ep.Graphics.DrawString(Convert.ToString(cell.Value), new Font("Arial", 7), Brushes.Black, left, top + 4);
                        left += cell.OwningColumn.Width;
                    }
                    top += DGV_ALTO;
                    ep.Graphics.DrawLine(Pens.Gray, ep.MarginBounds.Left, top, ep.MarginBounds.Right, top);
                }

            };
            ppd.ShowDialog();

        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {

        }

        private void agregarNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            //valir textbox1
            if (string.IsNullOrEmpty(textBox_Clave_Nuevo_Producto.Text) || String.IsNullOrEmpty(textBox_Nombre_Nuevo.Text) || String.IsNullOrEmpty(textBox_presentacion_nuevo.Text) || String.IsNullOrEmpty(textBox_inv_final_nuevo.Text))

            {

                MessageBox.Show("Debe Llenar la informacion completa poder agregar producto nuevo");
                return;

            }



            MySql.conectar();
            MySql.insertar(textBox_Clave_Nuevo_Producto.Text, textBox_Nombre_Nuevo.Text, textBox_presentacion_nuevo.Text, Convert.ToInt32(textBox_inv_final_nuevo.Text));
            llenargrid(MySql.obtenerdata());
            //limpiar las cajas de texto
            textBox_Clave_Nuevo_Producto.Clear();
            textBox_Nombre_Nuevo.Clear();
            textBox_presentacion_nuevo.Clear();
            textBox_inv_final_nuevo.Clear();
            // llenargrid(MySql.obtenerdata());
            MySql.cerrarconexion();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            llenargrid(MySql.obtenerdata());

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            llenargrid(MySql.obtener_salidas());
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            llenargrid_entradas(MySql.obtener_entradas());
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {











        }

        private void button6_Click_1(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(textBox_Salidas.Text))

            {

                MessageBox.Show("No has asignado cantidad");
                return;

            }

            MySql.conectar();
            MySql.actualizar_restar(Convert.ToInt32(textBox_clave_pro_sal.Text), this.dateTimePicker2.Text,Convert.ToInt32(textBox_Clave_Dep.Text), Convert.ToInt32(textBox_Salidas.Text));
            llenargrid(MySql.obtenerdata());
            //limpiar las cajas de texto
            textBox_Clave_Pro_Ent.Clear();
            textBox_entradas.Clear();
            MySql.cerrarconexion();
        }

        private void reporteDepartamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            llenargrid(MySql.obtener_depa());
        }

        private void button3_Click_3(object sender, EventArgs e)
        {
          
            llenargrid(MySql.obtener_reporte_fecha(this.dateTimePicker3.Text, this.dateTimePicker4.Text));
            MySql.cerrarconexion();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Clave_pro_suma.Text))

            {

                MessageBox.Show("Debes llenar el recuadro con la clave del producto");
                return;

            }



            llenargrid(MySql.obtener_suma_total(textBox_Clave_pro_suma.Text,this.dateTimePicker5.Text, this.dateTimePicker6.Text));
            MySql.cerrarconexion();
        }

        private void vaciarSalidasToolStripMenuItem_Click(object sender, EventArgs e)
        {

           




            if (MessageBox.Show("estás seguro que quieres borrar todas las entradas?", "Registradas",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (MySqlConnection cnn = new MySqlConnection("datasource=" + servidor + ";port=" + puerto + ";username="
            + usuario + ";password=" + password))
                using (MySqlCommand cmd = new MySqlCommand("TRUNCATE TABLE almacen1.salidas", cnn))
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("SALIDAS ELIMINADAS CORRECTAMENTE, vuelve a recargar las salidas");

                }
            }
            else
                return;
 


        }

        private void vaciarEntradasToolStripMenuItem_Click(object sender, EventArgs e)
        {




            if (MessageBox.Show("estás seguro que quieres borrar todas las entradas?", "Registradas",
      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (MySqlConnection cnn = new MySqlConnection("datasource=" + servidor + ";port=" + puerto + ";username="
            + usuario + ";password=" + password))
                using (MySqlCommand cmd = new MySqlCommand("TRUNCATE TABLE almacen1.entradas", cnn))
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("ENTRADAS ELIMINADAS CORRECTAMENTE, vuelve a recargar las entradas");
                }

            }
            
            else
                return;

        }

        private void toolStripDropDownButton4_Click(object sender, EventArgs e)
        {
            Buscar abrir = new Buscar();
            abrir.Show();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Debe llenar la informacion para actualizar la presentaion de un producto");
                return;
            }

            MySql.conectar();
            MySql.actualizar_presentacion(Convert.ToInt32(textBox1.Text),textBox2.Text);
            llenargrid(MySql.obtenerdata());
            MySql.cerrarconexion();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este programa fue desarrollado en tiempo de Practicas Profesionales, como personal de autoyuda, y cumple con los requerimientos del sistema establecidos por el personal administrativo que hará uso del mismo.");
            MessageBox.Show("De antemano gracias,Semestre 8° de la facultad de Telemática Enero/Julio 2018. ");
            MessageBox.Show("Made by duy and jj. ");
        }

        private void button9_Click(object sender, EventArgs e)
        {

           

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {



        }

        private void toolStripLabel1_Click_1(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            doc.DefaultPageSettings.Landscape = false;
            doc.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            PrintPreviewDialog ppd = new PrintPreviewDialog { Document = doc };
            ((Form)ppd).WindowState = FormWindowState.Maximized;

            doc.PrintPage += delegate (object ev, PrintPageEventArgs ep)
            {
                const int DGV_ALTO = 35;
                int left = ep.MarginBounds.Left, top = ep.MarginBounds.Top;

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {

                    ep.Graphics.DrawString(col.HeaderText, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, left, top);
                    left += col.Width;

                    if (col.Index < dataGridView1.ColumnCount)
                        ep.Graphics.DrawLine(Pens.Gray, left - 5, top, left - 5, top + 43 + (dataGridView1.RowCount + 1) * DGV_ALTO);
                }
                left = ep.MarginBounds.Left;
                ep.Graphics.FillRectangle(Brushes.Black, left, top + 40, ep.MarginBounds.Right - left, 3);
                top += 43;


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Index == dataGridView1.RowCount) break;
                    left = ep.MarginBounds.Left;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        ep.Graphics.DrawString(Convert.ToString(cell.Value), new Font("Arial", 7), Brushes.Black, left, top + 4);
                        left += cell.OwningColumn.Width;
                    }
                    top += DGV_ALTO;
                    ep.Graphics.DrawLine(Pens.Gray, ep.MarginBounds.Left, top, ep.MarginBounds.Right, top);
                }

            };
            ppd.ShowDialog();




        }
    }
    }

