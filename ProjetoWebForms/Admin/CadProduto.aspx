<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadProduto.aspx.cs" Inherits="ProjetoWebForms.Admin.CadProduto" MasterPageFile="~/Site.Master" %>

<%@ Register Src="~/Admin/UserContol/Util/ucAlertas.ascx" TagPrefix="uc1" TagName="ucAlertas" %>

<asp:Content ID="StyleSheetsContent" ContentPlaceHolderID="StyleSheetsContent" runat="server">
</asp:Content>

<%--corpo--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="DefaultContent" runat="server">
    <br />
    <uc1:ucAlertas runat="server" ID="ucAlertas" />
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
            <asp:LinkButton CssClass="btn btn-primary" runat="server" ID="lkbExcel" Text="Exportar" OnClick="lkbExcel_Click"></asp:LinkButton>
        </div>
    </div>
    <br />
    <div class="form-horizontal">
        <asp:GridView runat="server" ID="grid"
            ItemType="ProdutoTO"
            AutoGenerateColumns="false"
            PageSize="10"
            CssClass="table table-striped table-bordered table-hover"
            ShowHeaderWhenEmpty="false"
            AllowCustomPaging="true"
            AllowPaging="true"
            ShowHeader="true"
            Width="100%"
            EmptyDataText="Nenhum registro encontrado"
            OnPageIndexChanging="grid_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="Inicio">
                    <ItemTemplate>
                        <asp:HyperLink ID="link" NavigateUrl='~/' CssClass="btn btn-primary" Text="Inicio" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="id" HeaderText="Id" />
                <asp:BoundField DataField="nome" HeaderText="Nome" />
                <asp:BoundField DataField="valor" HeaderText="Valor" />
            </Columns>
            <PagerSettings Position="Bottom" />
            <PagerStyle HorizontalAlign="Right" />
        </asp:GridView>
    </div>
    <br />
    <br />
    <%--Ex table com repeater--%>
 <%--   <div class="col-md-12 ">
        <table border="1" class="table table-striped table-bordered table-hover">
            <thead>
                <tr>
                    <td>id</td>
                    <td>Nome</td>
                    <td>Valor</td>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="rpt" ItemType="To.ProdutoTO">
                    <ItemTemplate>
                        <tr>
                            <td><%#Item.id %></td>
                            <td><%#Item.nome%></td>
                            <td><%#Item.valor%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>--%>

</asp:Content>

<asp:Content ID="JavaScriptContent" ContentPlaceHolderID="JavaScriptContent" runat="server">
</asp:Content>
