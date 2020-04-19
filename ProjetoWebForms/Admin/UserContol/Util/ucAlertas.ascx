<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAlertas.ascx.cs" Inherits="ProjetoWebForms.Admin.UserContol.Util.ucAlertas" %>

<!-- ERROS -->
<div onclick="EsconderDiv(this)" class="cursor-pointer div-hide" title="Clique para fechar" visible="false" runat="server" id="divErro">
    <div class="alert alert-danger">
        <asp:Literal runat="server" ID="ltlErro" />
        <i class="fa fa-times" style="float: right"></i>
    </div>
</div>

<!-- SUCESSO -->
<div onclick="EsconderDiv(this)" class="cursor-pointer div-hide" title="Clique para fechar" visible="false" runat="server" id="divSucesso">
    <div class="alert alert-success">
        <asp:Literal runat="server" ID="ltlSucesso" />
        <i class="fa fa-times" style="float: right"></i>
    </div>
</div>

<!-- ALERTA -->
<div onclick="EsconderDiv(this)" class="cursor-pointer div-hide" title="Clique para fechar" visible="false" runat="server" id="divAlerta">
    <div class="alert alert-warning">
        <asp:Literal runat="server" ID="ltlAlerta" />
        <i class="fa fa-times" style="float: right"></i>
    </div>
</div>


