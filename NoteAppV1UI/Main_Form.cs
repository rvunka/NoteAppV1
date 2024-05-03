using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; 
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoteAppV1;

namespace NoteAppV1UI
{
    public partial class Main_Form : Form
    {
        private BindingList<Note> _filteredNotes = new BindingList<Note>();
        public Main_Form()
        {
            InitializeComponent();
            InitializeComboBoxWithCategories();
            //comboBox1.DataSource = Enum.GetValues(typeof(NoteCategory));
            FilterNotesByCategory(NoteCategory.Работа);
            listBoxNotes.DataSource = Project.Notes;
            listBoxNotes.DisplayMember = "Name";
            UpdateNoteProperties();
        }

        private void InitializeComboBoxWithCategories()
        {
            // Создание списка для хранения категорий и добавление значения "Все"
            List<string> categories = new List<string>();
            categories.Add("Все");

            // Добавление значений из перечисления NoteCategory в список
            foreach (var category in Enum.GetValues(typeof(NoteCategory)))
            {
                categories.Add(category.ToString());
            }

            // Установка списка как источника данных для ComboBox
            comboBoxCategory.DataSource = categories;
        }

        public void UpdateNoteProperties()
        {
            if (listBoxNotes.SelectedItem != null)
            {
                Note selectedNote = listBoxNotes.SelectedItem as Note;
                labelTitle.Text = selectedNote.Name;
                labelCategory.Text = selectedNote.Category.ToString();
                richTextBox1.Text = selectedNote.Text;
                dateTimeModified.Value = selectedNote.CreateTime;
            }
        }

        private void FilterNotesByCategory(NoteCategory selectedCategory)
        {
            _filteredNotes.Clear();
            foreach (Note note in Project.Notes)
            {
                if (note.Category == selectedCategory)
                {
                    _filteredNotes.Add(note);
                }
            }
            listBoxNotes.DataSource = _filteredNotes;
            listBoxNotes.DisplayMember = "Name";
            UpdateNoteProperties();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNoteProperties();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = comboBoxCategory.SelectedItem.ToString();
            if (selectedCategory == "Все")
            {
                // Отображение всех заметок
                listBoxNotes.DataSource = Project.Notes;
                listBoxNotes.DisplayMember = "Name";
            }
            else
            {
                // Фильтрация и отображение заметок по выбранной категории
                NoteCategory category = (NoteCategory)Enum.Parse(typeof(NoteCategory), selectedCategory);
                FilterNotesByCategory(category);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About_Form about_Form = new About_Form();

            about_Form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Edit_Form edit_Form = new Edit_Form(FormMode.Add);
            edit_Form.ShowDialog();
            UpdateNoteProperties();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Edit_Form edit_Form = new Edit_Form(FormMode.Edit, listBoxNotes.SelectedItem as Note);
            edit_Form.ShowDialog();
            UpdateNoteProperties();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Project.RemoveNote(listBoxNotes.SelectedItem as Note);
            UpdateNoteProperties();
        }
    }
}
