using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Etron_Model
{

    [Serializable]
    public class DelegateDisplay
    {
        public Guid id;

        public String typeName;

        public String userName;

        public String delegateUserName;

        public DateTime beginTime;

        public DateTime endTime;

        public Boolean enable;

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }
        

        public string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string DelegateUserName
        {
            get { return delegateUserName; }
            set { delegateUserName = value; }
        }

        public DateTime BeginTime
        {
            get { return beginTime; }
            set { beginTime = value; }
        }

        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        public bool Enable
        {
            get { return enable; }
            set { enable = value; }
        }

    }
}
