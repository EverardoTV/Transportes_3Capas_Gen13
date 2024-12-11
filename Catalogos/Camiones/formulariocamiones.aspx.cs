using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinesLogicLayer;
using ViewObjects;

namespace Transportes_3Capas_Gen13.Catalogos.Camiones
{
    public partial class formulariocamiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //valido si es Postback
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    //Voy a insertar
                    Titulo.Text = "Agregar Camión";
                    subTitulo.Text = "Registro de un nuevo camión";
                    lbldisponibilidad.Visible = false;
                    chkdisponibilidad.Visible = false;
                    imgfoto.Visible = false;
                    lblurlfoto.Visible = false;
                }
                else
                { 
                    //Voy a Atualizar
                    //Recupero el ID que proviene de la URL
                    int _id = Convert.ToInt32(Request.QueryString["Id"]);
                    //Obtengo el objeto original de la BD y coloco sus valores en los campos correspondientes
                    Camiones_VO _camion_original = BLL_Camiones.Get_Camiones("@ID_Camion", _id)[0];
                    //Valido que realmente obtenga el objeto y sus valores, de lo contrario, me regreso al formulario
                    if(_camion_original.ID_Camion != 0)
                    {
                        //Si encontré el camion y coloco sus valores
                        Titulo.Text = "Actualizar Camion";
                        subTitulo.Text = $"Modificar los datos del camion #{_id}";
                        txtmatricula.Text = _camion_original.Matricula;
                        txtcapacidad.Text = _camion_original.Capacidad.ToString();
                        txtkilometraje.Text = _camion_original.Kilometraje.ToString();
                        txttipo.Text = _camion_original.Tipo_Camion.ToString();
                        txtmarca.Text = _camion_original.Marca;
                        txtmodelo.Text = _camion_original.Modelo;
                        chkdisponibilidad.Checked = _camion_original.Disponibilidad;
                        imgfoto.ImageUrl = _camion_original.UrlFoto;
                    }
                    else
                    {
                        //No encontré el objeto y me voy pa' tras
                        Response.Redirect("listado_camiones.aspx");
                    }
                }
            }
        }

        protected void btnsubeimagen_Click(object sender, EventArgs e)
        {
            //Este metodo sirve para guardar y almacenar la imagen en el servidor y posteriormente recuperar la info desde la BD
            if (subeimagen.Value != "")
            {
                //recupero el nombre del archivo
                string filename = Path.GetFileName(subeimagen.Value);
                //Valido la extencion del archivo
                string fileExt = Path.GetExtension(filename).ToLower();
                if ((fileExt != ".jpg") && (fileExt != ".png"))
                {
                    //Sweet Alert
                }
                else
                {
                    //Verifico que existe el directorio en el servidor, para poder almacenar la imagen, de lo contrario, procedo a crearlo
                    string pathdir = Server.MapPath("~/Imagenes/Camiones");
                    //~(Vigulilla) hace referencia a la direccion completa del servidor, independientemente de donde esté instalado, permitiendo que la validacion funcione en diferentes entornos

                    //si no existe el directorio, lo creamos
                    if (!Directory.Exists(pathdir))
                    {
                        //Creo el directorio
                        Directory.CreateDirectory(pathdir);
                    }
                    //Subo la imagen a la carpeta del servidor
                    subeimagen.PostedFile.SaveAs(pathdir + filename);
                    //recuperamos la ruta de la URL que almacenaremos en ls BD
                    string urlfoto = "/Imagenes/Camiones" + filename;
                    //Mostramos en pantalla la URL creada
                    this.urlfoto.Text = urlfoto;
                    //Mostramos la imagen
                    imgcamion.ImageUrl = urlfoto;
                    //Sweet Alert
                }
            }
            else
            {
                //Sweet Alert
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            string titulo = "", respuesta = "", tipo = "", salida = "";
            try
            {
                //Creamos el objeto que enviaremos para aactualizar o insertar a las BD 
                //Existen 2 formas de instanciar y llenar un objeto
                //forma 1 (Por atributos)
                Camiones_VO _camion_aux = new Camiones_VO();
                _camion_aux.Matricula = txtmatricula.Text;
                _camion_aux.Marca = txtmarca.Text;
                _camion_aux.Tipo_Camion = txttipo.Text;
                _camion_aux.Modelo = txtmodelo.Text;
                _camion_aux.Capacidad = Convert.ToInt32(txtcapacidad.Text);
                _camion_aux.Kilometraje = Convert.ToDouble(txtkilometraje.Text);
                _camion_aux.UrlFoto = imgcamion.ImageUrl;
                _camion_aux.Disponibilidad = chkdisponibilidad.Checked;
                //Forma 2 (durante la propia instancia)
                Camiones_VO _camion_aux_2 = new Camiones_VO()
                {
                    Matricula = txtmatricula.Text,
                    Marca = txtmarca.Text,
                    Tipo_Camion = txttipo.Text,
                    Modelo = txtmodelo.Text,
                    Capacidad = Convert.ToInt32(txtcapacidad.Text),
                    Kilometraje = Convert.ToDouble(txtkilometraje.Text),
                    UrlFoto = imgcamion.ImageUrl
                };
                //decido si voy a insertar o actualizar
                if (Request.QueryString["Id"] == null)
                {
                    //Voy a insertar
                    _camion_aux.Disponibilidad = true;
                    salida = BLL_Camiones.insert_Camion(_camion_aux);
                }
                else
                {
                    //Actualizar 
                    _camion_aux.ID_Camion = int.Parse(Request.QueryString["Id"]);
                    salida = BLL_Camiones.actualizar_Camion(_camion_aux);
                }
                //Preparamos la salida para cachar un error y mostrar el Sweet alert
                if (salida.ToUpper().Contains("ERROR")) { } else { }
            }
            catch (Exception ex) 
            {
                titulo = "Error";
                respuesta = ex.Message;
                tipo = "error";
            }
            //Sweet alert
        }
    }
}