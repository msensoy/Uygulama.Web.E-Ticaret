using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class Helpers
    {
        public static bool IsTest { get; set; }

        public static T2 Mapping<T1, T2>(T1 obj) where T2 : new()
        {
            T2 result = new T2();
            PropertyInfo[] propertyInfos = typeof(T2).GetProperties();

            foreach (var propertyInfo in propertyInfos)
            {
                PropertyInfo t1PropertyInfo = obj.GetType().GetProperty(propertyInfo.Name);

                if (t1PropertyInfo != null)
                {
                    propertyInfo.SetValue(result, t1PropertyInfo.GetValue(obj));
                }
            }
            return result;
        }

        public static List<T2> Mapping<T1, T2>(IEnumerable<T1> objs)
            where T2 : new()
        {
            List<T2> result = new List<T2>();


            foreach (var obj in objs)
            {
                result.Add(Mapping<T1, T2>(obj));
            }
            return result;
        }
    }

}
