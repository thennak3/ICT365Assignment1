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
    public partial class EditSaveControl : UserControl, IControl
    {
        public EditSaveControl()
        {
            InitializeComponent();
        }

        EditorHandler handler;

        private void save_Click(object sender, EventArgs e)
        {
            handler.Save();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            handler.Edit();
        }

        private void close_Click(object sender, EventArgs e)
        {
            handler.CloseCallingForm();
        }

        public void SetLabelText(string text)
        {
            throw new NotImplementedException();
        }

        public void SetField(string fieldname)
        {
            throw new NotImplementedException();
        }

        public void SetHandler(EditorHandler handler)
        {
            this.handler = handler;
        }

        public void SetData(object data)
        {
            throw new NotImplementedException();
        }

        public void SetEditable(bool isEditable)
        {
            if (isEditable)
            {
                //assume new
                edit.Enabled = false;
                save.Enabled = true;
            }
            else
            {
                edit.Enabled = true;
                save.Enabled = false;

            }


        }

        private void Delete_Click(object sender, EventArgs e)
        {
            handler.Delete();
        }
    }
}
