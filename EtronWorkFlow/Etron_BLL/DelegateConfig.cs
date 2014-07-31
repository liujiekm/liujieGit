using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


using Etron_DAL;
using Etron_Model;
using Etron_Utility;
using System.Data;
using System.Data.Entity;
using System.Collections;

namespace Etron_BLL
{
    public class DelegateConfig
    {
        public static DataTable GetAllItem()
        {
            EtronWFEntities context = new EtronWFEntities();

            EtronHREntities hrEntities= new EtronHREntities();

            IEnumerable<WF_Delegate> delegates = from i in context.WF_Delegate
                                                 join j in context.WF_Type
                                                 
                                                 on i.TypeID equals j.ID
                                                 select i;

            return Converter.ConvertToDataTable(delegates);
        }



        public static Int32 UpdateItem(WF_Delegate newDelegate)
        {
            EtronWFEntities context = new EtronWFEntities();

            WF_Delegate item = context.WF_Delegate.FirstOrDefault(p => p.ID.Equals(newDelegate.ID));
            item = newDelegate;
            return context.SaveChanges();
        }

        public static Int32 DeleteItem(WF_Delegate item)
        {
            var context = new EtronWFEntities();
            WF_Delegate del = context.WF_Delegate.FirstOrDefault(p => p.ID.Equals(item.ID));
            if (del != null)
            {
                context.DeleteObject(del);
                return context.SaveChanges();
            }
            return 0;
        }

        public static Int32 InsertDelegate(WF_Delegate item)
        {
            var context = new EtronWFEntities();
            context.AddToWF_Delegate(item);
            return context.SaveChanges();
        }

        
    }
}
