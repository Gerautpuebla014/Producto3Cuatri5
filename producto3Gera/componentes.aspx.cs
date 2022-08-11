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
    public partial class componentes : System.Web.UI.Page
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            string m = "";
            string md = "";
            GridView3.DataSource = objBL.obtentodosComponentesG(ref m);
            GridView3.DataBind();
            TextBox1.Text = m;
            md = objBL.MiMessageBox("CONSULTA CORRECTA", m, 2);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string m = "";
            string md = "";
            GridView1.DataSource = objBL.obtentodasMarcas(ref m);
            GridView1.DataBind();
            TextBox1.Text = m;
            md = objBL.MiMessageBox("CONSULTA CORRECTA", m, 2);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            string md = "";
            GridView2.DataSource = objBL.obtentodasCategoria(ref m);
            GridView2.DataBind();
            TextBox1.Text = m;
            md = objBL.MiMessageBox("CONSULTA CORRECTA", m, 2);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string z = "";
            string md = "";
            if (GridView1.SelectedIndex >= 0)
            {
                if (GridView2.SelectedIndex >= 0)
                {
                    objBL.InsertarComponenteGenerico(txtnombrecomp.Text,txtdescripcion.Text,txtclavesat.Text, txtcodigounidad.Text,Convert.ToInt32(txtpiezas.Text), 
                        Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text),
                        Convert.ToInt32(GridView2.Rows[GridView2.SelectedIndex].Cells[1].Text), ref z);
                    TextBox1.Text = z;
                }
                else
                {
                    TextBox1.Text = "Debes seleccionar una Marca primero";
                    md = objBL.MiMessageBox("Selecciona Una Marca", z, 3);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
                }
            }
            else
            {
                TextBox1.Text = "Debes seleccionar una Categoria primero";
                md = objBL.MiMessageBox("Selecciona Una Categoria", z, 3);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
            }
            
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string m = "";
            string md = "";
            GridView4.DataSource = objBL.obtentodosComponentesG(ref m);
            GridView4.DataBind();
            TextBox2.Text = m;
            md = objBL.MiMessageBox("CONSULTA CORRECTA", m, 2);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string m = "";
            string md = "";
            if (GridView4.SelectedIndex >= 0)
            {
                objBL.ModificarComponente(Convert.ToInt32(GridView4.Rows[GridView4.SelectedIndex].Cells[1].Text),Convert.ToInt32(txtpzasnuevas.Text), ref m);
                md = objBL.MiMessageBox("CONSULTA CORRECTA", m, 2);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
            }
            else
            {
                TextBox2.Text = "Debes elegir Un Componente Primero";
                md = objBL.MiMessageBox("Debes Elegir Un componente", m, 3);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            string m = "";
            string md = "";
            if (GridView5.SelectedIndex >= 0)
            {
                objBL.EliminarComponente(Convert.ToInt32(GridView5.Rows[GridView5.SelectedIndex].Cells[1].Text), ref m);
                md = objBL.MiMessageBox("CONSULTA CORRECTA", m, 2);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
            }
            else
            {
                TextBox2.Text = "Debes elegir Un Componente Primero";
                md = objBL.MiMessageBox("CONSULTA CORRECTA", m, 3);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string m = "";
            string md = "";
            GridView5.DataSource = objBL.obtentodosComponentesG(ref m);
            GridView5.DataBind();
            TextBox2.Text = m;
            md = objBL.MiMessageBox("CONSULTA CORRECTA", m, 2);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
        }
    }
}