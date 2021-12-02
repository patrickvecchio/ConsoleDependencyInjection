using DependencyInjection.Dependencies;
using System;

namespace DependencyInjection
{
    internal class Program
    {
        private static Startup _startup;

        static void Main()
        {
            _startup = new Startup();

            var dependency1 = (IDependency1)_startup.Provider.GetService(typeof(IDependency1));
            var optionsJson1 = dependency1.GetPrettyJsonOfOptions();

            Console.WriteLine(optionsJson1);

            var dependency2 = (IDependency2)_startup.Provider.GetService(typeof(IDependency2));
            var optionsJson2 = dependency2.GetPrettyJsonOfOptions();

            Console.WriteLine(optionsJson2);
        }
    }
}
