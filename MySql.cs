using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace registro_medicamentos_v1
{
    // clave wifi  114AD6DE9A
    class MySql
    {
        // Atributos
        private static string servidor = "localhost"; //ipcompu de mi carnal
        private static string puerto = "3306";
        private static string usuario = "root";
        private static string password = "";
        //Aquí se crea la conexion //Conexion con el local host
        private static MySqlConnection connection = new MySqlConnection("datasource=" + servidor + ";port=" + puerto + ";username=" + usuario + ";password=" + password);
        //Metodo para abrir la conexion
        static public void conectar()
        {
            connection.Open();
        }

        //Metodo para cerrar la conexion
        static public void cerrarconexion()
        {
            connection.Close();
        }
        /*****************************************************************************************************************************************   
        ***************************************************************************************************************************************** 
        ***************************************************************************************************************************************** 
        ***************************************************************************************************************************************** 
        ***************************************************************************************************************************************** 
        ***************************************************************************************************************************************** 
        ***************************************************************************************************************************************** 
        ***************************************************************************************************************************************** 
        ***************************************************************************************************************************************** 
        ***************************************************************************************************************************************** 
        *****************************************************************************************************************************************       
            */
     
        //Metodo para insertar el medicamento nuevo  INSERTAR NUEVO NUEVO //Metodo para insertar el medicamento nuevo  INSERTAR NUEVO NUEVO
        static public void insertar(string clave, string nombre_producto , string presentacion, int total)
        {
            //try para poder mostrar errores con mensaje si hay alguna error al momento de ejecutar el insert
            try
            {
                //Cadena para la consulta inserta
                string insertQuery = "INSERT INTO almacen1.inventario (`Clave_Producto`, `Nombre_Producto`, `Presentacion`, `Inventario_Final`) VALUES('" + clave + "','" + nombre_producto + "','" + presentacion + "','" + total + "')";
                //Creacion de la variable "command" de tipo MySqlCommand
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Producto Agregado Correctamente");
                }
                else
                {
                    MessageBox.Show("Producto no agregado, intente nuevamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //****************************************************************************************************************************************************************************************************
        //Metodo para eliminar un medicamentoELIMINAR_ELIMINAR_ELIMINAR  //Metodo para eliminar un medicamentoELIMINAR_ELIMINAR_ELIMINAR  //Metodo para eliminar un medicamentoELIMINAR_ELIMINAR_ELIMINAR
        static public void eliminar(int id)
        {
            //try para poder mostrar errores con mensaje si hay alguna error al momento de ejecutar el insert
            try
            {
                //Cadena para la consulta borrar        
                string deleteQuery = "DELETE FROM almacen1.inventario WHERE Clave_Producto = ('" +id+ "')";
                //creaciond de la variable commando de tipo MySqlCommand
                MySqlCommand command = new MySqlCommand(deleteQuery, connection);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("producto borrado correctamente");                 
                }
                else
                {
                    MessageBox.Show("No se borró correctamente, no está en el inventario");
                }
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Este producto no está en el inventario, intente nuevamente");
            }
            
        }


        //*************************************************************************************************************************************************************************************************************************************+
        //metodo que hace la suma del inventario SUMA SUMA SUMA SUMA SUMA   //metodo que hace la suma del inventario SUMA SUMA SUMA SUMA SUMA 
         //Metodo para actualizar y sumar entradas del medicamento
        static public void actualizar_sumar(int clave_pro, string fecha_entrada,string procedencia, string descripcion,int cantidad)
        {

            //En este metodo falta insertar la entradas a la tabla entradas

            //try para poder mostrar errores con mensaje si hay alguna error al momento de ejecutar el
            try
            {

                //CONSULTA para actualizar/ sumar el inventario total con un UPDATE
                string selectquery = "UPDATE almacen1.inventario SET Inventario_Final = Inventario_Final + "+cantidad+"   WHERE Clave_Producto = '"+clave_pro+"' ";
                //Consulta para insertar en la tabla entradas como tipo "bitacora"
                string insertQuery = "INSERT INTO almacen1.entradas (Clave_Producto,Fecha_Entrada,Lugar_Procedencia,Descripcion,Cantidad) VALUES ('" + clave_pro + "','"+fecha_entrada+ "','" + procedencia + "','" + descripcion + "','" +cantidad + "') ";
                //creacion de la variable para el select commando de tipo MySqlCommand
                MySqlCommand commandselect = new MySqlCommand(selectquery, connection);
                //creacion de la variable para el insert commando de tipo MySqlCommand
                MySqlCommand commandinsert = new MySqlCommand(insertQuery, connection);
                if (commandselect.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Se Sumo la entrada de producto");
                }
                else
                {
                    MessageBox.Show("No se actualizo correctamento, este producto no esta en el inventario");
                }
                if (commandinsert.ExecuteNonQuery() == 1)
                {
                   MessageBox.Show("Se registró la entrada correctamente");
                }
                else
                {
                   MessageBox.Show("No se registró la entrada");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("SE ACTUALIZÓ LA ENTRADA DE PRODUCTO CORRECTAMENTE");
            }
            connection.Close();


        }

        //************************************************************************************************************************************************************************************************************************+
        //Metodo para restar la salida de medicamento
        static public void actualizar_restar(int clave_producto ,string fecha_salida,int clave_departamento,int cantidad)
        {


            try
            {

                //CONSULTA para actualizar/ restar el inventario total con un UPDATE
                string selectquery = "UPDATE almacen1.inventario SET Inventario_Final = Inventario_Final - " + cantidad + "   WHERE Clave_Producto = '" + clave_producto + "' ";
                //Consulta para insertar en la tabla salidas como tipo "bitacora"
                string insertQuery = "INSERT INTO almacen1.salidas (Clave_Producto, Fecha_salida, Clave_Departamento,Cantidad_Salidas) VALUES ('" + clave_producto + "','" + fecha_salida +"','"+clave_departamento + "','" + cantidad + "') ";
                //creacion de la variable para el select commando de tipo MySqlCommand
                MySqlCommand command = new MySqlCommand(selectquery, connection);
                //creacion de la variable para el insert commando de tipo MySqlCommand
                MySqlCommand commandsalidas = new MySqlCommand(insertQuery, connection);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Se Restó la salida de Producto");
                }
                else
                {
                    MessageBox.Show("No se actualizo correctamente, ese producto no esta en el inventario");
                }

                if (commandsalidas.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Se guardó la salida correctamente en la tabla");
                }
                else
                {
                    MessageBox.Show("No se guardo la salida en la tabla");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();


        }
        //**************************************************************************************************************************************************************************++
        //metodo para actualizar el total de un medicamento
        static public void actualizar_total(int clave_productof, int cantidad)
        {

            //cadena para la consulta update del inventario total de un medicamento
            string updateQuery = "UPDATE almacen1.inventario SET Inventario_Final = '" +cantidad + "' WHERE Clave_Producto = ('" + clave_productof + "')";

            try
            {
                //creacion de la variable command para la consultad UPDATE
                MySqlCommand command = new MySqlCommand(updateQuery, connection);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Se actualizo la cantidad total del producto");
                }
                else
                {
                    MessageBox.Show("No se actualizo correctamento, ese producto no esta en el inventario");
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }


       
        //**************************************************************************************************************************************************************************++
        //metodo para insertar un usuario
        static public void insertar_usuario(string usuario, string pass)
        {

            //MADE BY DUY
            //try para poder mostrar errores con mensaje si hay alguna error al momento de ejecutar el insert
            try
            {
                //Cadena para la consulta inserta
                string insertQuery = "INSERT INTO almacen1.usuarios ( `usuario`, `contrasena`) VALUES('" + usuario + "','" + pass + "')";
                //Creacion de la variable "command" de tipo MySqlCommand
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("usuario Agregado Correctamente");
                }
                else
                {
                    MessageBox.Show("usuario no agregado, intente nuevamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //**************************************************************************************************************************************************************************++
        //metodo para eliminar un usuario
        static public void eliminar_usuario(string usuario)
        {
            //try para poder mostrar errores con mensaje si hay alguna error al momento de ejecutar el insert
            try
            {
                //Cadena para la consulta borrar        
                string deleteQuery = "DELETE FROM almacen1.usuarios WHERE usuario = ('" + usuario + "')";
                //creaciond de la variable commando de tipo MySqlCommand
                MySqlCommand command = new MySqlCommand(deleteQuery, connection);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("usuario borrado correctamente");
                }
                else
                {
                    MessageBox.Show("No se borró correctamente, no está registado como usuario");
                }
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("No es encuentrá en los usuarios registrados");
            }

        }

       
        






        //************************************************************************************************************************************
        //LLENAR TABLA LLENAR TABLA LLENAR TABLA INVENTARIO
        public static MySqlDataAdapter obtenerdata()
        {
            //creacion de la variable cm para hacer seleccionar que colummnas vas a mostrar en la tabla
            MySqlCommand cm = new MySqlCommand("SELECT Clave_Producto,Nombre_Producto,Presentacion,Inventario_Final FROM almacen1.inventario;", connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            return da;

        }
        //************************************************************************************************************************************
        //LLENAR TABLA LLENAR TABLA LLENAR TABLA SALIDA
        public static MySqlDataAdapter obtener_salidas()
        {
            //creacion de la variable cm para seleccionar que colummnas vas a motrar en la tabla salidas
            MySqlCommand cm = new MySqlCommand("SELECT Clave_Producto,Fecha_Salida,Clave_Departamento,Cantidad_Salidas  FROM almacen1.salidas;", connection);
            MySqlDataAdapter ob_Salidas = new MySqlDataAdapter(cm);
            return ob_Salidas;

        }
        //************************************************************************************************************************************
        //LLENAR TABLA LLENAR TABLA LLENAR TABLA ENTRADAS
        public static MySqlDataAdapter obtener_entradas()
        {
            //creacion de la variable cm para selecionar que columnas mostraras en la tabla entradas
            MySqlCommand cm = new MySqlCommand("SELECT Clave_Producto,Fecha_Entrada,Lugar_Procedencia,Descripcion,Cantidad FROM almacen1.entradas;", connection);
            MySqlDataAdapter ob_Salidas = new MySqlDataAdapter(cm);
            return ob_Salidas;

        }
        //lllenar la tabla USUARIOS
        public static MySqlDataAdapter obtener_usuario()
        {
            //creacion de la variable cm para selecionar que columnas mostraras en la tabla usuarios
            MySqlCommand cm = new MySqlCommand("SELECT usuario, contrasena FROM almacen1.usuarios;", connection);
            MySqlDataAdapter ob_usuarios = new MySqlDataAdapter(cm);
            return ob_usuarios;

        }

        public static MySqlDataAdapter obtener_depa()
        {

            MySqlCommand cm = new MySqlCommand("SELECT ID, nombre_departamento FROM almacen1.departamentos;", connection);
            MySqlDataAdapter ob_depa = new MySqlDataAdapter(cm);
            return ob_depa;

        }



        public static MySqlDataAdapter obtener_reporte_fecha(string fecha1, string fecha2)
        {


            //select sum(cantidad) from libros
           // where editorial = 'Planeta';
            // string selectquery = "SELECT * FROM almacen1.salidas WHERE FECHA_SALIDA BETWEEN ('" + fecha1 + "')AND('" + fecha2 + "')";
            MySqlCommand cm = new MySqlCommand("SELECT * from almacen1.salidas WHERE FECHA_SALIDA BETWEEN('" + fecha1 + "')AND('" + fecha2 + "'); ", connection);
         

            MySqlDataAdapter ob_re_fecha = new MySqlDataAdapter(cm);
           
            return ob_re_fecha;
       
        }



        public static MySqlDataAdapter obtener_suma_total( string clave_pro, string fecha1, string fecha2)
        {
            //SELECT * from almacen1.salidas WHERE (fecha_salida BETWEEN('2017-06-05')AND('2018-12-05')) AND (clave_producto = 1001)
            //SOLO FALTA ESTOOOOO
            //select sum(cantidad) from libros
            // where editorial = 'Planeta';
            // string selectquery = "SELECT * FROM almacen1.salidas WHERE FECHA_SALIDA BETWEEN ('" + fecha1 + "')AND('" + fecha2 + "')";
          // MySqlCommand suma = new MySqlCommand("SELECT * FROM almacen1.salidas WHERE fecha_salida BETWEEN('" + fecha1 + "')AND('" + fecha2 + "') AND (Clave_Producto = '" + clave_pro + "'); ",connection);
            MySqlCommand suma = new MySqlCommand("SELECT clave_producto as clave_del_producto, clave_departamento as clave_de_departamento, sum(cantidad_salidas) as total_de_salidas from almacen1.salidas WHERE fecha_salida BETWEEN('" + fecha1 + "')AND('" + fecha2 + "') AND (Clave_Producto = '" + clave_pro + "'); ", connection);
            // MySqlCommand suma = new MySqlCommand("SELECT  sum(Cantidad_Salidas) from almacen1.salidas WHERE Clave_Producto = ('" + clave_pro + "'); ", connection);

            MySqlDataAdapter suma_total = new MySqlDataAdapter(suma);
          
            return suma_total;

            //FALTA ESTE PARA SUMAR
           // SELECT clave_producto as clave, fecha_salida as salida, clave_departamento as departamento, sum(cantidad_salidas) as cantidad from almacen1.salidas WHERE (fecha_salida BETWEEN('2017-06-05')AND('2018-12-05')) AND(clave_producto = 1001)
        }




        static public void actualizar_presentacion(int clave_productof, string presentacion)
        {

            //cadena para la consulta update del inventario total de un medicamento
            string updateQuery = "UPDATE almacen1.inventario SET presentacion = '" + presentacion + "' WHERE Clave_Producto = ('" + clave_productof + "')";

            try
            {
                //creacion de la variable command para la consultad UPDATE
                MySqlCommand command = new MySqlCommand(updateQuery, connection);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Se actualizo la presentacion del producto");
                }
                else
                {
                    MessageBox.Show("No se actualizo correctamento, ese producto no esta en el inventario");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }








    }










    

}

