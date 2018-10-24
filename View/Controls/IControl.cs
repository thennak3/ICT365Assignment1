using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.View.Controls
{
    interface IControl
    {
        void SetLabelText(string text);
        void SetField(string fieldname);
        void SetHandler(EditorHandler handler);
        void SetData(object data);

        void SetEditable(bool isEditable);
        
    }
}
