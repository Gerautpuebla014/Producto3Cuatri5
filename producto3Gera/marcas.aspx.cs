using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using ClassLibrary1;

namespace producto3Gera
{
    public partial class marcas : System.Web.UI.Page
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            string md = "";
            GridView1.DataSource = objBL.obtentodasMarcas(ref m);
            GridView1.DataBind();
            TextBox1.Text = m;
            md = objBL.MiMessageBox("CONSULTA CORRECTA", m, 2);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string z = "";
            string md = "";
            objBL.InsertarMarca(txtnombremarca.Text, ref z);
            TextBox1.Text = z;
            md = objBL.MiMessageBox("CONSULTA CORRECTA", z, 2);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string m = "";
            string md = "";
            GridView2.DataSource = objBL.obtentodasMarcas(ref m);
            GridView2.DataBind();
            TextBox2.Text = m;
            md = objBL.MiMessageBox("CONSULTA CORRECTA", m, 2);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string m = "";
            string md = "";
            if (GridView2.SelectedIndex >= 0)
            {
                objBL.ModificarMarca(Convert.ToInt32(GridView2.Rows[GridView2.SelectedIndex].Cells[1].Text), txtModiMarca.Text, ref m);
                md = objBL.MiMessageBox("CONSULTA CORRECTA", m, 2);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
            }
            else
            {
                TextBox2.Text = "Debes elegir Una marca Primero";
                md = objBL.MiMessageBox("Elige Una Marca", m, 3);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
            }

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string m = "";
            string md = "";
            GridView3.DataSource = objBL.obtentodasMarcas(ref m);
            GridView3.DataBind();
            TextBox2.Text = m;
            md = objBL.MiMessageBox("CONSULTA CORRECTA", m, 2);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string m = "";
            string md = "";
            if (GridView3.SelectedIndex >= 0)
            {
                objBL.EliminarMarca(Convert.ToInt32(GridView3.Rows[GridView3.SelectedIndex].Cells[1].Text), ref m);
                md = objBL.MiMessageBox("CONSULTA CORRECTA", m, 2);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
            }
            else
            {
                TextBox2.Text = "Debes elegir Una marca Primero";
                md = objBL.MiMessageBox("Elige Una Marca", m, 3);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
            }
        }
    }
}