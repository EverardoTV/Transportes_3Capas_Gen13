using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class configuracion
    {
        //Cadena de conexión
        //Data Source = nombre del servidor de BD
        //LocalHost
        //.
        //Nombre de mi instancia
        //Initial Catalog = nombre de la BD
        //Integrated Security = true (Credenciales de la máquina)
        //= false (Credeniales de acceso)
        //Se habilitan los campos de
        //User =;
        //Password =;

        static string _cadenaConexion = @"Data Source = DESKTOP-3KBJO3H\SQLEXPRESS;
                                           Initial Catalog = Transportes;
                                           Integrated Security = true;";

        //Encapsulamiento

        public static string CadenaConexion
        {
            get
            {
                return _cadenaConexion;
            }
        }
    }
}