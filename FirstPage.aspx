<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstPage.aspx.cs" Inherits="ShareYourConcern.FirstPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Grievance Portal</title>
    <style>
        body{
        text-align:center;
        margin-top:76px;
        margin-left:2rem;
        margin-right:2rem;
        font-size:2rem;
        height: 560px;
        background-color:aquamarine;
        }
        form{
             border:2px solid red;
             height: 733px;
             background-color:antiquewhite;
        }
        div{
             padding:5px;

        }
        .container{
            margin-top:100px;
            font-size:50px;
            height:250px;
        }
        .btn{
            font-size:100px;
            
        }
        .btn:hover{
            border: solid 1px grey;
        }   
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
            <asp:Label ID="Label1" runat="server" Text="Welcome To Grievance Portal-Raise your Concern" ForeColor="#0000CC"></asp:Label>
        <br />
            <asp:Label ID="Label2" runat="server" Text="How do you want to continue??" ForeColor="Red"></asp:Label>
            <br />
            <br />
        </div>
        <div >
            <asp:Button class="btn" ID="Anonymous" runat="server" Text="Anonymous User" Height="125px" style="margin-left: 0px" Width="287px" BackColor="#99CCFF" BorderStyle="Inset" Font-Size="X-Large" Font-Bold="True" ForeColor="Red" OnClick="Anonymous_Click" />
            <asp:Button class="btn" ID="Button" runat="server" Text="Login " Height="125px" Width="287px" BackColor="#FF9900" BorderStyle="Inset" Font-Size="X-Large" Font-Bold="True" ForeColor="#3333CC" OnClick="Login_Click" style="margin-left: 65px" />
        </div>
        
    </form>
    
</body>
</html>
