<%@ Page Title="Reports" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="AdTresh.Reports" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <h2><%: Title %>.</h2>
    </div>

    <div class="row pt-3 entireDiv">
        <div class="col-md-9">
            <h5 class="pb-3">Select type to generate  </h5>

            <select class="form-control selectreport" id="specialprojectname" style="width: 405px" runat="server" required>
                <option value="">Please Select </option>
                <%--<option value="yearlyReport">Monthly Report  </option>--%>
                <option value="monthlyReport">Monthly Report  </option>
                <option value="weeklySummary">Weekly Summary  </option>
                <option value="simpleSummary">Simple Summary </option>
              
            </select>
            <div id="showMonthlyFields">
                <div class="input-group pt-3 row">
                    <div class="col-sm-6">

                        <select class="form-control selectMonth" id="month" style="width: 200px" runat="server" >
                            <option value="">Select Month </option>
                            <option value="January">January  </option>
                            <option value="February">February  </option>
                            <option value="March">March  </option>
                            <option value="April">April  </option>
                            <option value="May">May </option>
                            <option value="June">June </option>
                            <option value="July">July </option>
                            <option value="August">August </option>
                            <option value="September">September </option>
                            <option value="October">October </option>
                            <option value="November">November </option>
                            <option value="December">December </option>
                        </select>
                    </div>

                    <div class="col-sm-6">
                        <select class="form-control selectYear" id="year" style="width: 200px;  margin-left: -130px" runat="server">
                            <option value="">Select Year </option>
                            <option value="2021">2021  </option>
                            <option value="2020">2020  </option>
                            <option value="2011">2019  </option>
                            <option value="2010">2010  </option>
                            <option value="2009">2009  </option>
                            <option value="2008">2008 </option>
                            <option value="2007">2007 </option>
                            <option value="2006">2006 </option>
                            <option value="2005">2005 </option>
                        </select>
                    </div>

                </div>
            </div>
            <div id="showWeeklyFields">
                <div class="input-group pt-3 row">
                    <div class="col-sm-6">
                        <input type="date" class="form-control" id="week" placeholder="DD-MM-YYYY" style="width: 200px" runat="server" />
                    </div>
                </div>
            </div>
               <div id="showSimpleSumamry">
                <div class="input-group pt-3 row">
                    <div class="col-sm-6">
                        <input type="date" class="form-control" id="simpleSummary" placeholder="DD-MM-YYYY" style="width: 200px" runat="server" />
                    </div>
                </div>
            </div>
            <div class=" pt-3">
                <asp:Button ID="Generate" runat="server" Text="Generate" OnClick="Generate_Click" CssClass="btn btn-outline-info" Width="200" />
            </div>

        </div>
        <div class="col-md-3">
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
        </div>

    


    </div>
</asp:Content>
