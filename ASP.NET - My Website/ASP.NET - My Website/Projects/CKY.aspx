<%@ Page Title="CKY" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CKY.aspx.cs" Inherits="ASP.NET___My_Website.Projects.CKY" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>CKY</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>

    <div>
    <div class="form-group">
      <label for="usr">Input:</label>
      <input type="text" class="form-control" id="usr">
    </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <h2>CKY Table</h2>
            <asp:Table ID="Table1" runat="server" Height="100%" Width="100%"/>
        </div>
        <div class="col-md-6">
            <h2>CNF Rules</h2>
            <asp:Table ID="Table2" runat="server" Height="100%" Width="100%" /> 
        </div>
   </div>


    <div class="alert alert-success" role="alert" hidden="hidden">Success</div>
    <div class="alert alert-danger" role="alert" hidden="hidden" >Error</div>

    <div style="text-align: center">
            <asp:Button ID="btnPrev" runat="server" class="btn btn-primary btn-lg" OnClick="btnPrev_Click" Text="<<< Prev" />
            <asp:Button ID="btnMain" runat="server" class="btn btn-success btn-lg" OnClick="btnMain_Click" Text="Browser" />
            <asp:Button ID="btnNext" runat="server" class="btn btn-primary btn-lg" OnClick="btnNext_Click" Text="Next >>>" />

    </div>
</asp:Content>
