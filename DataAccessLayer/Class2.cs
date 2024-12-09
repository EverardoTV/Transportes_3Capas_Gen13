using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal class metodos_datos
    {
        //método para ejecutar un dataset
        //Utilizado para ejecutar una consulta SQL que devuelve un conjunto de datos
        //que puede contener una  varias tablas con filas y columnas de datos

        public static DataSet execute_DataSet(string sp, params object[] parametros)
        {
            //Instanciamos un DS (Data Set) => Objeto de ADO (Access Data Object)
            DataSet ds = new DataSet();
            //obtenemos la cadena de conexion
            string conn = configuracion.CadenaConexion;
            //creamos una conexion => SqlConnection Objeto de ADO
            SqlConnection SQLcon = new SqlConnection(conn);
            try
            {
                //verificamos si la conexion está abierta
                if (SQLcon.State == ConnectionState.Open)
                {
                    //Cerramos la conexion
                    SQLcon.Close();
                }
                else
                {
                    //comando para SQL (sp, conexión) => SqlCommand objeto ADO
                    SqlCommand cmd = new SqlCommand(sp, SQLcon);
                    //defino que el comando será ejecutado como una SP(Stored Procedure)
                    cmd.CommandType = CommandType.StoredProcedure;
                    //Pasamos el SP
                    cmd.CommandText = sp;

                    //validamos si existen y están completos los parámetros.
                    //si es diferente de null y su residuo es diferente de 0
                    //parametros = { clave : valor }
                    if(parametros != null && parametros.Length % 2 != 0)
                    {
                        throw new Exception("Los parametros deben estar en pares (clave : valor)");
                    }
                    else
                    {
                        //asignamos los parámetros al comando
                        for(int i = 0; 1 < parametros.Length; i++)
                        {
                            //SqlParameter => Objeto de ADO
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());
                        }

                        //abrimos la conexion
                        SQLcon.Open();
                        //ejecutamos el comando
                        //SqlDataAdapter => Objeto de ADO
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        //Llenamos el ds
                        adapter.Fill(ds);
                        //Cerraos la conexón
                        SQLcon.Close();
                    }


                }
                //Retorno el DS(Data Set)
                return ds;

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                //Verificamos si la conexion está abierta
                if (SQLcon.State == ConnectionState.Open)
                {
                    //Cerramos la conexion
                    SQLcon.Close();
                }

            }
        }
        
        //Método que ejecuta un escalar
        //Ejecuta una cosulta SQL que devuelve un solo valor o una sola columna de datos.
        //Retorna el valor de la primera columna y la primera fila del conjunto de resultado

        public static int execute_Scalar(string sp, params object[] parametros)
        {
            //Instanciamos un DS (Data Set) => Objeto de ADO (Access Data Object)
            int id = 0;
            //obtenemos la cadena de conexion
            string conn = configuracion.CadenaConexion;
            //creamos una conexion => SqlConnection Objeto de ADO
            SqlConnection SQLcon = new SqlConnection(conn);
            try
            {
                //verificamos si la conexion está abierta
                if (SQLcon.State == ConnectionState.Open)
                {
                    //Cerramos la conexion
                    SQLcon.Close();
                }
                else
                {
                    //comando para SQL (sp, conexión) => SqlCommand objeto ADO
                    SqlCommand cmd = new SqlCommand(sp, SQLcon);
                    //defino que el comando será ejecutado como una SP(Stored Procedure)
                    cmd.CommandType = CommandType.StoredProcedure;
                    //Pasamos el SP
                    cmd.CommandText = sp;

                    //validamos si existen y están completos los parámetros.
                    //si es diferente de null y su residuo es diferente de 0
                    //parametros = { clave : valor }
                    if (parametros != null && parametros.Length % 2 != 0)
                    {
                        throw new Exception("Los parametros deben estar en pares (clave : valor)");
                    }
                    else
                    {
                        //asignamos los parámetros al comando
                        for (int i = 0; 1 < parametros.Length; i++)
                        {
                            //SqlParameter => Objeto de ADO
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());
                        }

                        //abrimos la conexion
                        SQLcon.Open();
                        //ejecutamos el comando
                        //SqlDataAdapter => Objeto de ADO
                        id = int.Parse(cmd.ExecuteScalar().ToString());
                        //Cerraos la conexón
                        SQLcon.Close();
                    }


                }
                //Retorno el DS(Data Set)
                return id;

            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                //Verificamos si la conexion está abierta
                if (SQLcon.State == ConnectionState.Open)
                {
                    //Cerramos la conexion
                    SQLcon.Close();
                }

            }
        }

        //Método que ejecuta un Nonquery
        //Utilizado para ejecutar consultas SQL que no devuelven un conjunto de resultados.
        //Como sentencias INSERT, UPDATE o DELETE
        //Retorna un valor entero que representa el número de filas afectadas por la operación.
        //(Por ejemplo, el número de filas insertadas, actualizadas o eliminadas).

        public static int execute_nonQuery(string sp, params object[] parametros)
        {
            //Instanciamos un DS (Data Set) => Objeto de ADO (Access Data Object)
            int id = 0;
            //obtenemos la cadena de conexion
            string conn = configuracion.CadenaConexion;
            //creamos una conexion => SqlConnection Objeto de ADO
            SqlConnection SQLcon = new SqlConnection(conn);
            try
            {
                //verificamos si la conexion está abierta
                if (SQLcon.State == ConnectionState.Open)
                {
                    //Cerramos la conexion
                    SQLcon.Close();
                }
                else
                {
                    //comando para SQL (sp, conexión) => SqlCommand objeto ADO
                    SqlCommand cmd = new SqlCommand(sp, SQLcon);
                    //defino que el comando será ejecutado como una SP(Stored Procedure)
                    cmd.CommandType = CommandType.StoredProcedure;
                    //Pasamos el SP
                    cmd.CommandText = sp;

                    //validamos si existen y están completos los parámetros.
                    //si es diferente de null y su residuo es diferente de 0
                    //parametros = { clave : valor }
                    if (parametros != null && parametros.Length % 2 != 0)
                    {
                        throw new Exception("Los parametros deben estar en pares (clave : valor)");
                    }
                    else
                    {
                        //asignamos los parámetros al comando
                        for (int i = 0; 1 < parametros.Length; i++)
                        {
                            //SqlParameter => Objeto de ADO
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());
                        }

                        //abrimos la conexion
                        SQLcon.Open();
                        //ejecutamos el comando
                        //SqlDataAdapter => Objeto de ADO
                        cmd.ExecuteNonQuery();
                        id = 1;
                        //Cerraos la conexón
                        SQLcon.Close();
                    }


                }
                //Retorno el DS(Data Set)
                return id;

            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                //Verificamos si la conexion está abierta
                if (SQLcon.State == ConnectionState.Open)
                {
                    //Cerramos la conexion
                    SQLcon.Close();
                }

            }
        }

    }

}
