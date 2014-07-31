using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etron_DAL;
using Etron_Model;

namespace Etron_BLL
{
    public class BirthdayOperation
    {
        public static List<String> GetBirthdayUser()
        {
            
            DateTime current = DateTime.Now;
           
            //获得当前月份
            Int32 currentMonth = current.Month;
         
            EtronHREntities context = new EtronHREntities();
            List<String> usersList =
                context.hr005.Where(p => p.birthday.Month==currentMonth)
                    .Select(p => p.chName)
                    .ToList();

            return usersList;
        }


        public static List<NoticeBoard> GetNoticeBoard()
        {
            EtronHREntities context = new EtronHREntities();

            var result = from i in context.tblNoticeBoard
                where i.numState == 0
                orderby i.dt_Update descending
                select new NoticeBoard
                {
                    NoticeTitle= i.NoticeTitle,
                    NoticeType = i.NoticeType,
                    NoticeContent = i.NoticeContent,
                    NoticeSign = i.NoticeSign
                };

            return result.ToList();
        }


    }
}
