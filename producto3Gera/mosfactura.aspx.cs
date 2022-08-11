using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using ClassLibrary1;
using CapaEntidad;

namespace producto3Gera
{
    public partial class mosfactura : System.Web.UI.Page
    {
        CapaNegocios objBL = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objBL = new CapaNegocios(ConfigurationManager.ConnectionStrings["cn1"].ConnectionString);
                Session["BL"] = objBL;
            }
            else
            {
                objBL = (CapaNegocios)Session["BL"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Folio = txtFolio.Text;
            string m = "";
            string md = "";
            GridView2.DataSource = objBL.obtenFacturaFolio(Folio,ref m);
            GridView2.DataBind();
            TextBox1.Text = m;
            md = objBL.MiMessageBox("CONSULTA CORRECTA", m, 2);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            string md = "";
            GridView3.DataSource = objBL.obtenFolios(ref m);
            GridView3.DataBind();
            TextBox1.Text = m;
            md = objBL.MiMessageBox("CONSULTA CORRECTA", m, 2);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
        }
    }
}