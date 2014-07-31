using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Etron_DAL;
using Etron_Model;
using Etron_Utility;
using System.Data;
using System.Data.Entity;
using System.Collections;



namespace Etron_BLL
{
    public class RetriveData
    {
      






        //获得我的任务
        public static DataTable  GetMyTask(String currentUser)
        {
            using (EtronWFEntities context = new EtronWFEntities())
            {

                var rec = from i in context.WF_Task
                    join j in context.WF_Type on i.TypeID equals j.ID
                          select new TaskDisplay
                          {
                              FormId = i.FormCode,
                              FormUrl = i.FormUrl,
                              CreateBy = i.CreaterDisplayName,
                              CreateByEn = i.CreaterAccount,
                              CreateTime = i.CreateTime.Value,
                              WorkFlowType = j.TypeName,
                              Status = i.State,
                              ProcessTime = i.ProcessTime.Value,
                              NextInquisitorEn = i.NextInquisitorAccount,
                              NextInquisitor = i.NextInquisitorDisplayName,
                              LasttimeStatus = i.LastState,
                              LasttimeInquisitor = i.LastInquisitorDisplayName,
                              LasttimeInquisitorEn = i.LastInquisitorAccount,
                              LasttimeProcessTime = i.LastProcessTime.Value
                          };

                List<TaskDisplay> tasks = new List<TaskDisplay>();
                foreach (TaskDisplay wfTask in rec)
                {
                    String[] nextInquisitors = wfTask.NextInquisitorEn.Split(new char[] { '$' },
                        StringSplitOptions.RemoveEmptyEntries);
                    
                    if (nextInquisitors.Contains(currentUser))
                    {
                        tasks.Add(wfTask);
                    }
                }

                return Converter.ConvertToDataTable(tasks);
            }
            
            
        }

        //获得我发起的表单
        public static DataTable GetMyApply(String currentUser)
        {
            using (EtronWFEntities context = new EtronWFEntities())
            {
                var result = from i in context.WF_Task
                             join j in context.WF_Type on i.TypeID equals j.ID
                             where i.CreaterAccount.Equals(currentUser)
                             select new TaskDisplay
                             {
                                 FormId = i.FormCode,
                                 FormUrl = i.FormUrl,
                                 CreateBy = i.CreaterDisplayName,
                                 CreateByEn = i.CreaterAccount,
                                 CreateTime = i.CreateTime.Value,
                                 WorkFlowType = j.TypeName,
                                 Status = i.State,
                                 ProcessTime = i.ProcessTime.Value,
                                 NextInquisitorEn = i.NextInquisitorAccount,
                                 NextInquisitor = i.NextInquisitorDisplayName,
                                 LasttimeStatus = i.LastState,
                                 LasttimeInquisitor = i.LastInquisitorDisplayName,
                                 LasttimeInquisitorEn = i.LastInquisitorAccount,
                                 LasttimeProcessTime = i.LastProcessTime.Value
                             };

                return Converter.ConvertToDataTable(result);
            }
 }

        //获得我审批过的表单
        public static DataTable GetMyApproved(String currentUser)
        {
            using (EtronWFEntities context = new EtronWFEntities())
            {
                var result = (from i in context.WF_Task
                             join j in context.WF_Type on i.TypeID equals j.ID
                             join k in context.WF_Record on i.ID equals k.TaskID
                             where k.ApproverAccount.Equals(currentUser)
                             select new TaskDisplay
                             {
                                 FormId = i.FormCode,
                                 FormUrl = i.FormUrl,
                                 CreateBy = i.CreaterDisplayName,
                                 CreateByEn = i.CreaterAccount,
                                 CreateTime = i.CreateTime.Value,
                                 WorkFlowType = j.TypeName,
                                 Status = i.State,
                                 ProcessTime = i.ProcessTime.Value,
                                 NextInquisitorEn = i.NextInquisitorAccount,
                                 NextInquisitor = i.NextInquisitorDisplayName,
                                 LasttimeStatus = i.LastState,
                                 LasttimeInquisitor = i.LastInquisitorDisplayName,
                                 LasttimeInquisitorEn = i.LastInquisitorAccount,
                                 LasttimeProcessTime = i.LastProcessTime.Value
                             }).Distinct();

                return Converter.ConvertToDataTable(result);
            }
            
            
        }





    }
}
