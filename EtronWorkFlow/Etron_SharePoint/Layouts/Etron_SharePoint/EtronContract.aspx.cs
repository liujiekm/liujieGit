using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using Etron_SharePoint.CONTROLTEMPLATES;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

using System.Runtime.Serialization;


using Etron_BLL;
using Etron_Model;

namespace Etron_SharePoint.Layouts.Etron_SharePoint
{
    public partial class EtronContract : LayoutsPageBase
    {


        public string zTreeNodes = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            //加载树
            List<ZTreeModel> lst = ContractOperation.GetDept();

            MemoryStream stream = new MemoryStream();

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof (List<ZTreeModel>));

            serializer.WriteObject(stream, lst);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);

            zTreeNodes = sr.ReadToEnd();

        }

    }
}
