<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CKY.aspx.cs" Inherits="ASP.NET___My_Website.Projects.CKY" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--<asp:ScriptManager ID="MainScriptManager" runat="server" />--%>
    <asp:UpdatePanel ID="MainUpdatePanel" runat="server">
        <ContentTemplate>
            
    <h2 class="text-center" style="height: 18px"><%: Title %>CKY Simulation</h2>
    <h3 class="text-center">Final Project of "Computational linguistics"</h3>
    <h4>Class: &nbsp&nbsp&nbsp&nbsp CS226.H21.KHTN</h4>
    <h4>Student: &nbsp <strong>Hoàng Hữu Tín</strong></h4>
    <h4>ID: &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp <strong>14520956</strong></h4>

    <div class="panel panel-primary">
      <div class="panel-heading">
          <strong>Step 1:</strong> Input CNF rules 
          <asp:Button ID="btnDefaulCNF" runat="server" Cssclass="btn btn-link" ForeColor="#66FF33" Height="30px" OnClick="btnDefaulCNF_Click" style="text-decoration: underline" Text="Sample" ToolTip="Default Sample of CNF Rules" />
      </div>
        <div class="panel-body">
          <div class="form-group">
            <textarea  id="CNF_Text"  class="form-control" rows="7" runat="server" cols="20" name="S1" placeholder="Input CNF Rule (each rule in one line)"></textarea>
            </div>
        </div>
    </div>

    <div class="panel panel-primary">
      <div class="panel-heading"><strong>Step 2:</strong> Input the Sentence<asp:Button ID="btnDefaulSentence" runat="server" Cssclass="btn btn-link" ForeColor="#66FF33" Height="30px" OnClick="btnDefaulSentence_Click" style="text-decoration: underline" Text="Sample" ToolTip="Default Sample of CNF Rules" />
        </div>
      <div class="panel-body">
          <div class="input-group">
              <span class="input-group-addon" id="basic-addon1">Sentence</span>
              <input id="Sentence_Text" type="text" class="form-control" placeholder="Enter Sentence here" Style="min-width:100%" runat="server" aria-describedby="basic-addon1">
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <div class="panel panel-primary" style="overflow-x: scroll">
              <div class="panel-heading">CKY Table</div>
              <div class="panel-body">
                  <asp:GridView ID="CKY_Grid" runat="server" Height="100%" Width="100%" AutoGenerateColumns = "False" HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" OnDataBound="Grid_DataBound">
                      <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                      <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                  </asp:GridView>

              </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="panel panel-primary">
              <div class="panel-heading">CNF Rules</div>
              <div class="panel-body">
                  <asp:GridView ID="CNF_Grid" runat="server" Height="100%" Width="100%" AutoGenerateColumns = "False">
                  </asp:GridView>
              </div>
            </div>
        </div>
   </div>


    <div class="alert alert-success" role="alert" hidden="hidden">Success</div>
    <div class="alert alert-danger" role="alert" hidden="hidden" >Error</div>
    <div class="alert alert-warning" role="alert" hidden="hidden" >Warning</div>

    <div style="text-align: center">
            <asp:Button ID="btnPrev" runat="server" Cssclass="btn btn-primary btn-lg" OnClick="btnPrev_Click" Text="<<< Prev" ToolTip="Prev Step" Enabled="False" />
            <asp:Button ID="btnMain" runat="server" Cssclass="btn btn-success btn-lg" OnClick="btnMain_Click" Text="Start" ToolTip="Start CKY parsing" Width="132px" />
            <asp:Button ID="btnNext" runat="server" Cssclass="btn btn-primary btn-lg" OnClick="btnNext_Click" Text="Next >>>" ToolTip="Next Step" Enabled="False" />

    </div>

         
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
