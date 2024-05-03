using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteAppV1
{
    /// <summary>
    /// Перечисление "Категория заметки"
    /// </summary>
    public enum NoteCategory
    {
        Работа,
        Дом,
        Здоровье_и_Спорт,
        Люди,
        Документы,
        Финансы,
        Разное
    }

    public enum FormMode
    {
        Add,
        Edit
    }
}
