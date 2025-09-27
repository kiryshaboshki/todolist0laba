using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using todolist0laba.Models;
using System.Linq;

namespace todolist0laba
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<TaskItem> allTasks = new ObservableCollection<TaskItem>();

        private ObservableCollection<TaskItem> displayedTasks = new ObservableCollection<TaskItem>();
        public MainWindow()
        {
            InitializeComponent();

            TasksListBox.ItemsSource = displayedTasks;

            allTasks.Add(new TaskItem { Title = "Сделать лабу номер 0", DueDate = DateTime.Today });
            allTasks.Add(new TaskItem { Title = "поесть", DueDate = DateTime.Today });
            allTasks.Add(new TaskItem { Title = "добавить даты", DueDate = DateTime.Today.AddDays(1) });
            allTasks.Add(new TaskItem { Title = "добавить календарь", DueDate = DateTime.Today.AddDays(2) });
            allTasks.Add(new TaskItem { Title = "База данных?", DueDate = DateTime.Today.AddDays(3) });
            allTasks.Add(new TaskItem { Title = "Улучшить интерфейс(внешка)", DueDate = DateTime.Today.AddDays(4) });


            ShowAllTasks();
        }

        private void ShowAllTasks()
        {
            displayedTasks.Clear();
            foreach (var task in allTasks)
            {
                displayedTasks.Add(task);
            }
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
                allTasks.Add(newTask);
                displayedTasks.Add(newTask);
                NewTaskTextBox.Text = "";
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TasksListBox.SelectedItem is TaskItem selectedTask)
            {
                allTasks.Remove(selectedTask);
                displayedTasks.Remove(selectedTask);
            }
        }

        private void TasksCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TasksCalendar.SelectedDate.HasValue)
            {
                SelectedDateText.Text = TasksCalendar.SelectedDate.Value.ToString("dd.MM.yyyy");

                ShowTasksForDate(TasksCalendar.SelectedDate.Value);
            }
        }

        private void ShowAllButton_Click(object sender, RoutedEventArgs e)
        {
            ShowAllTasks();
            SelectedDateText.Text = "Все ЗАдачи";
        }
        private void ShowTasksForDate(DateTime date)
        {
            displayedTasks.Clear();

            foreach (var task in allTasks)
            {
                if (task.DueDate.Date == date.Date)
                {
                    displayedTasks.Add(task);
                }
            }
        }
    }

}