using AMM_Lab14.Models;
using AMM_Lab14.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AMM_Lab14.VIews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentPage : ContentPage
    {
        public StudentPage(Student student)
        {
            InitializeComponent();
            this.BindingContext = new StudentViewModel(student);
        }
    }
}