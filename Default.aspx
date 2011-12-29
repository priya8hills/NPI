<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NPI</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    <asp:Button ID="btnnpi" runat="server" Text="Generate NPI" 
                        onclick="btnnpi_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
