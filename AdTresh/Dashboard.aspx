<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AdTresh.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-centerpb-5 mb-3 border-bottom">
        <h2><%: Title %>.</h2>
        <div class="btn-toolbar mb-2 mb-md-0 pb-2">
            <button type="button" class="btn btn-sm btn-outline-secondary">
                <span data-feather="calendar"></span>
                This Month
            </button>
        </div>
    </div>
    <br />

    <h5>Income Generated</h5>
    <br />

    <div class="row">
        <div class="col-sm-4">
            <div class="card">
                <div class="card-header">
                   <h6 >Tithe</h6>
                </div>
                <div class="card-body">
                    
                    <asp:Label ID="totaltithe" runat="server" ForeColor="Teal" Font-Size="XX-Large" Font-Bold="true"></asp:Label>

                </div>
            </div>
        </div>

        <div class="col-sm-4">
            <div class="card">
                <div class="card-header">
                    <h6>Offfering</h6>
                </div>
                <div class="card-body">
                    
                    <asp:Label ID="expenseoffering" runat="server" ForeColor="Teal" Font-Size="XX-Large" Font-Bold="true"></asp:Label>
                </div>
            </div>
        </div>
        <div class="col-sm-4">
            <div class="card">
                <div class="card-header">
                    <h6>Special Project</h6>
                </div>
                <div class="card-body">
                   
                    <asp:Label ID="specialprojcts" runat="server" ForeColor="Teal" Font-Size="XX-Large" Font-Bold="true"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />

    <h5>Remittances</h5>
    <br />

    <div class="row">
        <table class="table">
            <tbody>
                <tr>
                    <th scope="row">Sum total of all Tithes</th>
                    <td>
                        <asp:Label ID="sumtithe" runat="server" ForeColor="Teal" Font-Bold="true" Font-Size="Medium"></asp:Label></td>
                </tr>
                <tr>
                    <th scope="row">40% of Church Offerings</th>
                    <td>
                        <asp:Label ID="fortyper" runat="server" ForeColor="Teal" Font-Bold="true" Font-Size="Medium" ></asp:Label></td>
                </tr>
                <tr>
                    <th scope="row">10% of Church Offerings</th>
                    <td>
                        <asp:Label ID="tenper" runat="server" ForeColor="Teal" Font-Bold="true" Font-Size="Medium"></asp:Label></td>
                </tr>
                <tr>
                    <th scope="row">Total due to Conference</th>
                    <td>
                        <asp:Label ID="totaldue" runat="server" ForeColor="Teal" Font-Bold="true" Font-Size="Medium"></asp:Label></td>

                </tr>

            </tbody>
        </table>
    </div>


</asp:Content>
