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
        public static object StringToObject(string s)
        {
            string[] arrayInfo = s.Split("\n");

            var t4 = Activator.CreateInstance(null, arrayInfo[1]).Unwrap();


            if (t4 != null && arrayInfo.Length > 2)
            {
                Type type = t4.GetType();

                for (int i = 2; i < arrayInfo.Length; i++)
                {
                    string[] arrayInfo2 = arrayInfo[i].Split("=");

                    var prop = type.GetProperty(arrayInfo2[0]);
                    //Если свойство с таким именем отсутствует в классе, значит пройдемся по всем свойствам и проверим есть ли у них атрибут с полем Name = имени полученным из строки
                    if (prop == null)
                    {
                        foreach (var property in type.GetProperties())
                        {
                            CustomNameAttribute? attribute = property.GetCustomAttribute<CustomNameAttribute>();
                            if (attribute != null && attribute.Name == arrayInfo2[0])
                            { 
                                prop = type.GetProperty(property.Name);
                                break;
                            }
                        }
                        //Если всё ещё не нашли, значит пропускам это свойство
                        if (prop == null) continue;
                    }
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

        public static string ObjectToString(object o)
        {
            StringBuilder sb = new StringBuilder();

            Type type = o.GetType();

            sb.Append(type.Assembly + "\n");
            sb.Append(type.FullName + "\n");

            foreach (var prop in type.GetProperties())
            {
                if (prop.GetCustomAttribute<DontSaveAttribute>() != null) continue;

                //Если свойство помечено атрибутом CustomNameAttribute то сохраняем его под именем переданным в контруктор атрибута
                CustomNameAttribute? attribute = prop.GetCustomAttribute<CustomNameAttribute>();

                if (attribute != null) sb.Append(attribute.Name + "=");           
                else sb.Append(prop.Name + "=");

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
