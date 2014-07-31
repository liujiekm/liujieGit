using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI.WebControls.WebParts;


using System.Data;
using System.Data.Entity;
using System.Linq;
using Etron_Utility;
using Microsoft.SharePoint.WebControls;
using System.Web.UI.WebControls;
using System.Collections;


using Etron_BLL;

namespace Etron_SharePoint.WebParts.MyApproved
{
    [ToolboxItemAttribute(false)]
    public partial class MyApproved : WebPart
    {
        // 仅当使用检测方法对场解决方案进行性能分析时才取消注释以下 SecurityPermission
        // 特性，然后在代码准备进行生产时移除 SecurityPermission 特性
        // 特性。因为 SecurityPermission 特性会绕过针对您的构造函数的调用方的
        // 安全检查，不建议将它用于生产。
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public MyApproved()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Controls.Add(CreateDataSource());
            SPGridView spGridView = this.sp_GridView;
            ConfigSPGridView(spGridView);
        }


        //Config SPGridView
        public SPGridView ConfigSPGridView(SPGridView spGridView)
        {
            //{0}表示过滤值，{1}表示过滤字段值
            spGridView.FilteredDataSourcePropertyFormat = "{1}='{0}'";
            spGridView.FilteredDataSourcePropertyName = "FilterExpression";
            spGridView.EnableViewState = false;
            spGridView.AllowSorting = true;

            //设置分页
            spGridView.AllowPaging = true;
            spGridView.PageSize = 10;
            spGridView.PageIndexChanging += spGridView_PageIndexChanging;
            spGridView.PagerTemplate = new SmartPager(1, spGridView);
            //设置过滤字段
            spGridView.AllowFiltering = true;
            spGridView.FilterDataFields = "FormId,CreateBy,WorkFlowType,CreateTime,Status,NextInquisitor";
            //设置分组
            //spGridView.AllowGrouping = true;
            //spGridView.AllowGroupCollapse = true;
            //spGridView.GroupField = "WorkFlowType";
            //spGridView.GroupDescriptionField = "WorkFlowType";
            //spGridView.GroupFieldDisplayName = "分组:";

            //绑定数据源
            spGridView.DataSourceID = "approved_ObjectDataSource";//关联ObjectDataSource ID
            spGridView.DataBind();

            return spGridView;

        }



        void spGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            sp_GridView.PageIndex = e.NewPageIndex;
            sp_GridView.DataBind();
        }

        public ObjectDataSource CreateDataSource()
        {
            ObjectDataSource odsDataSource = new ObjectDataSource();
            odsDataSource.ID = "approved_ObjectDataSource";
            odsDataSource.TypeName = this.GetType().FullName + "," + this.GetType().Assembly.FullName;
            odsDataSource.SelectMethod = "GetDataSource";
            return odsDataSource;

        }


        public DataTable GetDataSource()
        {
            String currentUser = HttpContext.Current.User.Identity.Name.Split('\\')[1];
            return RetriveData.GetMyApproved(currentUser);
        }
    }
}
