﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.5472
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Etron_SharePoint.WebParts.MyApply {
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
    
    
    public partial class MyApply {
        
        protected global::Microsoft.SharePoint.WebControls.SPGridView sp_GridView;
        
        public static implicit operator global::System.Web.UI.TemplateControl(MyApply target) 
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
        private global::System.Web.UI.WebControls.HyperLinkField @__BuildControl__control5() {
            global::System.Web.UI.WebControls.HyperLinkField @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.HyperLinkField();
            @__ctrl.HeaderText = "表单编号";
            @__ctrl.DataNavigateUrlFields = new string[] {
                    "FormUrl"};
            @__ctrl.DataTextField = "FormId";
            @__ctrl.ShowHeader = true;
            @__ctrl.HeaderStyle.BackColor = ((System.Drawing.Color)(System.Drawing.Color.FromArgb(195, 195, 195)));
            @__ctrl.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.BoundField @__BuildControl__control6() {
            global::System.Web.UI.WebControls.BoundField @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.BoundField();
            @__ctrl.HeaderText = "创建者";
            @__ctrl.DataField = "CreateBy";
            @__ctrl.ShowHeader = true;
            @__ctrl.HeaderStyle.BackColor = ((System.Drawing.Color)(System.Drawing.Color.FromArgb(195, 195, 195)));
            @__ctrl.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.BoundField @__BuildControl__control7() {
            global::System.Web.UI.WebControls.BoundField @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.BoundField();
            @__ctrl.HeaderText = "表单类型";
            @__ctrl.DataField = "WorkFlowType";
            @__ctrl.ShowHeader = true;
            @__ctrl.HeaderStyle.BackColor = ((System.Drawing.Color)(System.Drawing.Color.FromArgb(195, 195, 195)));
            @__ctrl.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.BoundField @__BuildControl__control8() {
            global::System.Web.UI.WebControls.BoundField @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.BoundField();
            @__ctrl.HeaderText = "创建时间";
            @__ctrl.DataField = "CreateTime";
            @__ctrl.ShowHeader = true;
            @__ctrl.HeaderStyle.BackColor = ((System.Drawing.Color)(System.Drawing.Color.FromArgb(195, 195, 195)));
            @__ctrl.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.BoundField @__BuildControl__control9() {
            global::System.Web.UI.WebControls.BoundField @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.BoundField();
            @__ctrl.HeaderText = "表单状态";
            @__ctrl.DataField = "Status";
            @__ctrl.ShowHeader = true;
            @__ctrl.HeaderStyle.BackColor = ((System.Drawing.Color)(System.Drawing.Color.FromArgb(195, 195, 195)));
            @__ctrl.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.BoundField @__BuildControl__control10() {
            global::System.Web.UI.WebControls.BoundField @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.BoundField();
            @__ctrl.HeaderText = "下一步审批者";
            @__ctrl.DataField = "NextInquisitor";
            @__ctrl.ShowHeader = true;
            @__ctrl.HeaderStyle.BackColor = ((System.Drawing.Color)(System.Drawing.Color.FromArgb(195, 195, 195)));
            @__ctrl.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control4(System.Web.UI.WebControls.DataControlFieldCollection @__ctrl) {
            global::System.Web.UI.WebControls.HyperLinkField @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control5();
            @__ctrl.Add(@__ctrl1);
            global::System.Web.UI.WebControls.BoundField @__ctrl2;
            @__ctrl2 = this.@__BuildControl__control6();
            @__ctrl.Add(@__ctrl2);
            global::System.Web.UI.WebControls.BoundField @__ctrl3;
            @__ctrl3 = this.@__BuildControl__control7();
            @__ctrl.Add(@__ctrl3);
            global::System.Web.UI.WebControls.BoundField @__ctrl4;
            @__ctrl4 = this.@__BuildControl__control8();
            @__ctrl.Add(@__ctrl4);
            global::System.Web.UI.WebControls.BoundField @__ctrl5;
            @__ctrl5 = this.@__BuildControl__control9();
            @__ctrl.Add(@__ctrl5);
            global::System.Web.UI.WebControls.BoundField @__ctrl6;
            @__ctrl6 = this.@__BuildControl__control10();
            @__ctrl.Add(@__ctrl6);
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
            this.@__BuildControl__control4(@__ctrl.Columns);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControlTree(global::Etron_SharePoint.WebParts.MyApply.MyApply @__ctrl) {
            global::Microsoft.SharePoint.WebControls.SPGridView @__ctrl1;
            @__ctrl1 = this.@__BuildControlsp_GridView();
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n<div style=\"text-align: center\">\r\n   \r\n</div>"));
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
