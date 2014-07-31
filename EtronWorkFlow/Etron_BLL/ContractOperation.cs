using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

using Etron_DAL;
using Etron_Model;
using Etron_Utility;
using System.Data;
using System.Data.Entity;
using System.Collections;

namespace Etron_BLL
{
    public class ContractOperation
    {
        //查询公司内所有员工
        public static String GetAllEmployee()
        {

            EtronHREntities context = new EtronHREntities();

            return context.hr005.Distinct().Count().ToString();
            
            
        }


        //查询公司内所有员工
        public static List<ContractDisplay> GetAllEmployee(Int32 pageIndex,Int32 pageSize)
        {
            EtronHREntities context = new EtronHREntities();
            List<ContractDisplay> contracts = new List<ContractDisplay>();

            var result = context.hr005.Distinct().OrderByDescending(j => j.hr012Tsn).Skip(pageIndex * pageSize).Take(pageSize);

            foreach (var item in result)
            {

                var hr005a = from x in context.hr005a
                                  where x.hr005tsn.Equals(item.tsn)
                                  select x;
                String position = String.Empty;
                foreach (var hr005Item in hr005a)
                {
                    //根据职位编号找编号名称
                    var hr001 = context.hr001.FirstOrDefault(p => p.tsn.Equals(hr005Item.hr001Tsn));
                    if (hr001 != null)
                    {
                        var positionName = hr001.name;
                        position += positionName + " ";
                    }
                }
                ContractDisplay contract = new ContractDisplay
                {
                    Name = item.chName,
                    Ename = item.enName,
                    Email = item.email,
                    Gender = item.sex,
                    MobilePhone = item.mobilephone1,
                    Position = position,
                    PhoneSuffix = item.mobilephone2,
                    NewExtension = item.telephone1,
                    Photo = item.photo,
                    IsNew = IsNew(item.startDay)
                };
                contracts.Add(contract);


            }
            return contracts;


        }


        public static Boolean IsNew(DateTime startDateTime)
        {
            
            DateTime currentTime = DateTime.Now;

            TimeSpan timeSpan = currentTime - startDateTime;


            return timeSpan.TotalDays<=31;
        }


        public static String GetOUEmployee(String treeType,Int32 id)
        {


            EtronHREntities context = new EtronHREntities();
            String count = String.Empty;
            if (String.IsNullOrEmpty(treeType) || treeType.Equals("root"))
            {
                count = GetAllEmployee();
            }
            else if (treeType.Equals("dept"))
            {
                var result = from i in context.hr006
                             join j in context.hr005
                                 on i.hr005Tsn equals j.tsn
                             join x in context.hr003
                                 on i.hr003Tsn equals x.tsn
                             where x.tsn.Equals(id)&&i.enab.Equals(1)&&x.enab.Equals(1)
                             select j;
                count = result.Distinct().Count().ToString();
            }
            else if (treeType.Equals("group"))
            {
                var result = from i in context.hr006cft
                             join j in context.hr005
                                 on i.hr005Tsn equals j.tsn
                             join x in context.hr003cft
                                 on i.hr003cftTsn equals x.tsn
                             where x.tsn.Equals(id-100)&&i.enab.Equals(1)&&x.enab.Equals(1)
                             select j;
                count = result.Distinct().Count().ToString();

            }


            

            return count;


        }








