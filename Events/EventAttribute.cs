using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Events
{
    class EventLabel : Attribute
    {
        public string Label { get; set; }
    }

    class Field:Attribute { }
    class IgnoreField : Attribute { }

    class TextField : Field { }

    class ImageField : Field { }
    
    class VideoField : Field { }
    class DateField : Field { }

    class GPXField: Field { }

    class FileField: Field { }
}
