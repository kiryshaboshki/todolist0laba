using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System;

namespace todolist0laba.Models
{
    public class TaskItem : INotifyPropertyChanged
    {
        private string _title;
        private bool _isCompleted;
        private DateTime _dueDate;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));

            }
        }

        public bool IsCompleted
        {
            get { return _isCompleted; }
            set
            {
                _isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
            }
        }
        public DateTime DueDate
        {
            get { return _dueDate; }
            set
            {
                _dueDate = value;
                OnPropertyChanged(nameof(DueDate));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}