using AMM_Lab14.Droid;
using AMM_Lab14.Interfaces;
using System.IO;
using Xamarin.Forms;


[assembly: Dependency(typeof(ConfigDataBase))]
namespace AMM_Lab14.Droid
{
    public class ConfigDataBase : IConfigDataBase
    {
        public string GetFullPath(string databaseFileName)
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), databaseFileName);
        }
    }
}