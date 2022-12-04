using AMM_Lab14.Models;
using AMM_Lab14.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AMM_Lab14.ViewModels
{
    public class PeopleViewModel : BaseViewModel
    {
        private string color;
        public string Color
        {
            get { return this.color; }
            set { SetValue(ref this.color, value); }
        }


        private string filter;
        public string Filter
        {
            get { return this.filter; }
            set { SetValue(ref this.filter, value); }
        }

        private List<Person> people;
        public List<Person> People
        {
            get { return this.people; }
            set { SetValue(ref this.people, value); }
        }


        public ICommand SearchCommand { get; set; }

        public PeopleViewModel()
        {

            SearchCommand = new Command(() =>
            {
                PersonService service = new PersonService();
                People = service.GetByText(Filter);
                if (People.Count > 3)
                    Color = "Red";
                else
                    Color = "Blue";

            });


        }


    }
}

