<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="DemoWebApplication1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3> Thong tin lien he</h3>
        <div class="container text-center">
        <div class="row">
           <div class="col">
             <asp:CheckBox ID="chkGender" Text="Nam" runat="server" />
          </div>
          <div class="col">
           <asp:TextBox ID="txtMessage" placeholder="
         value" runat="server" CssClass="form-control"></asp:TextBox>
              <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
           </div>
           <div class="col">
               <asp:Button ID="btnSubmit" CssClass="btn btn-danger"
runat="server" OnClick ="btnSubmit_Click" Text="Submit" />
          </div>
            </div>
    </div>
    </main>
</asp:Content>
