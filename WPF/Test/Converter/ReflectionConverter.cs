using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace WpfApplication2.Converter
{
    public class ReflectionConverter
    {
        // DataTable转实体模型
        //List<StationInfo> entities = EntityConvertor.TableToEntity<StationInfo>(dt);

        public static List<T> TableToEntity<T>(DataTable dt) where T : class,new()
        {
            Type type = typeof(T);
            PropertyInfo[] pArray = type.GetProperties();

            List<T> list = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T entity = new T();
                foreach (PropertyInfo p in pArray)
                {
                    if (row[p.Name] is Int64)
                    {
                        p.SetValue(entity, Convert.ToInt32(row[p.Name]), null);
                        continue;
                    }
                    p.SetValue(entity, row[p.Name], null);
                }
                list.Add(entity);
            }
            return list;
        } 
    }
}
