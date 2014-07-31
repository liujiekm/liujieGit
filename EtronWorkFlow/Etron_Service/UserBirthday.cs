using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

using Microsoft.SharePoint.Client.Services;
using Microsoft.SharePoint;


using Etron_BLL;

namespace Etron_Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“UserBirthday”。
    [BasicHttpBindingServiceMetadataExchangeEndpoint]//此属性指示 SharePoint Foundation 服务工厂自动为服务创建元数据交换终结点
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class UserBirthday : IUserBirthday
    {
        public List<String> GetBirthdayUser()
        {
            return BirthdayOperation.GetBirthdayUser();
        }
    }
}
