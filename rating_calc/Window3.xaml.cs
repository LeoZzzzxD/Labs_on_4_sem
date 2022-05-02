using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Windows.Controls;


namespace rating_calc
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        private const string file_path_st = "students_data.txt";
          
        public Window3()
        {
            InitializeComponent();
        }

        private void Accept_Click2(object sender, RoutedEventArgs e)
        {
            var textboxes = new List<TextBox>()
            {
                Name,
            };
            try
            {
                StreamReader reader = new StreamReader(file_path_st);
                string line;
                short counter = 0, counter_ = 0;
                List<string> lines = new List<string>();
                if (Name.Text != "")
                {
                    while ((line = reader.ReadLine()) != null)
                    {

                        if (line.Split(' ')[0] != Name.Text)
                        {
                            lines.Add(line);
                        }
                        else
                            counter_ += 1;
                    }
                    if (counter_ != 0)
                    {
                        MessageBox.Show("Данные успешно удалены!");
                        reader.Close();
                        StreamWriter writer = new StreamWriter(file_path_st);
                        while (counter < lines.Count)
                        {
                            writer.WriteLine(lines[counter++]);
                        }
                        writer.Close();
                    }
                    else
                        MessageBox.Show("Совпадений не найдено!");

                    foreach (var value in textboxes)
                        value.Clear();
                }
                else
                {
                    MessageBox.Show("Поля не должны быть пустыми!");
                    reader.Close();
                }
            }
            catch
            {
                MessageBox.Show($"Файл {file_path_st} либо пустой, либо не существует. Удаление не требуется!");
                this.Close();
            }
        }
        private void Reset2(object sender, RoutedEventArgs e)
        {
            var textboxes = new List<TextBox>()
            {
                Name,
            };
            foreach (var value in textboxes)
                value.Clear();
        }
    }
}
