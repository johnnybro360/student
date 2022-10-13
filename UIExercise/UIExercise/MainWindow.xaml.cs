using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UIExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Business logic
        DataService service = new DataService();
        Student selectedStudent;
        EnrolmentStatus Status;
        public MainWindow()
        {
            InitializeComponent();
            comboEnrolment.ItemsSource = Enum.GetValues(typeof(EnrolmentStatus));
            RefreshStudents();

        }

        /// <summary>
        /// This is called when the get students button is pressed.
        /// TODO: Update this button to load the students from the service and update the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGetStudents_Click(object sender, RoutedEventArgs e)
        {
            //listStudents.ItemsSource = service.GetStudents();
            RefreshStudents();
           
        }

        private void RefreshStudents() 
        {
            List<Student> students = service.GetStudents();

            listStudents.Items.Clear();
            foreach (Student student in students) 
            {
                listStudents.Items.Add(student);
            }
        
        }

        /// <summary>
        /// This event is triggered when the user selects a student from the list.
        /// TODO: Update the controls to show the properties of the selected student.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // what student is selected?
            selectedStudent = (Student)listStudents.SelectedItem;
            if (selectedStudent == null) return;
            // Update the UI with that students.details
            textBoxFirstName.Text = selectedStudent.FirstName;
            textBoxLastName.Text = selectedStudent.LastName;
            comboEnrolment.SelectedItem = selectedStudent.Enrolment;

        }

        /// <summary>
        /// This event triggers when the combo box selection is changed.
        /// TODO: It should update the selected students enrolment.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboEnrolment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

      
            Status = (EnrolmentStatus)comboEnrolment.SelectedItem;
            selectedStudent = (Student)listStudents.SelectedItem;
            if ( selectedStudent == null) return;
            selectedStudent.Enrolment = Status;
            RefreshStudents();

            //listStudents.Items.Refresh();
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm?", MessageBoxButton.YesNo) == MessageBoxResult.No) return;
            selectedStudent = (Student)listStudents.SelectedItem;
            if (listStudents.SelectedItem == null) return;
            
            Status = (EnrolmentStatus)comboEnrolment.SelectedItem;
            selectedStudent.FirstName = textBoxFirstName.Text;
            selectedStudent.LastName = textBoxLastName.Text;
            //selectedStudent.Enrolment = Status;

            //listStudents.Items.Refresh();
            RefreshStudents();
            MessageBox.Show("Saved!");

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
          
            if (comboEnrolment.SelectedItem != null && textBoxFirstName.Text != "" && textBoxLastName.Text != "")
            {
                Status = (EnrolmentStatus)comboEnrolment.SelectedItem;
                int studentID = service.GetStudents().Count() + 1;
                Student newStudent = new Student(studentID, textBoxFirstName.Text, textBoxLastName.Text, Status);
                if (!service.ListBoxDuplicateCheck(newStudent))
                {
                    service.AddStudent(newStudent);

                }
                else MessageBox.Show("The selected student is already in the list.");

            }
            //listStudents.Items.Refresh();
            RefreshStudents();

        }


    }
}
