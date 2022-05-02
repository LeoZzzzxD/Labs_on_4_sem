using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Collections.Generic;

namespace rating_calc
{
    public partial class Window2 : Window
    {
        private const string file_path_teach = "teachers_data.txt";
        private const int MAX_COUNT_OF_NOTES = 40;

        public Window2()
        {
            InitializeComponent();
        }

        private void Accept_Click1(object sender, RoutedEventArgs e)
        {
            FileInfo file = new FileInfo(file_path_teach);
            string[] data_teach = { };
            try
            {
                if (file.Length != 0)
                    data_teach = File.ReadAllLines(file_path_teach);
            }
            catch 
            {}

            var data = new List<string>()
            {
                Name.Text,
                Item.Text,
            };
            var textboxes = new List<TextBox>()
            {
                Name,
                Item,
            };
            if (data_teach.Length < MAX_COUNT_OF_NOTES)
            {
                if (Name.Text != "" && Item.Text != "")
                {
                    if (Name.Text.Split(' ').Length == 2 && Item.Text.Split(' ').Length == 1)
                    {
                        foreach (var value in data)
                            File.AppendAllText(file_path_teach, value + " ");

                        File.AppendAllText(file_path_teach, "\n");
                        MessageBox.Show("Данные успешно добавлены!");
                        foreach (var value in textboxes)
                            value.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Повторите ввод!");
                        foreach (var value in textboxes)
                            value.Clear();
                    }
                }
                else
                    MessageBox.Show("Поля не должны быть пустыми!");
            }
            else
            {
                MessageBox.Show("Записей слшиком много!");
                this.Close();
            }
        }
        private void Reset1(object sender, RoutedEventArgs e)
        {
            var textboxes = new List<TextBox>()
            {
                Name,
                Item,
            };
            foreach (var value in textboxes)
                value.Clear();
        }
    }
}
