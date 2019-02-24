using System;
using Microsoft.Deployment.WindowsInstaller;

namespace TestVersion
{
    public class PropertyTable
    {
        public static string Get(string msi, string name)
        {
            String inputFile = @"C:\\Rohan\\sqlncli.msi";
            // Get the type of the Windows Installer object
            Type installerType = Type.GetTypeFromProgID("WindowsInstaller.Installer");

            // Create the Windows Installer object
            WindowsInstaller.Installer installer = (WindowsInstaller.Installer)Activator.CreateInstance(installerType);

            // Open the MSI database in the input file
            Database database = installer.OpenDatabase(inputFile, 0);

            // Open a view on the Property table for the version property
            View view = database.OpenView("SELECT * FROM _Tables");
            //View view = database.OpenView("SELECT * FROM Property");

            // Execute the view query
            view.Execute(null);

            // Get the record from the view
            Record record = view.Fetch();

            // Get the version from the data
            //string version = record.get_StringData(2);

            while (record != null)
            {
                Console.WriteLine(record.get_StringData(0) + '=' + record.get_StringData(1) + '=' + record.get_StringData(2) + '=' + record.get_StringData(3));
                record = view.Fetch();
            }
        }
        public static void Set(string msi, string name, string value)
        {
            using (Database db = new Database(msi, DatabaseOpenMode.Direct))
            {
                db.Execute("UPDATE `Property` SET `Value` = '{0}' WHERE `Property` = '{1}'", value, name);
            }
        }
    }
}