using System.Windows;
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

            tasks.Add(new TaskItem { Title = "Сделать лабу номер 0" });
            tasks.Add(new TaskItem { Title = "поесть" });
            tasks.Add(new TaskItem { Title = "добавить даты" });
            tasks.Add(new TaskItem { Title = "добавить календарь" });
            tasks.Add(new TaskItem { Title = "База данных?" });
            tasks.Add(new TaskItem { Title = "Улучшить интерфейс(внешка)" });
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NewTaskTextBox.Text))
            {
                tasks.Add(new TaskItem { Title = NewTaskTextBox.Text });
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
    }
}