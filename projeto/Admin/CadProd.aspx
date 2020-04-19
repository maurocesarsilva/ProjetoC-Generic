<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="CadProd.aspx.cs" Inherits="projeto.CadProd" MasterPageFile="~/Site.Master" %>

<asp:Content ID="StyleSheetsContent" ContentPlaceHolderID="StyleSheetsContent" runat="server">
</asp:Content>

<%--corpo--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="DefaultContent" runat="server">
    <div class="form-body" runat="server" id="divCadastro">
        <h1>Cadastro Produtos</h1>
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-2">
                    <asp:Label runat="server">Nome Produto</asp:Label>
                    <asp:TextBox runat="server" ID="txtNomeProd"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Label runat="server">Valor Produto</asp:Label>
                    <asp:TextBox runat="server" ID="txtValor"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="col-md-2 ">
            <br>
            <asp:LinkButton CssClass="btn btn-primary" runat="server" ID="lkbCadastro" Text="Cadastro" OnClick="lkbCadastro_Click"></asp:LinkButton>
        </div>
    </div>

</asp:Content>

<asp:Content ID="JavaScriptContent" ContentPlaceHolderID="JavaScriptContent" runat="server">
</asp:Content>
