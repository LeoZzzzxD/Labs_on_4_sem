using System.Collections.Generic;
using System.Windows;
using System.IO;
using System;
using System.Windows.Controls;
using System.Linq;

namespace rating_calc
{
   
    public partial class Window5 : Window
    {
        private const string file_path_st = "students_data.txt";
        private const string st_rating = "students_rating.txt";
        public Window5()
        {
            InitializeComponent();
        }

        private void check_rating_st(object sender, EventArgs e)
        {
            try 
            {
                List<string> passed_st = new List<string>();
                StreamWriter writer = new StreamWriter(st_rating, false);
                string[] data;
                double rating;
                int sum_of_grades = 0, count_of_grades = 0;
                int counter = 0;
                string current_st;
                bool checking = false;
                data = File.ReadAllLines(file_path_st);

                foreach (var str in data.Distinct())
                {
                    current_st = str;
                    foreach (var value in passed_st)
                    {
                        if (value.Split(' ')[0] == current_st.Split(' ')[0])
                        {
                            checking = true;
                            break;
                        }
                    }

                    while (counter < data.Length)
                    {

                        if (checking)
                            break;
                        if (current_st.Split(' ')[0] == data[counter].Split(' ')[0])
                        {
                            sum_of_grades += Int32.Parse(data[counter].Split(' ')[2]);
                            ++count_of_grades;
                        }
                        ++counter;
                    }
                    if (!checking)
                    {
                        passed_st.Add(current_st);

                        rating = (double)sum_of_grades / count_of_grades;
                        gr_1.Children.Add(new TextBlock
                        {
                            Text = current_st.Split(' ')[0]
                        });

                        gr_2.Children.Add(new TextBlock
                        {
                            Text = Math.Round(rating, 2).ToString()
                        });

                        writer.Write(current_st.Split(' ')[0] + " ");
                        writer.Write(Math.Round(rating, 2).ToString() + " ");
                        writer.Write(current_st.Split(' ')[1] + " ");
                        writer.Write(current_st.Split(' ')[3] + " ");
                        writer.Write(current_st.Split(' ')[4] + "\n");
                    }

                    checking = false;
                    counter = 0;
                    count_of_grades = 0;
                    sum_of_grades = 0;
                }
                writer.Close();
            }
            catch
            {
                MessageBox.Show("Не хватает данных для отображения. Добавьте студента!");
                File.Delete(file_path_st);
                this.Close();

            }
        }

        private void close_st(object sender, EventArgs e)
        {
            gr_1.Children.Clear();
            gr_2.Children.Clear();
        }
    }
}
