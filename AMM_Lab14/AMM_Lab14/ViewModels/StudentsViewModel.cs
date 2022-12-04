using AMM_Lab14.Models;
using AMM_Lab14.Services;
using AMM_Lab14.VIews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AMM_Lab14.ViewModels
{
    public class StudentsViewModel : BaseViewModel
    {
        #region Services        
        private readonly StudentService dataServiceStudents;
        #endregion Services

        #region Attributes

        private ObservableCollection<Student> students;

        #endregion Attributes

        #region Properties


        public ObservableCollection<Student> Students
        {
            get { return this.students; }
            set { SetValue(ref this.students, value); }
        }




        #endregion Properties

        #region Command

        public ICommand NeWStudentCommand
        {
            get
            {
                return new Command(NeWStudent);
            }
        }

        public ICommand LoadStudentsCommand
        {
            get
            {
                return new Command(LoadStudents);
            }
        }
        public ICommand DeleteStudentCommand
        {
            get
            {
                return new Command((x) =>
                {
                    var item = (x as Student);
                    DeleteStudent(item);
                });
            }
            //get;
            //set;
        }
        public ICommand UpdateStudentCommand
        {
            get
            {
                return new Command(async (x) =>
                {
                    var item = (x as Student);
                    await UpdateStudent(item);
                });
            }
        }
        #endregion

        #region Constructor
        public StudentsViewModel()
        {
            this.dataServiceStudents = new StudentService();

            this.LoadStudents();

        }
        #endregion Constructor



        #region Methods

        private void NeWStudent()
        {
            Student student = new Student();
            student.StudentId = 0;
            student.LastName = "";
            student.FirstName = "";
            student.Adress = "";
            student.Edad = 0;

            Application.Current.MainPage.Navigation.PushAsync(new StudentPage(student));

            LoadStudents();

        }

        private async Task UpdateStudent(Student student)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new StudentPage(student));

        }

        private void DeleteStudent(Student student)
        {

            this.dataServiceStudents.Delete(student);
            LoadStudents();
        }

        public void LoadStudents()
        {
            var studentsDB = this.dataServiceStudents.Get();
            this.Students = new ObservableCollection<Student>(studentsDB);
        }
        #endregion Methods
    }
}