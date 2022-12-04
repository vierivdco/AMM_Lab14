using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AMM_Lab14.DataContext;
using AMM_Lab14.Models;

namespace AMM_Lab14.Services
{
    public class PersonService
    {
        private readonly AppDbContext _context;

        public PersonService() => _context = App.GetContext();


        public bool Create(Person item)
        {
            try
            {
                _context.People.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }



        public bool CreateRange(List<Person> items)
        {
            try
            {
                _context.People.AddRange(items);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Person> Get()
        {
            return _context.People.ToList();
        }


        public List<Person> GetByText(string text)
        {
            return _context.People.Where(x => x.FirstName.Contains(text)).ToList();
        }



    }
}