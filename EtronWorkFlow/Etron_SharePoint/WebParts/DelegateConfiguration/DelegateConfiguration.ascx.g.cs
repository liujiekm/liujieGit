﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.5472
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Etron_SharePoint.WebParts.DelegateConfiguration {
    using System.Web;
    using System.Text.RegularExpressions;
    using Microsoft.SharePoint.WebPartPages;
    using Microsoft.SharePoint.WebControls;
    using System.Web.Security;
    using Microsoft.SharePoint.Utilities;
    using System.Web.UI;
    using System;
    using System.Web.UI.WebControls;
    using System.Collections.Specialized;
    using Microsoft.SharePoint;
    using System.Collections;
    using System.Web.Profile;
    using System.Text;
    using System.Web.Caching;
    using System.Configuration;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.SessionState;
    using System.Web.UI.HtmlControls;
    
    
    public partial class DelegateConfiguration {
        
        protected global::Microsoft.SharePoint.WebControls.SPGridView sp_GridView;
        
        public static implicit operator global::System.Web.UI.TemplateControl(DelegateConfiguration target) 
        {
            return target == null ? null : target.TemplateControl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control2(System.Web.UI.WebControls.TableItemStyle @__ctrl) {
            @__ctrl.CssClass = "ms-alternating";
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control3(System.Web.UI.WebControls.TableItemStyle @__ctrl) {
            @__ctrl.CssClass = "ms-selectednav";
            @__ctrl.Font.Bold = true;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::Microsoft.SharePoint.WebControls.SPGridView @__BuildControlsp_GridView() {
            global::Microsoft.SharePoint.WebControls.SPGridView @__ctrl;
            @__ctrl = new global::Microsoft.SharePoint.WebControls.SPGridView();
            this.sp_GridView = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "sp_GridView";
            @__ctrl.AutoGenerateColumns = false;
            @__ctrl.AllowPaging = true;
            @__ctrl.ShowHeader = true;
            @__ctrl.RowStyle.BackColor = ((System.Drawing.Color)(System.Drawing.Color.FromArgb(235, 235, 235)));
            @__ctrl.HeaderStyle.BackColor = ((System.Drawing.Color)(System.Drawing.Color.FromArgb(195, 195, 195)));
            @__ctrl.AlternatingRowStyle.BackColor = ((System.Drawing.Color)(System.Drawing.Color.FromArgb(246, 246, 246)));
            @__ctrl.EnableTheming = true;
            ((System.Web.UI.IAttributeAccessor)(@__ctrl)).SetAttribute("ShowHeaderWhenEmpty", "true");
            @__ctrl.SelectedRowStyle.BackColor = ((System.Drawing.Color)(System.Drawing.Color.FromArgb(237, 226, 117)));
            @__ctrl.AllowSorting = true;
            this.@__BuildControl__control2(@__ctrl.AlternatingRowStyle);
            this.@__BuildControl__control3(@__ctrl.SelectedRowStyle);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControlTree(global::Etron_SharePoint.WebParts.DelegateConfiguration.DelegateConfiguration @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n<style type=\"text/css\">\r\n    .auto-style1\r\n    {\r\n        wid" +
                        "th: 100%;\r\n    }\r\n</style>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n"));
            global::Microsoft.SharePoint.WebControls.SPGridView @__ctrl1;
            @__ctrl1 = this.@__BuildControlsp_GridView();
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n<table class=\"auto-style1\">\r\n    <tr>\r\n        <td>&nbsp;" +
                        "</td>\r\n        <td>&nbsp;</td>\r\n    </tr>\r\n    <tr>\r\n        <td>&nbsp;</td>\r\n  " +
                        "      <td>&nbsp;</td>\r\n    </tr>\r\n</table>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n"));
        }
        
        private void InitializeControl() {
            this.@__BuildControlTree(this);
            this.Load += new global::System.EventHandler(this.Page_Load);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        protected virtual object Eval(string expression) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        protected virtual string Eval(string expression, string format) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression, format);
        }
    }
}
