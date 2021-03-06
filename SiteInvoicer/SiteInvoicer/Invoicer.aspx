﻿<%@ Page Title="Crear Factura" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Invoicer.aspx.cs" Inherits="SiteInvoicer.Invoicer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %>.</h2>
    <h3>Crear Factura electrónica (Sucursal-Caja: <strong>004-040</strong>)</h3>
    <p>Llene los datos y envie a autorizar al SRI.</p>


    <div class="row text-right">
        <div class="col-md-11">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:Button ID="btCrear" CssClass="btn btn-success" OnClick="btCrear_Click" Enabled="false" runat="server" OnClientClick="modal()" Text="Crear Factura" />
            </ContentTemplate>
        </asp:UpdatePanel>
            </div>
    </div>


    <div class="row">
        <div class="col-md-6">
            <h4><strong>Datos del cliente</strong></h4>
            <hr />
            <div class="form-horizontal">
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-4 control-label">Identificación</label>
                    <div class="col-sm-8">
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Style="max-width: 280px;">
                                    <asp:ListItem Value="tipo">Tipo identificación</asp:ListItem>
                                    <asp:ListItem Value="cedula">Cedula</asp:ListItem>
                                    <asp:ListItem Value="ruc">Ruc</asp:ListItem>
                                    <asp:ListItem Value="pasaporte">Pasaporte</asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-4 control-label">Número identificación</label>
                    <div class="col-sm-8">
                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtCedula" TextMode="SingleLine" MaxLength="13" CssClass="form-control" placeholder="Número identificación" runat="server"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-4 control-label">Razon Social</label>
                    <div class="col-sm-8">
                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtNombre" TextMode="SingleLine" CssClass="form-control" placeholder="Razon Social" runat="server"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-4 control-label">Email</label>
                    <div class="col-sm-8">
                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtemail" TextMode="Email" CssClass="form-control" placeholder="Email" runat="server"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputPassword3" class="col-sm-4 control-label">Dirección</label>
                    <div class="col-sm-8">
                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtDireccion" CssClass="form-control" placeholder="Dirección" runat="server"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btSaveClient" OnClick="btSaveClient_Click" CssClass="btn btn-default" runat="server" Text="Nuevo Cliente" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-2">
                        <asp:UpdatePanel ID="UpdatePanel16" CssClass="btn btn-default" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btFoundClient" OnClick="btFoundClient_Click" CssClass="btn btn-default" runat="server" Text="Buscar Cliente" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

            </div>
        </div>

        <div class="col-md-6">
            <h4><strong>Subtotales</strong> </h4>
            <hr />
             <div class="col-md-4"></div>
            <div class="col-md-8 text-right">
                    <div class="table-responsive">
                        <table class="table ">
                            <tr>
                                <th scope="row">Subtotal Sin Impuestos</th>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lbl_SubtotalSin_Impuestos" runat="server" Text="0"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">Subtotal 0%</th>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lbl_Subtotal_iva0" runat="server" Text="0"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">Subtotal 12%</th>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lbl_Subtotal_iva12" runat="server" Text="0"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">Subtotal 14%</th>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lbl_Subtotal_iva14" runat="server" Text="0"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">Valor IVA</th>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lbl_valor_iva" runat="server" Text="0"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">Valor Total</th>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lbl_valor_total" runat="server" Text="0"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </div>
            </div>
        </div>
    </div>


          
  
    
       
    

    <div class="row">
        <h4><strong>Items</strong></h4>
           <hr />
    <div class="form-inline">
        <div class="form-group col-md-1">
            <label for="inputEmail4">Código</label>
            <asp:TextBox ID="txtCodigo" TextMode="Number" CssClass="form-control" runat="server" placeholder="Código"></asp:TextBox>
        </div>
        <div class="form-group col-md-3">
            <label for="inputPassword4">Descripción</label>
            <asp:TextBox ID="txtDescrip" TextMode="SingleLine" MaxLength="120" CssClass="form-control" runat="server" placeholder="Descripción"></asp:TextBox>
        </div>
        <div class="form-group col-md-2">
            <label for="inputPassword4">Cantidad</label>
            <asp:TextBox ID="txtCantidad" TextMode="Number" CssClass="form-control" runat="server" placeholder="Cantidad"></asp:TextBox>
        </div>
        <div class="form-group col-md-2">
            <label for="inputPassword4">Precio unitario</label>
            <asp:TextBox ID="txtprecio" TextMode="Number" CssClass="form-control" runat="server" placeholder="Precio unitario"></asp:TextBox>
        </div>
        <div class="form-group col-md-1">
            <label for="inputPassword4">% IVA</label>
            <asp:DropDownList ID="ddlIva" runat="server" CssClass="form-control">
                <asp:ListItem Value="0">0</asp:ListItem>
                <asp:ListItem Value="14">14</asp:ListItem>
                <asp:ListItem Value="12">12</asp:ListItem>
            </asp:DropDownList>
        </div>
        <%--<div class="form-group col-md-2">
            <label for="inputPassword4">Subtotal</label>
           <asp:TextBox ID="txtSubtotal" TextMode="Number" CssClass="form-control"  runat="server" placeholder="Subtotal"></asp:TextBox>
        </div>--%>
        <div class="form-group col-md-2">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Button ID="addItem" runat="server" Text="Agregar Item" OnClick="addItem_Click" CssClass="btn btn-default" Style="margin: 23px;" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    </div>

    <div class="row">
    <div class="form-inline">
        <div class="form-group col-md-12">
            <div class="table-responsive">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting" AutoGenerateColumns="False" CssClass="table table-striped">
                            <Columns>
                                <asp:BoundField HeaderText="Id" DataField="id" Visible="False">
                                    <HeaderStyle BackColor="Gray" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Código" DataField="codigo">
                                    <HeaderStyle BackColor="Gray" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Descripción" DataField="descripcion">
                                    <HeaderStyle BackColor="Gray" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Cantidad" DataField="cantidad">
                                    <HeaderStyle BackColor="Gray" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Precio Unitario" DataField="precio_unitario">
                                    <HeaderStyle BackColor="Gray" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="IVA" DataField="iva">
                                    <HeaderStyle BackColor="Gray" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Subtotal" DataField="subtotal">
                                    <HeaderStyle BackColor="Gray" />
                                </asp:BoundField>
                                <asp:CommandField ButtonType="Button" DeleteText="Eliminar" ShowDeleteButton="True">
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
    </div>
    




 <div id="myModal" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title">Mensaje</h4>
      </div>
      <div class="modal-body">
        <p id="myPersonalityMsj">Se ha creado correctamente su documento electrónico <strong>001-005-000000056</strong></p>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Ok</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->


    <script>

        function modal()
        {
            console.log('modal');
            $('#myModal').modal('show');
        }

        function modalWithMessage(mensaje) {
            $('#myPersonalityMsj').html(mensaje);
            console.log('modal');
            $('#myModal').modal('show');
        }

    </script>



</asp:Content>
