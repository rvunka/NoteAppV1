using NoteAppV1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteAppV1UI
{
    public partial class Edit_Form : Form
    {
        private FormMode _mode;
        private Note _selectedItem;
        public Edit_Form(FormMode mode)
        {
            InitializeComponent();
            comboBoxCategory.DataSource = Enum.GetValues(typeof(NoteCategory));
            _mode = mode;
        }

        public Edit_Form(FormMode mode, Note selectedItem)
        {
            InitializeComponent();
            comboBoxCategory.DataSource = Enum.GetValues(typeof(NoteCategory));
            _mode = mode;
            _selectedItem = selectedItem;   
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (_mode == FormMode.Add)
            {
                Project.AddNote(new Note(textBoxTitle.Text, comboBoxCategory.Text, richTextBox1.Text));
            }

            if (_mode == FormMode.Edit)
            {
                _selectedItem.Name = textBoxTitle.Text;
                _selectedItem.Text = richTextBox1.Text;
                _selectedItem.Category = (NoteCategory)Enum.Parse(typeof(NoteCategory), comboBoxCategory.Text);
                
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
