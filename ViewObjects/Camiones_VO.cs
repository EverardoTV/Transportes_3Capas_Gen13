using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewObjects
{
    public class Camiones_VO
    {
        //
        private int _ID_Camion;
        private string _Matricula;
        private string _Tipo_Camion;
        private string _Marca;
        private string _Modelo;
        private int _Capacidad;
        private double _Kilometraje;
        private string _UrlFoto;
        private bool _Disponibilidad;

        //Encapsulamiento
        public int ID_Camion { get => _ID_Camion; set => _ID_Camion = value; }
        public string Matricula { get => _Matricula; set => _Matricula = value; }
        public string Tipo_Camion { get => _Tipo_Camion; set => _Tipo_Camion = value; }
        public string Marca { get => _Marca; set => _Marca = value; }
        public string Modelo { get => _Modelo; set => _Modelo = value; }
        public int Capacidad { get => _Capacidad; set => _Capacidad = value; }
        public double Kilometraje { get => _Kilometraje; set => _Kilometraje = value; }
        public string UrlFoto { get => _UrlFoto; set => _UrlFoto = value; }
        public bool Disponibilidad { get => _Disponibilidad; set => _Disponibilidad = value; }


        //Constructores
        //Por defecto
        public Camiones_VO()
        {
            ID_Camion = 0;
            Matricula = "";
            Tipo_Camion = string.Empty;
            Marca = "";
            Modelo = "";
            Capacidad = 0;
            Kilometraje = 0;
            UrlFoto = "";
            Disponibilidad = true;

        }

        //Con parámetros
        //Datarow => Objeto ADO
        public Camiones_VO(DataRow dr)
        {
            ID_Camion = int.Parse(dr["ID_Camion"].ToString());
            Matricula = dr["Matricula"].ToString();
            Tipo_Camion = dr["Tipo_Camion"].ToString();
            Marca = dr["Marca"].ToString(); 
            Modelo = dr["Modelo"].ToString(); 
            Capacidad = int.Parse(dr["Capacidad"].ToString()); 
            Kilometraje = double.Parse(dr["Kilometraje"].ToString());
            UrlFoto = dr["UrlFoto"].ToString();
            Disponibilidad = bool.Parse(dr["Disponibilidad"].ToString()); 
        }
    }
}
