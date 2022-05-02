using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rating_calc
{
    class Teacher
    {
        //private string name;

        private string name_of_teach;
        private int id;
        private string item; //  имя преподавателя и предмет, который он ведет.
        public Teacher()
        {
            name_of_teach = "";
            id = 0;
            item = "";
        }
        //public bool checking_belonging_student_rating(Student st)
        //{
        //    foreach (var value in st.getting())
        //    {
        //        foreach (var value_ in value.Key)
        //        {
        //            if (value.Value == name_of_teach && item == value_.Key)
        //                return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
