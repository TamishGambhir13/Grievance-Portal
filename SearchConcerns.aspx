<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchConcerns.aspx.cs" Inherits="ShareYourConcern.SearchConcerns" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>See Older Concerns</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 20px;
        }

        h1 {
            margin-bottom: 20px;
            text-align: center;
        }

        .search-section {
            display: flex;
            justify-content: center; /* Center search elements horizontally */
            margin-bottom: 20px;
        }

        .search-label {
            width: 20%;
            text-align: right;
            margin-right: 10px;
            margin-top:auto;
        }

        .search-input {
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 3px;
            box-sizing: border-box;
            margin-top: 15px;
        }

        .search-button {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            width: 10%;
            padding: 10px 20px;
            border-radius: 3px;
            cursor: pointer;
            display: inline-block;
            background-color: #00CC00;
            color: white;
            margin-left: 28px;
        }

        .results-table {
            width: 100%;
            border-collapse: collapse;
        }

        .results-table th, .results-table td {
            padding: 10px;
            border: 1px solid #ccc;
            text-align: left;
        }

        .results-table thead {
            background-color: #ddd;
        }
    </style>
</head>
<body>
    <h1>See Your Previous Concerns and Their Status</h1>
    <form id="form1" runat="server">
        <div class="search-section">
            <label class="search-label" for="Search">Search by:</label>
            <asp:TextBox ID="SearchById" runat="server" CssClass="search-input" placeholder="ID" Width="560px" />
            
            <label class="search-label" for="Search">Search by:</label>
            <asp:TextBox ID="SearchByName" runat="server" CssClass="search-input" placeholder="Username" Width="560px" />
            
            <label class="search-label" for="Search">Search by:</label>
            <asp:TextBox ID="SearchByEmail" runat="server" CssClass="search-input" placeholder="Email" Width="560px" />
            
            <label class="search-label" for="Search">Search by:</label>
            <asp:TextBox ID="SearchByFromDate" runat="server" CssClass="search-input" placeholder=" From Date" TextMode="Date" Width="560px" /> 

            <asp:TextBox ID="SearchByToDate" runat="server" CssClass="search-input" placeholder=" To Date" TextMode="Date" Width="560px" />
            
            <label class="search-label" for="Search">Search by:</label>
            <asp:TextBox ID="SearchByEmpId" runat="server" CssClass="search-input" placeholder="Employee Id" Width="560px" />
            
            <label class="search-label" for="Search">Search by:</label>
            <asp:TextBox ID="SearchByPhone" runat="server" CssClass="search-input" placeholder="Phone Number" Width="560px" />
            
            <asp:Button ID="btn_search" runat="server" Text="Search" OnClick="Search_Click" CssClass="search-button" />
        </div>
        <asp:GridView ID="searchResultsGrid" runat="server" AllowSorting="True" AutoGenerateColumns="False" Visible="false">
            <Columns>
                <asp:BoundField DataField="USR_PKID" HeaderText="PKID" />
                <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="USR_NAME" HeaderText="Username" />
                <asp:BoundField DataField="Concern" HeaderText="Concern" />
                <%--<asp:BoundField DataField="Status" HeaderText="Status" />--%> 
            </Columns>
        </asp:GridView>
    </form>

    <asp:Label ID="noResultsLabel" runat="server" Visible="false" Text="No concerns found based on your search criteria." />
</body>
</html>
