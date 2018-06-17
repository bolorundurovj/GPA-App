using GPA_App.Models;
using System;
using System.Windows.Forms;

namespace GPA_App
{
    public partial class NewRecordForm : Form
    {
        public Student Student { get; set; }

        public NewRecordForm()
        {
            InitializeComponent();

            dgvResult.RowHeadersVisible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string courseTitle = txtCourseTitle.Text;
            string gradeObtained = txtGradeObtnd.Text;
            string courseWeight = txtCourseWeight.Text;
            

            if (string.IsNullOrWhiteSpace(courseTitle))
            {
                MessageBox.Show("The course title is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(gradeObtained))
            {
                MessageBox.Show("The grade obtained is required. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(string.IsNullOrWhiteSpace(courseWeight))
            {
                MessageBox.Show("The course unit is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dgvResult.Rows.Add(courseTitle, gradeObtained, courseWeight);

                txtCourseTitle.Clear();
                txtGradeObtnd.Clear();
                txtCourseWeight.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string matricNo = txtMatricNo.Text;

            this.Student = new Student();
            Student.Name = name;
            Student.MatricNo = matricNo;

            foreach(DataGridViewRow row in dgvResult.Rows)
            {
                var course = new Course();
                course.Title = row.Cells[0].Value.ToString();
                course.GradeObtained = char.Parse(row.Cells[1].Value.ToString());
                course.Weight = int.Parse(row.Cells[2].Value.ToString());
                Student.Results.Add(course);
            }

            this.Close();
        }
    }
}
