<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CKY.aspx.cs" Inherits="ASP.NET___My_Website.Projects.CKY" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>CKY Simulation</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>

    <%--<asp:ScriptManager ID="MainScriptManager" runat="server" />--%>
    <asp:UpdatePanel ID="MainUpdatePanel" runat="server">
        <ContentTemplate>
            

    <%--<script type="text/javascript">
    window.scrollTo = function( x,y ) 
    {
        return true;
    }
    </script>--%>
    <script type="text/javascript">
    window.onload = function () {
        var div = document.getElementById("dvScroll");
        var div_position = document.getElementById("div_position");
        var position = parseInt('<%=Request.Form["div_position"] %>');
        if (isNaN(position)) {
            position = 0;
        }
        div.scrollTop = position;
        div.onscroll = function () {
            div_position.value = div.scrollTop;
        };
    };
    </script>

    <div class="panel panel-primary">
      <div class="panel-heading">
          <strong>Step 1:</strong> Input CNF rules 
      </div>
        <div class="panel-body">
          <div class="form-group">
            <asp:Button id="btnDefaulCNF" runat="server" Cssclass="btn btn-link" OnClick="btnDefaulCNF_Click" Text="Default"  ToolTip="Default Sample of CNF Rules" Height="30px" style="text-decoration: underline" />
            <textarea  id="CNF_Text"  class="form-control" rows="7" runat="server" cols="20" name="S1" placeholder="Input CNF Rule (each rule in one line)"></textarea>
            </div>
        </div>
    </div>

    <div class="panel panel-primary">
      <div class="panel-heading"><strong>Step 2:</strong> Input a Sentence</div>
      <div class="panel-body">
          <div class="input-group">
              <span class="input-group-addon" id="basic-addon1">Sentence</span>
              <input id="Sentence_Text" type="text" class="form-control" placeholder="Enter Sentence here" Style="min-width:100%" runat="server" aria-describedby="basic-addon1">
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <div class="panel panel-primary">
              <div class="panel-heading">CKY Table</div>
              <div class="panel-body">
                  <asp:Table ID="CKY_Table" runat="server" Height="100%" Width="100%" BorderStyle="Double" GridLines="Both"/>
              </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="panel panel-primary">
              <div class="panel-heading">CNF Rules</div>
              <div class="panel-body">
                  <asp:Table ID="CNF_Table" runat="server" Height="100%" Width="100%" GridLines="Both" style="padding-left:110px;" Font-Names="Tahoma" Font-Size="Medium" Font-Underline="False"/>
              </div>
            </div>
        </div>
   </div>


    <div class="alert alert-success" role="alert" hidden="hidden">Success</div>
    <div class="alert alert-danger" role="alert" hidden="hidden" >Error</div>
    <div class="alert alert-warning" role="alert" hidden="hidden" >Warning</div>

    <div style="text-align: center">
            <asp:Button ID="btnPrev" runat="server" class="btn btn-primary btn-lg" OnClick="btnPrev_Click" Text="<<< Prev" ToolTip="Prev Step" />
            <asp:Button ID="btnMain" runat="server" class="btn btn-success btn-lg" OnClick="btnMain_Click" Text="Start" ToolTip="Start CKY parsing" Width="132px" />
            <asp:Button ID="btnNext" runat="server" class="btn btn-primary btn-lg" OnClick="btnNext_Click" Text="Next >>>" ToolTip="Next Step" />

    </div>

            <asp:Label runat="server" ID="lblHelloWorld" Text="Click the button!" />
            <br /><br />
            <asp:Button runat="server" ID="btnHelloWorld" OnClick="btnHelloWorld_Click" Text="Update label!" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
