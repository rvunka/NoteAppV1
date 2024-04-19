using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace NoteAppV1
{
    /// <summary>
    /// Класс "Менеджер проекта"
    /// </summary>
    public class ProjectManager
    {
        private const string FilePath = @"...\My Documents\NoteApp.notes";

        /// <summary>
        /// Сохранение проекта в файл
        /// </summary>
        /// <param name="project">Проект для сохранения</param>
        public static void SaveToFile<T>(T data)
        {
            try
            {
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(FilePath, json);
                Console.WriteLine("Данные успешно сохранены в файл.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении данных в файл: {ex.Message}");
            }
        }

        /// <summary>
        /// Загрузка проекта из файла
        /// </summary>
        /// <returns>Загруженный проект</returns>
        public static T LoadFromFile<T>()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string json = File.ReadAllText(FilePath);
                    T data = JsonConvert.DeserializeObject<T>(json);
                    Console.WriteLine("Данные успешно загружены из файла.");
                    return data;
                }
                else
                {
                    Console.WriteLine("Файл данных не найден.");
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке данных из файла: {ex.Message}");
                return default(T);
            }
        }
    }
}