        public static List<ContractDisplay> GetOUEmployee(String treeType, Int32 Id, Int32 pageIndex, Int32 pageSize)
        {

            EtronHREntities context = new EtronHREntities();
            List<ContractDisplay> contracts = new List<ContractDisplay>();



            IQueryable<hr005> result = null;



            if (String.IsNullOrEmpty(treeType)||treeType.Equals("root"))
            {
                result=context.hr005.Distinct().OrderByDescending(j => j.hr012Tsn).Skip(pageIndex * pageSize).Take(pageSize);
            }
            else if (treeType.Equals("dept"))
            {
                result = (from i in context.hr006
                              join j in context.hr005
                                  on i.hr005Tsn equals j.tsn
                              join x in context.hr003
                                  on i.hr003Tsn equals x.tsn
                              where x.tsn.Equals(Id)&&i.enab.Equals(1)&&x.enab.Equals(1)
                              orderby j.chName
                              select j).Distinct().OrderByDescending(j => j.hr012Tsn).Skip(pageIndex * pageSize).Take(pageSize);
            }
            else if (treeType.Equals("group"))
            {
                result = (from i in context.hr006cft
                          join j in context.hr005
                              on i.hr005Tsn equals j.tsn
                          join x in context.hr003cft
                              on i.hr003cftTsn equals x.tsn
                          where x.tsn.Equals(Id-100)&&i.enab.Equals(1)&&x.enab.Equals(1)
                          select j).Distinct().OrderByDescending(j => j.hr012Tsn).Skip(pageIndex * pageSize).Take(pageSize);


            }






            foreach (var item in result)
            {
                //获得员工职位编号
                var positionIds = from x in context.hr005a
                                  where x.hr005tsn.Equals(item.tsn)
                                  select x.hr001Tsn;
                //员工可能有多个职位编号
                String position = String.Empty;
                foreach (int tsn in positionIds)
                {
                    //根据职位编号找编号名称
                    var hr001 = context.hr001.FirstOrDefault(p => p.tsn.Equals(tsn));

                    if (hr001 != null)
                    {
                        var positionName = hr001.name;
                        position += positionName + " ";

                    }
                }
                ContractDisplay contract = new ContractDisplay
                {
                    Name = item.chName,
                    Ename = item.enName,
                    Email = item.email,
                    Gender = item.sex,
                    MobilePhone = item.mobilephone1,
                    Position = position,
                    PhoneSuffix = item.mobilephone2,
                    NewExtension = item.telephone1,
                    Photo = item.photo,
                    IsNew = IsNew(item.startDay)
                };
                contracts.Add(contract);

            }
            return contracts;

        }







        public static String GetFilterEmployee(String treeType, Int32 id,String chnName,String enName)
        {


            EtronHREntities context = new EtronHREntities();
            String count = String.Empty;
            if (String.IsNullOrEmpty(treeType) || treeType.Equals("root"))
            {
                count = (from i in context.hr005
                    where (chnName != "" ? i.chName.Contains(chnName) : true) &&
                          (enName != "" ? i.enName.Contains(enName) : true)
                    select i).Distinct().Count().ToString();
            }
            else if (treeType.Equals("dept"))
            {
                var result = from i in context.hr006
                             join j in context.hr005
                                 on i.hr005Tsn equals j.tsn
                             join x in context.hr003
                                 on i.hr003Tsn equals x.tsn
                             where x.tsn.Equals(id) &&i.enab.Equals(1)&&x.enab.Equals(1)&&
                          (chnName != "" ? j.chName.Contains(chnName) : true) &&
                         (enName != "" ? j.enName.Contains(enName) : true)
                             select j;
                count = result.Distinct().Count().ToString();
            }
            else if (treeType.Equals("group"))
            {
                var result = from i in context.hr006cft
                             join j in context.hr005
                                 on i.hr005Tsn equals j.tsn
                             join x in context.hr003cft
                                 on i.hr003cftTsn equals x.tsn
                             where x.tsn.Equals(id - 100) &&i.enab.Equals(1)&&x.enab.Equals(1)&&
                          (chnName != "" ? j.chName.Contains(chnName) : true) &&
                         (enName != "" ? j.enName.Contains(enName) : true)
                             select j;
                count = result.Distinct().Count().ToString();

            }




            return count;


        }








