using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1.View.Controls
{

    //Would add the interface methods into a base class, but Visual Studio doesn't like keeping the editor for child classes of UserControl
    public partial class TextControl : UserControl, IControl
    {
        EditorHandler handler;
        string field;
        public TextControl()
        {
            InitializeComponent();
        }

        public void SetLabelText(string text)
        {
            lblname.Text = text;
        }

        public void SetData(object data)
        {
            txtData.Text = (string)data;
        }

        private void txtData_TextChanged(object sender, EventArgs e)
        {
            handler.DataChanged(field, txtData.Text);
        }

        public void SetHandler(EditorHandler handler)
        {
            this.handler = handler;
        }

        public void SetField(string fieldname)
        {
            field = fieldname;
        }


        public void SetEditable(bool isEditable)
        {
            txtData.Enabled = isEditable;
        }
    }
}
