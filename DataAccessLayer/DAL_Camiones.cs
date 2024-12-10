using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewObjects;

namespace DataAccessLayer
{
    public class DAL_Camiones
    {
        //Create
        public static string accion_Camion(Camiones_VO camion)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_InsertarCamion",
                    "@Matricula", camion.Matricula,
                    "@Tipo_Camion", camion.Tipo_Camion,
                    "@Marca", camion.Marca,
                    "@Modelo", camion.Modelo,
                    "@Capacidad", camion.Capacidad,
                    "@Kilometraje", camion.Kilometraje,
                    "@UrlFoto", camion.UrlFoto,
                    "@Disponibilidad", camion.Disponibilidad
                    );

                if (respuesta != 0)
                {
                    salida = "Camión registrado con éxito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e) 
            {
                //Salida = "Error: " + e.Message;
                salida = $"Error: {e.Message}";
            }
            return salida;
        }






        //Read
        public static List<Camiones_VO> Get_Camiones(params object[] parametros)
        {
            //creo una lista de objetos VO
            List<Camiones_VO> list = new List<Camiones_VO>();
            try
            {
                //Creo un DataSet el cuál recibirá lo que devuelva la ejecución del método "execute_DataSet" de la clase "metodos_datos"
                DataSet ds_camiones = metodos_datos.execute_DataSet("SP_listar_camiones", parametros);
                //Recorro cada renglón existente de nuestro ds creando objetos del tipo VO y añadiéndolos a la lista
                foreach(DataRow dr in ds_camiones.Tables[0].Rows)
                {
                    list.Add(new Camiones_VO(dr));
                }
                return list;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        //Update
        public static string actualizar_Camion(Camiones_VO camion)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_ActualizarCamion",
                    "@Matricula", camion.Matricula,
                    "@Tipo_Camion", camion.Tipo_Camion,
                    "@Marca", camion.Marca,
                    "@Modelo", camion.Modelo,
                    "@Capacidad", camion.Capacidad,
                    "@Kilometraje", camion.Kilometraje,
                    "@UrlFoto", camion.UrlFoto,
                    "@Disponibilidad", camion.Disponibilidad
                    );

                if (respuesta != 0)
                {
                    salida = "Camión actualizado con éxito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                //Salida = "Error: " + e.Message;
                salida = $"Error: {e.Message}";
            }
            return salida;
        }



        //Delete

        public static string eliminar_Camion(int id)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_EliminarCamion",
                    "@Id_Camion", id
                    );

                if (respuesta != 0)
                {
                    salida = "Camión eliminado con éxito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                //Salida = "Error: " + e.Message;
                salida = $"Error: {e.Message}";
            }
            return salida;
        }

        public static string insert_Camion(Camiones_VO camion)
        {
            throw new NotImplementedException();
        }
    }
}
