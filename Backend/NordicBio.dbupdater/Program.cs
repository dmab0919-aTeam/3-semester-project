using DbUp;
using System;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace NordicBio.dbupdater
{
    class Program
    {
        static int Main(string[] args)
        {

            var appsettings = ConfigurationManager.AppSettings["myCustomConnString"];
			
			//string connectionString = ConfigurationManager.ConnectionString["myCustomConnString"];

			Console.WriteLine(appsettings);

            var connectionString =
                args.FirstOrDefault()
                ?? connectionString;

            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}
