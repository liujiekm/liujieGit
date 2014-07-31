using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using Etron_BLL;
using Etron_Model;

namespace Etron_SharePoint.Layouts.Etron_SharePoint
{
    public class ContractRetrive : IHttpHandler
    {
        /// <summary>
        /// 您将需要在网站的 Web.config 文件中配置此处理程序 
        /// 并向 IIS 注册它，然后才能使用它。有关详细信息，
        /// 请参见下面的链接: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // 如果无法为其他请求重用托管处理程序，则返回 false。
            // 如果按请求保留某些状态信息，则通常这将为 false。
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "text/plain";

            Int32 deptId, pageIndex, pageSize;

            Int32.TryParse(context.Request["DeptId"], out deptId);
            Int32.TryParse(context.Request["PageIndex"], out pageIndex);
            Int32.TryParse(context.Request["PageSize"], out pageSize);
            String treeType = context.Request["TreeType"];
            String type = context.Request["Type"];

            String chnName = context.Request["ChnName"];
            String enName = context.Request["EnName"];


            if (type.Equals("GetContent"))
            {
                GetContent(context, treeType,deptId, pageIndex, pageSize);
            }
            else if (type.Equals("GetCount"))
            {
                GetCount(context,treeType, deptId);
            }
            else if (type.Equals("GetAllCount"))
            {
                GetAllCount(context);
            }
            else if (type.Equals("GetFilterContent"))
            {
                GetFilterContent(context, treeType, deptId,chnName,enName ,pageIndex, pageSize);
            }
            else if (type.Equals("GetFilterCount"))
            {
                GetFilterCount(context, treeType, deptId, chnName, enName);
            }
        }

        public void GetContent(HttpContext context,String treeType, Int32 deptId, Int32 pageIndex, Int32 pageSize)
        {
            List<ContractDisplay> contracts = new List<ContractDisplay>();
            Int32 count = 0;

            contracts = ContractOperation.GetOUEmployee(treeType,deptId, pageIndex, pageSize);
         
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();

            String contractJson = jsSerializer.Serialize(contracts);

            context.Response.Write(contractJson);
        }



        public void GetCount(HttpContext context,String treeType,Int32 deptId )
        {

            context.Response.Write(ContractOperation.GetOUEmployee(treeType,deptId));

        }



        public void GetFilterContent(HttpContext context, String treeType, Int32 deptId,String chnName,String enName, Int32 pageIndex, Int32 pageSize)
        {
            List<ContractDisplay> contracts = new List<ContractDisplay>();
            Int32 count = 0;

            contracts = ContractOperation.GetFilterEmployee(treeType, deptId,chnName,enName, pageIndex, pageSize);
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();

            String contractJson = jsSerializer.Serialize(contracts);

            context.Response.Write(contractJson);
        }



        public void GetFilterCount(HttpContext context, String treeType, Int32 deptId, String chnName, String enName)
        {

            context.Response.Write(ContractOperation.GetFilterEmployee(treeType, deptId, chnName, enName));

        }



        public void GetAllCount(HttpContext context)
        {

            context.Response.Write(ContractOperation.GetAllEmployee());



        }


        #endregion
    }
}
