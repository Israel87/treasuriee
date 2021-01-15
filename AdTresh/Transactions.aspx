<%@ Page Title="Record Transaction" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Transactions.aspx.cs" Inherits="AdTresh.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <h2><%: Title %>.</h2>
        <div class="btn-toolbar mb-2 mb-md-0">
        </div>
    </div>

      

    <div class="row pt-5">
    

        <div class="col-lg-8">
              <h6 >Search Parameters</h6><hr />
                 <div class="row">
                          
                     <div class="col-lg-6">
                              <p class="" style="font-weight: 700">
                                    Entry Date
                                    <br />
                                </p>
                            <div class="input-group mb-3">
                                <input type="date" class="form-control" placeholder="Member ID" runat="server" id="entrydate">
                        
                             <%--<div class="input-group-append">
                                    <asp:LinkButton CssClass="btn btn-info" ID="generateData" runat="server" OnClick="generateData_Click"> <b>Generate Data</b></asp:LinkButton>
                                 </div>--%>

                            </div>

                          <h6 class="pt-5" >Member Details</h6><hr />

                            <div class="form-group">
                                <label><b>First Name</b></label>
                                <input type="text" class="form-control" id="firstName" runat="server" />
                            </div>
                            <div class="form-group">
                                <label><b>Address</b></label>
                                <input type="text" class="form-control" id="address" runat="server" />
                            </div>
                            <div class="form-group">
                                <label><b>Status</b> </label>
                                <input type="text" class="form-control" id="status" runat="server" />
                            </div>

                </div>
                      
                <div class="col-lg-6">
                       
                     <p class="" style="font-weight: 700">
                      Membership ID
                        <br />
                    </p>
                    <div class="input-group mb-3">
                        <input type="text" class="form-control" placeholder="Member ID" runat="server" id="memId">
                        
                        <div class="input-group-append">

                            <asp:LinkButton CssClass="btn btn-info" ID="LinkButton1" runat="server" OnClick="generateData_Click"> <b>Generate Data</b></asp:LinkButton>
                        </div>
                    </div>

                     <h6 class="pt-5"><br /></h6><hr />
                    <div class="form-group">
                        <label><b>Last Name</b>  </label>
                        <input type="text" class="form-control" id="lastName" runat="server" />
                    </div>
                    <div class="form-group">
                        <label><b>Phone Number</b>  </label>
                        <input type="text" class="form-control" id="phonenumber" runat="server" />
                    </div>
                    <div class="form-group">
                        <label><b>Email</b></label>
                        <input type="text" class="form-control" id="email" runat="server" />
                    </div>

                     <%--<asp:LinkButton CssClass="btn btn-info" ID="UpdateData" runat="server" OnClick="UpdateData_Click" Width="200"> <b>Update</b></asp:LinkButton>--%>
                </div>
            </div>

        </div>

        <div class="col-lg-4 pl-4 wrapperxs card">

            <p class="" style="font-weight: 700">
                Regular Offering
                <br />
            </p>

            <div class="p5">
                <div class="form-group">
                    <label>Tithe </label>
                    <input type="text" class="form-control" id="tithe" runat="server" />
                </div>
                <div class="form-group">
                    <label>Church Expense Offering </label>
                    <input type="text" class="form-control" id="offering" runat="server" />
                </div>
                <div class="form-group">
                    <p class="" style="font-weight: 700">
                        Other Offering
                        <br />
                    </p>
                    <select class="form-control form-input-wide" id="paymenttype" runat="server" required>
                        <option value="">Please Select </option>
                        <option value="Church Building">Church Building </option>
                        <option value="Sabbath School">Sabbath School </option>
                        <option value="Children's Department">Children's Department </option>
                        <option value="Choir">Choir </option>
                        <option value="AWM">AWM</option>
                        <option value="Special Project">Special Project</option>
                    </select>
                </div>
                <div class="form-group">
                    <label>Amount</label>
                    <input type="text" class="form-control" id="amount" runat="server" />
                </div>
                <div class="form-group">

                    <label>Remark</label>
                    <textarea type="text" class="form-control" id="remark" runat="server" />
                </div>
                <asp:LinkButton CssClass="btn btn-info" ID="saveTransaction" runat="server" OnClick="saveTransaction_Click"> <b>Submit</b></asp:LinkButton>

            </div>


        </div>


    </div>

</asp:Content>
