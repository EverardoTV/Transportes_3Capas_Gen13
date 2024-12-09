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



        //Read
        public static List<Camiones_VO> Get_Camiones(params object[] parametros)
        {
            return DAL_Camiones.Get_Camiones(parametros);
        }


        //Update



        //Delete
    }
}
