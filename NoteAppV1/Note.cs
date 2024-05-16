﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NoteAppV1
{

    /// <summary>
    /// Класс "Заметка"
    /// </summary>
    public class Note : ICloneable, INotifyPropertyChanged
    {
        private string _name;
        private NoteCategory _category;
        private string _text;
        private readonly DateTime _createTime;
        private DateTime _lastModifiedTime;

        /// <summary>
        /// Название заметки (не более 50 символов)
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException();
                }
                if (value.Length == 0)
                {
                    _name = "Без названия";
                }
                else
                {
                    _name = value;
                }
                _lastModifiedTime = DateTime.Now;
                OnPropertyChanged(nameof(Name));
            }
        }

        /// <summary>
        /// Категория заметки
        /// </summary>
        public NoteCategory Category
        {
            get { return _category; }
            set
            {
                _category = value;
                _lastModifiedTime = DateTime.Now;
                OnPropertyChanged(nameof(Category));
            }
        }

        /// <summary>
        /// Текст заметки
        /// </summary>
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                _lastModifiedTime = DateTime.Now;
                OnPropertyChanged(nameof(Text));
            }
        }

        /// <summary>
        /// Время создания заметки
        /// </summary>
        public DateTime CreateTime
        {
            get { return _createTime; }
        }

        /// <summary>
        /// Время последнего изменения заметки
        /// </summary>
        public DateTime LastModifedTime
        {
            get { return _lastModifiedTime; }
        }

        /// <summary>
        /// Создание заметки
        /// </summary>
        public Note()
        {
            Name = "Без названия";
            Category = NoteCategory.Разное;
            Text = "";
            _createTime = DateTime.Now;
            _lastModifiedTime = _createTime;
        }

        public Note(string _name, string _category, string _text)
        {
            Name = _name;
            Category = (NoteCategory)Enum.Parse(typeof(NoteCategory), _category);
            Text = _text;
            _createTime = DateTime.Now;
            _lastModifiedTime = _createTime;
        }

        /// <summary>
        /// Реализация интерфейса ICloneable
        /// </summary>
        public object Clone()
        {
            return this.MemberwiseClone();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
