using System.Collections.Generic;
using System.Windows;
using System.IO;
using System;
using System.Windows.Controls;
using System.Linq;

namespace rating_calc
{
   
    public partial class Window6 : Window
    {
        private const string file_path_teach = "teachers_data.txt";
        private const string st_rating = "students_rating.txt";
        public Window6()
        {
            InitializeComponent();
        }

        private void check_rating_teach(object sender, EventArgs e)
        {
            try 
            {
                List<string> rating_data = new List<string>();
                List<string> passed_st = new List<string>();
                string[] data, data_;
                string current_st;
                double rating = 0;
                int sum_of_st_rating = 0, count_of_st_rating = 0, sum_of_rating_rp = 0, count_of_repeats = 0;
                int counter = 0;
                bool checking = false;
                data = File.ReadAllLines(file_path_teach);
                data_ = File.ReadAllLines(st_rating);

                foreach (var str in data.Distinct())
                {
                    foreach (var str_ in data_)
                    {
                        if ((str.Split(' ')[0] + str.Split(' ')[1]) == (str_.Split(' ')[3] + str_.Split(' ')[4]))
                        {
                            sum_of_st_rating += Int32.Parse(str_.Split(' ')[1]);
                            ++count_of_st_rating;
                        }
                    }

                    if (sum_of_st_rating != 0 && count_of_st_rating != 0)
                        rating = (double)sum_of_st_rating / count_of_st_rating;

                    rating_data.Add(str.Split(' ')[0] + " " + str.Split(' ')[1] + " " + Math.Round(rating, 2).ToString());

                    //gr_1_teach.Children.Add(new TextBlock
                    //{
                    //    Text = current_teach.Split(' ')[0]
                    //});

                    //gr_2_teach.Children.Add(new TextBlock
                    //{
                    //    Text = Math.Round(rating, 2).ToString()
                    //});
                    counter = 0;
                    count_of_st_rating = 0;
                    sum_of_st_rating = 0;
                    rating = 0;
                }



                foreach (var str in rating_data)
                {
                    current_st = str;
                    foreach (var value in passed_st)
                    {
                        if ((value.Split(' ')[0] + " " + value.Split(' ')[1]) == (current_st.Split(' ')[0] + " " + current_st.Split(' ')[1]))
                        {
                            checking = true;
                            break;
                        }
                    }

                    while (counter < rating_data.Count)
                    {

                        if (checking)
                            break;
                        if ((current_st.Split(' ')[0] + " " + current_st.Split(' ')[1]) == (rating_data[counter].Split(' ')[0] + " " + rating_data[counter].Split(' ')[1]))
                        {
                            sum_of_rating_rp += Int32.Parse(rating_data[counter].Split(' ')[2]);
                            ++count_of_repeats;
                        }
                        ++counter;
                    }
                    if (!checking)
                    {
                        passed_st.Add(current_st);

                        rating = (double)sum_of_rating_rp / count_of_repeats;
                        gr_1_teach.Children.Add(new TextBlock
                        {
                            Text = current_st.Split(' ')[0] + " " + current_st.Split(' ')[1]
                        });

                        gr_2_teach.Children.Add(new TextBlock
                        {
                            Text = Math.Round(rating, 2).ToString()
                        });
                    }

                    checking = false;
                    counter = 0;
                    count_of_repeats = 0;
                    sum_of_rating_rp = 0;
                }
            }
            catch
            {
                MessageBox.Show("Не хватает данных для отображения. Добавьте преподавателя!");
                File.Delete(file_path_teach);
                this.Close();
            }
        }
        private void close_teach(object sender, EventArgs e)
        {
            gr_1_teach.Children.Clear();
            gr_2_teach.Children.Clear();
        }
    }
}
