﻿<%@ Page Title="InvoiceSite" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SiteInvoicer._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>InvoiceSite</h1>
        <p class="lead">Portal de Facturación Electrónica</p>
        <p><a href="http://www.softwaremonkey.com.ec" class="btn btn-primary btn-lg">Sotfware Monkey Ecuador &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Crear Comprobantes</h2>
            <p>Crear documentos electrónicos y autorizarlos ante el SRI.</p>
            <p>
                <a class="btn btn-default" href="Invoicer">Facturas &raquo;</a>
            </p>
            <p>
                <a class="btn btn-default" href="#">Notas de Débito &raquo;</a>
            </p>
            <p>
                <a class="btn btn-default" href="#">Notas de Crédito &raquo;</a>
            </p>
            <p>
                <a class="btn btn-default" href="#">Comprobantes de retención &raquo;</a>
            </p>
            <p>
                <a class="btn btn-default" href="#">Guías de remisión &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Visor Interno</h2>
            <p>Ver todos los comprobantes que se han generado hasta el momento, tambien puede visualizar los documentos electrónicos recibidos.</p>
            <p>
                <a class="btn btn-default" href="http://srv01351:83/" target="_blank">Vamos &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Visor Clientes</h2>
            <p>Portal de Facturación electrónica para sus clientes.</p>
            <p>
                <a class="btn btn-default" href="http://srv01351" target="_blank">Vamos &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
