<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebTransportes.aspx.cs" Inherits="WebTransportes.WebTransportes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" Text="AUTOS"></asp:Label>
            <br />
            <asp:Label runat="server" Text="Marca"></asp:Label>
            <asp:DropDownList ID="ddlMarca" runat="server" AutoPostBack="True"></asp:DropDownList>
            <br />
            <asp:Label runat="server" Text="Modelo"></asp:Label>
            <asp:TextBox ID="txtModelo" runat="server"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text="Matricula"></asp:Label>
            <asp:TextBox ID="txtMatricula" runat="server"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text="Precio"></asp:Label>
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text="Id"></asp:Label>
            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text="Buscar autos por marca"></asp:Label>
            <asp:DropDownList ID="ddlBuscar" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBuscar_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click1" />
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" style="height: 26px" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click1" />
            <br />
            <asp:GridView ID="gridAuto" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
