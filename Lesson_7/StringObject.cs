using Lesson_7.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_7
{
    static class StringObject
    {
        static object StringToObject(string s)
        {
            string[] arrayInfo = s.Split("\n");

            Console.WriteLine($"{arrayInfo[0]} - {arrayInfo[1]}");

            var t4 = Activator.CreateInstance(null, arrayInfo[1]).Unwrap();


            if (t4 != null && arrayInfo.Length > 2)
            {
                Type type = t4.GetType();

                for (int i = 2; i < arrayInfo.Length; i++)
                {
                    string[] arrayInfo2 = arrayInfo[i].Split("=");
                    var prop = type.GetProperty(arrayInfo2[0]);
                    if (prop == null) continue;
                    if (prop.PropertyType == typeof(int))
                    {
                        prop.SetValue(t4, int.Parse(arrayInfo2[1]));
                    }
                    else if (prop.PropertyType == typeof(string))
                    {
                        prop.SetValue(t4, arrayInfo2[1]);
                    }
                    else if (prop.PropertyType == typeof(char[]))
                    {
                        prop.SetValue(t4, arrayInfo2[1].ToCharArray());
                    }
                    else if (prop.PropertyType == typeof(decimal))
                    {
                        prop.SetValue(t4, decimal.Parse(arrayInfo2[1]));
                    }
                }
            }

            return t4;
        }

        static string ObjectToString(object o)
        {
            StringBuilder sb = new StringBuilder();

            Type type = o.GetType();

            sb.Append(type.Assembly + "\n");
            sb.Append(type.FullName + "\n");

            var properties = type.GetProperties();
            foreach (var prop in properties)
            {
                if (prop.GetCustomAttribute<DontSaveAttribute>() != null) continue;
                sb.Append(prop.Name + "=");
                var val = prop.GetValue(o);

                if (prop.PropertyType == typeof(char[]))
                {
                    sb.Append(new string(val as char[]) + "\n");
                }
                else
                {
                    sb.Append(val + "\n");
                }
            }

            return sb.ToString();
        }
    }
}
