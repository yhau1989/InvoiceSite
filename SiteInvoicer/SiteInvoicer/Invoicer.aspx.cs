using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tools;

namespace SiteInvoicer
{
    public partial class Invoicer : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { loadData(); }
        }

        protected void loadData()
        {
            DataTable items = new DataTable();
            items.Columns.Add("id", typeof(int));
            items.Columns.Add("codigo", typeof(string));
            items.Columns.Add("descripcion", typeof(string));
            items.Columns.Add("cantidad", typeof(string));
            items.Columns.Add("precio_unitario", typeof(string));
            items.Columns.Add("iva", typeof(string));
            items.Columns.Add("valorIvaItem", typeof(string));
            items.Columns.Add("subtotal", typeof(string));
            items.Columns.Add("subtotalItemConIva", typeof(string));

            DataTable clientes = new DataTable();
            clientes.Columns.Add("tipoidenti", typeof(string));
            clientes.Columns.Add("identificacion", typeof(string));
            clientes.Columns.Add("razon_social", typeof(string));
            clientes.Columns.Add("email", typeof(string));
            clientes.Columns.Add("direccion", typeof(string));
            Session["clientes"] = clientes;



            Session["myItems"] = items;
            Session["SubTotal_sin_impuestos2"] = 0;
            Session["SubTotal_iva0"] = 0;
            Session["SubTotal_iva14"] = 0;
            Session["SubTotal_iva12"] = 0;
            Session["SubTotal_iva14"] = 0;
            Session["ivaTotal"] = 0;
            Session["Valor_Total"] = 0;

            Session["secuencial"] = 3148;

        }

        protected void addItem_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 0 && txtCedula.Text.Length > 0 && txtDireccion.Text.Length > 0 && txtemail.Text.Length > 0 && !DropDownList1.SelectedValue.ToString().Equals("tipo"))
            {
                if (txtDescrip.Text.Length > 0 && txtCantidad.Text.Length > 0 && txtprecio.Text.Length > 0)
                {
                    DataTable dt = (DataTable)(Session["myItems"]);
                    DataRow dr = dt.NewRow();

                    dr["id"] = (dt.Rows.Count > 0) ? dt.Rows.Count + 1 : 1;
                    dr["codigo"] = txtCodigo.Text;
                    dr["descripcion"] = txtDescrip.Text;
                    dr["cantidad"] = txtCantidad.Text;
                    dr["precio_unitario"] = txtprecio.Text;
                    dr["iva"] = ddlIva.SelectedValue.ToString();

                    decimal iva = (ddlIva.SelectedValue.ToString().Equals("0")) ? 0 : (ddlIva.SelectedValue.ToString().Equals("14")) ? 0.14m : 0.12m;
                    decimal subtotal = (Convert.ToInt32(txtCantidad.Text) * Convert.ToDecimal(txtprecio.Text));

                    setSubtotales(subtotal, Convert.ToInt16(ddlIva.SelectedValue.ToString()), (subtotal * iva), "add");
                    dr["valorIvaItem"] = (subtotal * iva).ToString();
                    dr["subtotal"] = subtotal.ToString();
                    dr["subtotalItemConIva"] = ((subtotal * iva) + subtotal).ToString();

                    dt.Rows.Add(dr);
                    Session["myItems"] = dt;

                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    btCrear.Enabled = true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "consolemModal", " modalWithMessage('Ingrese correctamente datos en la sección de items.');", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "consolemModal", " modalWithMessage('Ingrese correctamente los datos del cliente.');", true);
               
            }

            

        }



        protected void setSubtotales(decimal subtotalItem, int tipoIva, decimal valorIvaItem, string accion)
        {
            decimal SubTotal_sin_impuestos = decimal.Parse(Session["SubTotal_sin_impuestos2"].ToString());
            decimal SubTotal_iva0 = decimal.Parse(Session["SubTotal_iva0"].ToString());
            decimal SubTotal_iva14 = decimal.Parse(Session["SubTotal_iva14"].ToString());
            decimal SubTotal_iva12 = decimal.Parse(Session["SubTotal_iva12"].ToString());
            decimal ivaTotal = decimal.Parse(Session["ivaTotal"].ToString());
            decimal Valor_Total = decimal.Parse(Session["Valor_Total"].ToString());

            if (accion.Equals("add"))
            {
                SubTotal_sin_impuestos += subtotalItem;
                SubTotal_iva0 += (tipoIva == 0) ? subtotalItem : 0;
                SubTotal_iva14 += (tipoIva == 14) ? subtotalItem : 0;
                SubTotal_iva12 += (tipoIva == 12) ? subtotalItem : 0;
                ivaTotal += valorIvaItem;
                Valor_Total = (SubTotal_sin_impuestos + ivaTotal);

            }
            else if (accion.Equals("delete"))
            {
                SubTotal_sin_impuestos -= subtotalItem;
                SubTotal_iva0 -= (tipoIva == 0) ? subtotalItem : 0;
                SubTotal_iva14 -= (tipoIva == 14) ? subtotalItem : 0;
                SubTotal_iva12 -= (tipoIva == 12) ? subtotalItem : 0;
                ivaTotal -= valorIvaItem;
                ivaTotal = (ivaTotal < 0) ? 0 : ivaTotal;
                Valor_Total = (SubTotal_sin_impuestos + ivaTotal);
            }
            

            Session["SubTotal_sin_impuestos2"] = SubTotal_sin_impuestos;
            Session["SubTotal_iva0"] = SubTotal_iva0;
            Session["SubTotal_iva14"] = SubTotal_iva14;
            Session["SubTotal_iva12"] = SubTotal_iva12;
            Session["ivaTotal"] = ivaTotal;
            Session["Valor_Total"] = Valor_Total;

            lbl_SubtotalSin_Impuestos.Text = "$ " + SubTotal_sin_impuestos.ToString();
            lbl_Subtotal_iva0.Text = "$ " + SubTotal_iva0.ToString();
            lbl_Subtotal_iva12.Text = "$ " + SubTotal_iva12.ToString();
            lbl_Subtotal_iva14.Text = "$ " + SubTotal_iva14.ToString();
            lbl_valor_iva.Text = "$ " + ivaTotal.ToString();
            lbl_valor_total.Text = "$ " + Valor_Total.ToString();



        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string code = Convert.ToString(GridView1.DataKeys[e.RowIndex].Values[0]);

            DataTable dt = (DataTable)(Session["myItems"]);

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dt.Rows[i];

                if (dr["id"].ToString().Equals(code))
                {
                    
                    decimal iva = (ddlIva.SelectedValue.ToString().Equals("0")) ? 0 : (ddlIva.SelectedValue.ToString().Equals("14")) ? 0.14m : 0.12m;
                    decimal subtotal = decimal.Parse(dr["subtotal"].ToString());
                    setSubtotales(subtotal, Convert.ToInt16(dr["iva"].ToString()), (subtotal * iva), "delete");
                    dr.Delete();
                    break;
                }
            }

            btCrear.Enabled = (dt.Rows.Count <= 0) ? false : true;

            Session["myItems"] = dt;

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btCrear_Click(object sender, EventArgs e)
        {
            int secuencial = (int)(Session["secuencial"]);
            secuencial++;
            Session["secuencial"] = secuencial;

            string claveAcceso = new CA().GeneraClaveAcceso(secuencial.ToString());
            string infoTruibutaria = new MyXml().infoTributaria(claveAcceso, secuencial.ToString());
            string infoFactura = new MyXml().infoFactura(txtCedula.Text.Trim(), txtNombre.Text, Session["SubTotal_sin_impuestos2"].ToString().Replace(',','.'),
                Session["ivaTotal"].ToString().Replace(',', '.'), Session["Valor_Total"].ToString().Replace(',', '.'));

            DataTable items = (DataTable)(Session["myItems"]);
            string detalles = new MyXml().detalles(items);
            string infoAdicional = new MyXml().adiocnales(txtDireccion.Text, txtemail.Text);
            string xml = infoTruibutaria + infoFactura + detalles + infoAdicional;

            string autorizado = new MyXml().autotizerXML(xml, claveAcceso);

            OperadorDatos op = new OperadorDatos("TEst");
            op.CadenaConexion = ConfigurationManager.ConnectionStrings["Ecomp_Connection"].ToString();
            op.NombreProcedimiento = "test_insert_tViewerSend";
            op.AgregarParametro("@documento_autorizado", autorizado);
            op.AgregarParametro("@claveAcceso", claveAcceso);
            op.AgregarParametro("@nroAutorizacion", claveAcceso);
            op.AgregarParametro("@RUC", txtCedula.Text.Trim());
            op.AgregarParametro("@RazonSocial", txtNombre.Text);
            op.AgregarParametro("@nro_documento","00404000000" + secuencial.ToString());
            op.EjecutarNonQuery();

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "console", "SetItemsErroresMsj('Se ha creado correctamente su documento electrónico <strong>"+ "004-040-00000" + secuencial.ToString() + "</strong>');", true);

        }

        protected void btSaveClient_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 0 && txtCedula.Text.Length > 0 && txtDireccion.Text.Length > 0 && txtemail.Text.Length > 0 && !DropDownList1.SelectedValue.ToString().Equals("tipo"))
            {
                DataTable clientes = (DataTable)(Session["clientes"]);

                DataRow[] find = clientes.Select("identificacion = '" + txtCedula.Text.Trim() + "'");

                if (find.Length > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "consolemModal", " modalWithMessage('Cliente ya existe.');", true);
                }
                else
                {
                    DataRow dr = clientes.NewRow();

                    dr["tipoidenti"] = DropDownList1.SelectedValue.ToString();
                    dr["identificacion"] = txtCedula.Text;
                    dr["razon_social"] = txtNombre.Text;
                    dr["email"] = txtemail.Text;
                    dr["direccion"] = txtDireccion.Text;
                    clientes.Rows.Add(dr);

                    Session["clientes"] = clientes;

                    txtNombre.Text = "";
                    txtCedula.Text = "";
                    txtDireccion.Text = "";
                    txtemail.Text = "";
                    DropDownList1.SelectedIndex = 0;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "consolemModal", " modalWithMessage('Los datos de tu nuevo cliente se grabaron correctamente.');", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "consolemModal", " modalWithMessage('Ingrese correctamente los datos del cliente.');", true);
            }
        }

        protected void btFoundClient_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text.Length > 0)
            {
                DataTable clientes = (DataTable)(Session["clientes"]);
                DataRow[] find = clientes.Select("identificacion = '" + txtCedula.Text.Trim() + "'");

                if (find.Length > 0)
                {
                    txtNombre.Text = find[0].Field<string>("razon_social"); 
                    txtCedula.Text = find[0].Field<string>("identificacion");
                    txtDireccion.Text = find[0].Field<string>("direccion"); 
                    txtemail.Text = find[0].Field<string>("email");
                    DropDownList1.SelectedValue = find[0].Field<string>("tipoidenti");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "consolemModal", " modalWithMessage('Cliente no existe.');", true);
                }
            }
            
        }
    }
}