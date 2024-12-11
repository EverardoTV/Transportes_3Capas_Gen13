using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using ViewObjects;

namespace BusinesLogicLayer
{
    public class BLL_Camiones
    {
        //Create
        public static string insert_Camion(Camiones_VO camion)
        {
            return DAL_Camiones.accion_Camion(camion);

        }


        //Read
        public static List<Camiones_VO> Get_Camiones(params object[] parametros)
        {
            return DAL_Camiones.Get_Camiones(parametros);
        }


        //Update
        public static string actualizar_Camion(Camiones_VO camion)
        {
            return DAL_Camiones.actualizar_Camion(camion);
        }


        //Delete
        public static string eliminar_Camion(int id)
        {
            return DAL_Camiones.eliminar_Camion(id);
        }
    }
}
