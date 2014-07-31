using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

using Etron_BLL;
using Microsoft.SharePoint.Client.Services;

namespace Etron_SharePoint.ISAPI.UserBirthdayService
{
    [BasicHttpBindingServiceMetadataExchangeEndpoint]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class UserBirthday:IUserBirthday
    {
        public List<string> GetBirthdayUser()
        {
            return BirthdayOperation.GetBirthdayUser();
 
        }


        public string Test()
        {
            return "fuck";
        }


        public List<Etron_Model.NoticeBoard> GetNoticeBoard()
        {
            return BirthdayOperation.GetNoticeBoard();
        }
    }
}
