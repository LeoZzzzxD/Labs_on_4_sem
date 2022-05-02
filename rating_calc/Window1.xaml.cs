using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace rating_calc
{
    public partial class Window1 : Window
    {
        private const string file_path_st = "students_data.txt";
        private const int MAX_COUNT_OF_NOTES = 40;
       
        public Window1()
        {
            InitializeComponent();

        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            FileInfo file = new FileInfo(file_path_st);
            string[] data_st = {};
            try
            {
                if (file.Length != 0)
                    data_st = File.ReadAllLines(file_path_st);
            }
            catch
            {}
            
            var data = new List<string>()
            {
                   Name.Text,
                   Item.Text,
                   Grade.Text,
                   Lead_teach.Text
            };
            List<TextBox> textboxes = new List<TextBox>()
            {
                   Name,
                   Item,
                   Grade,
                   Lead_teach
            };
            if (data_st.Length < MAX_COUNT_OF_NOTES)
            {
                    if (Name.Text != "" && Item.Text != "" && Grade.Text != "" && Lead_teach.Text != "")
                    {
                        if (Name.Text.Split(' ').Length == 1 && Item.Text.Split(' ').Length == 1 && (CharUnicodeInfo.GetDigitValue(Grade.Text[0]) == 2 || CharUnicodeInfo.GetDigitValue(Grade.Text[0]) == 3 || CharUnicodeInfo.GetDigitValue(Grade.Text[0]) == 4 || CharUnicodeInfo.GetDigitValue(Grade.Text[0]) == 5) && Lead_teach.Text.Split(' ').Length == 2)
                        {

                            foreach (var value in data)
                                File.AppendAllText(file_path_st, value + " ");

                            File.AppendAllText(file_path_st, "\n");

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
                    MessageBox.Show("Записей слишком много!");
                    this.Close();
            }
        }
        private void Reset(object sender, RoutedEventArgs e)
        {
            var textboxes = new List<TextBox>()
            {
                Name,
                Item,
                Grade,
                Lead_teach
            };
            foreach (var value in textboxes)
                value.Clear();
        }
    }
}
