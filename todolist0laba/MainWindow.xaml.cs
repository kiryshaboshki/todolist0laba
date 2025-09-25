using System.Windows;
using System.Collections.ObjectModel;

namespace todolist0laba
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<string> tasks = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
            TasksListBox.ItemsSource = tasks;

            tasks.Add("Сделать лабу номер 0");
            tasks.Add("поесть");
            tasks.Add("добавить даты и т.д");
            tasks.Add("проверить работу коммитов в VS");
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NewTaskTextBox.Text))
            {
                tasks.Add(NewTaskTextBox.Text);
                NewTaskTextBox.Text = "";
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TasksListBox.SelectedItem is string selectedTask)
            {
                tasks.Remove(selectedTask);
            }
        }
    }
}