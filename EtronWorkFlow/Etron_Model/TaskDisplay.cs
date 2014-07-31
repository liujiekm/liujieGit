using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Etron_Model
{
    [Serializable]
    public class TaskDisplay
    {
        public TaskDisplay()
        {

        }

        private string formUrl;
        private string formId;
        private string workFlowType;
        private string createBy;
        private string createByEn;
        private DateTime createTime;
        private string status;
        private string nextInquisitor;
        private string nextInquisitorEn;
        private DateTime processTime;
        private string lasttimeInquisitor;
        private string lasttimeInquisitorEn;
        private DateTime lasttimeProcessTime;
        private string lasttimeStatus;

        public string FormUrl
        {
            get { return formUrl; }
            set { formUrl = value; }
        }

        public string FormId
        {
            get { return formId; }
            set { formId = value; }
        }
        public string WorkFlowType
        {
            get { return workFlowType; }
            set { workFlowType = value; }
        }

        public string CreateBy
        {
            get { return createBy; }
            set { createBy = value; }
        }
        public string CreateByEn
        {
            get { return createByEn; }
            set { createByEn = value; }
        }
        public DateTime CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public string NextInquisitor
        {
            get { return nextInquisitor; }
            set { nextInquisitor = value; }
        }
        public string NextInquisitorEn
        {
            get { return nextInquisitorEn; }
            set { nextInquisitorEn = value; }
        }
        public DateTime ProcessTime
        {
            get { return processTime; }
            set { processTime = value; }
        }
        public string LasttimeInquisitor
        {
            get { return lasttimeInquisitor; }
            set { lasttimeInquisitor = value; }
        }
        public string LasttimeInquisitorEn
        {
            get { return lasttimeInquisitorEn; }
            set { lasttimeInquisitorEn = value; }
        }
        public DateTime LasttimeProcessTime
        {
            get { return lasttimeProcessTime; }
            set { lasttimeProcessTime = value; }
        }
        public string LasttimeStatus
        {
            get { return lasttimeStatus; }
            set { lasttimeStatus = value; }
        }
    }
}
