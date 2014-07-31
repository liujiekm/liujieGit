using System;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Etron_SharePoint.CONTROLTEMPLATES
{
    public partial class Pager : UserControl
    {
        //当前第几页
        private int _PageIndex;

        public int PageIndex
        {
            get
            {
                if (_PageIndex == 0)
                {
                    _PageIndex = 1;
                }
                return _PageIndex;
            }
            set { _PageIndex = value; }
        }


        //每页多少条
        private int _PageSize;

        public int PageSize
        {
            get
            {
                if (_PageSize == 0)
                {
                    _PageSize = 1;
                }
                return _PageSize;
            }
            set { _PageSize = value; }
        }


        //总条目数
        private int _Count;

        public int Count
        {
            get { return _Count; }
            set { _Count = value; }
        }

        //绑定的方法名称，用于反射绑定数据
        public string BindName
        {
            get { return hfBindName.Value; }
            set { hfBindName.Value = value; }
        }




        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //绑定分页数字
                BindPager();
            }
        }




        //绑定分页数字
        public void BindPager()
        {
            Int32 pageCount = (Count%PageSize) == 0 ? Count/PageSize : Count/PageSize + 1;

            //设置四个按钮可用状态设置
            SetButtonEnable(pageCount);
            //绑定循环数字
            BindPageNum(pageCount);

        }

        /// <summary>
        /// 设置四个按钮可用状态设置
        /// </summary>
        /// <param name="pageCount">页数</param>

        private void SetButtonEnable(Int32 pageCount)
        {
            lbtnFirstLink.Enabled = PageIndex != 1;
            lbtnPrevPage.Enabled = PageIndex != 1;

            lbtnNextPage.Enabled = PageIndex != pageCount;
            lbtnLastPage.Enabled = PageIndex != pageCount;


            lbtnFirstLink.CommandArgument = "1";
            lbtnPrevPage.CommandArgument = (PageIndex - 1).ToString();

            lbtnNextPage.CommandArgument = (PageIndex + 1).ToString();
            lbtnLastPage.CommandArgument = pageCount.ToString();


        }



        /// <summary>
        /// 绑定循环数字
        /// </summary>
        /// <param name="pageCount">总页数</param>
        protected void BindPageNum(Int32 pageCount)
        {
            Int32 start = 1, end = 10;
            if (pageCount < end)
            {
                end = pageCount;
            }
            else
            {
                start = (PageIndex > 5) ? PageIndex - 5 : start;
                Int32 result = (start + 9) - pageCount;//是否超过最后面的页数
                if (result > 0)
                {
                    end = pageCount;
                    start -= result;
                }
                else
                {
                    end = start + 9;
                }
            }


            //根据开始页码，结束页码生成连续数字
            ReBuildNum(start, end);
        }


        //根据开始页码，结束页码生成连续数字
        private void ReBuildNum(Int32 start, Int32 end)
        {
            Int32[] rows = new Int32[end-start+1];
            Int32 index = 0;
            for (int i = start; i <= end; i++)
            {
                rows[index] = i;
                index++;
            }
            rptNum.DataSource = rows;
            rptNum.DataBind();
        }


        //反射绑定
        private void ReBindData(String pageIndex)
        {
            Int32 PageIndex = Int32.Parse(pageIndex);
            //object obj = base.Parent is HtmlForm ? this.Page : base.Parent;
            this.PageIndex = PageIndex;
            object obj = this.Page;
            MethodInfo method = obj.GetType().GetMethod(BindName);

            method.Invoke(obj, null);
            BindPager();
        }





        protected void ClickEvent(Object sender, EventArgs args)
        {
            ReBindData(((LinkButton)sender).CommandArgument.ToString());

        }

        protected void rptNum_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ReBindData(e.CommandArgument.ToString());
        }


    }
}
