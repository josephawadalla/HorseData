<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RelationList.aspx.cs" Inherits="hoursedata.RelationList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-header text-right">
                    <h3 class="card-title text-info">جدول التزاوج</h3>
                    <div class="card-tools" style="direction: rtl;">
                        <div class="input-group input-group-sm text-right" style="direction: rtl;">
                            <a href="#" class="btn btn-info">أضافة تزاوج   </a>
                        </div>
                    </div>
                </div>
                <div class="card-body table-responsive p-0">
                    <table class="table table-hover text-nowrap" style="direction: rtl;">
                        <thead>
                            <tr>
                                <th class="text-center">رقم </th>
                                <th class="text-center">اسم الذكر</th>
                                <th class="text-center">اسم الانثى</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td class="text-center"><a href='ParentRelationPage?ParentRelationID=<%# Eval("ParentRelationID") %>'><%# Eval("ParentRelationID") %></a></td>
                                        <td class="text-center"><a href='ParentRelationPage?ParentRelationID=<%# Eval("ParentRelationID") %>'><%# Eval("FatherName") %></a></td>
                                        <td class="text-center"><a href='ParentRelationPage?ParentRelationID=<%# Eval("ParentRelationID") %>'><%# Eval("MotherName") %></a></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
