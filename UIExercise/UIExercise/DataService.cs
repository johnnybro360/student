using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UIExercise
{
    class DataService
    {
       private List<Student> students = new List<Student>();

        public DataService()
        {
            students.Add(new Student(1, "Bob", "Ross", EnrolmentStatus.Enrolled));
            students.Add(new Student(2, "James", "Ross", EnrolmentStatus.Enrolled));
            students.Add(new Student(3, "Mary", "Sue", EnrolmentStatus.Withdrawn));
            students.Add(new Student(4, "Peter", "Smith", EnrolmentStatus.Enrolled));
            students.Add(new Student(5, "Jane", "Doe", EnrolmentStatus.Paid));
        }

        public List<Student> GetStudents()
        {
            return students;
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            students.Remove(student);
        }

        public bool ListBoxDuplicateCheck(Student newStudent)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (newStudent.FirstName == students[i].FirstName && newStudent.LastName == students[i].LastName)
                    return true;
            }
            return false;
          
        }

    }
}
