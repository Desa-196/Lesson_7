using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_7.CustomAttribute
{
    /// <summary>
    /// Атрибут для произвольного именования свойств при сохранении
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomNameAttribute : Attribute
    {
        public string Name;
        public CustomNameAttribute(string name) => Name = name;

    }

}
