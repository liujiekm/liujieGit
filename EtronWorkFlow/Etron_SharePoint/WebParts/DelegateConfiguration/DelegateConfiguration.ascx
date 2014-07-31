<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DelegateConfiguration.ascx.cs" Inherits="Etron_SharePoint.WebParts.DelegateConfiguration.DelegateConfiguration" %>









<style type="text/css">
    .auto-style1
    {
        width: 100%;
    }
</style>









<SharePoint:SPGridView ID="sp_GridView" runat="server" AutoGenerateColumns="False" AllowPaging="True"
    ShowHeader="true" RowStyle-BackColor="#EBEBEB" HeaderStyle-BackColor="#C3C3C3"
    AlternatingRowStyle-BackColor="#F6F6F6" EnableTheming="true" ShowHeaderWhenEmpty="true"
    SelectedRowStyle-BackColor="#EDE275" AllowSorting="true"
    >
    <AlternatingRowStyle CssClass="ms-alternating" />
    <SelectedRowStyle CssClass="ms-selectednav" Font-Bold="True" />
    <Columns>
       <%-- <asp:BoundField HeaderText="被代理者" DataField="UserAccount" ShowHeader="true"
            HeaderStyle-BackColor="#C3C3C3" HeaderStyle-ForeColor="#000000" />
        <asp:BoundField HeaderText="代理者" DataField="DelegateUserAccount" ShowHeader="true"
            HeaderStyle-BackColor="#C3C3C3" HeaderStyle-ForeColor="#000000" />
        <asp:BoundField HeaderText="表单类型" DataField="Work" ShowHeader="true"
            HeaderStyle-BackColor="#C3C3C3" HeaderStyle-ForeColor="#000000" />
        <asp:BoundField HeaderText="生效开始时间" DataField="BeginTime" ShowHeader="true"
            HeaderStyle-BackColor="#C3C3C3" HeaderStyle-ForeColor="#000000" />
        <asp:BoundField HeaderText="生效结束时间" DataField="EndTime" ShowHeader="true"
            HeaderStyle-BackColor="#C3C3C3" HeaderStyle-ForeColor="#000000" />
        <asp:BoundField HeaderText="是否可用" DataField="Enable" ShowHeader="true"
            HeaderStyle-BackColor="#C3C3C3" HeaderStyle-ForeColor="#000000" />--%>

    </Columns>

</SharePoint:SPGridView>











<table class="auto-style1">
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>












<%--<table>
    <thead>
<tr>
        <td rowspan="2">序号</td>
        <td rowspan="2">项目名称</td>
        <td colspan="3">项目组人员</td>
        <td colspan="5">进程</td>
        <td rowspan="2">拟投资金额</td>
        <td rowspan="2">以投资金额</td>
        <td rowspan="2">项目来源</td>
    </tr>
    <tr>
        <td>项目经理</td>
        <td>风险经理</td>
        <td>项目执行人员</td>
        <td>部门立项</td>
        <td>公司立项</td>
        <td>投决会</td>
        <td>投后管理</td>
        <td>投资退出</td>
    </tr>
        </thead>
    <tbody>
        
         <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>

    </tbody>
    </table>--%>