using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using todolist0laba.Models;

namespace todolist0laba
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<TaskItem> tasks = new ObservableCollection<TaskItem>();

        public MainWindow()
        {
            InitializeComponent();
            TasksListBox.ItemsSource = tasks;

            tasks.Add(new TaskItem { Title = "Сделать лабу номер 0", DueDate = DateTime.Today });
            tasks.Add(new TaskItem { Title = "поесть", DueDate = DateTime.Today });
            tasks.Add(new TaskItem { Title = "добавить даты", DueDate = DateTime.Today.AddDays(1) });
            tasks.Add(new TaskItem { Title = "добавить календарь", DueDate = DateTime.Today.AddDays(2) });
            tasks.Add(new TaskItem { Title = "База данных?", DueDate = DateTime.Today.AddDays(3) });
            tasks.Add(new TaskItem { Title = "Улучшить интерфейс(внешка)", DueDate = DateTime.Today.AddDays(4) });
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NewTaskTextBox.Text))
            {
                var newTask = new TaskItem
                {
                    Title = NewTaskTextBox.Text,
                    DueDate = TasksCalendar.SelectedDate ?? DateTime.Today
                };
                tasks.Add(newTask);
                NewTaskTextBox.Text = "";
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TasksListBox.SelectedItem is TaskItem selectedTask)
            {
                tasks.Remove(selectedTask);
            }
        }

        private void TasksCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TasksCalendar.SelectedDate.HasValue)
            {
                SelectedDateText.Text = TasksCalendar.SelectedDate.Value.ToString("dd.MM.yyyy");
            }
        }
    }
}