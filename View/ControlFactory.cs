using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Assignment1.Events;
using Assignment1.View.Controls;

namespace Assignment1.View
{
    class ControlFactory
    {


        internal IControl GenerateControls(Attribute attribute)
        {
            switch(attribute.GetType().Name)
            {
                case nameof(TextField): return new TextControl();
                case nameof(ImageField): return new PhotoControl();
                case nameof(DateField):return new DateControl();
                case nameof(GPXField): return new GPXControl();
                case nameof(VideoField): return new VideoControl();
            }
            return null;
        }
    }
}

