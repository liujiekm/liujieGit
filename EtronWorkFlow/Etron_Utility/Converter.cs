using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Etron_DAL;
using Etron_Model;
using System.Data;
using System.Data.Entity;
using System.Collections;
using System.Reflection;

namespace Etron_Utility
{
    public class Converter
    {

        public static DataTable ConvertToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dt = new DataTable();

            if (null == varlist) return dt;
            //列名
            PropertyInfo[] propertyInfos = null;

            foreach (T rec in varlist)
            {
                if (propertyInfos == null)
                {
                    propertyInfos = rec.GetType().GetProperties();
                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        Type pType = propertyInfo.PropertyType;
                        if (pType.IsGenericType && pType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {

                            pType = pType.GetGenericArguments()[0];
                        }
                        dt.Columns.Add(propertyInfo.Name, pType);
                    }

                }


                DataRow dr = dt.NewRow();

                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    dr[propertyInfo.Name] = propertyInfo.GetValue(rec, null) == null
                        ? DBNull.Value
                        : propertyInfo.GetValue(rec, null);
                }
                dt.Rows.Add(dr);


            }

            return dt;

        }

    }
}
