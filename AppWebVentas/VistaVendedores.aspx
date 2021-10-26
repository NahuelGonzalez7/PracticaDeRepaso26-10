<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaVendedores.aspx.cs" Inherits="AppWebVentas.VistaVendedores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblId" runat="server" Text="ID:"></asp:Label>
            <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
            <asp:Button ID="btnListar" runat="server" Text="Mostrar Todos" OnClick="btnListar_Click" />
        </div>
        <p>
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <asp:Button ID="btnTraerPorID" runat="server" Text="Traer vendedor por ID" OnClick="btnTraerPorID_Click" />
            <asp:TextBox ID="txtTraerPorID" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label>
        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
        <asp:Label ID="lblVendedorComision" runat="server" Text="Vendedores por Comision"></asp:Label>
        <asp:DropDownList ID="ddlVendedorComision" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlVendedorComision_SelectedIndexChanged">
        </asp:DropDownList>
        <p>
            <asp:Label ID="lblDNI" runat="server" Text="DNI:"></asp:Label>
            <asp:TextBox ID="txtDNI" runat="server" style="margin-bottom: 0px"></asp:TextBox>
        <asp:Button ID="btnInsertar" runat="server" Text="Insertar Vendedor" OnClick="btnInsertar_Click" />
        </p>
        <p>
            <asp:Label ID="lblComision" runat="server" Text="Comision:"></asp:Label>
            <asp:TextBox ID="txtComision" runat="server"></asp:TextBox>
            <asp:Button ID="btnEliminarVendedor" runat="server" Text="Eliminar Vendedor" OnClick="btnEliminarVendedor_Click" />
            <asp:Button ID="btnModificar" runat="server" Text="Modificar Vendedor" OnClick="btnModificar_Click" />
        </p>
        <asp:GridView ID="gridVendedores" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
