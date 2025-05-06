<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearRutina.aspx.cs" Inherits="BetterLife.CrearRutina" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>BetterLife Crear Rutina</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Crear rutina</h2>

            <asp:Label runat="server" Text="Cliente: " />
            <asp:TextBox ID="txtCliente" runat="server"></asp:TextBox><br />

            <asp:Label runat="server" Text="Edad: " />
            <asp:TextBox ID="txtEdad" runat="server"></asp:TextBox><br />

            <asp:Label runat="server" Text="Peso: " />
            <asp:TextBox ID="txtPeso" runat="server"></asp:TextBox><br />

            <asp:Label runat="server" Text="Estatura: " />
            <asp:TextBox ID="txtEstatura" runat="server"></asp:TextBox><br />

            <h3>Medidas</h3>

            <asp:Label runat="server" Text="Brazo(relajado): " />
            <asp:TextBox ID="txtBrazoR" runat="server"></asp:TextBox><br />

            <asp:Label runat="server" Text="Brazo(contraido): " />
            <asp:TextBox ID="txtBrazoC" runat="server"></asp:TextBox><br />

            <asp:Label runat="server" Text="Cintura: " />
            <asp:TextBox ID="txtCintura" runat="server"></asp:TextBox><br />

            <asp:Label runat="server" Text="Pierna: " />
            <asp:TextBox ID="txtPierna" runat="server"></asp:TextBox><br />

            <h3>Rutina</h3>

            <asp:Label runat="server" Text="Rutina: " /> <br/>
            <asp:TextBox ID="txtRutina" runat="server" TextMode="MultiLine" Rows="5" Columns="40"></asp:TextBox><br />
            
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar rutina" OnClick="btnAgregar_Click" /><br /><br />
        
        </div>
    </form>
</body>
</html>
