<%@ Page Title="Members" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="AdTresh.Members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <h2><%: Title %>.</h2>
        <div class="btn-toolbar mb-2 mb-md-0">
            <div class="btn-group mr-2">
                <button type="button" class="btn btn-sm btn-outline-secondary display" runat="server" id="displayform">Add New Member</button>
            </div>
        </div>
    </div>

    <div id="showmwmberform">
        <p class="" style="font-weight: 700">
            Create New Member
            <br />
        </p>
        <hr />
        <div class="row">
            <div class="col-lg-4">
                <div class="form-group">
                    <label><b>Surname</b></label>
                    <input type="text" class="form-control" id="surname" runat="server" />
                </div>
                <div class="form-group">
                    <label><b>Sex</b></label>
                    <select class="form-control" id="sex" runat="server" required>
                        <option value="">Please Select </option>
                        <option value="1">Male  </option>
                        <option value="2">Female </option>
                    </select>
                </div>
                <div class="form-group">
                    <label><b>Phone Number </b></label>
                    <input type="text" class="form-control" id="phonenumber" runat="server" />
                </div>
            </div>

            <div class="col-lg-4">
                <div class="form-group">
                    <label><b>First Name</b></label>
                    <input type="text" class="form-control" id="firstname" runat="server" />
                </div>
                <div class="form-group">
                    <label><b>Marital Status</b></label>
                    <select class="form-control" id="maritalstatus" runat="server" required>
                        <option value="">Please Select </option>
                        <option value="1">Single  </option>
                        <option value="2">Married </option>
                        <option value="3">Widow </option>
                        <option value="4">Widower </option>
                        <option value="5">Divorced </option>
                    </select>
                </div>
                <div class="form-group">
                    <label><b>Email Number</b> </label>
                    <input type="text" class="form-control" id="email" runat="server" />
                </div>
            </div>

            <div class="col-lg-4">
                <div class="form-group pt-2">
                    <label><b>Other Names</b>  </label>
                    <input type="text" class="form-control" id="othernames" runat="server" />
                </div>
                <div class="form-group">
                    <label><b>Residential Address</b>  </label>
                    <input type="text" class="form-control" id="residentialaddress" runat="server" />
                </div>
                <div class="form-group pt-3">
                    <asp:LinkButton CssClass="btn btn-info" ID="saveTransaction" runat="server" Width="200" OnClick="saveTransaction_Click"> <b>Save</b></asp:LinkButton>
                </div>
            </div>

        </div>
    </div>
    <div id="showmembertable">
        <p class="" style="font-weight: 700">
               
            View Members List
           </p>
  
      
        <table class="table table-striped table-hover" id="searchtable">
            <thead>
                <tr>
                     <th colspan="13">
                    
                          <input type="text" class="form-control" id="search" placeholder="Search by Membership ID" style="border-radius:0px" onkeyup="MyFilter('searchtable','search')" />
                    </th>
                       
                </tr>
                <tr>
                    <th scope="col">M.ID</th>
                    <th scope="col">First Name</th>
                    <th scope="col">Last Name</th>
                    <th scope="col">Sex</th>
                </tr>
            </thead>
            <tbody id="t_body" runat="server">
            </tbody>
        </table>
        <nav aria-label="...">
            <ul class="pagination">
                <li class="page-item">
                    <asp:LinkButton CssClass="btn btn-info" ID="Previous" runat="server" Width="200" OnClick="Previous_Click"> <b>Prev</b></asp:LinkButton>
                </li>
             
                <li class="page-item active">
                     <asp:LinkButton CssClass="btn btn-info" ID="Next" runat="server" Width="200" OnClick="Next_Click"> <b>Next</b></asp:LinkButton>
                </li>
            </ul>
        </nav>
    </div>

</asp:Content>


