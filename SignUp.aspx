<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="ShareYourConcern.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Registration</title>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</head>
<body>
<div class="container">
 
<form class="row g-3 bg-light" runat="server" method="post">
<div class="bg-primary p-4 rounded mb-3 mt-3">
<h1 class="text-center text-light">User Registration- For New Users</h1>
</div>
<div class="col-md-6">
<label for="inputEmail4" class="form-label">Email</label>
<asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
</div>
<div class="col-md-6">
<label for="inputPassword4" class="form-label">Password</label>
<asp:TextBox ID="txtPass" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
</div>
<div class="col-md-6">
<label for="inputName4" class="form-label">Name</label>
<asp:TextBox ID="txtFname" CssClass="form-control" runat="server"></asp:TextBox>
</div>
 
<div class="col-md-6">
<label for="inputCity" class="form-label">Phone</label>
<asp:TextBox ID="txtPhone" CssClass="form-control" runat="server" TextMode="Phone"></asp:TextBox>
</div>
 
 <div class="col-md-6">
 <asp:CheckBox ID="bitCeased" runat="server" />
  <asp:Label ID="Cease" runat="server" Text="Cease Your Details"></asp:Label>
</div>
 
<div class="col-12 mb-3">
<asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Register" OnClick="Button1_Click" />
<asp:Button ID="Back" CssClass="btn btn-danger" runat="server" Text="Back" OnClick="Back_Click" />
</div>
</form>
 
</div>
</body>
 
&nbsp;