<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyApproved.ascx.cs" Inherits="Etron_SharePoint.WebParts.MyApproved.MyApproved" %>

<SharePoint:SPGridView ID="sp_GridView" runat="server" AutoGenerateColumns="False" AllowPaging="True"
    ShowHeader="true" RowStyle-BackColor="#EBEBEB" HeaderStyle-BackColor="#C3C3C3"
    AlternatingRowStyle-BackColor="#F6F6F6" EnableTheming="true" ShowHeaderWhenEmpty="true"
   SelectedRowStyle-BackColor="#EDE275" AllowSorting="true">
    <AlternatingRowStyle CssClass="ms-alternating" />
    <SelectedRowStyle CssClass="ms-selectednav" Font-Bold="True" />
    <Columns>
        <asp:HyperLinkField HeaderText="表单编号" DataNavigateUrlFields="FormUrl"
            DataTextField="FormId"
            ShowHeader="true" HeaderStyle-BackColor="#C3C3C3"
            HeaderStyle-ForeColor="#000000" />
        <asp:BoundField HeaderText="创建者" DataField="CreateBy" ShowHeader="true"
            HeaderStyle-BackColor="#C3C3C3" HeaderStyle-ForeColor="#000000" />
        <asp:BoundField HeaderText="表单类型" DataField="WorkFlowType" ShowHeader="true"
            HeaderStyle-BackColor="#C3C3C3" HeaderStyle-ForeColor="#000000" />
        <asp:BoundField HeaderText="创建时间" DataField="CreateTime" ShowHeader="true"
            HeaderStyle-BackColor="#C3C3C3" HeaderStyle-ForeColor="#000000" />
        <asp:BoundField HeaderText="表单状态" DataField="Status" ShowHeader="true"
            HeaderStyle-BackColor="#C3C3C3" HeaderStyle-ForeColor="#000000" />
        <asp:BoundField HeaderText="下一步审批者" DataField="NextInquisitor" ShowHeader="true"
            HeaderStyle-BackColor="#C3C3C3" HeaderStyle-ForeColor="#000000" />

    </Columns>

</SharePoint:SPGridView>
<div style="text-align: center">
  <%--  <SharePoint:SPGridViewPager ID="sp_GridViewPager" runat="server" GridViewId="sp_GridView">
    </SharePoint:SPGridViewPager>--%>
</div>