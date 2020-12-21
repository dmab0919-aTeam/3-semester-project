using DbUp;
using NordicBio.dbSetup;
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

            const string dbString = "Server=localhost,1433\\Catalog=NordicBio;Database=NordicBio;User=SA;Password=Q23wa!!!32;";

            var connectionString =
                args.FirstOrDefault()
                ?? dbString;

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

            SetupDB s = new SetupDB();
            s.Setup();
            s.AddDummyData();

            return 0;
        }
    }
}
