using AMM_Lab14.Droid.Implementations;
using AMM_Lab14.Interfaces;
using System.IO;
using Xamarin.Forms;
[assembly: Dependency(typeof(ConfigDataBase))]
namespace AMM_Lab14.Droid.Implementations
{
    public class ConfigDataBase : IConfigDataBase
    {
        public string GetFullPath(string databaseFileName)
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), databaseFileName);
        }
    }
}