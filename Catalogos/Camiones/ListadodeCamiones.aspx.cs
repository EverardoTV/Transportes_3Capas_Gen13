﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinesLogicLayer;

namespace Transportes_3Capas_Gen13.Catalogos.Camiones
{
    public partial class ListadodeCamiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Utilizamos la varibable "IsPostBack" para controlar la primera vez que carga la pagina
            if (!IsPostBack)
            {
               // cargarGrid();
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


        }

        protected void GVCamiones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GVCamiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {

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