<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pager.ascx.cs" Inherits="Etron_SharePoint.CONTROLTEMPLATES.Pager" %>

<style type="text/css">
   
.num_blue{ color: #369; font-size: 14px; font-family: 宋体; background-color: #e7f2fc; width:15px; border: solid 1px #85bcf1; text-align:center; text-decoration:none }

.num_yellow{ color: #369; font-size: 14px; font-family: 宋体; background-color: #ffebcc; width:15px;  border: solid 1px #ff9900; text-align:center; text-decoration:none  } 

</style>


<table id="pager" border="0" cellpadding="0" cellspacing="0" width="100%" style="text-align: center;">
    <tr>
        <td>
            <asp:LinkButton ID="lbtnFirstLink" runat="server" CausesValidation="false" OnClick="ClickEvent">首页</asp:LinkButton>
            <asp:LinkButton ID="lbtnPrevPage" runat="server" CausesValidation="false"  OnClick="ClickEvent">上一页</asp:LinkButton>
    
            <asp:Repeater ID="rptNum" runat="server" OnItemCommand="rptNum_ItemCommand">
                <ItemTemplate>
    <asp:LinkButton ID="lbtnNum" runat="server" CausesValidation="false" CommandArgument='<%# Container.DataItem %>'
    CssClass='<%# Convert.ToInt32(Container.DataItem)==PageIndex?"num_yellow":"num_blue"%>' Width="15"><%# Container.DataItem %>
</asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
      
            <asp:LinkButton ID="lbtnNextPage" runat="server" CausesValidation="false"  OnClick="ClickEvent">下一页</asp:LinkButton>
            <asp:LinkButton ID="lbtnLastPage" runat="server" CausesValidation="false"  OnClick="ClickEvent">尾页</asp:LinkButton>
            <asp:HiddenField ID="hfBindName" runat="server" />
        </td>
    </tr>
</table>
