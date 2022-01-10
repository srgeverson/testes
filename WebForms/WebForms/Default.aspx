<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function cliqueFileUpload() {
            alert("Oi..");
            $('#<%= lblTesteFileUpload.ClientID %>').attr("enabled", "false");
        }
    </script>

    <div class="jumbotron">
        <h1>Testes Web Forms</h1>
        <p class="lead">Testando componentes web forms.</p>
    </div>

    <div class="row">
        <div class="col-md-4">
        </div>
        <div class="col-md-4">
            <h2>Componentes</h2>
            <asp:Button ID="btnTesteFileUpload" Text="Desligar Por Arquivo" runat="server" OnClick="btnTesteFileUpload_Click" />
            <asp:FileUpload ID="FileUpload1" runat="server" ClientIDMode="Static" OnDisposed="FileUpload1_DataBinding" Visible="false" />
            <asp:Label ID="lblTesteFileUpload" runat="server" Text="Vazio!!!" ClientIDMode="Static" />

        </div>
        <div class="col-md-4">
        </div>
    </div>

</asp:Content>
