<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConcernPage.aspx.cs" Inherits="ShareYourConcern.ConcernPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Concern Form</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 20px;
            background-color: #f0ffff; /* Light blue background */
        }

        .container {
            width: 100%;
            max-width: 800px;
            margin: 0 auto;
            display: flex; /* Use flexbox for layout */
            flex-direction: column; /* Stack elements vertically */
            align-items: center;
            height: 776px;
        }

        h1 {
            margin-bottom: 20px;
            text-align: center; /* Center the heading */
        }

        .form-section {
            width: 100%;
            background-color: #fff; /* White background for form sections */
            padding: 20px;
            border-radius: 5px; /* Rounded corners */
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1); /* Subtle shadow */
        }
        .ChkDisableDetails{
            margin-bottom: 20px;
            width: 100%;
            background-color: #fff; /* White background for form sections */
            padding: 20px;
            border-radius: 5px; /* Rounded corners */
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1); /* Subtle shadow */
            margin-bottom: 20px;

        }

        .form-group {
            margin-bottom: 15px;
        }

        .form-label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }

        .form-control {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 3px;
            box-sizing: border-box; /* Include padding in width calculation */
        }

        .concern-section textarea {
            height: 200px;
            resize: vertical; /* Allow users to resize the textarea */
        }

        .btn-section {
            display: flex;
            justify-content: center; /* Center buttons horizontally */
            margin-top: 20px;
        }

        .btn {
            padding: 10px 20px;
            border: none;
            border-radius: 3px;
            cursor: pointer;
            display: inline-block;
            margin: 0 10px; /* Adjust margin for spacing */
        }

        .btn-submit {
            background-color: #00CC00;
            color: white;
        }

        .btn-back {
            background-color: #ddd;
            color: #333;
            margin-left: 20px;
        }
        .login-btn-submit {
            background-color: crimson;
            color: white;
            margin-left: 1125px;
        }

        .login-btn-back {
            background-color:aquamarine;
            color: #333;
            margin-left: 40px;
        }
        .next{
            display:flex;
            align-items:center;
            justify-content:center;
        }
    </style>
</head>
<body>
    <h1>Concern Form</h1>
    <form id="concernForm" runat="server">
     <div class="login-btn-section">
     <asp:Button ID="UsrLogin" runat="server" Text="User Login" CssClass="login-btn-submit" OnClick="Usr_Login" Height="45px" Width="91px" /> 
     <asp:Button ID="AdmLogin" runat="server" Text="Admin Login" CssClass="login-btn-back" OnClick="Back_Click" Height="45px" Width="91px" />
    </div>
        <div class="container">
            <div class="ChkDisableDetails">
               <%-- <asp:CheckBox ID="ChkDisableDetails" runat="server" />
                <asp:Label ID="Label1" class="form-label" runat="server" Text="Check the box if you want to raise the concern 'Anonymously'"></asp:Label>--%>
                <h2>Personal Information</h2>
                <div class="form-group">
                    <label for="txtName" class="form-label">Name:</label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Height="22px" Width="800px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtEmail" class="form-label">Email:</label>
                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control" Height="22px" Width="800px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtEmpId" class="form-label">Employee ID:</label>
                    <asp:TextBox ID="txtEmpId" runat="server" TextMode="Number" CssClass="form-control" Height="22px" Width="800px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtPhone" class="form-label">Phone No:</label>
                    <asp:TextBox ID="txtPhone" runat="server" TextMode="Number" CssClass="form-control" Height="22px" Width="800px"></asp:TextBox>
            </div>
                </div>
            <div class="form-section">
                <h2>Write Concern</h2>
                <div>
                    <label for="txtConcern">Describe your concern&nbsp;
                    <br />
                    :</label>
                    <asp:TextBox ID="txtConcern" runat="server" TextMode="MultiLine" Rows="10" Width="800px"></asp:TextBox>
                </div>
            </div>
        <div class="btn-section">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn-submit" OnClick="btnSubmit_Click" Height="37px" Width="74px" /> 
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn-back" OnClick="Back_Click" Height="37px" Width="74px" />
        </div>
       </div>
        <div class="next">
            <br />
            <asp:Label ID="OldConcerns" runat="server" Text="Want To See Your Older Concerns? " Font-Bold="True" Font-Underline="True"></asp:Label>
            <asp:Button ID="SearchConcern" runat="server" Text="Click Here" Font-Bold="True" OnClick="Next_Click" />
        </div>

 
    </form>
</body>
</html>
&nbsp;