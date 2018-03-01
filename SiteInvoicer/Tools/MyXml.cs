using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class MyXml
    {

        public MyXml()
        {

        }


        public string infoTributaria(string claveAcceso, string secuencial)
        {

            string infoTri = $@"<infoTributaria>
                                <ambiente>1</ambiente>
                                <tipoEmision>1</tipoEmision>
                                <razonSocial>Almacenes De Prati S.A.</razonSocial>
                                <nombreComercial>Almacenes De Prati S.A.</nombreComercial>
                                <ruc>0990011214001</ruc>
                                <claveAcceso>{claveAcceso}</claveAcceso>
                                <codDoc>01</codDoc>
                                <estab>004</estab>
                                <ptoEmi>040</ptoEmi>
                                <secuencial>00000{secuencial}</secuencial>
                               <dirMatriz>LUQUE 502 Y BOYACA</dirMatriz>
                              </infoTributaria>";
            return infoTri;
        }

        public string infoFactura(string cedula, string rsocial, string totalSinImpuestos, string ivaTotal, string totalConIva)
        {
            DateTime fecha = DateTime.Now;
            string fech = fecha.ToString("dd") + "/" + fecha.ToString("MM") + "/" + fecha.ToString("yyyy");

            string infoFact = $@"<infoFactura>
                                <fechaEmision>{fech}</fechaEmision>
                                <dirEstablecimiento>CDLA. ALBORADA DECIMA ETAPA AV. BENJAMIN CARRION S/N Y CALLE SEGUNDA TERCERA C.C.LA ROTONDA LOCAL 40</dirEstablecimiento>
                                <contribuyenteEspecial>6925</contribuyenteEspecial>
                                <obligadoContabilidad>SI</obligadoContabilidad>
                                <tipoIdentificacionComprador>05</tipoIdentificacionComprador>
                                <razonSocialComprador>{rsocial}</razonSocialComprador>
                                <identificacionComprador>{cedula}</identificacionComprador>
                                <totalSinImpuestos>{totalSinImpuestos}</totalSinImpuestos>
                                <totalDescuento>0.00</totalDescuento>
                                <totalConImpuestos>
                                  <totalImpuesto>
                                    <codigo>2</codigo>
                                    <codigoPorcentaje>2</codigoPorcentaje>
                                    <baseImponible>{totalSinImpuestos}</baseImponible>
                                    <valor>{ivaTotal}</valor>
                                  </totalImpuesto>
                                </totalConImpuestos>
                                <propina>0.00</propina>
                                <importeTotal>{totalConIva}</importeTotal>
                                <moneda>DOLAR</moneda>
                                <pagos>
                                  <pago>
                                    <formaPago>01</formaPago>
                                    <total>{totalConIva}</total>
                                    <plazo>0</plazo>
                                    <unidadTiempo>meses</unidadTiempo>
                                  </pago>
                                </pagos>
                              </infoFactura>";
            return infoFact;
        }

        public string detalles(DataTable items)
        {
            
            string allDetalles = "";
            foreach (DataRow row in items.Rows)
            {
                string codP = (row["codigo"].ToString().Length > 0) ? $"<codigoPrincipal>{row["codigo"].ToString()}</codigoPrincipal>" : "<codigoPrincipal></codigoPrincipal>";
                string detalle = $@"<detalle>
                                  {codP}
                                  <descripcion>{row["descripcion"].ToString()}</descripcion>
                                  <cantidad>{row["cantidad"].ToString()}</cantidad>
                                  <precioUnitario>{row["precio_unitario"].ToString().Replace(',', '.')}</precioUnitario>
                                  <descuento>0.00</descuento>
                                  <precioTotalSinImpuesto>{row["subtotal"].ToString().Replace(',', '.')}</precioTotalSinImpuesto>
                                  <impuestos>
                                    <impuesto>
                                      <codigo>2</codigo>
                                      <codigoPorcentaje>2</codigoPorcentaje>
                                      <tarifa>{row["iva"].ToString()}</tarifa>
                                      <baseImponible>{row["subtotal"].ToString().Replace(',', '.')}</baseImponible>
                                      <valor>{row["valorIvaItem"].ToString().Replace(',','.')}</valor>
                                    </impuesto>
                                  </impuestos>
                                </detalle>";
                allDetalles += detalle; 
            }

            allDetalles = $"<detalles>{allDetalles}</detalles>";

            return allDetalles;
        }


        public string autotizerXML(string comprobante, string claveAcceco)
        {
            DateTime fecha = DateTime.Now;
            string fech = fecha.ToString("yyyy") +"-"+ fecha.ToString("MM") + "-" + fecha.ToString("dd") + "T"+ fecha.ToString("HH:mm:ss");
            const string Comillas = "\"";
            string autorizer = $@"<autorizacion>
                                  <estado>AUTORIZADO</estado>
                                  <numeroAutorizacion>{claveAcceco}</numeroAutorizacion>
                                  <fechaAutorizacion>{fech}-05:00</fechaAutorizacion>
                                  <ambiente>PRUEBAS</ambiente>
                                  <comprobante><factura id={Comillas}comprobante{Comillas} version={Comillas}1.0.0{Comillas}>{comprobante}</factura></comprobante></autorizacion>";
            return autorizer;
        }

        public string adiocnales(string direcccio, string email)
        {
            const string Comillas = "\"";
            string acid = $@"<infoAdicional>
                                <campoAdicional nombre={Comillas}Dirección del cliente{Comillas}>{direcccio}</campoAdicional>
                                <campoAdicional nombre ={Comillas}Email del cliente{Comillas}>{email}</campoAdicional>
                            </infoAdicional >";

            return acid;
        }

    }
}
