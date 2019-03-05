using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace registro_medicamentos_v1
{
    public partial class eliminar_usuario : Form
    {
        public eliminar_usuario()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_id_us.Text))
            {
                MessageBox.Show("Debe llenar el recuadro para borrar un usuario");
                return;
            }

            MySql.conectar();
            MySql.eliminar_usuario ((textBox_id_us.Text));
            MySql.cerrarconexion();




        }
    }
}
