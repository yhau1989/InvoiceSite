using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SiteInvoicer
{
    public partial class Invoicer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadData();
            }
        }

        protected void loadData()
        {
            DataTable items = new DataTable();
            items.Columns.Add("codigo", typeof(string));
            items.Columns.Add("descripcion", typeof(string));
            items.Columns.Add("cantidad", typeof(string));
            items.Columns.Add("precio_unitario", typeof(string));
            items.Columns.Add("iva", typeof(string));
            items.Columns.Add("subtotal", typeof(string));

            Session["myItems"] = items;

        }

        protected void addItem_Click(object sender, EventArgs e)
        {
            
            DataTable dt = (DataTable)(Session["myItems"]);
            DataRow dr = dt.NewRow();

            dr["codigo"] = txtCodigo.Text;
            dr["descripcion"] = txtDescrip.Text;
            dr["cantidad"] = txtCantidad.Text;
            dr["precio_unitario"] = txtprecio.Text;
            dr["iva"] = ddlIva.SelectedValue.ToString();

            decimal iva = (ddlIva.SelectedValue.ToString().Equals("0")) ? 0 : (ddlIva.SelectedValue.ToString().Equals("14")) ? 1.14m : 1.12m;
            decimal subtotal = (iva > 0) ? ((Convert.ToInt32(txtCantidad.Text) * Convert.ToDecimal(txtprecio.Text)) * iva) : (Convert.ToInt32(txtCantidad.Text) * Convert.ToDecimal(txtprecio.Text));

            dr["subtotal"] = subtotal.ToString();

            dt.Rows.Add(dr);
            Session["myItems"] = dt;

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}