using AMM_Lab14.Models;
using AMM_Lab14.Services;
using AMM_Lab14.VIews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AMM_Lab14.ViewModels
{
    public class StudentViewModel : BaseViewModel
    {
        #region Services
        private readonly StudentService dataServiceStudents;
        #endregion

        #region Attributes
        private string lastName;
        private string firstName;
        private string adress;
        private int edad;
        private Student student;
        #endregion

        #region Properties
        public Student Student
        {
            get { return this.student; }
            set { SetValue(ref this.student, value); }
        }
        public string LastName
        {
            get { return this.lastName; }
            set { SetValue(ref this.lastName, value); }
        }
        public string FirstName
        {
            get { return this.firstName; }
            set { SetValue(ref this.firstName, value); }
        }
        public string Adress
        {
            get { return this.adress; }
            set { SetValue(ref this.adress, value); }
        }
        public int Edad
        {
            get { return this.edad; }
            set { SetValue(ref this.edad, value); }
        }

        #endregion

        #region Commands
        public ICommand CreateCommand
        {
            get
            {
                return new Command<Student>(execute: async (student) =>
                {
                    if (this.Student.StudentId > 0)
                    {

                        var newStudent = new Student()
                        {
                            StudentId = this.Student.StudentId,
                            LastName = this.LastName,
                            FirstName = this.FirstName,
                            Adress = this.Adress,
                            Edad = this.Edad
                        };

                        await this.dataServiceStudents.Update(newStudent);

                    }
                    else
                    {
                        var newStudent = new Student()
                        {
                            LastName = this.LastName,
                            FirstName = this.FirstName,
                            Adress = this.Adress,
                            Edad = this.Edad
                        };

                        this.dataServiceStudents.Create(newStudent);
                        await Application.Current.MainPage.Navigation.PopAsync();
                    }


                    await Application.Current.MainPage.Navigation.PushAsync(new StudentsPage());
                    StudentsViewModel studentsViewModel = new StudentsViewModel();
                    studentsViewModel.LoadStudents();
                });
            }
        }
        #endregion Commands

        #region Constructor
        public StudentViewModel(Student student)
        {
            this.dataServiceStudents = new StudentService();
            if (student != null)
            {
                this.Student = student;
                this.LastName = student.LastName;
                this.FirstName = student.FirstName;
                this.Adress = student.Adress;
                this.Edad = student.Edad;

            }
            else
            {
                this.LastName = "";
                this.FirstName = "";
                this.Adress = "";
                this.Edad = 0;
            }
        }
        #endregion Constructor






        #region Methods

        #endregion
    }
}

