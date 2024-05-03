using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteAppV1
{
    /// <summary>
    /// Класс "Проект"
    /// </summary>
    public static class Project
    {
        private static BindingList<Note> notes;

        /// <summary>
        /// Список заметок в проекте.
        /// </summary>
        public static BindingList<Note> Notes
        {
            get { return notes; }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса Project.
        /// </summary>
        static Project()
        {
            notes = new BindingList<Note>();
        }

        /// <summary>
        /// Добавляет заметку в проект.
        /// </summary>
        /// <param name="note">Заметка для добавления.</param>
        public static void AddNote(Note note)
        {
            notes.Add(note);
        }

        /// <summary>
        /// Удаляет заметку из проекта.
        /// </summary>
        /// <param name="note">Заметка для удаления.</param>
        public static void RemoveNote(Note note)
        {
            notes.Remove(note);
        }
    }
}