        public static List<ContractDisplay> GetFilterEmployee(String treeType, Int32 Id, String chnName,String enName,Int32 pageIndex, Int32 pageSize)
        {

            EtronHREntities context = new EtronHREntities();
            List<ContractDisplay> contracts = new List<ContractDisplay>();

            IQueryable<hr005> result = null;

            if (String.IsNullOrEmpty(treeType) || treeType.Equals("root"))
            {
                result = (from i in context.hr005
                         where (chnName!=""?i.chName.Contains(chnName):true)&&
                         (enName!=""?i.enName.Contains(enName):true)
                         select i)
                    .Distinct().OrderByDescending(j => j.hr012Tsn).Skip(pageIndex * pageSize).Take(pageSize);
            }
            else if (treeType.Equals("dept"))
            {
                result = (from i in context.hr006
                          join j in context.hr005
                              on i.hr005Tsn equals j.tsn
                          join x in context.hr003
                              on i.hr003Tsn equals x.tsn
                          where x.tsn.Equals(Id)&&i.enab.Equals(1)&&x.enab.Equals(1)&&
                          (chnName != "" ? j.chName.Contains(chnName) : true) &&
                         (enName != "" ? j.enName.Contains(enName) : true)
                          orderby j.chName
                          select j).Distinct().OrderByDescending(j => j.hr012Tsn).Skip(pageIndex * pageSize).Take(pageSize);
            }
            else if (treeType.Equals("group"))
            {
                result = (from i in context.hr006cft
                          join j in context.hr005
                              on i.hr005Tsn equals j.tsn
                          join x in context.hr003cft
                              on i.hr003cftTsn equals x.tsn
                          where x.tsn.Equals(Id - 100)&&i.enab.Equals(1)&&x.enab.Equals(1)&&
                           (chnName != "" ? j.chName.Contains(chnName) : true) &&
                         (enName != "" ? j.enName.Contains(enName) : true)
                          select j).Distinct().OrderByDescending(j => j.hr012Tsn).Skip(pageIndex * pageSize).Take(pageSize);


            }






            foreach (var item in result)
            {
                //获得员工职位编号
                var positionIds = from x in context.hr005a
                                  where x.hr005tsn.Equals(item.tsn)
                                  select x.hr001Tsn;
                //员工可能有多个职位编号
                String position = String.Empty;
                foreach (int tsn in positionIds)
                {
                    //根据职位编号找编号名称
                    var hr001 = context.hr001.FirstOrDefault(p => p.tsn.Equals(tsn));

                    if (hr001 != null)
                    {
                        var positionName = hr001.name;
                        position += positionName + " ";

                    }
                }
                ContractDisplay contract = new ContractDisplay
                {
                    Name = item.chName,
                    Ename = item.enName,
                    Email = item.email,
                    Gender = item.sex,
                    MobilePhone = item.mobilephone1,
                    Position = position,
                    PhoneSuffix = item.mobilephone2,
                    NewExtension = item.telephone1,
                    Photo = item.photo,
                    IsNew = IsNew(item.startDay)
                };
                contracts.Add(contract);

            }
            return contracts;

        }











        //获取部门层次树结构
        //需要手动填充跟节点以及CFT组节点
        public static List<ZTreeModel> GetDept()
        {
            EtronHREntities context = new EtronHREntities();
            List<ZTreeModel> lst = new List<ZTreeModel>();
            //加载根节点
            var root = from i in context.hr003a
                where i.tsn.Equals(1)
                select new ZTreeModel
                {
                    Id = 0,
                    Name = i.companyChName,
                    ParentId = -1,
                    Icon = "image/node.png",
                    TreeType="root"
                };

            lst.AddRange(root.ToList());

            //行政组织架构
            var result = from d in context.hr003
                select new ZTreeModel
                {
                    Id = d.tsn,
                    Name = d.chFullName,
                    ParentId = d.lastTsn,
                    Icon = "image/node.png",
                    TreeType="dept"
                    
                };
            lst.AddRange(result.ToList());

            

            //CFT根组
            var cftRoot = from i in context.hr003cft
                where i.enab.Equals(1)&&i.treeLevel.Equals(0)
                          select new ZTreeModel
                          {
                              Id = i.tsn+100,
                              Name = i.cftName,
                              ParentId = 0,
                              Icon = "image/node.png",
                              TreeType = "root"
                          };
            lst.AddRange(cftRoot.ToList());


            var crt = from i in context.hr003cft
                      where i.enab.Equals(1) && !i.treeLevel.Equals(0)
                select new ZTreeModel
                {
                    Id = i.tsn+100,
                    Name = i.cftName,
                    ParentId =i.lastTsn+100 ,
                    Icon = "image/node.png",
                    TreeType="group"
                };

            

            lst.AddRange(crt.ToList());
            return lst;

        }


    }
}
