using NoteAppV1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteAppV1UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main_Form());
            
            /*
            // Создание объекта заметки
            Note note1 = new Note("Заголовок заметки 1", "Категория 1", "Текст заметки 1"); 
            //Note note2 = new Note("Заголовок заметки 2", "Категория 2", "Текст заметки 2");

            // Создание объекта проекта и добавление заметок
            Project project = new Project();
            project.AddNote(note1);
            
            //project.AddNote(note2);

            // Сохранение проекта в файл
            ProjectManager.SaveToFile(project);

            // Загрузка проекта из файла
            Project loadedProject = ProjectManager.LoadFromFile<Project>();

            // Вывод загруженных заметок
            if (loadedProject != null)
            {
                Console.WriteLine("Загруженные заметки из проекта:");
                foreach (Note note in loadedProject.Notes)
                {
                    Console.WriteLine($"Заголовок: {note.Name}, Категория: {note.Category}, Текст: {note.Text}");
                }
            }
            else
            {
                Console.WriteLine("Не удалось загрузить проект.");
            }
            */
        }
    }
}
