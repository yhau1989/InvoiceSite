<%@ Page Title="Crear Factura" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Invoicer.aspx.cs" Inherits="SiteInvoicer.Invoicer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %>.</h2>
    <h3>Crear Factura electrónica</h3>
    <p>Llene los datos y envie a autorizar al SRI.</p>



    <div class="col-md-11 text-right">
        
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <button type="button" class="btn btn-success">Autorizar Factura</button>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <br />
    <br />
    <h4>Dastos del cliente</h4>
    <hr />
    <div class="form-horizontal">
        <div class="form-group">
            <label for="inputEmail3" class="col-sm-2 control-label">Ruc</label>
            <div class="col-sm-10">
                <input type="email" class="form-control" id="sdsdsds" placeholder="Ruc">
            </div>
        </div>
        <div class="form-group">
            <label for="inputEmail3" class="col-sm-2 control-label">Razon Social</label>
            <div class="col-sm-10">
                <input type="email" class="form-control" id="inputEmail3ss" placeholder="Razon Social">
            </div>
        </div>
        <div class="form-group">
            <label for="inputEmail3" class="col-sm-2 control-label">Email</label>
            <div class="col-sm-10">
                <input type="email" class="form-control" id="inputEmail3" placeholder="Email">
            </div>
        </div>
        <div class="form-group">
            <label for="inputPassword3" class="col-sm-2 control-label">Dirección</label>
            <div class="col-sm-10">
                <input type="password" class="form-control" id="inputPassword3" placeholder="Dirección">
            </div>
        </div>

        <%--<div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <button type="submit" class="btn btn-default">Sign in</button>
            </div>
        </div>--%>
    </div>

    <br />
    <br />
    <h4>Items</h4>
    <hr />

    <div class="form-inline">
        <div class="form-group col-md-1">
            <label for="inputEmail4">Código</label>
            <asp:TextBox ID="txtCodigo" TextMode="Number" CssClass="form-control"  runat="server" placeholder="Código"></asp:TextBox>
        </div>
        <div class="form-group col-md-3">
            <label for="inputPassword4">Descripción</label>
            <asp:TextBox ID="txtDescrip" TextMode="SingleLine" MaxLength="120" CssClass="form-control"  runat="server" placeholder="Código"></asp:TextBox>
        </div>
        <div class="form-group col-md-1">
            <label for="inputPassword4">Cantidad</label>
            <asp:TextBox ID="txtCantidad" TextMode="Number" CssClass="form-control"  runat="server" placeholder="Cantidad"></asp:TextBox>
        </div>
        <div class="form-group col-md-2">
            <label for="inputPassword4">Precion unitario</label>
           <asp:TextBox ID="txtprecio" TextMode="Number" CssClass="form-control"  runat="server" placeholder="Precion unitario"></asp:TextBox>
        </div>
        <div class="form-group col-md-1">
            <label for="inputPassword4">% IVA</label>
            <asp:DropDownList ID="ddlIva" runat="server" CssClass="form-control" >
                <asp:ListItem Value="0">% 0</asp:ListItem>
                <asp:ListItem Value="14">% 14</asp:ListItem>
                <asp:ListItem Value="12">% 12</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group col-md-2">
            <label for="inputPassword4">Subtotal</label>
           <asp:TextBox ID="txtSubtotal" TextMode="Number" CssClass="form-control"  runat="server" placeholder="Subtotal"></asp:TextBox>
        </div>
        <div class="form-group col-md-2">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Button ID="addItem" runat="server" Text="Agregar Item" OnClick="addItem_Click" CssClass="btn btn-default" style="margin:23px;" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <div class="form-inline">
        <div class="form-group col-md-12">
                     <div class="table-responsive">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                 
                         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                        <Columns>
                            <asp:BoundField HeaderText="Código" DataField="codigo" >
                            <HeaderStyle BackColor="Gray" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Descripción" DataField="descripcion" >
                            <HeaderStyle BackColor="Gray" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Cantidad" DataField="cantidad" >
                            <HeaderStyle BackColor="Gray" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Precio Unitario" DataField="precio_unitario" >
                            <HeaderStyle BackColor="Gray" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="IVA" DataField="iva" >
                            <HeaderStyle BackColor="Gray" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Subtotal" DataField="subtotal" >
                            <HeaderStyle BackColor="Gray" />
                            </asp:BoundField>
                            <asp:CommandField ButtonType="Button" DeleteText="Eliminar" ShowDeleteButton="True" >
                            <ControlStyle CssClass="btn btn-danger" />
                            <HeaderStyle BackColor="Gray" />
                            <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:CommandField>
                        </Columns>
                     </asp:GridView>
                    
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
                </div>
    </div>

    
</asp:Content>
