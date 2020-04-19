<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadProduto.aspx.cs" Inherits="ProjetoWebForms.Admin.CadProduto"  MasterPageFile="~/Site.Master" %>

<%@ Register Src="~/Admin/UserContol/Util/ucAlertas.ascx" TagPrefix="uc1" TagName="ucAlertas" %>

<asp:Content ID="StyleSheetsContent" ContentPlaceHolderID="StyleSheetsContent" runat="server">
</asp:Content>

<%--corpo--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="DefaultContent" runat="server">
    <br />
    <uc1:ucAlertas runat="server" id="ucAlertas" />
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
                <div class="col-md-2">
                    <asp:Label runat="server">id</asp:Label>
                    <asp:TextBox runat="server" ID="txtId"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="col-md-6 ">
            <br>
            <asp:LinkButton CssClass="btn btn-primary" runat="server" ID="lkbCadastro" Text="Cadastro" OnClick="lkbCadastro_Click"></asp:LinkButton>
            <asp:LinkButton CssClass="btn btn-primary" runat="server" ID="lkbAtualizar" Text="Atuaizar" OnClick="lkbAtualizar_Click"></asp:LinkButton>
            <asp:LinkButton CssClass="btn btn-primary" runat="server" ID="lkbDeletar" Text="Deletar" OnClick="lkbDeletar_Click"></asp:LinkButton>
            <asp:LinkButton CssClass="btn btn-primary" runat="server" ID="lkbtvp" Text="getTvp" OnClick="lkbtvp_Click"></asp:LinkButton>
            <asp:LinkButton CssClass="btn btn-primary" runat="server" ID="lkbTodos" Text="BUscar todos" OnClick="lkbTodos_Click"></asp:LinkButton>
            <asp:LinkButton CssClass="btn btn-primary" runat="server" ID="lkbid" Text="BUscar por ID" OnClick="lkbid_Click"></asp:LinkButton>
        </div>
    </div>

</asp:Content>

<asp:Content ID="JavaScriptContent" ContentPlaceHolderID="JavaScriptContent" runat="server">
</asp:Content>
