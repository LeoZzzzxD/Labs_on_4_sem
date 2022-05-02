using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace rating_calc
{
    public class Student : INotifyPropertyChanged
    {
        //private string name 
        //{
        //set { name = value};
        //get { return name};

        //}
        private string name_of_st;
        private string item;
        private int grade;
        private string lead_teach; // предмет, оценка за него и ведущий преподаватель
        public int Id { get; set; }

        public string Name_of_st
        {
            get { return name_of_st; }
            set
            {
                name_of_st = value;
                OnPropertyChanged("Имя");
            }
        }
        public string Item
        {
            get { return item; }
            set
            {
                item = value;
                OnPropertyChanged("Предмет");
            }
        }
        public int Grade
        {
            get { return grade; }
            set
            {
                grade = value;
                OnPropertyChanged("Оценка");
            }
        }
        public string Lead_teach
        {
            get { return lead_teach; }
            set
            {
                lead_teach = value;
                OnPropertyChanged("Ведущий преподаватель");
            }
        }

        //public int calc_student_rating()
        //{
        //    int rating = 0;
        //    foreach (var value in item_grade_and_lead_teach)
        //    {
        //        foreach (var value_ in value.Key)
        //        {
        //            rating += value_.Value;
        //        }
        //    }
        //    return rating / item_grade_and_lead_teach.Keys.Count;
        //}

        //public Dictionary<Dictionary<string, int>, string> getting()
        //{
        //    return item_grade_and_lead_teach;
        //}

        //public string func()
        //{
        //    return name_of_st;
        //}

        //public int func_()
        //{
        //    return id;
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
