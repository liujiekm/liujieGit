using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Etron_Model;

namespace Etron_SharePoint.ISAPI.UserBirthdayService
{
    [ServiceContract]
    interface IUserBirthday
    {
        [OperationContract]
        [WebGet(UriTemplate = "/GetBirthdayUser", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        List<String> GetBirthdayUser();



        [OperationContract]
        [WebGet(UriTemplate = "/GetNoticeBoard", BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json)]
        List<NoticeBoard> GetNoticeBoard();




        [OperationContract]
        [WebGet(UriTemplate = "/Test", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        String Test();


    }
}
