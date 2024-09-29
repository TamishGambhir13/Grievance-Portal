<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShareYourConcern.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />

    <style>
        /* Remove default margin from body */
        body {
            margin: 0;
        }

        /* Center the form container */
        .login-form {
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            background-color: #eee;
        }

        /* Style the form */
        .form-container {
            background-color: #fff;
            padding: 30px;
            border-radius: 5px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
            width: 800px;
            height: 600px;
        }

        /* Style form labels */
        .form-label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;

        }

        /* Style buttons */
        .btn-login,
        .btn-cancel {
            width: 100%;
            margin-top: 10px;
        }

        .btn-login {
            background-color: #00CC00;
            color: white;
            border: none;
        }

        .btn-cancel {
            background-color: #ddd;
            color: #333;
        }

        /* Style checkbox and label for password visibility */
        .show-password-container {
            display: flex;
            align-items: center;
            margin-top: 5px;
        }

        .show-password-container label {
            margin-left: 5px;
            font-size: smaller;
        }
    </style>
</head>
<body>
    <div class="login-form">
        <div class="form-container">
            <form id="form" runat="server">
                <div class="text-center">
                    <asp:Label ID="Label1" runat="server" Text="Login" ForeColor="#0000CC" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                </div>
                <div class="mb-3">
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Username" Class="form-label"></asp:Label>
                    <asp:TextBox ID="username" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="Label3" runat="server" Text="Password" Class="form-label"></asp:Label>
                    <asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="show-password-container">
                    <input type="checkbox" id="showPassword" onchange="document.getElementById('password').type=this.checked?'text'='password'"/>
                    <label for="showPassword">Show Password</label>
                </div>
                <div class="d-grid gap-2">
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-login" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="btn btn-cancel" OnClick="Cancel_Click" />
                </div>
                <div class="text-center mt-3">
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Not a user? Click Here To "></asp:Label>
          <asp:Button ID="SignUp" runat="server" Text="SignUp" OnClick="SignUp_Click" />
      </div>
  </form>
   </div>
    </div>
</body>
</html>
