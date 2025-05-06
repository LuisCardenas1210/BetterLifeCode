<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="BetterLife.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>BetterLife Usuarios</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="false"
            OnRowCommand="gvUsuarios_RowCommand"
            DataKeyNames="id_Usuario" Height="187px" Width="425px">
            <Columns>
                <asp:BoundField DataField="Nombre_Usuario" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellidos_Usuario" HeaderText="Apellidos" />
                <asp:BoundField DataField="Edad_Usuario" HeaderText="Edad" />
                <asp:BoundField DataField="Genero_Usuario" HeaderText="Género" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar"
                            CommandName="Seleccionar" CommandArgument='<%# Container.DataItemIndex %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
