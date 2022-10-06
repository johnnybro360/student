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
        DataService service = new DataService();

        public MainWindow()
        {
            InitializeComponent();
            comboEnrolment.ItemsSource = Enum.GetValues(typeof(EnrolmentStatus));
        }

        /// <summary>
        /// This is called when the get students button is pressed.
        /// TODO: Update this button to load the students from the service and update the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGetStudents_Click(object sender, RoutedEventArgs e)
        {
            
            listStudents.ItemsSource = service.GetStudents();
        }

        /// <summary>
        /// This event is triggered when the user selects a student from the list.
        /// TODO: Update the controls to show the properties of the selected student.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Student selectedStudent = (Student)listStudents.SelectedItem;
            textBoxFirstName.Text = selectedStudent.FirstName;
            textBoxLastName.Text = selectedStudent.LastName;
        }

        /// <summary>
        /// This event triggers when the combo box selection is changed.
        /// TODO: It should update the selected students enrolment.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboEnrolment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Enum enrolmentStatus = (Enum)comboEnrolment.SelectedItem;
            Student selectedStudent = (Student)listStudents.SelectedItem;
            //MessageBox.Show(selectedStudent.Enrolment.ToString());
            //MessageBox.Show(enrolmentStatus.ToString());

            if (enrolmentStatus.ToString() == "Enrolled")
            {
                selectedStudent.EnrolStudent();
                MessageBox.Show(selectedStudent.Enrolment.ToString());

            }
            else if (enrolmentStatus.ToString() == "Withdrawn")
            {
                selectedStudent.Withdraw();
                MessageBox.Show(selectedStudent.Enrolment.ToString());

            }
        }
    }
}
