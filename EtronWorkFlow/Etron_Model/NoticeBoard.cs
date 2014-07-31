using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Etron_Model
{
    [DataContract]
    public class NoticeBoard
    {
        [DataMember]
        private String noticeTitle;
        [DataMember]
        private String noticeType;
        [DataMember]
        private String noticeContent;
        [DataMember]
        private String noticeSign;


        public string NoticeTitle
        {
            get { return noticeTitle; }
            set { noticeTitle = value; }
        }

        public string NoticeType
        {
            get { return noticeType; }
            set { noticeType = value; }
        }

        public string NoticeContent
        {
            get { return noticeContent; }
            set { noticeContent = value; }
        }

        public string NoticeSign
        {
            get { return noticeSign; }
            set { noticeSign = value; }
        }
    }
}
