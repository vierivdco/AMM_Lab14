using AMM_Lab14.DataContext;
using AMM_Lab14.Interfaces;
using AMM_Lab14.VIews;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AMM_Lab14
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            GetContext().Database.EnsureCreated();
            //MainPage = new PeopleView();
            MainPage = new NavigationPage(new StudentsPage());
        }


        public static AppDbContext GetContext()
        {
            string DbPath = DependencyService.Get<IConfigDataBase>().GetFullPath("efCore.db");

            return new AppDbContext(DbPath);
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
