<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HourseCertificate.aspx.cs" Inherits="hoursedata.HourseCertificate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-2" style="height: 800px; padding-top: 300px;">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="card">
                        <div class="card-body"><a href='HourseCertificate?HourseID=<%# Eval("HourseID") %>'><%# Eval("HourseName") %></a> </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="col-md-2" style="height: 800px; padding-top: 280px;">
            <asp:Repeater ID="Repeater2" runat="server">
                <ItemTemplate>
                    <div style="padding: 3px;">
                        <div class="card">
                            <div class="card-body"><a href='HourseCertificate?HourseID=<%# Eval("HourseID") %>'><%# Eval("HourseName") %></a> </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="col-md-2" style="height: 800px; padding-top: 240px;">
            <asp:Repeater ID="Repeater3" runat="server">
                <ItemTemplate>
                    <div style="padding: 3px;">
                        <div class="card">
                            <div class="card-body"><a href='HourseCertificate?HourseID=<%# Eval("HourseID") %>'><%# Eval("HourseName") %></a> </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="col-md-2" style="height: 800px; padding-top: 160px;">
            <asp:Repeater ID="Repeater4" runat="server">
                <ItemTemplate>
                    <div style="padding: 3px;">
                        <div class="card">
                            <div class="card-body"><a href='HourseCertificate?HourseID=<%# Eval("HourseID") %>'><%# Eval("HourseName") %></a> </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="col-md-2" style="height: 800px; padding-top: 80px;">
            <asp:Repeater ID="Repeater5" runat="server">
                <ItemTemplate>
                    <div style="padding: 3px;">
                        <div class="card">
                            <div class="card-body"><a href='HourseCertificate?HourseID=<%# Eval("HourseID") %>'><%# Eval("HourseName") %></a> </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="col-md-2">
            <asp:Repeater ID="Repeater6" runat="server">
                <ItemTemplate>
                    <div style="padding: 3px;">
                        <div class="card">
                            <div class="card-body"><a href='HourseCertificate?HourseID=<%# Eval("HourseID") %>'><%# Eval("HourseName") %></a> </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
