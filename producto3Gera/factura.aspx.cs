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
    public partial class factura : System.Web.UI.Page
    {
        CapaNegocios objBL = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objBL = new CapaNegocios(ConfigurationManager.ConnectionStrings["cn1"].ConnectionString);
                Session["BL"] = objBL;
                Proveedor();
                EstadoC();
                FacturaCompra();
                Componente();


            }
            else
            {
                objBL = (CapaNegocios)Session["BL"];
                GridView1.DataSource = Session["ProveedorDL"];
                GridView1.DataBind();
                GridView2.DataSource = Session["EstadosDL"];
                GridView2.DataBind();
                GridView5.DataSource = Session["FacturaDL"];
                GridView5.DataBind();
                GridView4.DataSource = Session["ComponenteDL"];
                GridView4.DataBind();
            }
        }

        public void Proveedor()
        {
            string m = "";
            Session["ProveedorDL"] = objBL.obtentodosProveedores(ref m);
            GridView1.DataSource = Session["ProveedorDL"];
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string m = "";
            string md = "";
            if (GridView1.SelectedIndex >= 0)
            {
                objBL.InsertarFacturaCompra(txtfolio.Text,Convert.ToDateTime(txtFecha.Text),Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text),txtAnotacion.Text, ref m);
                md = objBL.MiMessageBox("CONSULTA CORRECTA", m, 2);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
            }
            else
            {
                TextBox1.Text = "Debes elegir Una Proveedor Primero";
                md = objBL.MiMessageBox("Debes Elegir Un proveedor", m, 3);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
            }
            TextBox1.Text = m;

        }
        public void EstadoC()
        {
            string m = "";
            Session["EstadosDL"] = objBL.obtenEstados(ref m);
            GridView2.DataSource = Session["EstadosDL"];
            GridView2.DataBind();
        }

        public void FacturaCompra()
        {
            string m = "";
            Session["FacturaDL"] = objBL.obtenFacturaC(ref m);
            GridView5.DataSource = Session["FacturaDL"];
            GridView5.DataBind();
        }
        public void Componente()
        {
            string m = "";
            Session["ComponenteDL"] = objBL.obtentodosComponentesG(ref m);
            GridView4.DataSource = Session["ComponenteDL"];
            GridView4.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            string md = "";
            if (GridView2.SelectedIndex >= 0)
            {
                if (GridView5.SelectedIndex >= 0)
                {
                    if (GridView4.SelectedIndex >= 0)
                    {
                        objBL.InsertarContenidoFactura(Convert.ToDecimal(txtPrecio.Text),txtNumS.Text, Convert.ToInt16(GridView2.Rows[GridView2.SelectedIndex].Cells[1].Text),
                            Convert.ToInt32(GridView5.Rows[GridView5.SelectedIndex].Cells[1].Text), Convert.ToInt32(GridView4.Rows[GridView4.SelectedIndex].Cells[1].Text),ref m);
                        md = objBL.MiMessageBox("CONSULTA CORRECTA", m, 2);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
                    }
                    else
                    {
                        TextBox1.Text = "Debes elegir Un Componente Primero";
                        md = objBL.MiMessageBox("Debes Elegir un componente", m, 3);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
                    }
                }
                else
                {
                    TextBox1.Text = "Debes elegir Una Factura Primero";
                    md = objBL.MiMessageBox("Debes Elegir Una Factura", m, 3);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
                }
            }
            else
            {
                TextBox1.Text = "Debes elegir Un Estado Primero";
                md = objBL.MiMessageBox("Debes elegir Un estado", m, 3);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "etiqueta" + 1, "" + md + "", true);
            }
            TextBox1.Text = m;
        }
    }
}