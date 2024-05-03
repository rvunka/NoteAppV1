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
            comboBox1.DataSource = Enum.GetValues(typeof(NoteCategory));
            _mode = mode;
        }

        public Edit_Form(FormMode mode, Note selectedItem)
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(NoteCategory));
            _mode = mode;
            _selectedItem = selectedItem;   
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (_mode == FormMode.Add)
            {
                Project.AddNote(new Note(textBox1.Text, comboBox1.Text, richTextBox1.Text));
            }

            if (_mode == FormMode.Edit)
            {
                _selectedItem.Name = textBox1.Text;
                _selectedItem.Text = richTextBox1.Text;
                _selectedItem.Category = (NoteCategory)Enum.Parse(typeof(NoteCategory), comboBox1.Text);
                
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
