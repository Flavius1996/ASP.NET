<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ASP.NET___My_Website.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>CKY</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>

    <div class="auto-style1" style="text-align: center">
    <div>
    <div class="row">
        <div class="col-md-4">
            <asp:Table ID="Table1" runat="server" Height="100%" Width="100%">
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">12</asp:TableCell>
                            <asp:TableCell runat="server">21</asp:TableCell>                          
                            <asp:TableCell runat="server">21</asp:TableCell>                        
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">12</asp:TableCell>
                            <asp:TableCell runat="server">21</asp:TableCell>                          
                            <asp:TableCell runat="server">21</asp:TableCell>                        
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">12</asp:TableCell>
                            <asp:TableCell runat="server">21</asp:TableCell>                          
                            <asp:TableCell runat="server">21</asp:TableCell>                        
                        </asp:TableRow>
                        </asp:Table>
        </div>
        <div class="col-md-4">
            <asp:Table ID="Table2" runat="server" Height="100%" Width="100%">
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">12</asp:TableCell>
                            <asp:TableCell runat="server">21</asp:TableCell>                          
                            <asp:TableCell runat="server">21</asp:TableCell>                        
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">12</asp:TableCell>
                            <asp:TableCell runat="server">21</asp:TableCell>                          
                            <asp:TableCell runat="server">21</asp:TableCell>                        
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">12</asp:TableCell>
                            <asp:TableCell runat="server">21</asp:TableCell>                          
                            <asp:TableCell runat="server">21</asp:TableCell>                        
                        </asp:TableRow>
                        </asp:Table>
        </div>
    </div>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
     </div>
    <button type="button" class="btn btn-success">Tin</button>
    <br />
    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server" Height="155px">
            <asp:Table ID="LayoutTable" runat="server" Height="100%" Width="100%" GridLines="Both">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">
                        <asp:Table ID="Table5" runat="server" Height="100%" Width="100%">
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">12</asp:TableCell>
                            <asp:TableCell runat="server">21</asp:TableCell>                          
                            <asp:TableCell runat="server">21</asp:TableCell>                        
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">12</asp:TableCell>
                            <asp:TableCell runat="server">21</asp:TableCell>                          
                            <asp:TableCell runat="server">21</asp:TableCell>                        
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">12</asp:TableCell>
                            <asp:TableCell runat="server">21</asp:TableCell>                          
                            <asp:TableCell runat="server">21</asp:TableCell>                        
                        </asp:TableRow>
                        </asp:Table>
                    </asp:TableCell>

                    

                    <asp:TableCell runat="server" Width="50%">
<br /> np(np(X))           --> nnp(X).                     % nam, lan
<br /> np(np(X))           --> prp(X).                     % no, ho
<br /> np(np(X))           --> nn(X).                      % sach, truong,...
<br /> np(np(X, Y))        --> nn(X), nn(Y).               % nn(nha) nn(thanh pho)
<br /> np(np(X, Y))        --> nn(X), nnp(Y).              % nn(gia dinh) nnp(nam)
<br /> np(np(X, Y))        --> nn(X), prp(Y).              % nn(gia dinh) prp(ho)

<br /> np(np(X,Y))         --> un(X), nn(Y).               % un(can) nn(nha)
<br /> np(np(X,Y,Z))       --> un(X), nn(Y), nn(Z).        % un(can) nn(nha) nn(thanh pho)

<br /> np(np(X,Y))         --> nn(X), adjp(Y).             % sach adjp(hay)
<br /> np(np(X,Y,Z))       --> un(X), nn(Y), adjp(Z).      % can nha adjp(rat tot)

<br /> np(np(X,Y))         --> cd(X), np(Y).               % cd(mot) np(can nha o thanh pho)
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>


    <asp:GridView ID="GridView1" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-Width="30" />
        <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="150" />
        <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-Width="150" />
    </Columns>
</asp:GridView>
    </div>
</asp:Content>
