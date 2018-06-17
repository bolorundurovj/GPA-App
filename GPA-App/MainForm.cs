using GPA_App.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GPA_App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void newRecord_Click(object sender, EventArgs e)
        {
            NewRecordForm newRecordForm = new NewRecordForm();
            newRecordForm.ShowDialog();
            Student student = newRecordForm.Student;

            if (student != null)
            {
                dgvRecords.Rows.Add(student.MatricNo, student.Name, CalculateCgpa(student.Results));
            }
        }

        private float CalculateCgpa(List<Course> courses)
        {
            int sumOfCouseWeights = 0;
            int sumOfGradeCourseUnits = 0;

            for(int i = 0; i < courses.Count; i++)
            {
                Course selectedCourse = courses[i];
                sumOfCouseWeights += selectedCourse.Weight;
                int grade = GetValueFromGrade(selectedCourse.GradeObtained);
                int gradeCourseUnit = grade * selectedCourse.Weight;
                sumOfGradeCourseUnits += gradeCourseUnit;
            }

            return ((float)sumOfGradeCourseUnits / (float)sumOfCouseWeights);
        }

        private int GetValueFromGrade(char grade)
        {
            grade = char.Parse(grade.ToString().ToLower());
            switch(grade)
            {
                case 'a':
                    return 5;
                case 'b':
                    return 4;
                case 'c':
                    return 3;
                case 'd':
                    return 2;
                case 'e':
                    return 1;
                case 'f':
                    return 0;
                default:
                    throw new Exception("The grade entered is invalid.");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
