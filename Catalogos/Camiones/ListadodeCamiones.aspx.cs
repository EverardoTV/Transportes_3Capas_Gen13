using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinesLogicLayer;
using Microsoft.Ajax.Utilities;

namespace Transportes_3Capas_Gen13.Catalogos.Camiones
{
    public partial class ListadodeCamiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Utilizamos la varibable "IsPostBack" para controlar la primera vez que carga la pagina
            if (!IsPostBack)
            {
               cargarGrid();
            }
        }

        public void cargarGrid()
        { 
            //Cargar la informacion desde la BLL al GV
            GVCamiones.DataSource = BLL_Camiones.Get_Camiones();
            GVCamiones.DataBind();
        }



        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("formulariocamiones.aspx");

        }

        protected void GVCamiones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Recupero el ID del renglón adectado
            int id_camion = int.Parse(GVCamiones.DataKeys[e.RowIndex].Values["ID_Camion"].ToString());
            //Invoco mi metodo para eliminar mi camion
            string respuesta = BLL_Camiones.eliminar_Camion(id_camion);
            //Preparamos el Sweet Alert
            string titulo, msg, tipo;
            if (respuesta.ToUpper().Contains("ERROR"))
            {
                titulo = "Error";
                msg = respuesta;
                tipo = "error";
            }
            else
            {
                titulo = "Correcto!";
                msg = respuesta;
                tipo = "Success";
            }

            //Sweet alert
            //recargamos la pagina
            cargarGrid();

        }

        protected void GVCamiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Defino si el comando(El click que se detecta) tiene la propiedad "Select"
            if (e.CommandName == "Select")
            {
                //Recupero el indice en funcion de aquel elemento que haya detonado el evento
                int varIndex = int.Parse(e.CommandArgument.ToString());
                //Recupero el ID en función del indice que recuperamos anteriormente
                string id = GVCamiones.DataKeys[varIndex].Values["ID_Camion"].ToString();
                //Redirecciono al formulario de edicion pasando como parametro el ID
                Response.Redirect($"formulariocamiones.aspx?Id={id}");
            }
        }

        protected void GVCamiones_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GVCamiones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GVCamiones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    }
}