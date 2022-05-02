using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System;
using System.IO;

namespace rating_calc
{
    public partial class MainWindow : Window
    {
        private const string file_path_st = "students_data.txt";
        private const string file_path_teach = "teachers_data.txt";
      
        public MainWindow()
        {
            InitializeComponent();
            show_students();
            show_teachers();
            show_items();
        }
        private void get_teach_rating(object sender, RoutedEventArgs e)
        {
            Window6 window6 = new Window6();
            window6.Owner = this;
            window6.ShowDialog();
        }
        private void get_st_rating(object sender, RoutedEventArgs e)
        {
            Window5 window5 = new Window5();
            window5.Owner = this;
            window5.ShowDialog();
        }
        private void add_student(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Owner = this;
            window1.ShowDialog();
            StudentList.Items.Clear();
            ItemList.Items.Clear();
            show_students();
            show_items();
        }

        private void add_teacher(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Owner = this;
            window2.ShowDialog();
            TeachList.Items.Clear();
            ItemList.Items.Clear();
            show_teachers();
            show_items();
        }

        private void show_students()
        {
            try
            {
                List<string> student_names = new List<string>();
                StreamReader reader = new StreamReader(file_path_st);
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line != "")
                        student_names.Add(line.Split(' ')[0]);
                }
                reader.Close();
                foreach (var value in student_names.Distinct())
                {
                    StudentList.Items.Add(value);
                }
            }
            catch
            {}
        }
        private void show_teachers()
        {
            try
            {
                List<string> teacher_names = new List<string>();
                StreamReader reader = new StreamReader(file_path_teach);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line != "")
                        teacher_names.Add(line.Split(' ')[0] + ' ' + line.Split(' ')[1]);
                }
                reader.Close();
                foreach (var value in teacher_names.Distinct())
                {
                    TeachList.Items.Add(value);
                }
            }
            catch
            {}
        }
        private void show_items()
        {
            try
            {
                List<string> items_names = new List<string>();
                List<string> items_names_ = new List<string>();
                List<string> unique_values = new List<string>();
           
                if (File.Exists(file_path_st))
                {
                    StreamReader reader = new StreamReader(file_path_st);
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line != "")
                            items_names.Add(line.Split(' ')[1]);
                    }
                   
                    reader.Close();
                }
                if (File.Exists(file_path_teach))
                {
                    StreamReader reader_ = new StreamReader(file_path_teach);
                    string line;
                    while ((line = reader_.ReadLine()) != null)
                    {
                        if (line != "")
                            items_names_.Add(line.Split(' ')[2]);
                    }
                    reader_.Close();
                }
              
                foreach (var value in items_names.Distinct())
                {
                    unique_values.Add(value);
                }
                foreach (var value in items_names_.Distinct())
                {
                    unique_values.Add(value);
                }

                foreach (var value in unique_values.Distinct())
                {
                    ItemList.Items.Add(value);
                }
            }
            catch
            {}  
        }
        private void remove_student(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new Window3();
            window3.Owner = this;
            window3.ShowDialog();
            StudentList.Items.Clear();
            ItemList.Items.Clear();
            show_students();
            show_items();
        }
        private void remove_teacher(object sender, RoutedEventArgs e)
        {
            Window4 window4 = new Window4();
            window4.Owner = this;
            window4.ShowDialog();
            TeachList.Items.Clear();
            ItemList.Items.Clear();
            show_teachers();
            show_items();
        }
    }
}
