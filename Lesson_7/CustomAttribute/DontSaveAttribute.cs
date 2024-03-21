using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_7.CustomAttribute
{
    /// <summary>
    /// Атрибут для свойств, помеченные им свойства не будут сохраняться в строку
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DontSaveAttribute : Attribute
    {
        public DontSaveAttribute() { }
    }
}
